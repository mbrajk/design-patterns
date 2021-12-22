namespace StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Fly;

public class NoFlyBehavior : IFlyBehavior
{
    public string Fly()
    {
        return "No Action";
    }
}