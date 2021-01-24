module Day2

    let passwordPolicyOccurences  (data:string) =
        let parts = data.Split(' ') // data looks like "1-3 b: cdefg"
        let range = parts.[0].Split('-') |> Array.map int
        let letter = parts.[1].[0]
        let pass = parts.[2]
        let occurences =
            pass
            |> String.filter (fun c -> c = letter)
            |> String.length

        if [range.[0] .. range.[1]] |> List.contains occurences
        then Ok pass
        else Error "Password not valid"

    let one inputs =

        inputs
        |> List.map passwordPolicyOccurences
        |> List.sumBy (fun r ->
            match r with
            | Ok _ -> 1
            | _    -> 0)