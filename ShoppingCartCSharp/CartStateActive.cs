using System;
using System.Collections.Generic;

namespace ShoppingCartCSharp
{
    public class CartStateActive : ICartState
    {
        private IList<Product> products;

        public ICartState Transition(
            Func<CartStateEmpty, ICartState> cartStateEmpty,
            Func<CartStateActive, ICartState> cartStateActive,
            Func<CartStatePaid, ICartState> cartStatePaid
            )
        {
            return cartStateActive(this);
        }

        public ICartState Add(Product product)
        {
            products.Add(product);
            return this;
        }

        public ICartState Pay(decimal amount)
        {
            return this;
        }
    }
}
