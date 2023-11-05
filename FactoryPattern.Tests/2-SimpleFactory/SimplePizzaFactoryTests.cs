using System;
using FactoryPattern._2_SimpleFactory;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryPattern.Tests._2_SimpleFactory;

[TestClass]
public class SimplePizzaFactoryTests
{
    [TestMethod]
    public void CreatePizzaOrderTest()
    {
        // Arrange
        var pizzaType = PizzaFactoryPizzaType.Veggie;
        var pizzaOrderSystem = new PizzaOrderSystem();

        // Act
        var pizza = pizzaOrderSystem.OrderPizza(pizzaType);

        // Assert
        pizza.Should().BeOfType(typeof(VeggiePizza));
        Console.WriteLine(pizza);
    }
}
