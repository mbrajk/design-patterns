using ObserverPattern._3_ObserverImplementationPull.Observers;

namespace ObserverPattern._3_ObserverImplementationPull.Subjects;

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