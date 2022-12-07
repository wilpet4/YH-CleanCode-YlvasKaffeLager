namespace YlvasKaffelager.Calculations.Decorators
{
    public class CalculationsDecoratorBase : Calculations
    {
        private Calculations calculations;
        public CalculationsDecoratorBase(Calculations calculations)
        {
            this.calculations = calculations;
        }
    }
}
