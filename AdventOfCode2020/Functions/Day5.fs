module Day5

    open System
    open System.Text.RegularExpressions

    type Row = Row of int
    type Column = Column of int
    type Id = Id of int
    type Seat = Row * Column * Id

    let private convertBinary regex zero one code =

        let rgx = Regex(regex)
        rgx.Match(code)
            .Groups.[1]
            .Value
            .Replace(zero, '0')
            .Replace(one, '1')
            |> fun x -> Convert.ToInt32(x, 2)

    let determineRow (code:string) =

        convertBinary "^([FB]{7})[LR]{3}$" 'F' 'B' code |> Row

    let determineColumn (code:string) =

        convertBinary "^[FB]{7}([LR]{3})$" 'L' 'R' code |> Column

    let determineId (code:string) =

        let (Row row) = determineRow code
        let (Column column) = determineColumn code
        Id (row * 8 + column)

    let one (inputs:string list) =

        inputs
        |> List.map determineId
        |> List.map (fun id ->
            let (Id x) = id
            x)
        |> List.max
