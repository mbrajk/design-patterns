using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Fly;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Sound;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

namespace BehaviorPattern._3_DuckBehaviorImplementation;

/*
 * Finally we look at using behaviors to solve the issues in the previous two examples.
 * In this way we have ducks who can be swapped at runtime so they no longer violate
 * LSP. Secondly we can encapsulate common code into a single behavior class, making
 * our code DRY. If we add a new interface in the future we only need to create distinct
 * classes for the types of functionality required, e.g. if we add a ISleepBehavior we would
 * add a couple of behavior classes that implement this interface like NoSleepBehavior and
 * SleepBehavior. Consolidate all of the code in these two classes and assign them to 
 * the ducks as needed. We wouldn't have to re-implement the logic for every single duck.
 * 
 * Furthermore, If we slightly modify the code to add methods that allow us to update 
 * behaviors, we are able to change a duck's behavior at runtime. This was not possible
 * in our previous solutions.
 */
public abstract class BehaviorDuckBase
{
    private ISoundBehavior _soundBehavior;
    private ISwimBehavior _swimBehavior;
    private IFlyBehavior _flyBehavior;

    public BehaviorDuckBase(
        ISoundBehavior soundBehavior, 
        ISwimBehavior swimBehavior, 
        IFlyBehavior flyBehavior)
    {
        _soundBehavior = soundBehavior;
        _swimBehavior = swimBehavior;
        _flyBehavior = flyBehavior;
    }
    
    public abstract string DescribeAppearance();

    public string Fly()
    {
        return _flyBehavior.Fly();
    }

    public string Swim()
    {
        return _swimBehavior.Swim();
    }

    public string Quack()
    {
        return _soundBehavior.MakeSound();
    }

    public void SetFlyBehavior(IFlyBehavior flyBehavior)
    {
        _flyBehavior = flyBehavior;
    }

    public void SetSoundBehavior(ISoundBehavior soundBehavior)
    {
        _soundBehavior = soundBehavior;
    }

    public void SetSwimBehavior(ISwimBehavior swimBehavior)
    {
        _swimBehavior = swimBehavior;
    }
}