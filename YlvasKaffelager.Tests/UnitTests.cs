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
        private IDbContext context;
        private Mock<IDbContext> mock;
        Coffee firstCoffee;
        Coffee secondCoffee;
        Coffee? nullCoffee = null;
        public UnitTests()
        {
            firstCoffee = new Coffee
            {
                Id = 1,
                Brand = "Gevalia",
                Price = 29.90m
            };
            secondCoffee = new Coffee
            {
                Id = 2,
                Brand = "Lavazza",
                Price = 49.90m
            };

            mock = new Mock<IDbContext>();
            mock.Setup(x => x.GetCoffe(1)).Returns(firstCoffee);
            mock.Setup(x => x.GetCoffe(2)).Returns(secondCoffee);
            mock.Setup(x => x.GetCoffe(3)).Returns(nullCoffee);
            context = mock.Object;
        }

        [Theory]
        [InlineData(29.90, 1)]
        [InlineData(49.90, 2)]
        [InlineData(49.90, 0)]
        [InlineData(29.90, 5)]
        [InlineData(-29.90, -2)]
        public void Should_Return_Correct_Sum(decimal coffeePrice, int orderAmount)
        {
            // Arrange
            Calculations calculations = new Calculations();
            CoffeeDecorator withDecorator = new CoffeeDecorator(calculations);
            decimal expectedWithoutDecorator = coffeePrice * orderAmount;
            decimal expectedWithDecorator = (coffeePrice * orderAmount) * 1.06m;

            // Act
            decimal actualWithoutDecorator = calculations.PriceTotal(coffeePrice, orderAmount);
            decimal actualWithDecorator = withDecorator.PriceTotal(coffeePrice, orderAmount);

            //Assert
            Assert.Equal(expectedWithoutDecorator, actualWithoutDecorator);
            Assert.Equal(expectedWithDecorator, actualWithDecorator);
        }

        [Fact]
        public void Should_Return_Coffee()
        {
            // Arrange
            var expectedResult = firstCoffee;

            // Act
            var actualResult = context.GetCoffe(1);
            var actualWrongResult = context.GetCoffe(2);
            var actualNullResult = context.GetCoffe(3);
            var actualWrongId = context.GetCoffe(4);

            //Assert
            Assert.Equal(expectedResult, actualResult);
            Assert.NotEqual(expectedResult, actualWrongResult);
            Assert.Null(actualNullResult);
            Assert.Null(actualWrongId);
        }
    }
}