module TicTacToe.Implementation

open TicTacToe.Domain

let allHorizPositions = [Left; HCenter; Right]
let allVertPositions = [Top; VCenter; Bottom]

let linesToCheck =
    let makeHline v = Line [for h in allHorizPositions do yield (h,v)]
    let hLines = [for v in allVertPositions do yield makeHline v]

    let makeVLine h = Line [for v in allVertPositions do yield (h,v)]
    let vLines = [for h in allHorizPositions do yield makeVLine h]

    let diagonalLine1 = Line [Left,Top; HCenter,VCenter; Right,Bottom]
    let diagonalLine2 = Line [Left,Bottom; HCenter,VCenter; Right,Top]

    [
    yield! hLines
    yield! vLines
    yield diagonalLine1
    yield diagonalLine2
    ]

let getDisplayInfo gameState = 
    { DisplayInfo.cells = gameState.cells }

let getCell gameState posToFind =
    gameState.cells 
    |> List.find (fun cell -> cell.position = posToFind)

let private updateCell newCell gameState =
    let substituteNewCell oldCell =
        if oldCell.position = newCell.position then
            newCell
        else
            oldCell

    let newCells = gameState.cells |> List.map substituteNewCell

    {gameState with cells = newCells}

let private isGameWonBy player gameState =

    let cellWasPlayedBy playerToCompare cell =
        match cell.state with
        | Played player -> player = playerToCompare
        | Empty -> false

    let lineIsAllSamePlayer player (Line cellPosList) =
        cellPosList
        |> List.map (getCell gameState)
        |> List.forall (cellWasPlayedBy player)

    linesToCheck 
    |> List.exists (lineIsAllSamePlayer player)

let private isGameTied gameState =
    let cellWasPlayed cell =
        match cell.state with
        | Played _ -> true
        | Empty -> false

    gameState.cells
    |> List.forall cellWasPlayed

let private remainingMoves gameState = 
    let playableCell cell =
        match cell.state with
        | Played _ -> None
        | Empty -> Some (cell.position)

    gameState.cells
    |> List.choose playableCell

let otherPlayer player = 
    match player with
    | PlayerX -> PlayerO
    | PlayerO -> PlayerX

let moveResultFor player displayInfo nextMoves =
    match player with
    | PlayerX -> PlayerXToMove(displayInfo, nextMoves)
    | PlayerO -> PlayerOToMove(displayInfo, nextMoves)

let makeNextMoveInfo f player gameState cellPosition = 
    let capability() = f player cellPosition gameState
    { posToPlay = cellPosition; capability = capability }

let makeMoveResultWithCapabilities f player gameState cellPosList = 
    let displayInfo = getDisplayInfo gameState
    
    cellPosList
    |> List.map (makeNextMoveInfo f player gameState)
    |> moveResultFor player displayInfo

let rec playerMove player cellPos gameState =
    let newCell = {state = Played player; position = cellPos}
    let newGameState = gameState |> updateCell newCell
    let displayInfo = getDisplayInfo newGameState

    if newGameState |> isGameWonBy player then
        GameWon(displayInfo, player)

    elif newGameState |> isGameTied then

        GameTied(displayInfo)

    else
        let otherPlayer = otherPlayer player
        let moveResult = 
            newGameState
            |> remainingMoves
            |> (makeMoveResultWithCapabilities playerMove otherPlayer newGameState)
        moveResult

let newGame() =
    
    let allPositions = [
        for h in allHorizPositions do
        for v in allVertPositions do
            yield(h, v)
    ]

    let emptyCells = 
        allPositions
        |> List.map (fun pos -> {position = pos; state = Empty})

    let gameState = { cells = emptyCells }

    let moveResult = 
        allPositions
        |> makeMoveResultWithCapabilities playerMove PlayerX gameState

    moveResult


let api = {
    newGame = newGame
    }