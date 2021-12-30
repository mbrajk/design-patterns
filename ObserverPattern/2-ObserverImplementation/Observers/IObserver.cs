namespace ObserverPattern._2_ObserverImplementation.Observers;

public interface IObserver
{
    public void Update(float temperature, float pressure, float humidity);
}