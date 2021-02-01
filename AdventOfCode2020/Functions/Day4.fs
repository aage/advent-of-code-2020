module Day4

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