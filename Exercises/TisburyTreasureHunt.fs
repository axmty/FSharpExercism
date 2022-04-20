module TisburyTreasureHunt

let getCoordinate (line: string * string) : string = snd line

let convertCoordinate (coordinate: string) : int * char = (int coordinate[0..0], coordinate[1])

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool =
    let azarasCoord = getCoordinate azarasData
    let (_, ruisCoord, _) = ruisData
    convertCoordinate azarasCoord = ruisCoord

let createRecord
    (azarasData: string * string)
    (ruisData: string * (int * char) * string)
    : (string * string * string * string) =
    if compareRecords azarasData ruisData then
        match azarasData, ruisData with
        | (treasure, coord), (location, _, quadrant) -> (coord, location, quadrant, treasure)
    else
        ("", "", "", "")
