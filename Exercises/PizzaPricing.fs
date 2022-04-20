module PizzaPricing

type Pizza =
    | Margherita
    | Caprese
    | Formaggio
    | ExtraSauce of Pizza
    | ExtraToppings of Pizza

let rec pizzaPrice (pizza: Pizza) : int =
    let rec loop accPrice pizza =
        match pizza with
        | Margherita -> accPrice + 7
        | Caprese -> accPrice + 9
        | Formaggio -> accPrice + 10
        | ExtraSauce sauce -> loop (accPrice + 1) sauce
        | ExtraToppings toppings -> loop (accPrice + 2) toppings

    loop 0 pizza

let orderPrice (pizzas: Pizza list) : int =
    match pizzas with
    | [ pizza ] -> 3 + pizzaPrice pizza
    | [ firstPizza; secondPizza ] -> 2 + pizzaPrice firstPizza + pizzaPrice secondPizza
    | pizzas -> List.sumBy pizzaPrice pizzas
