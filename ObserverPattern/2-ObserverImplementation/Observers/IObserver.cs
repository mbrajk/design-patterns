namespace ObserverPattern._2_ObserverImplementation.Observers;

public interface IObserver
{
    public void Update(int temperature, int pressure, int humidity);
}