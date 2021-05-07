module Day7Tests

    open Xunit
    open Day7
    open FileSystem

    let rules =
        [
            "light red bags contain 1 bright white bag, 2 muted yellow bags."
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags."
            "bright white bags contain 1 shiny gold bag."
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags."
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags."
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags."
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags."
            "faded blue bags contain no other bags."
            "dotted black bags contain no other bags."
        ]

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

    [<Fact>]
    let ``a set of rules determines how many bags can hold a specific bag`` () =

        let expected = 4
        let bags = rules |> List.map parse
        let bag = { Color = Color "shiny gold" ; CanContain = [] }

        let actual = bagsThatCanHoldBag bag bags |> List.length

        Assert.Equal (expected, actual)

    [<Fact>]
    let ``day 7 part 1`` () =
        let expected = 326
        let inputs = readPuzzleInput 7

        let actual = one inputs

        Assert.Equal(expected,actual)
