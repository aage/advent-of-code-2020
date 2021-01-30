module Day3

    open Utilities

    type TobaggonRoute = { Right:int; Down:int }

    let log msg = System.IO.File.AppendAllLines(@"c:\temp\foo.log",[msg])

    let treesEncountered (route:TobaggonRoute) (inputs: string list) =

        let len = List.head inputs |> String.length

        let nextIndex delta idx =
            let nxt = idx + delta
            if nxt >= len then nxt - len else nxt

        let rec inner acc idx (data: string list) =
            match data with
            | [] -> acc
            | head::tail ->
                let tree = head.[idx] = '#'
                let count = if tree then acc + 1 else acc
                let nxt =  nextIndex route.Right idx
                let tl = trySkip (route.Down - 1) tail
                inner count nxt tl       

        inner 0 0 inputs

    let one (inputs: string list) =

        let algo = { Right = 3 ; Down = 1 }
        treesEncountered algo inputs
    
    let two (inputs: string list) =

        let routes = [
            { Right = 1; Down = 1 }
            { Right = 3; Down = 1 }
            { Right = 5; Down = 1 }
            { Right = 7; Down = 1 }
            { Right = 1; Down = 2 }
        ]

        let outcomes = routes |> List.map (fun algo -> treesEncountered algo inputs)

        for o in outcomes do
         sprintf "%i" o |> log

        outcomes |> List.reduce (*)