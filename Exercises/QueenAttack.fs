module QueenAttack

let create (position: int * int) =
  match position with
  | (x, y) -> x >= 0 && x < 8 && y >= 0 && y < 8

let canAttack (x1, y1) (x2, y2) =
  x1 = x2
  || y1 = y2
  || (y2 - y1 |> abs) = (x2 - x1 |> abs)
