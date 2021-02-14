module TicTacToe.Domain

type HorizontalPosition = 
    | Left
    | HCenter
    | Right

type VerticalPosition =
    | Top
    | VCenter
    | Bottom

type CellPosition = HorizontalPosition * VerticalPosition

type Line = Line of CellPosition list

type Player = 
    | PlayerX
    | PlayerO

type CellState =
    | Played of Player
    | Empty

type Cell = {
    state : CellState
    position : CellPosition
}

type DisplayInfo = {
    cells : Cell list
}

type MoveCapability = unit -> MoveResult

and NextMoveInfo = {
    posToPlay : CellPosition
    capability : MoveCapability
}

and MoveResult =
    | PlayerXToMove of DisplayInfo * NextMoveInfo list
    | PlayerOToMove of DisplayInfo * NextMoveInfo list
    | GameWon of DisplayInfo * Player
    | GameTied of DisplayInfo

type TicTackToeAPI =
    {
        newGame : MoveCapability
    }

type GameState = {
    cells : Cell list
}