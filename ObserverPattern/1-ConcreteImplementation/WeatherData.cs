namespace ObserverPattern._1_ConcreteImplementation;

/*
 * With this implementation we are EXPLICITLY specifying each type of display that
 * the weather data class can operate on. This implementation is inflexible as we cannot
 * add displays at runtime, additionally adding or removing displays requires us to
 * modify this WeatherData class which violates the Open/Closed SOLID design principle
 *
 * The displays all implement the Update method so the constructor could be changed
 * to take 3 IDisplay's, allowing us to mock and properly unit test this class. However
 * that is only addressing one issue with this implementation and further confuses the
 * caller since they would have to figure out which displays exist by parameter names
 * instead of the types.
 */
public class WeatherData
{
    private readonly CurrentConditionsDisplay _currentConditionsDisplay;
    private readonly ForecastDisplay _forecastDisplay;
    private readonly StatisticsDisplay _statisticsDisplay;

    public WeatherData(
        CurrentConditionsDisplay currentConditionsDisplay, 
        ForecastDisplay forecastDisplay, 
        StatisticsDisplay statisticsDisplay)
    {
        _currentConditionsDisplay = currentConditionsDisplay;
        _forecastDisplay = forecastDisplay;
        _statisticsDisplay = statisticsDisplay;
    }

    public void MeasurementsChanged()
    {
        var temperature = GetTemperature();
        var humidity = GetHumidity();
        var pressure = GetPressure();
        
        // At least the displays all implement a common interface
        _currentConditionsDisplay.Update(temperature, humidity, pressure);
        _forecastDisplay.Update(temperature, humidity, pressure);
        _statisticsDisplay.Update(temperature, humidity, pressure);
    }

    private int GetPressure()
    {
        return 1;
    }

    private int GetHumidity()
    {
        return 50;
    }

    private float GetTemperature()
    {
        return 22f;
    }
}