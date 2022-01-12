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
public class ForecastDisplay : DisplayBase
{
    private (int temperature, int humidity, int pressure) _data = (0, 0, 0);
    private readonly IWeatherDataSubject _weatherDataSubject;

    public ForecastDisplay(IWeatherDataSubject weatherDataSubject)
        : base(weatherDataSubject)
    {
        _weatherDataSubject = weatherDataSubject;
    }

    //TODO there is an update and now we need to get the data.. 
    public override void Update()
    {
        _data.pressure = _weatherDataSubject.GetPressure();
        _data.humidity = _weatherDataSubject.GetHumidity();
        _data.temperature = _weatherDataSubject.GetTemperature();

        //we can update the display whenever Update is called by calling Display() here
        //there are other and better ways to update the display but we are using this for a 
        //simple example
        Display();
    }

    public override string Display()
    {
        var output = $"Upcoming Temp: {_data.temperature}, Pressure: {_data.pressure}, Humidity: {_data.humidity}";
        
        //This would update a display instead of simply writing to console but we use this example for simplicity
        Console.WriteLine(output);
        
        //we return the string in this method simply for unit testing purposes
        return output;
    }
}