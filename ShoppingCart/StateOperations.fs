module ShoppingCart.StateOperations

open ShoppingCart.Domain

let addToEmptyState item =
    Cart.Active { UnpaidItems = [item] }

type EmptyState with 
    member this.Add = addToEmptyState

let addToActiveState state itemToAdd = 
    let newItemList = itemToAdd :: state.UnpaidItems
    Cart.Active { state with UnpaidItems = newItemList }

let removeFromActiveState state itemToRemove =
    let newItemList = state.UnpaidItems 
                        |> List.filter(fun i -> i <> itemToRemove)

    match newItemList with
    | [] -> Cart.Empty NoItems
    | _ -> Cart.Active { state with UnpaidItems = newItemList }

let payForActiveState state amount = 
    Cart.PaidFor { PaidItems = state.UnpaidItems; Payment = amount }

type ActiveState with
    member this.Add = addToActiveState this
    member this.Remove = removeFromActiveState this
    member this.Pay = payForActiveState this

