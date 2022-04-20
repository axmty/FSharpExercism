module PigLatin

open System.Text.RegularExpressions

let matchRegex regex groupLengthMap str =
    let matchResult = Regex(regex).Match(str)

    if matchResult.Success then
        Some(groupLengthMap matchResult.Groups.[1].Length)
    else
        None

let getMovingIndex str =
    [ (id, "^(?:[AEIOUYaeiouy]|YT|yt|XR|xr)")
      (((-) 1), "^(?:[a-zA-Z](?:y|Y))")
      (id, "^[^AEIOUYaeiouy]+")
      (id, "([^AEIOUYaeiouy]*(qu|QU))") ]
    |> Seq.map (fun (map, regex) -> matchRegex regex map str)
    |> Seq.tryFind Option.isSome
    |> Option.flatten

let translate input =
    match getMovingIndex input with
    | Some index -> input[index..] + input[.. index - 1] + "ay"
    | None -> input