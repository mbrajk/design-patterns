using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverPattern._1_ConcreteImplementation;

namespace ObserverPattern.Tests._1_ConcreteImplementation;

[TestClass]
public class ConcreteImplementationTests
{
    private WeatherData? _sut;
    
    [TestMethod]
    public void UntestableClassExample()
    {
        // Arrange
        // We cannot mock out these classes because the constructor does not take interfaces.
        // For our unit tests this doesn't matter but in a real system this would make unit
        // testing difficult as you could accidentally be performing real work (e.g. calling an API)
        var currentConditionsDisplay = new CurrentConditionsDisplay();
        var forecastDisplay = new ForecastDisplay();
        var statisticsDisplay = new StatisticsDisplay();
        
        _sut = new WeatherData(currentConditionsDisplay, forecastDisplay, statisticsDisplay);
        
        // Act
        _sut.MeasurementsChanged();
        
        // Assert
        // We currently have nothing to assert because our constructor takes concrete implementations.
        // If we were using interfaces we could mock the interfaces and verify that the correct
        // methods were called etc.
    }
}