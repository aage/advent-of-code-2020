module Day6Tests

    open Xunit
    open Day6
    open FileSystem

    [<Fact>]
    let ``questions anyone answers with yes`` () =
        let expected = 11
        let inputs = [
            "abc"
            ""
            "a"
            "b"
            "c"
            ""
            "ab"
            "ac"
            ""
            "a"
            "a"
            "a"
            "a"
            ""
            "b" ]

        let actual = one inputs

        Assert.Equal(expected,actual)

    [<Fact>]
    let ``questions everyone answers with yes`` () =
        let expected = 6
        let inputs = [
            "abc"
            ""
            "a"
            "b"
            "c"
            ""
            "ab"
            "ac"
            ""
            "a"
            "a"
            "a"
            "a"
            ""
            "b" ]

        let actual = two inputs

        Assert.Equal(expected,actual)

    [<Fact>]
    let ``day 5 part 1`` () =
        let expected = 6947
        let inputs = readPuzzleInput 6

        let actual = one inputs

        Assert.Equal(expected,actual)

    [<Fact>]
    let ``day 5 part 2`` () =
        let expected = 3398
        let inputs = readPuzzleInput 6

        let actual = two inputs

        Assert.Equal(expected,actual)