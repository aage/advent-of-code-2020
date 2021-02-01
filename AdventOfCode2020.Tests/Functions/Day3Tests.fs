module Day3Tests

open Day3
open Xunit
open FileSystem

[<Fact>]
let ``toboggan correctly counts amount of trees`` () =
    let data = [
        "..##......."
        "#...#...#.."
        ".#....#..#."
        "..#.#...#.#"
        ".#...##..#."
        "..#.##....."
        ".#.#.#....#"
        ".#........#"
        "#.##...#..."
        "#...##....#"
        ".#..#...#.#" ]
    let expected = 7

    let actual = one data
    
    Assert.Equal(expected,actual)

[<Fact>]
let ``day 3 part 1`` () =
    let expected = 276
    let inputs = readPuzzleInput 3

    let actual = one inputs

    Assert.Equal(expected, actual)

[<Fact>]
let ``day 3 part 2`` () =
    let expected = 7812180000L
    let inputs = readPuzzleInput 3

    let actual = two inputs

    let equal = expected = actual
    Assert.True(equal)

[<Fact>]
let ``day 3 works with test input`` () =
    let data = [
        "..##......."
        "#...#...#.."
        ".#....#..#."
        "..#.#...#.#"
        ".#...##..#."
        "..#.##....."
        ".#.#.#....#"
        ".#........#"
        "#.##...#..."
        "#...##....#"
        ".#..#...#.#" ]
    let expected = 336L

    let actual = two data
    
    Assert.Equal(expected,actual)