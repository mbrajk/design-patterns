using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverPattern._3_ObserverImplementationPull.Observers;
using ObserverPattern._3_ObserverImplementationPull.Subjects;

namespace ObserverPattern.Tests._3_ObserverImplementationPull
{
    /// <summary>
    ///     We are using this unit test to simulate a running system as we are not
    ///     building a console application that we can actually run.
    /// </summary>
    [TestClass]
    public class WeatherStationTests
    {
        public WeatherStationTests()
        {
        }

        [TestMethod]
        public void WeatherStationFullTest()
        {
            // Arrange
            
            // we create the initial weather data subject which is responsible for updating displays
            // when weather data changes 
            var weatherDataSubject = new WeatherDataSubject();

            // we add the displays that reference the weather data subject that they wish to register to
            var forecastDisplay = new ForecastDisplay(weatherDataSubject);
            var temperatureDisplay = new TemperatureDisplay(weatherDataSubject);

            // Act
            // we notify the displays about the current weather
            weatherDataSubject.NotifyDisplays();

            // Assert
            // NOTE: There is no assert for this test since we are running real code. 
            // However you can check the standard output in the Unit Test when running the unit tests
            // to verify that we did in fact print out 2 messages, one for each display that was created above.
        }
    }
}
