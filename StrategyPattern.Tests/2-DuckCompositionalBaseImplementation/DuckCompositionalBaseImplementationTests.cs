using StrategyPattern._2_DuckCompositionalBaseImplementation.Ducks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Tests._2_DuckCompositionalBaseImplementation
{
    [TestClass]
    public class DuckCompositionalBaseImplementationTests
    {
        // We can no longer test RubberDuck.Fly() as it is not a method in our
        // composition style
        [TestMethod]
        public void RubberDuck_CallFly_ReturnsNoAction()
        {
            // Arrange
            //var duck = new RubberDuck();

            // Act
            //var result = duck.Fly();

            // Assert
            //result
            //   .Should()
            //   .Be("No Action");
        }

        // We have the same problem with DuckCall.Fly() and DuckCall.Swim()
        [TestMethod]
        public void DuckCall_CallFly_ReturnsNoAction()
        {
            // Arrange
            //var duck = new DuckCall();

            //// Act
            //var result = duck.Fly();

            //// Assert
            //result
            //   .Should()
            //   .Be("No Action");
        }

        [TestMethod]
        public void DuckCall_CallSwim_ReturnsNoAction()
        {
            // Arrange
            //var duck = new DuckCall();

            //// Act
            //var result = duck.Swim();

            //// Assert
            //result
            //   .Should()
            //   .Be("No Action");
        }

        // Methods that exist still work and are testable, obviously
        [TestMethod]
        public void DuckCall_CallQuack_ReturnsQuack()
        {
            // Arrange
            var duck = new DuckCall();

            // Act
            var result = duck.Quack();

            // Assert
            result
               .Should()
               .Be("Quacking");
        }
    }
}
