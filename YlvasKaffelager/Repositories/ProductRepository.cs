using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YlvasKaffelager.DataModels;
using YlvasKaffelager.DbContext.Interface;
using YlvasKaffelager.Repositories.Interfaces;

namespace YlvasKaffelager.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IDbContext _context { get; }
        public ProductRepository(IDbContext context)
        {
            _context = context;
        }
        public Coffee GetCoffe(int Id)
        {
            return _context.GetCoffe(Id);
        }

        public void AddOrder(Order order)
        {
            _context.AddOrder(order);
        }
    }
}
