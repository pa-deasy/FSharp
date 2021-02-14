#load "Domain.fs"
#load "StateOperations.fs"
#load "CartOperations.fs"

open ShoppingCart.Domain
open ShoppingCart.StateOperations
open ShoppingCart.CartOperations

let emptyCart = Cart.NewCart
printf "emptyCart = "; emptyCart.Display

let cartPlusOne = emptyCart.Add "milk"
printf "cartPlusOne = "; cartPlusOne.Display

let cartPlusTwo = cartPlusOne.Add "bread"
printf "cartPlusTwo = "; cartPlusTwo.Display

let cartMinusOne = cartPlusTwo.Remove "milk"
printf "cartMinusOne = "; cartMinusOne.Display

let cartMinusTwo = cartMinusOne.Remove "bread"
printf "cartMinusTwo = "; cartMinusTwo.Display

let cartUnremoveable = cartMinusTwo.Remove "bread"
printf "cartUnremoveable = ";cartUnremoveable.Display

let cartPlusOnePaid =
    match cartPlusOne with
    | Empty _ | PaidFor _ -> cartPlusOne
    | Active state -> state.Pay 100m
printf "cartPlusOne paid = "; cartPlusOnePaid.Display


let emptyCartPaid = 
    match emptyCart with
    | Empty _ | PaidFor _ -> emptyCart
    | Active state -> state.Pay 100m
printf "emptyCart paid = "; emptyCartPaid.Display
