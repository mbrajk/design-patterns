using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Fly;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Sound;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

namespace BehaviorPattern._3_DuckBehaviorImplementation;

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
