﻿using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Fly;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Sound;
using BehaviorPattern._3_DuckBehaviorImplementation.Behaviors.Swim;

namespace BehaviorPattern._3_DuckBehaviorImplementation;

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
    
    public abstract void DescribeAppearance();

    public void Fly()
    {
        _flyBehavior.Fly();
    }

    public void Swim()
    {
        _swimBehavior.Swim();
    }

    public void Quack()
    {
        _soundBehavior.MakeSound();
    }
}

// we should set up these behaviors via Dependency Injection but that's another topic
public class MallardDuck : BehaviorDuckBase
{
    public MallardDuck()
        : base(
            new QuackBehavior(), 
            new SwimBehavior(), 
            new FlyBehavior())
    {
    }

    public override void DescribeAppearance()
    {
        Console.WriteLine("Mallard Duck");
    }
}

public class DuckCall : BehaviorDuckBase
{
    // we should set up these behaviors via Dependency Injection but that's another topic
    public DuckCall()
        : base(
            new QuackBehavior(), 
            new NoSwimBehavior(), 
            new NoFlyBehavior())
    {
    }

    public override void DescribeAppearance()
    {
        Console.WriteLine("Duck Call");
    }
}

public class RubberDuck : BehaviorDuckBase
{
    public RubberDuck()
        : base(
            new SqueakBehavior(), 
            new FloatBehavior(), 
            new NoFlyBehavior())
    {
    }

    public override void DescribeAppearance()
    {
        Console.WriteLine("Rubber Duck");
    }
}

public class DecoyDuck : BehaviorDuckBase
{
    public DecoyDuck()
        : base(
            new SilentBehavior(), 
            new NoSwimBehavior(), 
            new NoFlyBehavior())
    {
    }

    public override void DescribeAppearance()
    {
        Console.WriteLine("Decoy Duck");
    }
}