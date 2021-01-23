module Day1

    open Utilities

    let tripleThatSumTo2020 (inputs: seq<int>) =

        seq {
                for x in inputs do
                 for y in inputs do
                  for z in inputs do
                   if x + y + z = 2020 then yield (x, y, z)
        }

    let one inputs =

        combinations inputs
        |> Seq.filter (fun (x, y) -> x + y = 2020)
        |> Seq.map (fun (x,y) -> x * y)
        |> Seq.head

    let two inputs =

        tripleThatSumTo2020 inputs
        |> Seq.map (fun (x, y, z) -> x * y * z)
        |> Seq.head