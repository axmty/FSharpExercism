module Accumulate

let accumulate (func: 'a -> 'b) (input: 'a list) : 'b list =
  let rec loop accumulatedList input =
    match input with
    | [] -> accumulatedList |> List.rev
    | head :: tail -> loop (func head :: accumulatedList) tail

  loop [] input |> List.rev
