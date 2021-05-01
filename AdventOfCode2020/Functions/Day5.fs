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

    let determineSeat (code:string) =
        let row = convertBinary "^([FB]{7})[LR]{3}$" 'F' 'B' code
        let column = convertBinary "^[FB]{7}([LR]{3})$" 'L' 'R' code
        let id = (row * 8 + column)
        Seat (Row row, Column column, Id id)

    let one (inputs:string list) =

        inputs
        |> List.map determineSeat
        |> List.map (fun (_, _, id) ->
            let (Id x) = id
            x)
        |> List.max

    let two (inputs:string list) =

        // map to ordered list of seat ids
        let ids =
            inputs
            |> List.map determineSeat
            |> List.map (fun (_, _, id) ->
                let (Id x) = id
                x)
            |> List.sortBy id

        // use lowest and highest id to determine range
        let range = [Seq.head ids .. Seq.last ids]

        // compare with actual range to find missing seat
        range |> List.except ids |> List.head