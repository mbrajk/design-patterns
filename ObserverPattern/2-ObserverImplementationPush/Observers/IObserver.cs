namespace ObserverPattern._2_ObserverImplementationPush.Observers;

/*
 * We separate out the IDisplay interface and the IObserver interface to componentize 
 * our application. This allows us flexibility in our design, e.g. we can create an
 * observer that has no display, perhaps it calls an API on update etc.
 */
public interface IObserver
{
    // This type of data passing is actually not-ideal for future growth of the application
    // We use this for simplicity but you may consider some form of data contract in the future
    // where a payload is passed around or key value pairs, etc. This can be an exercise for anyone
    // learning from this code base.

    // Furthermore, in the current state, updating the data that weather data subject passes would
    // require an update to every display. This would violate the Open/Closed principle but also
    // would just be really annoying. In addition to this, displays depend on the weather data subject
    // to push data to them, there is an alternate implementation where observers pull data
    // from the weather data subject instead. This gives displays more control over the data they retrieve
    // and when they retrieve it. You can find this example in 3-ObserverImplementationPull
    public void Update(int temperature, int pressure, int humidity);
}