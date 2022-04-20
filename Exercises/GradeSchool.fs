module GradeSchool

type School = Map<int, string list>

let empty: School = Map.empty

let add (student: string) (grade: int) (school: School) : School =
    let newList =
        match school |> Map.tryFind grade with
        | Some old -> student :: old
        | None -> List.singleton student

    Map.add grade newList school

let roster (school: School) : string list =
    school
    |> Map.toList
    |> List.sortBy fst
    |> List.collect (snd >> List.sort)

let grade (number: int) (school: School) : string list =
    match school |> Map.tryFind number with
    | Some students -> students
    | None -> []
