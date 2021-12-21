namespace BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

public class NoSwimBehavior : ISwimBehavior
{
    public string Swim()
    {
        return "No Action";
    }
}