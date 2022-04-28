module PigLatin

open System.Text.RegularExpressions

let (|Pattern|_|) (regex: string) (input: string) =
    let regexMatch = Regex(regex).Match(input)

    if regexMatch.Success then
        Some(regexMatch.Groups[0].Length)
    else
        None

let translateWord word =
    match word with
    | Pattern @"^([yY][tT]|[xX][rR])" _ -> word + "ay"
    | Pattern @"^([^AEIOUaeiou]*[qQ][uU]|[^AEIOUYaeiouy]+|[yY])" len -> word[len..] + word[.. len - 1] + "ay"
    | word -> word + "ay"

let translate input =
    Regex.Replace(input, @"\w+", MatchEvaluator(fun m -> translateWord m.Value))
