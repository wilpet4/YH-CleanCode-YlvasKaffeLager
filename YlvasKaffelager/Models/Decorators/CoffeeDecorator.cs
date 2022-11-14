using YlvasKaffelager.DataModels;

namespace YlvasKaffelager.Models.Decorators
{
    public class CoffeeDecorator : ProductDecoratorBase
    {
        private Product product;
        public CoffeeDecorator(Product product)
        {
            this.product = product;
        }
        public override decimal GetTotalPrice()
        {
            return base.GetTotalPrice() + Price;
        }
    }
}
