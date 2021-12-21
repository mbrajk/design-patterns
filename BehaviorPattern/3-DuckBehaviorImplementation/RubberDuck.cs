using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Fly;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Sound;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

namespace BehaviorPattern._3_DuckBehaviorImplementation;

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
