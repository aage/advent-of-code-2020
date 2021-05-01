module Day5

    open System
    open System.Text.RegularExpressions

    type Row = Row of int
    type Column = Column of int
    type Id = Id of int
    type Seat = Row * Column * Id

    let private translate (code:string) =
        code
            .Replace('F', '0')
            .Replace('B', '1')
            .Replace('L', '0')
            .Replace('R', '1')

    let private convertBinary lhs rhs code =

        code
        |> translate
        |> fun s -> s.[lhs .. rhs]
        |> fun x -> Convert.ToInt32(x, 2)

    let determineSeat (code:string) =
        let row = convertBinary 0 6 code
        let column = convertBinary 7 9 code
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