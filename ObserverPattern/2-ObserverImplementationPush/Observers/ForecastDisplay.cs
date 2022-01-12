using ObserverPattern._2_ObserverImplementationPush.Subjects;

namespace ObserverPattern._2_ObserverImplementationPush.Observers;

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

    public ForecastDisplay(IWeatherDataSubject weatherDataSubject)
        : base(weatherDataSubject)
    {
    }

    public override void Update(int temperature, int pressure, int humidity)
    {
        _data.pressure = pressure;
        _data.humidity = humidity;
        _data.temperature = temperature;

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