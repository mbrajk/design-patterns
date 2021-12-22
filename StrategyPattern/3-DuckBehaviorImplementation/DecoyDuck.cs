using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Fly;
using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Sound;
using StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

namespace StrategyPattern._3_DuckBehaviorImplementation;

/*
 * All ducks provide a behavior for all required behaviors that a duck posseses.
 * We simply provide a behavior that does nothing if that behavior is unnecessary.
 * This allows us to have DRY code that doesn't violate the Liskov Substitution Principle.
 * A DecoyDuck and a MallardDuck appear exactly the same at runtime and can be acted
 * upon as though they were the exact same.
 * 
 * There is still an issue in that we should set up these behaviors via Dependency Injection
 * or elsewhere, and we should allow changing behaviors, but those features are another topic
 */
public class DecoyDuck : BehaviorDuckBase
{
    public DecoyDuck()
        : base(
            new SilentBehavior(), 
            new NoSwimBehavior(), 
            new NoFlyBehavior())
    {}

    public override string DescribeAppearance()
    {
        return "Decoy Duck";
    }
}