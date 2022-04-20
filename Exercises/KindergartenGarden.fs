module KindergartenGarden

type Plant =
    | Clover
    | Grass
    | Radishes
    | Violets

let plants (diagram: string) student =
    let index =
        [ "Alice"
          "Bob"
          "Charlie"
          "David"
          "Eve"
          "Fred"
          "Ginny"
          "Harriet"
          "Ileana"
          "Joseph"
          "Kincaid"
          "Larry" ]
        |> List.findIndex ((=) student)

    diagram.Split '\n'
    |> Seq.collect (Seq.skip (index * 2) >> Seq.take 2)
    |> Seq.map (function
        | 'C' -> Clover
        | 'G' -> Grass
        | 'R' -> Radishes
        | 'V' -> Violets
        | _ -> failwith "unknown plant")
    |> List.ofSeq
