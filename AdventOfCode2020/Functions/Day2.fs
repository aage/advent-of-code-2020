module Day2

    let applyPasswordPolicy  (data:string) =
        let parts = data.Split(' ') // data looks lieke"1-3 b: cdefg"
        let range = parts.[0].Split('-') |> Array.map int
        let letter = parts.[1].[0]
        let pass = parts.[2]
        let cs =
            pass
            |> String.filter (fun c -> c = letter)
            |> String.length

        if [range.[0] .. range.[1]] |> List.contains cs
        then Ok pass
        else Error "Password not valid"

    let one inputs =

        inputs
        |> List.map applyPasswordPolicy
        |> List.sumBy (fun r ->
            match r with
            | Ok _ -> 1
            | _    -> 0)