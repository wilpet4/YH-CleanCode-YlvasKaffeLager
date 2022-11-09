using YlvasKaffelager.DataModels;

namespace YlvasKaffelager.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddOrder(Order order);
        Coffee GetCoffe(int Id);
    }
}