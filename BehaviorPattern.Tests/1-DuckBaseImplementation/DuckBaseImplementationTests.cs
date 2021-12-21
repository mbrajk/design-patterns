using BehaviorPattern._1_DuckBaseImplementation;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BehaviorPattern.Tests._1_DuckBaseImplementation;

[TestClass]
public class DuckBaseImplementationTests
{
    [TestMethod]
    public void MallardDuck_CallFly_ReturnsFlying()
    {
        // Arrange
        var duck = new MallardDuck();
        
        // Act
        var result = duck.Fly();
        
        // Assert
        result
           .Should()
           .Be("Flying");
    }
    
    [TestMethod]
    public void MallardDuck_CallSwim_ReturnsSwimming()
    {
        // Arrange
        var duck = new MallardDuck();
        
        // Act
        var result = duck.Swim();
        
        // Assert
        result
           .Should()
           .Be("Swimming");
    }
    
    [TestMethod]
    public void MallardDuck_CallQuack_ReturnsQuacking()
    {
        // Arrange
        var duck = new MallardDuck();
        
        // Act
        var result = duck.Fly();
        
        // Assert
        result
           .Should()
           .Be("Flying");
    }
    
    [TestMethod]
    public void RubberDuck_CallFly_ReturnsNoAction()
    {
        // Arrange
        var duck = new RubberDuck();
        
        // Act
        var result = duck.Fly();
        
        // Assert
        result
           .Should()
           .Be("No Action");
    }
    
    [TestMethod]
    public void RubberDuck_CallSwim_ReturnsFloating()
    {
        // Arrange
        var duck = new RubberDuck();
        
        // Act
        var result = duck.Swim();
        
        // Assert
        result
           .Should()
           .Be("Floating");
    }
    
    [TestMethod]
    public void RubberDuck_CallQuack_ReturnsSqueak()
    {
        // Arrange
        var duck = new RubberDuck();
        
        // Act
        var result = duck.Quack();
        
        // Assert
        result
           .Should()
           .Be("Squeak");
    }
    
    [TestMethod]
    public void DuckCall_CallFly_ReturnsNoAction()
    {
        // Arrange
        var duck = new DuckCall();
        
        // Act
        var result = duck.Fly();
        
        // Assert
        result
           .Should()
           .Be("No Action");
    }
    
    [TestMethod]
    public void DuckCall_CallSwim_ReturnsNoAction()
    {
        // Arrange
        var duck = new DuckCall();
        
        // Act
        var result = duck.Swim();
        
        // Assert
        result
           .Should()
           .Be("No Action");
    }
    
    [TestMethod]
    public void DuckCall_CallQuack_ReturnsQuack()
    {
        // Arrange
        var duck = new DuckCall();
        
        // Act
        var result = duck.Quack();
        
        // Assert
        result
           .Should()
           .Be("Quacking");
    }
}