using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ObserverPattern._2_ObserverImplementation.Observers;
using ObserverPattern._2_ObserverImplementation.Subjects;

namespace ObserverPattern.Tests._2_ObserverImplementation.Observer
{
    class Sut : DisplayBase
    {
        public Sut(IWeatherDataSubject weatherDataSubject) : base(weatherDataSubject)
        {
        }

        public override string Display()
        {
            throw new System.NotImplementedException();
        }

        public override void Update(int temperature, int pressure, int humidity)
        {
            throw new System.NotImplementedException();
        }
    }

    [TestClass]
    public class BaseDisplayTests
    {
        private readonly IWeatherDataSubject _weatherDataSubject;
        private Sut _sut;

        public BaseDisplayTests()
        {
            _weatherDataSubject = Substitute.For<IWeatherDataSubject>();
            _sut = new Sut(_weatherDataSubject);
        }

        [TestMethod]
        public void Constructor_RegistersDisplay()
        {
            // Arrange and Act happened in the constructor            

            // Assert
            _weatherDataSubject
                .Received(1)
                .RegisterDisplay(_sut);
        }
    }
}
