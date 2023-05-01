namespace Trungnt2910.Browser.Generators.TypeScript.Utilities;

public static class NameHelpers
{
    private static readonly ISet<string> _keywords = new HashSet<string> 
        { "namespace", "event", "string", "object", "ref", "lock" };

    private static readonly ISet<string> _englishWords = new HashSet<string>
    {
        "on", "abort", "after", "print", "animation", "end", "start",
        "iteration", "before", "unload", "blur", "can", "play", "through",
        "change", "click", "context", "menu", "copy", "cut", "dbl", "drag",
        "enter", "leave", "over", "drop", "duration", "ended", "error", "focus",
        "in", "out", "fullscreen", "hash", "input", "invalid", "key", "down", "up",
        "load", "loaded", "metadata", "message", "mouse", "move", "wheel", "offline",
        "online", "open", "page", "hide", "show", "paste", "pause", "playing", "pop",
        "state", "progress", "rate", "resize", "reset", "scroll", "search", "seeked",
        "seeking", "select", "stalled", "storage", "submit", "suspend", "time", "update",
        "toggle", "touch", "cancel", "transition", "volume", "waiting", "aux", "close",
        "cue", "emptied", "form", "data", "got", "pointer", "capture", "press", "move",
        "security", "policy", "violation", "selection", "slot", "webkit", "composition",
        "finish", "remove", "gamepad", "connected", "disconnected", "lost", "rejection",
        "unhandled", "handled", "language", "run", "processor", "lock", "ready", "visibility",
        "for", "picture", "version", "upgrade", "needed", "device", "statuses", "available",
        "source", "mute", "unmute", "loading", "done", "encrypted", "success", "blocked",
        "complete", "add", "track", "remove", "payment", "method", "resource", "timing",
        "buffer", "full", "tone", "buffered", "amount", "low", "closing", "gathering",
        "connection", "channel", "ice" /* ICE, not the frozen water stuff */, "candidate",
        "negotiation", "signaling", "audio", "process", "connect", "connecting", "disconnect",
        "controller", "found", "voices", "changed", "boundary", "mark", "exit", "motion",
        "orientation"
    };

    static NameHelpers()
    {
#if DEBUG
        var set = new HashSet<string>();
        foreach (var word in _englishWords)
        {
            if (!set.Add(word))
            {
                throw new InvalidOperationException("Duplicate word found.");
            }
        }
#endif
    }

    private static readonly IReadOnlyDictionary<string, string> _eventVerbsMap = new Dictionary<string, string>
    {
        { "abort", "aborted" },
        { "blur", "blurred" },
        { "cancel", "cancelled" },
        { "click", "clicked" },
        { "close", "closed" },
        { "error", "errored" },
        { "finish", "finished" },
        { "focus", "focused" },
        { "load", "loaded" },
        { "pause", "paused" },
        { "play", "played" },
        { "resume", "resumed" },
        { "scroll", "scrolled" },
        { "select", "selected" },
        { "start", "started" },
        { "stop", "stopped" },
        { "submit", "submitted" },
    };

    public static string ToCSharpElementName(this string jsName)
    {
        jsName = ProcessCase(jsName);
        return ProcessKeywords(jsName);
    }

    public static string ToCSharpParamName(this string jsName)
    {
        return ProcessKeywords(jsName);
    }

    public static string ToCSharpEventName(this string jsName)
    {
        // The prefix "When" is used, because "On" is already used.
        // Switch-case for these one-word events.
        switch (jsName)
        {
            // Both "abort" and "aborted" members exists.
            case "abort":
                return "WhenAborted";
            case "addtrack":
                return "WhenAddTrack";
            case "close":
                return "WhenClosed";
            case "ended":
                return "WhenEnded";
            case "finish":
                return "WhenFinished";
            case "pause":
                return "WhenPaused";
            case "play":
                return "WhenPlayed";
            case "removetrack":
                return "WhenRemoveTrack";
            // "resetted" is not a valid English word.
            case "reset":
                return "WhenReset";
            case "seeking":
                return "WhenSeeking";
            case "select":
                return "WhenSelected";
            case "timeout":
                return "TimedOut";
        }

        if (_eventVerbsMap.TryGetValue(jsName, out var pastTenseVerb))
        {
            return TrivialToPascalCase(pastTenseVerb);
        }

        return ToCSharpElementName(jsName);
    }

    public static string ToCSharpTypeName(this string jsName)
    {
        switch (jsName)
        {
            case "boolean":
                return "bool";
            case "number":
                return "double";
            case "any":
            case "object":
                return "JsObject";
            default:
                return jsName;
        }
    }

    private static string ProcessKeywords(string name)
    {
        if (_keywords.Contains(name))
        {
            return $"@{name}";
        }
        return name;
    }

    private static string ProcessCase(string jsName)
    {
        var lowerCharCount = jsName.Where(c => char.IsLower(c)).Count();
        var upperCharCount = jsName.Where(c => char.IsUpper(c)).Count();

        // Constant names with underscore separators and uppercase characters
        if (lowerCharCount == 0)
        {
            return jsName;
        }

        // This string is already in camelCase.
        if (upperCharCount != 0)
        {
            return TrivialToPascalCase(jsName);
        }

        // This string is all lowercase. Try to brute force some English words out of it.
        if (TryBruteForce(jsName, out var stringList))
        {
            return string.Join("", stringList.Select(s => TrivialToPascalCase(s)));
        }

        var trace = new System.Diagnostics.StackTrace();
        if (trace.GetFrames().Reverse().FirstOrDefault(f => f.GetMethod()?.Name == nameof(ToCSharpEventName)) != null)
        {
            System.Diagnostics.Debugger.Break();
            Console.Error.WriteLine($"Cannot resolve the English event name: {jsName}. Consider adding it to the English words database.");
        }

        return TrivialToPascalCase(jsName);
    }

    private static bool TryBruteForce(string jsName, out List<string> list)
    {
        list = new List<string>();
        return TryBruteForce(jsName, list, 0);
    }

    private static bool TryBruteForce(string jsName, List<string> list, int startIndex)
    {
        if (startIndex == jsName.Length)
        {
            return true;
        }

        // We prioritize longer words, so start from the back.
        for (int endIndex = jsName.Length; endIndex > startIndex; --endIndex)
        {
            var word = jsName.Substring(startIndex, endIndex - startIndex);
            if (!_englishWords.Contains(word))
            {
                continue;
            }
            list.Add(word);
            if (TryBruteForce(jsName, list, endIndex))
            {
                return true;
            }
            list.Remove(word);
        }

        return false;
    }

    private static string TrivialToPascalCase(string jsName)
    {
        if (jsName.Length > 1)
        {
            return char.ToUpperInvariant(jsName[0]) + jsName.Substring(1);
        }
        else
        {
            return jsName.ToUpperInvariant();
        }
    }
}
