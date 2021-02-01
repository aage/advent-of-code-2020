module Day4

    open Utilities

    let validatePassport (data:string) =

        let mandatory = [
            "byr"
            "iyr"
            "eyr"
            "hgt"
            "hcl"
            "ecl"
            "pid" ]

        mandatory
        |> List.map (fun field -> sprintf "%s:" field)
        |> List.map (fun field -> data.Contains(field))
        |> List.forall id

    let one (inputs:string list) =

        inputs
        |> splitBy (fun x -> x = "")
        |> Seq.map (Seq.reduce (+))
        |> Seq.map validatePassport
        |> Seq.filter id
        |> Seq.length