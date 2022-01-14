using ObserverPattern._3_ObserverImplementationPull.Observers;

namespace ObserverPattern._3_ObserverImplementationPull.Subjects;

// Our final implementation moves the responsibility for data to the displays.
// Our WeatherDataSubject doesn't sent data to the displays when there is new data, 
// instead the displays are informed that there is new data and they must fetch that
// data from us.
//
// This allows us flexibility in design of the WeatherDataSubject. If we add addtional data
// that the WeatherDataSubject can obtain, we will not need to update the displays immediately. 
// Instead, they are respoinsible for updating if and when they require the new data.
//
// We still maintain all the benefits of our implementation in 2-ObserverImplementationPull
// 
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

    // we are not sending parameters to the displays anymore. We simply inform them that there is new data
    // the display becomes responsible for reaching back out to us for the updated data that they require.
    public void NotifyDisplays()
    {
        foreach (var display in _displays)
        {
            display.Update();
        }
    }
    
    // Realistically these would obtain real data
    public int GetPressure()
    {
        return new Random().Next(0, 2);
    }

    public int GetHumidity()
    {
        return new Random().Next(0, 100);
    }

    public int GetTemperature()
    {
        return new Random().Next(0, 100);
    }
}