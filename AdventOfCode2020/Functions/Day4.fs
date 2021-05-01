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

    let validateYearRange lhs rhs name =

        fun (data:string) ->
            let rgx = Regex("^[0-9]{4}$")
            let valid = if rgx.Match(data).Success then
                            let x = int data
                            x >= lhs && x <= rhs
                        else false
            if valid then Ok data
            else Error (sprintf "%s = %s and is not valid" name data)

    let validateRegex regex name =

        fun (data:string) ->
            let rgx = Regex(regex)
            if rgx.Match(data).Success then Ok data
            else Error (sprintf "%s = %s and is not valid" name data)

    let validateBirthYear =

        let f = validateYearRange 1920 2002 "byr"
        validate "byr" f

    let validateIssueYear =

        let f = validateYearRange 2010 2020 "iyr"
        validate "iyr" f

    let validateExpirationYear =

        let f = validateYearRange 2020 2030 "eyr"
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

        let f = validateRegex "^\#[0-9a-z]{6}$" "hcl"
        validate "hcl" f

    let validateEyeColor =

        let f = fun (data:string) ->
            let colors = ["amb";"blu";"brn";"gry";"grn";"hzl";"oth"]
            if colors |> List.contains data then Ok data
            else Error (sprintf "Eye = %s and is not valid" data)
        validate "ecl" f

    let validatePassportId =

        let f = validateRegex "^[0-9]{9}$" "pid"
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
        |> List.map (fun field -> data.Contains(field))
        |> List.forall id

    let validateCorrectData (data:string) = 

        validateBirthYear (data.Replace("\n", " ").Replace("\r", " "))
        |> Result.bind validateIssueYear
        |> Result.bind validateExpirationYear
        |> Result.bind validateHeight
        |> Result.bind validateHairColor
        |> Result.bind validateEyeColor
        |> Result.bind validatePassportId        
    
    let one (inputs:string list) =

        inputs
        |> splitBy ((=) "")
        |> Seq.map (Seq.reduce (+))
        |> Seq.map validateMandatoryData
        |> Seq.sumBy (System.Convert.ToInt32)

    let two (inputs:string list) =

        inputs
        |> splitBy ((=) "")
        |> Seq.map (Seq.map (sprintf "%s " ))
        |> Seq.map (Seq.reduce (+))
        |> Seq.map validateCorrectData
        |> Seq.map isOk
        |> Seq.sumBy (System.Convert.ToInt32)