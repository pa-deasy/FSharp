namespace ShoppingCartCSharp
{
    public class ClientExample
    {
        public ICartState AddProduct(ICartState currentState, Product product)
        {
            return currentState.Transition(
                cartStateEmpty => cartStateEmpty.Add(product),
                cartStateActive => cartStateActive.Add(product),
                cartStatePaid => cartStatePaid
                );
        }

        public void Example()
        {
            var currentState = new CartStateEmpty() as ICartState;

            currentState = AddProduct(currentState, new Product { Description = "Milk" });

            currentState = AddProduct(currentState, new Product { Description = "Bread" });

            const decimal paidAmount = 12.34m;

            currentState = currentState.Transition(
                cartStateEmpty => cartStateEmpty,
                cartStateActive => cartStateActive.Pay(paidAmount),
                cartStatePaid => cartStatePaid
                );
        }
    }
}
