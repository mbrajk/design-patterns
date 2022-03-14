using DecoratorPattern._3_Decorator;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecoratorPattern.Tests._3_Decorator;

[TestClass]
public class BeverageTests
{
    [TestMethod]
    public void MochaWhipDarkRoastTest()
    {
        // Arrange
        var baseBeverage = new DarkRoast();
        var mocha = new Mocha(baseBeverage);
        var whip = new Whip(mocha);
        
        // Act
        var cost = whip.GetCost();

        // Assert
        cost
            .Should()
            .Be(4.75m);
    }
    
    [TestMethod]
    public void MochaWhipWhipDarkRoastTest()
    {
        // Arrange
        var baseBeverage = new DarkRoast();
        var mocha = new Mocha(baseBeverage);
        var whip = new Whip(mocha);
        var whip2x = new Whip(whip);
        
        // Act
        var cost = whip2x.GetCost();

        // Assert
        cost
            .Should()
            .Be(6.00m);
    }
    
    [TestMethod]
    public void MochaWhipWhipMochaDarkRoastDescriptionTest()
    {
        // Arrange
        var baseBeverage = new DarkRoast();
        var mocha = new Mocha(baseBeverage);
        var whip = new Whip(mocha);
        var whip2 = new Whip(whip);  
        var mocha2 = new Mocha(whip2);

        
        // Act
        var description = mocha2.GetDescription();

        // Assert
        description
            .Should()
            .Be("Mocha\r\nWhipped Cream\r\nWhipped Cream\r\nMocha\r\nDark Roast");
    }
    
    [TestMethod]
    public void MochaTest()
    {
        // Arrange
        var baseBeverage = new DarkRoast();
        var mocha = new Mocha(baseBeverage);
        
        // Act
        var cost = mocha.GetCost();
        
        // Assert
        cost
            .Should()
            .Be(3.50m);
    }
    
    [TestMethod]
    public void DarkRoastTest()
    {
        // Arrange
        var baseBeverage = new DarkRoast();
        //var mocha = new Mocha(baseBeverage);
        
        // Act
        var cost = baseBeverage.GetCost();
        
        // Assert
        cost
            .Should()
            .Be(2.50m);
    }
}