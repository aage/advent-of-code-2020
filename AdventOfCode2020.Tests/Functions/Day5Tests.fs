module Day5Tests

    open Xunit
    open Day5
    open FileSystem

    [<Theory>]
    [<InlineData("FBFBBFFRLR", 44, 5, 357)>]
    [<InlineData("BFFFBBFRRR", 70, 7, 567)>]
    [<InlineData("FFFBBBFRRR", 14, 7, 119)>]
    [<InlineData("BBFFBBFRLL", 102, 4, 820)>]
    let ``a seat can be determined for a code`` code row column id =

        let expected = Seat(Row row, Column column, Id id)
        let actual = determineSeat code
        Assert.Equal(expected,actual)

    [<Fact>]
    let ``day 5 part 1`` () =
        let expected = 858
        let inputs = readPuzzleInput 5

        let actual = one inputs

        Assert.Equal(expected,actual)

    [<Fact>]
    let ``day 5 part 2`` () =
        let expected = 557
        let inputs = readPuzzleInput 5

        let actual = two inputs

        Assert.Equal(expected,actual)