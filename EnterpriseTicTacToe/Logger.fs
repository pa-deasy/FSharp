module TicTacToe.Logger

open TicTacToe.Domain


let transformCapability transformMR player cellPos (cap:MoveCapability) :MoveCapability =
    
    let newCap() =
        printfn "LOGINFO: %A played %A" player cellPos
        let moveResult = cap() 
        transformMR moveResult 
    newCap

let transformNextMove transformMR player (move:NextMoveInfo) :NextMoveInfo = 
    let cellPos = move.posToPlay 
    let cap = move.capability
    {move with capability = transformCapability transformMR player cellPos cap} 

let rec transformMoveResult (moveResult:MoveResult) :MoveResult =
    
    let tmr = transformMoveResult

    match moveResult with
    | PlayerXToMove (display,nextMoves) ->
        let nextMoves' = nextMoves |> List.map (transformNextMove tmr PlayerX) 
        PlayerXToMove (display,nextMoves') 
    | PlayerOToMove (display,nextMoves) ->
        let nextMoves' = nextMoves |> List.map (transformNextMove tmr PlayerO)
        PlayerOToMove (display,nextMoves') 
    | GameWon (display,player) ->
        printfn "LOGINFO: Game won by %A" player 
        moveResult
    | GameTied display ->
        printfn "LOGINFO: Game tied" 
        moveResult

let injectLogging api =
   
    { api with
        newGame = fun () -> api.newGame() |> transformMoveResult
        }



