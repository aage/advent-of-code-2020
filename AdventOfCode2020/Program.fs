// Learn more about F# at http://fsharp.org

open FileSystem
open Day7

[<EntryPoint>]
let main argv =
    let inputs = readPuzzleInput 7
    let answer = one inputs

    printfn "%i" answer
    0 // return an integer exit code
