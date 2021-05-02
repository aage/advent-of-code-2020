// Learn more about F# at http://fsharp.org

open System
open FileSystem
open Day6

[<EntryPoint>]
let main argv =
    let inputs = readPuzzleInput 6
    let answer = two inputs

    printfn "%i" answer
    0 // return an integer exit code
