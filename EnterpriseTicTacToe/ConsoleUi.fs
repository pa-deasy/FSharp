module TicTacToe.ConsoleUi

open TicTacToe.Domain
open System

type UserAction<'a> =
    | ContinuePlay of 'a
    | ExitGame

let displayNextMoves nextMoves =
    nextMoves 
    |> List.iteri (fun i moveInfo -> printfn "%i) %A " i moveInfo.posToPlay)

let getCapability selectedIndex nextMoves =
    if selectedIndex < List.length nextMoves then
        let move = List.nth nextMoves selectedIndex
        Some move.capability
    else
        None

let processMoveIndex (inputStr:String) availableMoves processInputAgain =
    match Int32.TryParse inputStr with
    | true,inputIndex ->
        match getCapability inputIndex availableMoves with
        | Some capability ->
            let moveResult = capability()
            ContinuePlay moveResult
        | None ->
            printfn "....No move found for input index %i. Try again" inputIndex
            processInputAgain()
    | false, _ ->
        printfn "Please enter an int corresponding to a displayed move:"
        processInputAgain()

let rec processInput availableCapabilities =
    let processInputAgain() = 
        processInput availableCapabilities
    
    printfn "Enter an int corresponding to a displayed move or q to quit:"
    let inputStr = Console.ReadLine()
    if inputStr = "q" then
        ExitGame
    else
        processMoveIndex inputStr availableCapabilities processInputAgain

let displayCells (displayInfo:DisplayInfo) = 
    let cellToStr cell = 
        match cell.state with
        | Empty -> "-"
        | Played player -> 
            match player with
            | PlayerX -> "X"
            | PlayerO -> "O"

    let printCells cells =
        cells
        |> List.map cellToStr
        |> List.reduce (fun s1 s2 -> s1 + "|" + s2)
        |> printfn "|%s|"

    let topCells = 
        displayInfo.cells |> List.filter (fun cell -> snd cell.position = Top)
    let centerCells =
        displayInfo.cells |> List.filter (fun cell -> snd cell.position = VCenter)
    let bottomCells =
        displayInfo.cells |> List.filter (fun cell -> snd cell.position = Bottom)

    printCells topCells
    printCells centerCells
    printCells bottomCells

    printfn ""

let rec askToPlayAgain api =
    printfn "Would you like to play again (y/n)?"
    match Console.ReadLine() with
    | "y" -> ContinuePlay (api.newGame())
    | "n" -> ExitGame
    | _ -> askToPlayAgain api

let rec gameLoop api userAction =
    printfn "\n--------------------------\n"

    match userAction with
    | ExitGame -> printfn "Exiting game"
    | ContinuePlay moveResult ->        
        match moveResult with
        | GameTied displayInfo ->
            displayInfo |> displayCells
            printfn "GAME OVER - Tie"
            printfn ""
            let nextUserAction = askToPlayAgain api
            gameLoop api nextUserAction
        | GameWon (displayInfo, player) ->
            displayInfo |> displayCells
            printfn "GAME WON by %A" player
            let nextUserAction = askToPlayAgain api
            gameLoop api nextUserAction
        | PlayerOToMove (displayInfo, nextMoves) ->
            displayInfo |> displayCells
            printfn "Player O to move"
            displayNextMoves nextMoves
            let newResult = processInput nextMoves
            gameLoop api newResult
        | PlayerXToMove (displayInfo, nextMoves) ->
            displayInfo |> displayCells
            printfn "Player X to move"
            displayNextMoves nextMoves
            let newResult = processInput nextMoves
            gameLoop api newResult

let startGame api =
    let userAction = ContinuePlay (api.newGame())
    gameLoop api userAction