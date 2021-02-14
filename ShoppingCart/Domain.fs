module ShoppingCart.Domain

type CartItem = string

type EmptyState = NoItems

type ActiveState = { UnpaidItems : CartItem list; }

type PaidForState = { PaidItems : CartItem list; Payment : decimal }

type Cart = 
    | Empty of EmptyState
    | Active of ActiveState
    | PaidFor of PaidForState

