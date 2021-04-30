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
            Error (sprintf "Data not present, data = '%s'" data)
        else
            let value = m.Groups.[1].Value
            f value |> Result.map (fun _ -> data)

    let validateBirthYear =

        let f = fun (data:string) ->
            let rgx = Regex("^[0-9]{4}$")
            let valid = if rgx.Match(data).Success then
                            let x = int data
                            x >= 1920 && x <= 2002
                        else false
            if valid then Ok data
            else Error (sprintf "Byr = %s and is not valid" data)
        validate "byr" f

    let validateIssueYear =

        let f = fun (data:string) ->
            let rgx = Regex("^[0-9]{4}$")
            let valid = if rgx.Match(data).Success then
                            let x = int data
                            x >= 2010 && x <= 2020
                        else false
            if valid then Ok data
            else Error (sprintf "Issue year = %s and is not valid" data)
        validate "iyr" f

    let validateExpirationYear =

        let f = fun (data:string) ->
            let rgx = Regex("^[0-9]{4}$")
            let valid = if rgx.Match(data).Success then
                            let x = int data
                            x >= 2020 && x <= 2030
                        else false
            if valid then Ok data
            else Error (sprintf "Exp = %s and is not valid" data)
        validate "eyr" f

    let validateHeight =

        let f = fun (data:string) ->
            
            let nums = String.filter Char.IsDigit data
            let rgx = Regex("^[0-9]{2,3}$")
            let valid = if rgx.Match(nums).Success then
                            let num = data |> String.filter Char.IsDigit |> int
                            let sys = data |> String.filter (Char.IsDigit >> not)
                            let valid =
                                if sys = "in" then num >= 59 && num <= 76
                                elif sys = "cm" then num >= 150 && num <= 193
                                else false
                            valid
                        else false
            if valid then Ok data
            else Error (sprintf "hgt = %s and is not valid" data)
        validate "hgt" f

    let validateHairColor =

        let f = fun (data:string) ->
            let rgx = Regex("^\#[0-9a-z]{6}$")
            if rgx.Match(data).Success then Ok data
            else Error (sprintf "Hair = %s and is not valid" data)
        validate "hcl" f

    let validateEyeColor =

        let f = fun (data:string) ->
            let colors = ["amb";"blu";"brn";"gry";"grn";"hzl";"oth"]
            if colors |> List.contains data then Ok data
            else Error (sprintf "Eye = %s and is not valid" data)
        validate "ecl" f

    let validatePassportId =

        let f = fun (data:string) ->
            let rgx = Regex("^[0-9]{9}$")
            if rgx.Match(data).Success then Ok data
            else Error (sprintf "Pid = %s and is not valid" data)
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
        |> List.map (sprintf "%s:")
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

        let removedBreaks = data.Replace("\n", " ").Replace("\r", " ");
        validateBirthYear removedBreaks
        |> Result.bind validateIssueYear
        |> Result.bind validateExpirationYear
        |> Result.bind validateHeight
        |> Result.bind validateHairColor
        |> Result.bind validateEyeColor
        |> Result.bind validatePassportId        

    let two (inputs:string list) =

        inputs
        |> splitBy ((=) "")
        |> Seq.map (Seq.map (sprintf "%s " ))
        |> Seq.map (Seq.reduce (+))
        |> Seq.map validateCorrectData
        |> Seq.sumBy (fun r ->
            match r with
            | Ok _ -> 1
            | _    -> 0)