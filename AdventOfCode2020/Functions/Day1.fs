module Day1

    open Utilities

    let one inputs =

        combinations inputs
        |> Seq.filter (fun (x, y) -> x + y = 2020)
        |> Seq.map (fun (x,y) -> x * y)
        |> Seq.head

    let two inputs =

        let nums =
            seq {
             for (x,y) in combinations inputs do
              for z in inputs do
               if x + y + z = 2020 then yield x * y * z }

        Seq.head nums