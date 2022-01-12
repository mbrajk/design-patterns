using ObserverPattern._2_ObserverImplementation.Observers;

namespace ObserverPattern._2_ObserverImplementation.Subjects;

public interface IWeatherDataSubject
{
    public void RegisterDisplay(IObserver observer);
    public void RemoveDisplay(IObserver observer);
    public void NotifyDisplays();
}