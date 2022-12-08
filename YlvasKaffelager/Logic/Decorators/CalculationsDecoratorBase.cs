namespace YlvasKaffelager.Logic.Decorators
{
    public class CalculationsDecoratorBase : Calculations
    {
        protected Calculations calculations;
        public CalculationsDecoratorBase(Calculations calculations)
        {
            this.calculations = calculations;
        }
    }
}
