using ObserverPattern._2_ObserverImplementationPush.Observers;

namespace ObserverPattern._2_ObserverImplementationPush.Subjects;

public interface IWeatherDataSubject
{
    public void RegisterDisplay(IObserver observer);
    public void RemoveDisplay(IObserver observer);
    public void NotifyDisplays();
}