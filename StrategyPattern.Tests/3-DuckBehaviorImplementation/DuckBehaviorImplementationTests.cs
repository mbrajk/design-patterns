using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using StrategyPattern._3_DuckBehaviorImplementation;
using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Fly;

namespace StrategyPattern.Tests._3_DuckBehaviorImplementation
{
    [TestClass]
    public class DuckBehaviorImplementationTests
    {
        // Here we can show off the ability to dynamically change duck behavior at runtime
        [TestMethod]
        public void MallardDuck_ChangeToNoFlyBehavior_ReturnsNoAction()
        {
            // Arrange
            var mallardDuck = new MallardDuck();

            // Act
            var result = mallardDuck.Fly();

            // Assert
            result
                .Should()
                .Be("Flying");

            // Clip the ducks wings (Re-Arrange)
            mallardDuck.SetFlyBehavior(new NoFlyBehavior());
            
            // Act
            result = mallardDuck.Fly();

            // Assert
            result
                .Should()
                .Be("No Action");
        }

        // Additionally we are able to test RubberDuck.Fly() again as all behaviors exist on duck
        [TestMethod]
        public void RubberDuck_CallFly_ReturnsNoAction()
        {
            // Arrange
            var duck = new RubberDuck();

            // Act
            var result = duck.Fly();

            // Assert
            result
               .Should()
               .Be("No Action");
        }
    }
}
