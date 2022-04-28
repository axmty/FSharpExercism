module Hamming

let distance (strand1: string) (strand2: string) : int option =
    if strand1.Length <> strand2.Length then
        None
    else
        (strand1, strand2)
        ||> Seq.fold2 (fun diff x y -> if x <> y then diff + 1 else diff) 0
        |> Some
