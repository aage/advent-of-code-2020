module FileSystem

    open System.IO
    open System.Reflection

    type Part = | One | Two

    let readPuzzleInput day (part:Part) =

        let asm = Assembly.GetExecutingAssembly();
        let path = System.IO.Path.GetDirectoryName(asm.Location);
        let relativePath = sprintf "Day-%i-part-%i.txt" day (if part = One then 1 else 2)
        let puzzlePath = Path.Combine(path, "PuzzleInputs", relativePath)

        puzzlePath
        |> File.ReadLines
        |> Seq.filter (fun l -> l <> "")
        |> List.ofSeq