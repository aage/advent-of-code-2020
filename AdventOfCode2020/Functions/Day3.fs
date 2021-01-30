module Day3

    let one (inputs: string list) =

        let len = List.head inputs |> String.length

        let nextIndex idx =
            let mutable nxt = idx + 3
            nxt <- if nxt >= len then nxt - len else nxt
            nxt

        let rec inner acc idx (data: string list) =
            match data with
            | [] -> acc
            | h::tl ->
                let tree = h.[idx] = '#'
                let count = if tree then acc + 1 else acc
                let nxt =  nextIndex idx
                inner count nxt tl       

        inner 0 0 inputs