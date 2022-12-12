using Moq;
using System.Reflection;
using Xunit;
using YlvasKaffelager.Database;
using YlvasKaffelager.Database.Interfaces;
using YlvasKaffelager.DataModels;
using YlvasKaffelager.Logic;
using YlvasKaffelager.Logic.Decorators;

namespace YlvasKaffelager.Tests
{
    public class UnitTests
    {
        private DbContext context = new DbContext();
        private Mock<IDbContext> mock;
        public UnitTests()
        {
            Coffee firstCoffee = new Coffee
            {
                Id = 1,
                Brand = "Gevalia",
                Price = 29.90m
            };
            Coffee secondCoffee = new Coffee
            {
                Id = 2,
                Brand = "Lavazza",
                Price = 49.90m
            };

            mock = new Mock<IDbContext>();
            mock.Setup(x => x.GetCoffe(1)).Returns(firstCoffee);
            mock.Setup(x => x.GetCoffe(2)).Returns(secondCoffee);
        }
        [Fact]
        public void Should_Return_Correct_Sum()
        {
            // Arrange
            var coffee = context.GetCoffe(1);
            var calculations = new Calculations();
            var withDecorator = new CoffeeDecorator(calculations);
            decimal expectedWithoutDecorator = 29.90m;
            decimal expectedWithDecorator = 29.90m * 1.06m;

            // Act
            var actualWithoutDecorator = calculations.PriceTotal(coffee.Price, 2);
            var actualWithDecorator = withDecorator.PriceTotal(coffee.Price, 2);

            //Assert
            Assert.Equal(expectedWithoutDecorator, actualWithoutDecorator);
            Assert.Equal(expectedWithDecorator, actualWithDecorator);
        }

        [Fact]
        public void Should_Return_Coffee()
        {
            // Arrange


            // Act


            //Assert

        }
    }
}