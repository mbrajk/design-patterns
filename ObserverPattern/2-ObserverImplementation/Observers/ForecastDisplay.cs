namespace ObserverPattern._2_ObserverImplementation.Observers;

public class ForecastDisplay : IObserver, IDisplay
{
    private (float temperature, float humidity, float pressure) _data = (0, 0, 0);

    public void Update(float temperature, float pressure, float humidity)
    {
        _data.pressure = pressure;
        _data.humidity = humidity;
        _data.temperature = temperature;
    }

    public string Display()
    {
        return $"Temp: {_data.temperature}, Pressure: {_data.pressure}, Humidity: {_data.humidity}";
    }
}