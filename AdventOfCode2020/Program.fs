// Learn more about F# at http://fsharp.org

open System
open FileSystem
open Day1

[<EntryPoint>]
let main argv =
    let inputs = readPuzzleInput 1 One
    let answer = inputs |> Seq.map int |> partOne
    let msg = match answer with
              | None -> "Could not determine"
              | Some i -> i.ToString()

    printfn "%s" msg
    0 // return an integer exit code
