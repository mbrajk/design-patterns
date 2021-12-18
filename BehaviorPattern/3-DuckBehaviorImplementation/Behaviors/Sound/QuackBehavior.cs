namespace BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Sound;

public class QuackBehavior : ISoundBehavior
{
    public void MakeSound()
    {
        Console.WriteLine("Quacking");
    }
}