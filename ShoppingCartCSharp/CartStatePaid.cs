using System;

namespace ShoppingCartCSharp
{
    public class CartStatePaid : ICartState
    {
        public ICartState Transition(
            Func<CartStateEmpty, ICartState> cartStateEmpty, 
            Func<CartStateActive, ICartState> cartStateActive, 
            Func<CartStatePaid, ICartState> cartStatePaid)
        {
            return cartStatePaid(this);
        }
    }
}
