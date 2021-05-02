module Day6Tests

    open Xunit
    open Day6
    open FileSystem

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

        let actual = everyoneYes inputs

        Assert.Equal(expected,actual)

    [<Fact>]
    let ``day 5 part 1`` () =
        let expected = 6947
        let inputs = readPuzzleInput 6

        let actual = one inputs

        Assert.Equal(expected,actual)