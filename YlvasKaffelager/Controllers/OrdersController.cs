using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YlvasKaffelager.DataModels;
using YlvasKaffelager.Repositories.Interfaces;
using YlvasKaffelager.ViewModels;
using YlvasKaffelager.Logic;
using YlvasKaffelager.Logic.Decorators;

namespace YlvasKaffelager.Controllers
{
    public class OrdersController : Controller
    {
        private IProductRepository _repository { get; init; }
        public Calculations Calculations { get; init; }
        public int NumberOfOrders { get; set; }
        public OrdersController(IProductRepository repository, Calculations calculations) // Dependency Injection för att komma åt repository.
        {
            _repository = repository;
            Calculations = calculations;
            NumberOfOrders = 0;
        }
        public IActionResult Index()
        {
            var model = new OrderViewModel();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Orders(OrderViewModel model)
        {
            var coffee = _repository.GetCoffe(model.CoffeeId);
            
            int amount = model.Amount;

            var viewModel = new ViewOrderModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Brand = coffee.Brand,
                Amount = amount,
                Total = new CoffeeDecorator(Calculations).PriceTotal(coffee.Price, model.Amount)
            };

            return View("ViewOrder", viewModel);
        }

        public IActionResult ViewOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Confirm(ViewOrderModel model)
        {
            NumberOfOrders++;

            var order = new Order
            {
                Id = NumberOfOrders,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Brand = model.Brand,
                Amount= model.Amount,
                Total = model.Total,
            };

            _repository.AddOrder(order);

            return View("Completed");
        }

        public IActionResult Completed()
        {
            return View();
        }
    }
}