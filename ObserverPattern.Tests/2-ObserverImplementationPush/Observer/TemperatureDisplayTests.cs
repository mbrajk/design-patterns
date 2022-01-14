using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ObserverPattern._2_ObserverImplementationPush.Observers;
using ObserverPattern._2_ObserverImplementationPush.Subjects;

namespace ObserverPattern.Tests._2_ObserverImplementationPush.Observer;

[TestClass]
public class TemperatureDisplayTests
{
    private IWeatherDataSubject _weatherDataSubject;
    private TemperatureDisplay _sut;

    public TemperatureDisplayTests()
    {
        _weatherDataSubject = Substitute.For<IWeatherDataSubject>();
        _sut = new TemperatureDisplay(_weatherDataSubject);
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
            .Be("Temperature: 5");
    }
    
    [TestMethod]
    public void Update_ReturnsDefaultValues()
    {
        // Act
        var result = _sut.Display();
        
        // Assert
        result
            .Should()
            .Be("Temperature: 0");
    }
}