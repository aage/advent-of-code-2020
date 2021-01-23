module Utilities

    let combinations xs =

        seq {
            for lhs in xs do
             for rhs in xs do
              yield (lhs,rhs) }