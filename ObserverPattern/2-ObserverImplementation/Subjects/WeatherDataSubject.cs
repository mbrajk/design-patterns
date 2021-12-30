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
    
    private float GetPressure()
    {
        return 1;
    }

    private float GetHumidity()
    {
        return 50;
    }

    private float GetTemperature()
    {
        return 22f;
    }
}