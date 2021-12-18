namespace BehaviorPattern._1_DuckBaseImplementation;

public abstract class DuckBase
{
    public virtual void Fly()
    {
        Console.WriteLine("Flying");
    }

    public virtual void Swim()
    {
        Console.WriteLine("Swimming");
    }

    public virtual void Quack()
    {
        Console.WriteLine("Quacking");
    }

    public abstract void DescribeAppearance();
}

// this implementation works fine since a Mallard duck is essentially just like any other duck
public class MallardDuck : DuckBase
{
    public override void DescribeAppearance()
    {
        Console.WriteLine("Mallard");
    }
}

// this implementation breaks down as a rubber duck squeaks and cannot fly
public class RubberDuck : DuckBase
{
    public override void Fly()
    {
        return;
    }

    public override void Quack()
    {
        Console.WriteLine("Squeak");
    }

    public override void DescribeAppearance()
    {
        Console.WriteLine("Rubber Duck");
    }
}

// this implementation breaks down as a DuckCall can only Quack
public class DuckCall : DuckBase
{
    public override void Fly()
    {
        return;
    }
    
    public override void Swim()
    {
        return;
    }
    
    
    public override void DescribeAppearance()
    {
        Console.WriteLine("Duck Call");
    }
}

// if we were to implement additional features in the DuckBase we would need to modify every
// class that doesn't need the functionality. Consider a LayEgg method would be inappropriate
// for DuckCall and RubberDuck