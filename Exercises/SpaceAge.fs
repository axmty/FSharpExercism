module SpaceAge

type Planet =
    | Earth
    | Jupiter
    | Mars
    | Mercury
    | Neptune
    | Saturn
    | Uranus
    | Venus

let age (planet: Planet) (seconds: int64) : float =
    let earthYears = float seconds / 31557600.

    match planet with
    | Earth -> earthYears
    | Jupiter -> earthYears / 11.862615
    | Mars -> earthYears / 1.8808158
    | Mercury -> earthYears / 0.2408467
    | Neptune -> earthYears / 164.79132
    | Saturn -> earthYears / 29.447498
    | Uranus -> earthYears / 84.016846
    | Venus -> earthYears / 0.61519726
