using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DecoratorPattern._4_CopilotRefactor;

namespace DecoratorPattern.Tests._4_CopilotRefactor
{
    [TestClass]
    public class BeverageTests
    {
        [TestMethod]
        public void DarkRoastTest()
        {
            // Arrange
            IBeverage myBeverage = new SugarDecorator(new MilkDecorator(new DarkRoast()));

            // Act
            var cost = myBeverage.Cost();

            // Assert
            cost.Should().Be(3.80m);
        }
    }
}
