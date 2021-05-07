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