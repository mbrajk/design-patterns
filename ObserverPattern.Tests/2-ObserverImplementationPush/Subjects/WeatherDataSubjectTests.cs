using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ObserverPattern._2_ObserverImplementationPush.Observers;
using ObserverPattern._2_ObserverImplementationPush.Subjects;

namespace ObserverPattern.Tests._2_ObserverImplementationPush.Subjects;

[TestClass]
public class WeatherDataSubjectTests
{
    private WeatherDataSubject _sut;

    public WeatherDataSubjectTests()
    {
        _sut = new WeatherDataSubject();
    }

    [TestMethod]
    public void NotifyDisplays_CallsUpdateOnEveryRegisteredDisplay()
    {
        // Arrange
        var display1 = Substitute.For<IObserver>();
        var display2 = Substitute.For<IObserver>();

        _sut.RegisterDisplay(display1);
        _sut.RegisterDisplay(display2);

        // Act
        _sut.NotifyDisplays();

        // Assert
        display1
            .Received(1)
            .Update(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>());

        display2
            .Received(1)
            .Update(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>());
    }

    [TestMethod]
    public void NotifyDisplays_DoesNotCallUpdateOnUnregisteredDisplay()
    {
        // Arrange
        var display1 = Substitute.For<IObserver>();

        _sut.RegisterDisplay(display1);
        _sut.RemoveDisplay(display1);

        // Act
        _sut.NotifyDisplays();

        // Assert
        display1
            .Received(0)
            .Update(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>());
    }
}