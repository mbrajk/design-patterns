using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ObserverPattern._2_ObserverImplementation.Observers;
using ObserverPattern._2_ObserverImplementation.Subjects;

namespace ObserverPattern.Tests._2_ObserverImplementation.Subjects;

[TestClass]
public class WeatherDataSubjectTests
{
    private WeatherDataSubject _sut;

    public WeatherDataSubjectTests()
    {
        _sut = new WeatherDataSubject();
    }

    [TestMethod]
    public void NotifyDisplays_CallsUpdateOnEveryDisplay()
    {
        // Arrange
        var display = Substitute.For<IObserver>();
        
        _sut.RegisterDisplay(display);
        
        // Act
        _sut.NotifyDisplays();
        
        // Assert
        display
            .Received(1)
            .Update(Arg.Any<float>(), Arg.Any<float>(), Arg.Any<float>());
    }
}