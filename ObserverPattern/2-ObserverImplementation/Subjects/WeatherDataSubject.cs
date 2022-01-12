using ObserverPattern._2_ObserverImplementation.Observers;

namespace ObserverPattern._2_ObserverImplementation.Subjects;

public class WeatherDataSubject : IWeatherDataSubject
{
    private readonly List<IObserver> _displays = new ();
    
    public void RegisterDisplay(IObserver observer)
    {
        _displays.Add(observer);
    }

    public void RemoveDisplay(IObserver observer)
    {
        _displays.Remove(observer);
    }

    public void NotifyDisplays()
    {
        var (temperature, humidity, pressure) 
            = (GetTemperature(), GetHumidity(), GetPressure());

        foreach (var display in _displays)
        {
            display.Update(temperature, pressure, humidity);
        }
    }
    
    // Realistically these would obtain real data
    private int GetPressure()
    {
        return new Random().Next(0, 2);
    }

    private int GetHumidity()
    {
        return new Random().Next(0, 100);
    }

    private int GetTemperature()
    {
        return new Random().Next(0, 100);
    }
}