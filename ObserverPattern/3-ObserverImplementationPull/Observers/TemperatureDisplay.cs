using ObserverPattern._3_ObserverImplementationPull.Subjects;

namespace ObserverPattern._3_ObserverImplementationPull.Observers;

/*
 * Displays now implement a base class, this moves some of the logic like registration and
 * un-registration to a common location so we don't forget it when adding new displays.
 * 
 * This leaves us to only require implementing the code specific to each individual display
 * e.g. Display and Update
 * 
 * Further details can be found in the DisplayBase class
 */
public class TemperatureDisplay : DisplayBase
{
    private (int temperature, int humidity, int pressure) _data = (0, 0, 0);
    private readonly IWeatherDataSubject _weatherDataSubject;

    /*
     * We could create a temperature display before but we would always recieve
     * the pressure and humidity, regardless of the fact that we would never utilize
     * that data.
     */
    public TemperatureDisplay(IWeatherDataSubject weatherDataSubject) 
        : base(weatherDataSubject)
    {
        _weatherDataSubject = weatherDataSubject;
    }

    /* On update we no longer recieve parameters. However we still know that an update occured.
     * This allows us to retrieve the data we need and update our display manually. We are no
     * longer required to recieve an ever increasing amount of data and if the WeatherDataSubject
     * adds addtional functionality, our displays are not required to update until they want or need to.
     */
    public override void Update()
    {
        _data.temperature = _weatherDataSubject.GetTemperature();

        //we can update the display whenever Update is called by calling Display() here
        //there are other and better ways to update the display but we are using this for a 
        //simple example
        Display();
    }

    public override string Display()
    {
        var output = $"Current Temp: {_data.temperature}, Pressure: {_data.pressure}, Humidity: {_data.humidity}";

        //This would update a display instead of simply writing to console but we use this example for simplicity
        Console.WriteLine(output);

        //we return the string in this method simply for unit testing purposes
        return output;
    }
}