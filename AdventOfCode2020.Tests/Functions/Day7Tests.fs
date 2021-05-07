module Day7Tests

    open Xunit
    open Day7

    [<Theory>]
    [<InlineData(
        "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
        "dark orange",
        "3:bright white;4:muted yellow")>]
    [<InlineData(
        "bright white bags contain 1 shiny gold bag.",
        "bright white",
        "1:shiny gold")>]
    [<InlineData(
        "faded blue bags contain no other bags.",
        "faded blue",
        "")>]
    let ``a rule can be parsed to a bag`` (rule, color, (bags:string)) =
        let color' = Color color
        let canContain =
            match bags with
            | "" -> []
            | _  ->
                bags.Split(';')
                |> Array.map (fun arr ->
                    let arr' = arr.Split(':')
                    let num = int arr'.[0]
                    let clr = Color arr'.[1]
                    (num, { Color = clr; CanContain = [] }))
                |> List.ofArray

        let expected = { Color = color' ; CanContain = canContain }
        let actual = parse rule

        Assert.Equal(expected,actual)

