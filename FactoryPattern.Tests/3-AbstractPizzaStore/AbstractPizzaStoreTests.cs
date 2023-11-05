using FactoryPattern._3_AbstractPizzaStore;
using FactoryPattern._3_AbstractPizzaStore.NewYorkPizza;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryPattern.Tests._3_AbstractPizzaStore;

[TestClass]
public class AbstractPizzaStoreTests
{
    [TestMethod]
    public void ChicagoPizzaCreate()
    {
        // Arrange
        var pizzaStore = new ChicagoPizzaStore();
        
        // Act
        var pizza = pizzaStore.OrderPizza(AbstractPizzaType.Cheese);
        
        // Assert
        pizza
            .PizzaType
            .Should()
            .Be(AbstractPizzaType.Cheese);
    }
    
    [TestMethod]
    public void NewYorkPizzaCreate()
    {
        // Arrange
        var pizzaStore = new NewYorkPizzaStore();
        
        // Act
        var pizza = pizzaStore.OrderPizza(AbstractPizzaType.Pepperoni);
        
        // Assert
        pizza
            .PizzaType
            .Should()
            .Be(AbstractPizzaType.Pepperoni);
    }
}