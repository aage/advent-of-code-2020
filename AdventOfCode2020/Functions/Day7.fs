module Day7

    open System
    open System.Text.RegularExpressions

    type Color = Color of String
    type Bag =
        {
            Color: Color
            CanContain: (int * Bag) list
        }

    let parse (rule:string) =

        let rgx = Regex "^(.*) bags contain (no other bags\.|.*)$"

        let mtc = rgx.Match(rule)
        let color = Color mtc.Groups.[1].Value
        let bags =
            match mtc.Groups.[2].Value with
            | "no other bags." -> []
            | _ ->
                mtc.Groups.[2].Value.Split(',')
                |> Array.map (fun s ->
                    let rgx = Regex "^(\d{1,2})\s(.*)\sbag[s]?[\.]?$"
                    let mtc = rgx.Match (s.Trim())
                    let num = mtc.Groups.[1].Value |> int
                    let clr = mtc.Groups.[2].Value
                    (num, { Color = Color clr ; CanContain = [] }))
                |> List.ofArray
        { Color = color ; CanContain = bags }

    let bagsThatCanHoldBag (rules: string list) (bag: Bag) =
    
        let bags = rules |> List.map parse

        let rec inner
            (bagsToCheck: Bag list)
            (bagsThatCanHold: Bag list)
            (addedAny : bool) =

            match (addedAny, bagsToCheck) with
            | (false, _) -> bagsThatCanHold
            | (true, []) -> bagsThatCanHold
            | _  ->
                // prefix initial bag
                let colors =
                    bag::bagsThatCanHold
                    |> List.map (fun b -> b.Color)
                    |> Set.ofList
                // check if the colors of the bags to check overlap
                // with the colors of the bags should be contained
                let canHold =
                    bagsToCheck
                    |> List.filter (fun b ->
                        b.CanContain
                        |> List.map snd
                        |> List.map (fun b -> b.Color)
                        |> Set.ofList
                        |> Set.intersect colors
                        |> Seq.length > 0)
                inner
                    (bagsToCheck |> List.except canHold)
                    (canHold @ bagsThatCanHold)
                    (canHold.Length > 0)

        inner bags [] true