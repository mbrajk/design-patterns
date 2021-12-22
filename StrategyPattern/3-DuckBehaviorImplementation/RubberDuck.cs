using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Fly;
using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Sound;
using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

namespace StrategyPattern._3_DuckBehaviorImplementation;

public class RubberDuck : BehaviorDuckBase
{
    public RubberDuck()
        : base(
            new SqueakBehavior(), 
            new FloatBehavior(), 
            new NoFlyBehavior())
    {
    }

    public override string DescribeAppearance()
    {
        return "Rubber Duck";
    }
}
