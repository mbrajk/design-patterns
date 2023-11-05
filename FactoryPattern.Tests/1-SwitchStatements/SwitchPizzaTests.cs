using System;
using FactoryPattern._1_SwitchStatements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace FactoryPattern.Tests._1_SwitchStatements;

/**
 * For this version of creating a pizza we have to interrogate the type
 * passed in and return a pizza of the given type. This requires us to use
 * a switch statement to determine the type of pizza to instantiate.
 * The main issue with this approach is violation of the open closed
 * principle. If we add a pizza type we need to edit the enum and the
 * switch statement. Additionally custom pizzas would need their own
 * switch statement, meaning a custom pizza would require a code change. >:(
 */
[TestClass]
public class SwitchPizzaTests
{
    [TestMethod]
    public void CreatePizzaOrderTest()
    {
        // Arrange
        var pizzaType = SwitchPizzaType.Veggie;
        var pizzaOrderSystem = new PizzaOrderSystem();

        // Act
        var pizza = pizzaOrderSystem.OrderPizza(pizzaType);

        // The test doesn't work since the actual pizza types are internal but this is what it would look like
        // Assert
        //pizza.Should().BeOfType(VeggieSwitchPizza);
        Console.WriteLine(pizza); // this will demonstrate the correct type in the console
    }
}
