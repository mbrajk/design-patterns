namespace StrategyPattern._3_DuckBehaviorImplementation.Behaviors.Sound;

public class QuackBehavior : ISoundBehavior
{
    public string MakeSound()
    {
        return "Quacking";
    }
}