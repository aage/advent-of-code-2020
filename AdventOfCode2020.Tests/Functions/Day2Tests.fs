module Day2Tests

open Day2
open Xunit
open FileSystem

[<Fact>]
let ``password policy occurences correctly determines a valid password`` () =
    let data = "1-3 a: abcde"
    let expected = Ok "abcde"

    let actual = passwordPolicyOccurences data

    Assert.Equal(expected,actual)

[<Fact>]
let ``password policy occurences correctly determines an invalid password`` () =
    let data = "1-3 b: cdefg"
    let expected = Error "Password not valid"

    let actual = passwordPolicyOccurences data

    Assert.Equal(expected,actual)

[<Fact>]
let ``password policy position correctly determines a valid password`` () =
    let data = "1-3 a: abcde"
    let expected = Ok "abcde"

    let actual = passwordPolicyPosition data

    Assert.Equal(expected,actual)

[<Theory>]
[<InlineData("1-3 b: cdefg")>]
[<InlineData("2-9 c: ccccccccc")>]
let ``password policy position correctly determines an invalid password`` data =
    let expected = Error "Password not valid"
    let actual = passwordPolicyPosition data
    Assert.Equal(expected,actual)

[<Fact>]
let ``day 2 part 1`` () =
    let expected = 622
    let inputs = readPuzzleInput 2

    let actual = one inputs

    Assert.Equal(expected, actual)

[<Fact>]
let ``day 2 part 2`` () =
    let expected = 263
    let inputs = readPuzzleInput 2

    let actual = two inputs

    Assert.Equal(expected, actual)