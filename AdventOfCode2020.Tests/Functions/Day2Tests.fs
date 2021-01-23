module Day2Tests

open Day2
open Xunit
open FileSystem

[<Fact>]
let ``password policy correctly determines a valid password`` () =
    let data = "1-3 a: abcde"
    let expected = Ok "abcde"

    let actual = applyPasswordPolicy data

    Assert.Equal(expected,actual)

[<Fact>]
let ``password policy correctly determines an invalid password`` () =
    let data = "1-3 b: cdefg"
    let expected = Error "Password not valid"

    let actual = applyPasswordPolicy data

    Assert.Equal(expected,actual)

[<Fact>]
let ``day 2 part 1`` () =
    let expected = 622
    let inputs = readPuzzleInput 2

    let actual = one inputs

    Assert.Equal(expected, actual)