namespace BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Sound;

public class SqueakBehavior : ISoundBehavior
{
    public void MakeSound()
    {
        Console.WriteLine("Squeak");
    }
}