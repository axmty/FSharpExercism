module Pangram

let addCharIfLetter (set: Set<char>) c =
    if System.Char.IsLetter(c) then
        set.Add(System.Char.ToLower(c))
    else
        set

let isPangram (input: string) : bool =
    input
    |> Seq.fold addCharIfLetter Set.empty
    |> Seq.length
    |> (=) 26

let isPangramWithSet (input: string) : bool =
    set [ 'a' .. 'z' ] - set (input.ToLower())
    |> Set.isEmpty
