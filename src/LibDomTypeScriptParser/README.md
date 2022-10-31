# LibDomTypeScriptParser

A ~~bunch of hacks~~ script to parse lib.dom.d.ts into C# bindings for Trungnt2910.Browser.

## Status

### Supports
- Interfaces
- Classes
- Methods
- Properties
- Events
- Most TypeScript types.
- Converting `@deprecated` into `[Obsolete]`
- Converting JsDoc into XML comments
- Converting `camelCase` into `PascalCase`

### Does not support
- Constructors
- Get/Set accessors (the underlying [parser library](https://github.com/ToCSharp/TypeScriptAST) does not support 
get/set accessors.)
- Using any other library than `lib.dom.d.ts` for input.
- Generating output for any other target than `Trungnt2910.Browser.dll`.

## To do
- Clean up the code. This program was written in a rush so copy-paste coding is heavily used.
- Support constructors.
- Migrate away from TypeScriptAST. There are two options:
    + Use the official TypeScript parser from Microsoft, port this whole program to NodeJS, and find a Mono.Cecil JavaScript equivalent.
    + Use a new port of the TypeScript parser for .NET.

## Generation instructions
- Delete `lib.dom` from the `Trungnt2910.Browser` project and rebuild the library.
- Copy the output file (`Trungnt2910.Browser.dll`) to the `LibDomTypeScriptParser` project folder.
- Optional: Update the `TypeScript` submodule to the latest TypeScript release, and update the version in `typescript_version.txt`. 
- Run the project using Visual Studio.

The generated files should be at `bin/$(Configuration)/net$(_BrowserNetVersion)/lib.dom`.