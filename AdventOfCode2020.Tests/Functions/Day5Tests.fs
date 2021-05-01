module Day5Tests

    open Xunit
    open Day5

    [<Theory>]
    [<InlineData("FBFBBFFRLR", 44)>]
    [<InlineData("BFFFBBFRRR", 70)>]
    [<InlineData("FFFBBBFRRR", 14)>]
    [<InlineData("BBFFBBFRLL", 102)>]
    let ``a row can be determined for a code`` (code:string) (expected:int) =

        let row = determineRow code
        let (Row actual) = row
        Assert.Equal(expected,actual)

    [<Theory>]
    [<InlineData("FBFBBFFRLR", 5)>]
    [<InlineData("BFFFBBFRRR", 7)>]
    [<InlineData("FFFBBBFRRR", 7)>]
    [<InlineData("BBFFBBFRLL", 4)>]
    let ``a column can be determined for a code`` (code:string) (expected:int) =

        let column = determineColumn code
        let (Column actual) = column
        Assert.Equal(expected,actual)

