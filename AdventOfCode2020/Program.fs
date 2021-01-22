// Learn more about F# at http://fsharp.org

open System
open FileSystem
open Day1

[<EntryPoint>]
let main argv =
    let inputs = readPuzzleInput 1
    let answer = inputs |> Seq.map int |> two

    printfn "%i" answer
    0 // return an integer exit code
