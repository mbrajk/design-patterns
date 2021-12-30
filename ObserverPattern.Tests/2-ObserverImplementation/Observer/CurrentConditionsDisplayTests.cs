using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverPattern._2_ObserverImplementation.Observers;

namespace ObserverPattern.Tests._2_ObserverImplementation.Observer;

[TestClass]
public class CurrentConditionsDisplayTests
{
    private CurrentConditionsDisplay _sut;

    public CurrentConditionsDisplayTests()
    {
        _sut = new CurrentConditionsDisplay();
    }
    
    [TestMethod]
    public void Update_ReturnsExpectedValues()
    {
        // Arrange
        _sut.Update(5, 6, 7);
        
        // Act
        var result = _sut.Display();
        
        // Assert
        result
            .Should()
            .Be("Temp: 5, Pressure: 6, Humidity: 7");
    }
    
    [TestMethod]
    public void Update_ReturnsDefaultValues()
    {
        // Act
        var result = _sut.Display();
        
        // Assert
        result
            .Should()
            .Be("Temp: 0, Pressure: 0, Humidity: 0");
    }
}