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
let ``day 2 part 1`` () =
    let expected = 276
    let inputs = readPuzzleInput 3

    let actual = one inputs

    Assert.Equal(expected, actual)

[<Fact>]
let ``day 2 works with test input`` () =
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
    let expected = 336

    let actual = two data
    
    Assert.Equal(expected,actual)