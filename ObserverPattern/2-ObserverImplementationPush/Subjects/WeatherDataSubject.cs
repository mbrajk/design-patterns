using ObserverPattern._2_ObserverImplementation.Observers;

namespace ObserverPattern._2_ObserverImplementation.Subjects;

// Our new implementation adds a lot of flexibility over the previous design.
// We can add displays at runtime which you can see happening in the WeatherStattionTests
// in the Tests project. We have removed one violation of the Open/Closed principle, though 
// some inefficiencies still exist which you will find in the comments and in
// example 3-ObserverImplementationPull.
// Speaking of which, our classes are now testable unlike in the 1-ConcreteImplementation example.
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

    // We rely on random data to update the displays and we obtain the data and update the displays in the same method
    // This logic should probably be separated out and we should create a different method that sets the weather data.
    // This way we could set the weather data from an outside source and we would let that method call NotifyDisplays() when
    // it recieved new weather data
    public void NotifyDisplays()
    {
        var (temperature, humidity, pressure) 
            = (GetTemperature(), GetHumidity(), GetPressure());


        // In the current state, updating the data that weather data subject passes would
        // require an update to every display. This would violate the Open/Closed principle but also
        // would just be really annoying. In addition to this, displays depend on the weather data subject
        // to push data to them, there is an alternate implementation where observers pull data
        // from the weather data subject instead. This gives displays more control over the data they retrieve
        // and when they retrieve it. You can find this example in 3-ObserverImplementationPull
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