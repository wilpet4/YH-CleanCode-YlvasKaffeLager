using YlvasKaffelager.DataModels;

namespace YlvasKaffelager.DbContext.Interface
{
    public interface IDbContext
    {
        void AddOrder(Order order);
        Coffee GetCoffe(int Id);
    }
}