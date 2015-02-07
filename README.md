# RustParser
Rust parser written with Nitra

## Released parsing
* Boolean, integer, float, char and string literals
* Bitwise, conditional and arithmetic operations
* Non-generic free functions declarations
* Basic control blocks: if, loop, while, for, break and contiue
* let and unit statements
* Single and multiline commets
* Keywords
* Extern crate declarations
* Use declarations

## Building
* Install nitra ([https://confluence.jetbrains.com/display/Nitra/Install](https://confluence.jetbrains.com/display/Nitra/Install))
* Pull sources and build in recent version Visual Studio


## Syntax highlighting
* Build RustParser project
* Copy library RustParser.dll into Nitra setup folder (by default: %ProgramFiles(x86)%/JetBrains/Nitra)
* Edit file NitraGlobalConfig.xml
```
    <Language Name="Rust" FileExtensions=".rs" Grammar="RustParser.RustGrammar" StartRule="CompilationUnit">
    	<Module>$NitraPath\RustParser.dll</Module>
    </Language>
```
* Restart Visual Studio and have fun!