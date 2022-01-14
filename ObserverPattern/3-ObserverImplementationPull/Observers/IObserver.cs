namespace ObserverPattern._3_ObserverImplementationPull.Observers;

/*
 * We separate out the IDisplay interface and the IObserver interface to componentize 
 * our application. This allows us flexibility in our design, e.g. we can create an
 * observer that has no display, perhaps it calls an API on update etc.
 */
public interface IObserver
{
    /* On update we no longer recieve parameters. However we still know that an update occured.
     * This allows us to retrieve the data we need and update our display manually. We are no
     * longer required to recieve an ever increasing amount of data and if the WeatherDataSubject
     * adds addtional functionality, our displays are not required to update until they want or need to.
     */
    public void Update();
}