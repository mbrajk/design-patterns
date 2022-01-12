namespace ObserverPattern._2_ObserverImplementation.Observers;

public class CurrentConditionsDisplay : IObserver, IDisplay
{
    private (int temperature, int humidity, int pressure) _data = (0, 0, 0);

    public void Update(int temperature, int pressure, int humidity)
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