using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ObserverPattern._2_ObserverImplementation.Observers;
using ObserverPattern._2_ObserverImplementation.Subjects;

namespace ObserverPattern.Tests._2_ObserverImplementation.Observer;

[TestClass]
public class CurrentConditionsDisplayTests
{
    private IWeatherDataSubject _weatherDataSubject;
    private CurrentConditionsDisplay _sut;

    public CurrentConditionsDisplayTests()
    {
        _weatherDataSubject = Substitute.For<IWeatherDataSubject>();
        _sut = new CurrentConditionsDisplay(_weatherDataSubject);
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
            .Be("Current Temp: 5, Pressure: 6, Humidity: 7");
    }
    
    [TestMethod]
    public void Update_ReturnsDefaultValues()
    {
        // Act
        var result = _sut.Display();
        
        // Assert
        result
            .Should()
            .Be("Current Temp: 0, Pressure: 0, Humidity: 0");
    }
}