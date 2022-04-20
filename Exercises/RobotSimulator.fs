module RobotSimulator

type Direction =
    | North
    | East
    | South
    | West

let rightTurns =
    [ North; East; South; West; North ]
    |> List.pairwise
    |> Map

let leftTurns =
    rightTurns
    |> Seq.map (fun (KeyValue (a, b)) -> (b, a))
    |> Map

type Position = int * int

type Robot =
    { Direction: Direction
      Position: Position }

type Turn =
    | Left
    | Right

let create direction position =
    { Direction = direction
      Position = position }

let turn turnDir { Direction = dir; Position = pos } =
    let turns =
        turnDir
        |> (function
        | Left -> leftTurns
        | Right -> rightTurns)

    { Direction = turns[dir]
      Position = pos }

let offset =
    function
    | North -> (0, 1)
    | East -> (1, 0)
    | South -> (0, -1)
    | West -> (-1, 0)

let advance { Direction = dir; Position = (x, y) } =
    let (x', y') = offset dir

    { Direction = dir
      Position = (x + x', y + y') }

let move instructions robot =
    instructions
    |> Seq.map (function
        | 'A' -> advance
        | 'L' -> turn Left
        | 'R' -> turn Right
        | _ -> failwith "unknown robot command")
    |> Seq.fold (|>) robot
