// Learn more about F# at http://fsharp.org

open System
open FileSystem
open Day3

[<EntryPoint>]
let main argv =
    let inputs = readPuzzleInput 3
    let answer = two inputs

    printfn "%i" answer
    0 // return an integer exit code
