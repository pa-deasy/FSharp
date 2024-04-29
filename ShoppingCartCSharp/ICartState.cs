using System;

namespace ShoppingCartCSharp
{
    public interface ICartState
    {
        public ICartState Transition(
            Func<CartStateEmpty, ICartState> cartStateEmpty,
            Func<CartStateActive, ICartState> cartStateActive,
            Func<CartStatePaid, ICartState> cartStatePaid
            );
    }
}
