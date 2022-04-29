module Isogram

open System

let isIsogram (str: string) =
    let letters =
        str
        |> Seq.filter Char.IsLetter
        |> Seq.map Char.ToLower

    Seq.distinct letters |> Seq.length = Seq.length letters

let isIsogramWithCountBy str =
    str
    |> Seq.filter Char.IsLetter
    |> Seq.countBy Char.ToLower
    |> Seq.forall (snd >> (=) 1)
