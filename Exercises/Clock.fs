module Clock

let rec overflow hours minutes =
    match hours, minutes with
    | (h, m) when m >= 60 -> overflow (h + 1) (m - 60)
    | (h, m) when m < 0 -> overflow (h - 1) (m + 60)
    | (h, m) when h >= 24 -> overflow (h - 24) m
    | (h, m) when h < 0 -> overflow (h + 24) m
    | _ -> (hours, minutes)

let create hours minutes = overflow hours minutes

let add minutesToAdd (hours, minutes) = create hours (minutes + minutesToAdd)

let subtract minutesToSubstract (hours, minutes) =
    create hours (minutes - minutesToSubstract)

let display (hours, minutes) = sprintf "%02d:%02d" hours minutes
