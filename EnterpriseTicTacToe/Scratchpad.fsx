

//type InitGame = unit -> Game

//type PlayerXMoves = GameState * SomeOtherStuff -> GameState
//type PlayerOMoves = GameState * SomeotherSTuff -> GameState

//type UserAction =
//    | PlayerXMoves of SomeStuff
//    | PlayerOMoves of SomeStuff


//type Move = UserAction * GameState -> GameState


type HorizontalPosition = 
    | Left
    | HCenter
    | Right

type VerticalPosition =
    | Top
    | VCenter
    | Bottom

type CellPosition = HorizontalPosition * VerticalPosition

type Player = 
    | PlayerX
    | PlayerO

type PlayerXPosition = PlayerXPosition of CellPosition

type PlayerOPotition = PlayerOPosition of CellPosition

type CellState =
    | Played of Player
    | Empty

type Cell = {
    State : CellState
    Position : CellPosition
}

type GameState = private {
    cells : Cell List
}

//type ValidPositionsForNextMove = CellPosition List
type ValidMovesForPlayerX = PlayerXPosition List
type ValidMovesForPlayerO = PlayerOPotition List

type GetCells<'GameState> = 'GameState -> Cell List

type InitGame = unit -> GameState

//type GameStatus =
//    | InProgress
//    | Won of Player
//    | Tie

type MoveResult =
    | PlayerXToMove of GameState * ValidMovesForPlayerX
    | PlayerOToMove of GameState * ValidMovesForPlayerO
    | GameWon of GameState * Player
    | GameTie of GameState

type PlayerXMoves<'GameState> = 
    'GameState * PlayerXPosition -> 
       'GameState * MoveResult
type PlayerOMoves<'GameState> = 
    'GameState * PlayerOPotition -> 
        'GameState * MoveResult

type NewGame<'GameState> = 'GameState * MoveResult


//let playerXMoves : PlayerXMoves<GameState> =
//    fun(gameState, move) ->
//    //implementation

//let playerOMoves : PlayerOMoves<GameState> =
//    fun(gameState, move) ->
//    //implementation

//let newGame : NewGame<GameState> =
//    let validMoves = //to do
//    gameState, PlayerXToMove validmoves


open System.Windows.Forms

//type TicTacToeForm<'T> 
//    (
//    newGame : NewGame<'T>,
//    playerXMoves : PlayerXMoves<'T>,
//    playerOMoves : PlayerOMoves<'T>,
//    getCells : GetCells<'T>
//    ) =
//    inherit Form
//    //implementation to do

