module Utilities

    let combinations xs =

        seq {
            for lhs in xs do
             for rhs in xs do
              yield (lhs,rhs) }

    let trySkip n data =
        if n >= List.length data
        then []
        else data.[n ..]

    // taken from: https://stackoverflow.com/a/6737659
    let splitBy f input =
      let i = ref 0
      input
      |> Seq.groupBy (fun x ->
        if f x then incr i
        !i)
      |> Seq.map snd

    let splitBy2 f input =
      let i = ref 0
      input
      |> Seq.groupBy (fun x ->
        if f x then incr i
        !i)
      |> Seq.map snd
      |> Seq.map (Seq.filter (fun x -> f x |> not))

    let isOk =
      function
      | Ok _ -> true
      | _    -> false

    let isError r = isOk r |> not