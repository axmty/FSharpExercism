module Leap

let (|DivBy|_|) b a = if a % b = 0 then Some(DivBy) else None

let isLeapYear year =
  match year with
  | DivBy 400 -> true
  | DivBy 100 -> false
  | DivBy 4 -> true
  | _ -> false
