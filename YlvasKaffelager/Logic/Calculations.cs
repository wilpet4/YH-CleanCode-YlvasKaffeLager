namespace YlvasKaffelager.Logic
{
    /// <summary>
    /// Denna klass ska ansvara för alla beräkningar i programmet.
    /// </summary>
    public class Calculations
    {
        public virtual decimal PriceTotal(decimal price, int amount)
        {
            return price * amount;
        }
    }
}
