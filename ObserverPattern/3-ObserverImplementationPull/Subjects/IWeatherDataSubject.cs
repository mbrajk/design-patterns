using ObserverPattern._3_ObserverImplementationPull.Observers;

namespace ObserverPattern._3_ObserverImplementationPull.Subjects;

public interface IWeatherDataSubject
{
    public void RegisterDisplay(IObserver observer);
    public void RemoveDisplay(IObserver observer);
    public void NotifyDisplays();
    public int GetPressure();
    public int GetHumidity();
    public int GetTemperature();
}