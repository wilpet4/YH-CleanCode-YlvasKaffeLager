namespace YlvasKaffelager.Logic.Decorators
{
    public abstract class CalculationsDecoratorBase : Calculations
    {
        protected Calculations calculations;
        public CalculationsDecoratorBase(Calculations calculations)
        {
            this.calculations = calculations;
        }
    }
}
