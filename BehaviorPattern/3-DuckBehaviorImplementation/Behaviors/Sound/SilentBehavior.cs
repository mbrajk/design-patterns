namespace BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Sound;

public class SilentBehavior : ISoundBehavior
{
    public string MakeSound()
    {
        return "No Action";
    }
}