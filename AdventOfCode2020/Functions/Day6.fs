module Day6

    open Utilities

    let one (inputs:string list) =

        inputs
        |> Seq.map (fun s -> s.Replace(" ", ""))
        |> splitBy ((=) "")
        |> Seq.map (Seq.concat >> Seq.distinct >> Seq.length)
        |> Seq.sum