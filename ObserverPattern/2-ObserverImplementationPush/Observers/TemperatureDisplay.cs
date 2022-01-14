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
public class TemperatureDisplay : DisplayBase
{
    private int _temperature = 0;

    public TemperatureDisplay(IWeatherDataSubject weatherDataSubject)
        : base(weatherDataSubject)
    {
    }

    /*
     * Unfortunately we always recieve the pressure and humidity even though our display only
     * cares about temperature. This problem would only get worse as the features of 
     * WeatherDataSubject grow.
     */
    public override void Update(int temperature, int pressure, int humidity)
    {
        _temperature = temperature;

        //we can update the display whenever Update is called by calling Display() here
        //there are other and better ways to update the display but we are using this for a 
        //simple example
        Display();
    }

    public override string Display()
    {
        var output = $"Temperature: {_temperature}";

        //This would update a display instead of simply writing to console but we use this example for simplicity
        Console.WriteLine(output);

        //we return the string in this method simply for unit testing purposes
        return output;
    }
}