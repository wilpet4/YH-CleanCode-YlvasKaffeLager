using YlvasKaffelager.DataModels;

namespace YlvasKaffelager.Database.Interfaces
{
    public interface IDbContext
    {
        void AddOrder(Order order);
        Coffee GetCoffe(int Id);
    }
}