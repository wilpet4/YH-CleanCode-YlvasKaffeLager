
namespace YlvasKaffelager.Logic.Decorators
{
    public class CoffeeDecorator : CalculationsDecoratorBase
    {
        private decimal vat = 1.06m; // Moms på 6%.
        public CoffeeDecorator(Calculations calculations) : base(calculations)
        {

        }
        public override decimal PriceTotal(decimal price, int amount)
        {
            return base.PriceTotal(price, amount) * vat; // Lägger till moms i beräkningen för kaffe.
        }
    }
}
