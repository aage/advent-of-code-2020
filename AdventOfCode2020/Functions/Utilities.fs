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