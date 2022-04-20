module OcrNumbers

open System

let allLengthsMultipleOf n =
    Seq.forall (fun line -> (String.length line) % n = 0)

let hasCountMultipleOf n seq = Seq.length seq % n = 0

let convertNumber =
    function
    | [| " _ "; "| |"; "|_|"; "   " |] -> '0'
    | [| "   "; "  |"; "  |"; "   " |] -> '1'
    | [| " _ "; " _|"; "|_ "; "   " |] -> '2'
    | [| " _ "; " _|"; " _|"; "   " |] -> '3'
    | [| "   "; "|_|"; "  |"; "   " |] -> '4'
    | [| " _ "; "|_ "; " _|"; "   " |] -> '5'
    | [| " _ "; "|_ "; "|_|"; "   " |] -> '6'
    | [| " _ "; "  |"; "  |"; "   " |] -> '7'
    | [| " _ "; "|_|"; "|_|"; "   " |] -> '8'
    | [| " _ "; "|_|"; " _|"; "   " |] -> '9'
    | _ -> '?'

let convertNumberLine (input: string []) =
    Seq.init (input[0].Length / 3) id
    |> Seq.map (fun i -> [| for line in 0..3 -> input[line][i * 3 .. i * 3 + 2] |])
    |> Seq.map convertNumber
    |> String.Concat

let convert (input: string list) =
    let areDimensionsValid =
        hasCountMultipleOf 4 input
        && allLengthsMultipleOf 3 input

    if not areDimensionsValid then
        None
    else
        input
        |> Seq.chunkBySize 4
        |> Seq.map convertNumberLine
        |> String.concat ","
        |> Some
