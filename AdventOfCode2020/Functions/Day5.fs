module Day5

    open System.Text.RegularExpressions

    type Row = Row of int
    type Column = Column of int
    type Id = Id of int

    let determineRow (code:string) =
    
        let rgx = Regex("^([FB]{7})[LR]{3}$")
        rgx.Match(code).Groups.[1].Value
        |> Seq.fold (fun (state:int * int) (t:char) ->
            let lhs = fst state
            let rhs = snd state
            let middle =
                (rhs - lhs)
                |> fun x -> x / 2
                |> (+) (lhs)
            
            match t with
            | 'F' -> (lhs, middle)
            | 'B' -> (middle + 1, rhs)
            | _ -> failwith "This data is unexpected") (0, 127)
        |> (fst >> Row)

