using ObserverPattern._3_ObserverImplementationPull.Subjects;

namespace ObserverPattern._3_ObserverImplementationPull.Observers
{
    /*
     * We change the displays to be added to the IWeatherDataSubject individually. 
     * IWeatherDataSubject maintains a list of each display and updates every display
     * by calling the Update method that now lives inside of each display.
     * 
     * To further facilitate this we let the displays register themselves to the
     * IWeatherDataSubject on creation in their own constructors. This allows us to
     * easily register and de-register from the Subject without some other monitoring
     * system.
     */
    public abstract class DisplayBase : IDisplay, IObserver
    {
        private IWeatherDataSubject _weatherDataSubject;

        public DisplayBase(IWeatherDataSubject weatherDataSubject)
        {
            _weatherDataSubject = weatherDataSubject;
            _weatherDataSubject.RegisterDisplay(this);
        }

        public abstract string Display();

        public abstract void Update();

        // Since we are responsible for registering ourselves with the Subject, we can also
        // manage un-registration
        ~DisplayBase()
        {
            _weatherDataSubject.RemoveDisplay(this);
        }
    }
}