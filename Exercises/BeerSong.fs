module BeerSong

let verse bottles =
  match bottles with
  | 0 ->
    [ "No more bottles of beer on the wall, no more bottles of beer."
      "Go to the store and buy some more, 99 bottles of beer on the wall." ]
  | 1 ->
    [ "1 bottle of beer on the wall, 1 bottle of beer."
      "Take it down and pass it around, no more bottles of beer on the wall." ]
  | 2 ->
    [ "2 bottles of beer on the wall, 2 bottles of beer."
      "Take one down and pass it around, 1 bottle of beer on the wall." ]
  | bottles ->
    [ sprintf "%d bottles of beer on the wall, %d bottles of beer." bottles bottles
      sprintf "Take one down and pass it around, %d bottles of beer on the wall." (bottles - 1) ]

let recite (startBottles: int) (takeDown: int) =
  Seq.init takeDown (fun i -> startBottles - i)
  |> Seq.map verse
  |> Seq.collect (fun verse -> "" :: verse)
  |> Seq.skip 1
  |> Seq.toList
