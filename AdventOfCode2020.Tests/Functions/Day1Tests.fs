module Day1Tests

open Day1
open Xunit
open FileSystem

[<Fact>]
let ``day 1 part 1`` () =
    let expected = 864864
    let inputs = readPuzzleInput 1 One |> Seq.map int
    let actual = one inputs
    Assert.Equal(expected, actual)
