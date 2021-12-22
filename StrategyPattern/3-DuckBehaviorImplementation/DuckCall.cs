using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Fly;
using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Sound;
using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

namespace StrategyPattern._3_DuckBehaviorImplementation;

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
