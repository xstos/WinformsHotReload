Hot Reload for C# apps implemented using Roslyn. It watches the "hot" source folder for changes, and recompiles and reloads the code and restarts the winforms app. Aside from a brief 5-10s delay when first loading Roslyn, subsequent compiles are nearly instant and pretty snappy. Debugging works too. Just set a breakpoint and modify a source file in the "hot" folder and the debugger will pause at that line. The intent of this code is to **Bret Victor**-ize [^1] the process of software development and make it more humane.

Credit to Rick Strahl's Westwind Scripting for the Roslyn piece. ( https://github.com/RickStrahl/Westwind.Scripting )

[^1]: [Bret Victor's seminal and famous talk - Inventing on Principle](https://www.youtube.com/watch?v=PUv66718DII)