module TicTacToe.ConsoleApplication

let startGame = 
    let api = Implementation.api |> Logger.injectLogging
    ConsoleUi.startGame api
    