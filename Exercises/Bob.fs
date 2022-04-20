module Bob

let response (input: string) : string =
    let input = input.Trim()
    let hasLetter = input |> String.exists System.Char.IsLetter
    let yelling = hasLetter && input.ToUpper() = input
    let asking = input.EndsWith '?'

    match input, yelling, asking with
    | (input, _, _) when System.String.IsNullOrWhiteSpace input -> "Fine. Be that way!"
    | (_, true, true) -> "Calm down, I know what I'm doing!"
    | (_, true, false) -> "Whoa, chill out!"
    | (_, false, true) -> "Sure."
    | _ -> "Whatever."
