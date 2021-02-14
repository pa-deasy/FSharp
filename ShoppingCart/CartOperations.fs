module ShoppingCart.CartOperations

open ShoppingCart.Domain
open ShoppingCart.StateOperations

let addItemToCart cart item =
    match cart with
    | Empty state -> state.Add item
    | Active state -> state.Add item
    | PaidFor state -> 
        printfn "Error the cart is already paid for" 
        cart

let removeItemsFromCart cart item =
    match cart with
    | Empty state -> 
        printfn "Error cart is empty"
        cart
    | Active state -> state.Remove item
    | PaidFor state -> 
        printfn "Error the cart is already paid for"
        cart

let displayCart cart = 
    match cart with
    | Empty state -> 
        printfn "Cart is empty"
    | Active state ->
        printfn "The cart contains %A unpaid items" state.UnpaidItems
    | PaidFor state ->
        printfn "%f was paid for items %A" state.Payment state.PaidItems

type Cart with
    static member NewCart = Cart.Empty NoItems
    member this.Add = addItemToCart this
    member this.Remove = removeItemsFromCart this
    member this.Display = displayCart this