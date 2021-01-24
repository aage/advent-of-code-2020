module Day2

    type Policy = {Nums:int * int ; Letter:char ; Pass:string}

    let makePolicy (data:string) =
        let parts = data.Split(' ') // data looks like "1-3 b: cdefg"
        let nums =
            parts.[0].Split('-')
            |> Array.map int

        { Nums = nums.[0], nums.[1] ; Letter = parts.[1].[0] ; Pass = parts.[2] }

    let passwordPolicyOccurences data =
        let policy = makePolicy data
        let occurences =
            policy.Pass
            |> String.filter (fun c -> c = policy.Letter)
            |> String.length

        if [fst policy.Nums .. snd policy.Nums] |> List.contains occurences
        then Ok policy.Pass
        else Error "Password not valid"

    let passwordPolicyPosition data =

        let policy = makePolicy data
        let letters = (policy.Pass.[fst policy.Nums - 1], policy.Pass.[snd policy.Nums - 1])

        if (fst letters = policy.Letter) <> (snd letters = policy.Letter)
        then Ok policy.Pass
        else Error "Password not valid"

    let one inputs =

        inputs
        |> List.map passwordPolicyOccurences
        |> List.sumBy (fun r ->
            match r with
            | Ok _ -> 1
            | _    -> 0)

    let two inputs =

        inputs
        |> List.map passwordPolicyPosition
        |> List.sumBy (fun r ->
            match r with
            | Ok _ -> 1
            | _    -> 0)