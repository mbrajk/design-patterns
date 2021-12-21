using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Fly;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Sound;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

namespace BehaviorPattern._3_DuckBehaviorImplementation;

public class DuckCall : BehaviorDuckBase
{
    public DuckCall()
        : base(
            new QuackBehavior(), 
            new NoSwimBehavior(), 
            new NoFlyBehavior())
    {
    }

    public override string DescribeAppearance()
    {
        return "Duck Call";
    }
}
