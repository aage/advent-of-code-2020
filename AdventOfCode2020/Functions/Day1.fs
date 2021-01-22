module Day1

    let setThatSumTo2020 (inputs: seq<int>) =

        seq {
                for x in inputs do
                 for y in inputs do
                  if x + y = 2020 then yield (x, y)
        }

    let one inputs =

        setThatSumTo2020 inputs
        |> Seq.map (fun (x, y) -> x * y)
        |> Seq.head