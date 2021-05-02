module Day6Tests

    open Xunit
    open Day6
    open FileSystem

    [<Fact>]
    let ``day 5 part 1`` () =
        let expected = 6947
        let inputs = readPuzzleInput 6

        let actual = one inputs

        Assert.Equal(expected,actual)