module Day3Tests

open Day3
open Xunit

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