module Day5

    open System.Text.RegularExpressions

    type Row = Row of int
    type Column = Column of int
    type Id = Id of int

    let private determine regex range useLower code =

        let rgx = Regex(regex)
        rgx.Match(code).Groups.[1].Value
        |> Seq.fold (fun (state:int * int) (t:char) ->
            let lhs = fst state
            let rhs = snd state
            let middle =
                (rhs - lhs)
                |> fun x -> x / 2
                |> (+) (lhs)
            
            if useLower t
            then (lhs, middle)
            else (middle + 1, rhs)) range
        |> fst

    let determineRow (code:string) =
    
        determine "^([FB]{7})[LR]{3}$" (0, 127) ((=) 'F') code |> Row

    let determineColumn (code:string) =

        determine "^[FB]{7}([LR]{3})$" (0, 7) ((=) 'L') code |> Column
