using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Fly;
using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Sound;
using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

namespace StrategyPattern._3_DuckBehaviorImplementation;

// we should set up these behaviors via Dependency Injection but that's another topic
public class MallardDuck : BehaviorDuckBase
{
    public MallardDuck()
        : base(
            new QuackBehavior(), 
            new SwimBehavior(), 
            new FlyBehavior())
    {
    }

    public override string DescribeAppearance()
    {
        return "Mallard Duck";
    }
}
