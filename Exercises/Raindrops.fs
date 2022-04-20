module Raindrops

let convert (number: int) : string =
    let s =
        [ (3, "Pling")
          (5, "Plang")
          (7, "Plong") ]
        |> Seq.choose (fun (p, s) -> if number % p = 0 then Some(s) else None)

    if s |> Seq.isEmpty then
        string number
    else
        String.concat "" s
