module Day6

    open Utilities

    let one (inputs:string list) =

        inputs
        |> Seq.map (fun s -> s.Replace(" ", ""))
        |> splitBy ((=) "")
        |> Seq.map (Seq.concat >> Seq.distinct >> Seq.length)
        |> Seq.sum

    let two (inputs:string list) =

        let alphabet = seq { 'a' .. 'z' }

        inputs
        |> splitBy2 ((=) "")
        |> Seq.map (fun group ->
            let len = Seq.length group
            let str = group |> Seq.concat
            alphabet
            |> Seq.filter (fun c ->
                let occ = str |> Seq.filter ((=) c) |> Seq.length
                let count = occ = len
                count))
        |> Seq.collect id
        |> Seq.length