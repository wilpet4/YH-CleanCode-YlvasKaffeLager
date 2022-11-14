using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YlvasKaffelager.DataModels;
using YlvasKaffelager.DbContext.Interfaces;

namespace YlvasKaffelager.DbContext
{
    public class DbContext : IDbContext
    {
        public DbContext()
        {
            Orders = new List<Order>();
        }

        private List<Coffee> Coffees { get; set; } = new List<Coffee>
        {
            new Coffee
            {
                Id = 1,
                Brand = "Gevalia",
                Price = 29.90m
            },
            new Coffee
            {
                Id = 2,
                Brand = "Lavazza",
                Price = 49.90m
            },
            new Coffee
            {
                Id = 3,
                Brand = "Zoegas",
                Price = 59.90m
            },
            new Coffee
            {
                Id = 4,
                Brand = "Löfbergs",
                Price = 39.90m
            }
        };

        private List<Order> Orders { get; set; }

        public Coffee GetCoffe(int Id)
        {
            return Coffees.Where(c => c.Id == Id).FirstOrDefault()!;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }
    }
}