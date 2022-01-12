using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverPattern._2_ObserverImplementationPush.Observers;
using ObserverPattern._2_ObserverImplementationPush.Subjects;

namespace ObserverPattern.Tests._2_ObserverImplementationPush
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

            // we add 3 new displays that reference the weather data subject that they wish to register to
            var currentConditionsDisplay = new CurrentConditionsDisplay(weatherDataSubject);
            var forecastDisplay = new ForecastDisplay(weatherDataSubject);
            var statisticsDisplay = new StatisticsDisplay(weatherDataSubject);

            // Act
            // we notify the displays about the current weather
            weatherDataSubject.NotifyDisplays();

            /*-----
            * NOTE: check the implementation of NotifyDisplays to understand how the displays are being
            * updated. NotifyDisplays() is relying on private methods to generate random weather data. 
            * this data is used to notify the displays. It may be reasonable to expose a method that 
            * allows setting the measurements directly on the weatherDataSubject. That will be a design
            * decision. For now we are using this for simplicity.
            -----*/


            // Assert
            // NOTE: There is no assert for this test since we are running real code. 
            // However you can check the standard output in the Unit Test when running the unit tests
            // to verify that we did in fact print out 3 messages, one for each display that was created above.
        }
    }
}
