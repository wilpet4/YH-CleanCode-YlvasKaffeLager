using YlvasKaffelager.DataModels;

namespace YlvasKaffelager.DbContext.Interfaces
{
    public interface IDbContext
    {
        void AddOrder(Order order);
        Coffee GetCoffe(int Id);
    }
}