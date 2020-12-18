open System

let startFields = [['1'..'3']; ['4'..'6']; ['7'..'9']]
let player1char = 'X'
let player2char = 'O'

// Print out the game field
let print_field(field : char list list) =
    field |> List.iter(fun row -> 
        List.iter(fun c -> printf "%c " c) row
        printfn ""
    )

// Function to check if the game is won
let check_win(field: char list list, player: char): bool =
    // Vertical or horizontal winning conndition
    let check_row(f: char list list, p: char, x: int): bool = (f.[x].[0].Equals(p) && f.[x].[1].Equals(p) && f.[x].[2].Equals(p))
    let check_column(f: char list list, p: char, y: int): bool = (f.[0].[y].Equals(p) && f.[1].[y].Equals(p) && f.[2].[y].Equals(p))
    // Diagonal winning condition
    let check_vert1(f: char list list, p: char): bool =  (f.[0].[0].Equals(p) && f.[1].[1].Equals(p) && f.[2].[2].Equals(p))
    let check_vert2(f: char list list, p: char): bool =  (f.[0].[2].Equals(p) && f.[1].[1].Equals(p) && f.[2].[0].Equals(p))
    // Loop thorugh all rows and columns, if an empty result is returned, no winner is found
    let result = [0..2] |> List.filter(fun i -> (check_row(field, player, i)) || (check_column(field, player, i)))
    // Check all conditions
    result.Length > 0 || check_vert1(field, player) || check_vert2(field, player)

// Create a new game field with the user input
let append_input(field: char list list, player: char, input: char): char list list =
    field |> List.map(fun row -> row |> List.map(fun c -> if c = input then player else c))

// Check if the input is valid (I think it should be possible to do this without the || but I don't know how to loop correctly)
let check_valid_input(field: char list list, input: string): bool =
    input.Length = 1 && (field.[0] |> List.contains input.[0] || field.[1] |> List.contains input.[0] || field.[2] |> List.contains input.[0])

// Check all fields are set (I think there is a better way to slove it, but could't figured it out)
let check_draw(field: char list list) : bool=
    field.[0] |> List.forall(fun c -> c = player1char || c = player2char) &&
    field.[1] |> List.forall(fun c -> c = player1char || c = player2char) &&
    field.[2] |> List.forall(fun c -> c = player1char || c = player2char) 

// Recursive method to go to the next step till the game is finished
let rec next_move(field : char list list, player : char) = 
    printfn "Player %c is next" player
    print_field(field)
    printf "Choose a Field: "
    let userInput = Console.ReadLine()
    // Check if the user input is valid, otherwise repeat the move
    if check_valid_input(field, userInput) then
        let newField = append_input(field, player, userInput.[0])
        if check_draw(newField) then
            // Draw
            printfn "Draw! Game Over!"
        elif not (check_win(newField, player)) then
            // Move of the next player
            next_move(newField, if player = player1char then player2char else player1char) 
        else
            // Player has won
            print_field(field)
            printfn "Player %c has won!" player
    else
        printfn "Unvalid Input!"
        next_move(field, player)

// Start the game function
let start_game() =
    next_move(startFields, player1char)

start_game()