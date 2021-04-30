module Day4

    open Utilities
    open System.Text.RegularExpressions
    open System

    let validate text f data =

        let pattern = sprintf ".*%s\:([^ ]*).*" text
        let regex = Regex(pattern)
        let m = regex.Match(data)
        if not m.Success
        then
            Error "Data not present"
        else
            let value = m.Groups.[1].Value
            if not (f value)
            then
                Error "Invalid data"
            else
                Ok data

    let validateBirthYear =

        let f = fun (data:string) ->
            let x = int data
            let r = x >= 1920 && x <= 2002
            r
        validate "byr" f

    let validateIssueYear =

        let f = fun (data:string) ->
            let x = int data
            let r = x >= 2010 && x <= 2020
            r
        validate "iyr" f

    let validateExpirationYear =

        let f = fun (data:string) ->
            let x = int data
            let r = x >= 2020 && x <= 2030
            r
        validate "eyr" f

    let validateHeight =

        let f = fun (data:string) ->
            let num = data |> String.filter Char.IsDigit |> int
            let sys = data |> String.filter (Char.IsDigit >> not)
            let valid =
                if sys = "in" then num >= 59 && num <= 76
                elif sys = "cm" then num >= 150 && num <= 193
                else false
            valid
        validate "hgt" f

    let validateHairColor =

        let f = fun (data:string) ->
            let rgx = Regex("^\#[0-9a-z]{6}$")
            let r = rgx.Match(data).Success
            r
        validate "hcl" f

    let validateEyeColor =

        let f = fun (data:string) ->
            let colors = ["amb";"blu";"brn";"gry";"grn";"hzl";"oth"]
            let r = colors |> List.contains data
            r
        validate "ecl" f

    let validatePassportId =

        let f = fun (data:string) ->
            let rgx = Regex("^[0-9]{9}$")
            let r = rgx.Match(data).Success
            r
        validate "pid" f

    let validateMandatoryData (data:string) =

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
        |> splitBy ((=) "")
        |> Seq.map (Seq.reduce (+))
        |> Seq.map validateMandatoryData
        |> Seq.filter id
        |> Seq.length

    let validateCorrectData (data:string) = 

        let removedBreaks = data.Replace(Environment.NewLine, "")
        validateBirthYear removedBreaks
        |> Result.bind validateIssueYear
        |> Result.bind validateExpirationYear
        |> Result.bind validateHeight
        |> Result.bind validateHairColor
        |> Result.bind validateEyeColor
        |> Result.bind validatePassportId        

    let two (inputs:string list) =

        let results =
            inputs
            |> List.map validateCorrectData
        results
        |> List.sumBy (fun r ->
            match r with
            | Ok _ -> 1
            | _    -> 0)