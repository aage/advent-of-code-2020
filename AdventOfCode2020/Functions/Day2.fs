module Day2

    let applyPasswordPolicy  (data:string) =
        let charToInt c = int c - int '0'

        let s = data.Split(' ')
        let range = (charToInt s.[0].[0], charToInt s.[0].[2])
        let ch = s.[1].[0]
        let pass = s.[2]
        let cs =
            pass
            |> String.filter (fun c -> c = ch)
            |> String.length

        if [fst range .. snd range] |> List.contains cs
        then Ok pass
        else Error "Password not valid"