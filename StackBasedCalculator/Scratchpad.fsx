#load "Domain.fs"
#load "Operations.fs"

open StackBasedCalculator.Domain
open StackBasedCalculator.Operations

let stack = StackContents[1.0; 2.0; 3.0]

let stackWithFour = push 4.0 stack
let stackWithFive = stack |> push 5.0


//let stackWith1 = ONE EMPTY
//let stackWith2 = TWO stackWith1
//let stackWith3 = THREE stackWith2

let stackWith123 = EMPTY |> ONE |> TWO |> THREE
let stackWith321 = EMPTY |> THREE |> TWO |> ONE

let pop3, stackWith12 = stackWith123 |> pop
let pop2, stackWith3 = stackWith12 |> pop

printfn "A popped float %f" pop3

let _ = EMPTY |> pop

let add12 = EMPTY |> ONE |> TWO |> ADD
let mult33Leave1 = EMPTY |> ONE |> THREE |> THREE |> MULT

let square3 = EMPTY |> ONE |> TWO |> THREE |> SQUARE |> SHOW


let runOneTwoAdd = EMPTY |> ONETWOADD |> SHOW