module StackBasedCalculator.Operations

open StackBasedCalculator.Domain

let push x (StackContents contents) =
    StackContents(x :: contents)

let EMPTY = StackContents []
let ONE = push 1.0
let TWO = push 2.0
let THREE = push 3.0
let FOUR = push 4.0
let FIVE = push 5.0

let pop (StackContents contents) = 
    match contents with
    | top :: rest -> 
        top, StackContents(rest)
    | [] -> 
        failwith "Stack underflow"

//let ADD stack =
//    let x, pop1 = stack |> pop
//    let y, pop2 = pop1 |> pop
//    let result = x + y
//    pop2 |> push result
//
//let MULT stack =
//    let x, pop1 = stack |> pop
//    let y, pop2 = pop1 |> pop
//    let result = x * y
//    pop2 |> push result

let binary mathFn stack =
    let x, pop1 = stack |> pop
    let y, pop2 = pop1 |> pop
    let result = mathFn x y
    pop2 |> push result

let ADD = binary (fun x y -> x + y) 
    
let MULT = binary (fun x y -> x * y) 

let unary mathFn stack =
    let x, pop1 = stack |> pop
    let result = mathFn x
    pop1 |> push result

let SQUARE = unary (fun x -> x * x)

let SHOW stack =
    let x, _ = stack |> pop
    printfn "Top of stack is %f" x
    stack

let ONETWOADD = ONE >>TWO >> ADD