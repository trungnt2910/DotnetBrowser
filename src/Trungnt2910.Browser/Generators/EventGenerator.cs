using Gobie;
using Trungnt2910.Browser.Dom;

namespace Trungnt2910.Browser.Generators;

[GobieGeneratorName($"EventAttribute", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class EventGenerator : GobieClassGenerator
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Comments { get; set; } = "To be added.";

    [GobieTemplate]
    const string Template = @"
        /// <summary>
        /// {{Comments}}
        /// </summary>
        public event global::System.EventHandler<Event> {{Name}}
        {
            add => AddEventListener(""{{JsName}}"", value);
            remove => RemoveEventListener(""{{JsName}}"", value);
        }
    ";
}

[GobieGeneratorName($"EventAttribute<TEvent>", Namespace = "Trungnt2910.Browser.Generators", AllowMultiple = true)]
internal sealed class EventGenerator<TEvent> : GobieClassGenerator where TEvent: Event
{
    [Required]
    public string JsName { get; set; } = string.Empty;

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Comments { get; set; } = "To be added.";

    [GobieTemplate]
    const string Template = @"
        private global::System.Collections.Generic.HashSet<global::System.EventHandler<{{TEvent}}>>? _handlersFor{{Name}}OfType{{TEvent}};
        
        private void _DispatcherFor{{Name}}OfType{{TEvent}}(object? sender, Event args)
        {
            var castedSender = sender;
            if (sender is EventTarget eventTarget)
            {
                castedSender = eventTarget.Cast<{{ClassName}}>();
            }
            foreach (var handler in _handlersFor{{Name}}OfType{{TEvent}}!)
            {
                handler?.Invoke(castedSender, args.Cast<{{TEvent}}>());
            }
        }

        /// <summary>
        /// {{Comments}}
        /// </summary>
        public event global::System.EventHandler<{{TEvent}}> {{Name}}
        {
            add
            {
                _handlersFor{{Name}}OfType{{TEvent}} ??= new();
                if (_handlersFor{{Name}}OfType{{TEvent}}.Count == 0)
                {
                    AddEventListener(""{{JsName}}"", _DispatcherFor{{Name}}OfType{{TEvent}});
                }
                _handlersFor{{Name}}OfType{{TEvent}}.Add(value);
            }
            remove 
            {
                if (_handlersFor{{Name}}OfType{{TEvent}} != null)
                {
                    _handlersFor{{Name}}OfType{{TEvent}}.Remove(value);
                    if (_handlersFor{{Name}}OfType{{TEvent}}.Count == 0)
                    {
                        RemoveEventListener(""{{JsName}}"", _DispatcherFor{{Name}}OfType{{TEvent}});
                        _handlersFor{{Name}}OfType{{TEvent}} = null;
                    }
                }
            }
        }
    ";
}