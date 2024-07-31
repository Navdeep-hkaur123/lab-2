// For more information see https://aka.ms/fsharp-console-apps

type Cuisine =
    | Korean
    | Turkish

type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float

let calculateBudget activity =
    match activity with
    | BoardGame -> 0.0
    | Chill -> 0.0
    | Movie movieType ->
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 12.0 + 5.0
        | IMAXWithSnacks -> 17.0 + 5.0
        | DBOXWithSnacks -> 20.0 + 5.0
    | Restaurant cuisine ->
        match cuisine with
        | Korean -> 70.0
        | Turkish -> 65.0
    | LongDrive (kilometres, fuelPerKm) ->
        float kilometres * fuelPerKm

let activities = [
    BoardGame
    Chill
    Movie RegularWithSnacks
    Restaurant Korean
    LongDrive (100, 1.5)  
]

let budgetDetails = 
    activities
    |> List.map (fun activity -> (activity, calculateBudget activity))

let totalBudget = budgetDetails |> List.sumBy snd


budgetDetails 
|> List.iter (fun (activity, budget) -> 
    printfn "Activity: %A, Budget: %.2f CAD" activity budget)

printfn "Total Budget for the evening: %.2f CAD" totalBudget
