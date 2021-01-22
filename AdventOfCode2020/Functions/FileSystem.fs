module FileSystem

    open System.IO
    open System.Reflection

    let readPuzzleInput day =

        let asm = Assembly.GetExecutingAssembly();
        let path = System.IO.Path.GetDirectoryName(asm.Location);
        let relativePath = sprintf "Day-%i.txt" day
        let puzzlePath = Path.Combine(path, "PuzzleInputs", relativePath)

        puzzlePath
        |> File.ReadLines
        |> Seq.filter (fun l -> l <> "")
        |> List.ofSeq