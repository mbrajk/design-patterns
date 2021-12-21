namespace BehaviorPattern._1_DuckBaseImplementation;

public abstract class DuckBase
{
    public virtual string Fly()
    {
        return "Flying";
    }

    public virtual string Swim()
    {
        return "Swimming";
    }

    public virtual string Quack()
    {
        return "Quacking";
    }

    public abstract string DescribeAppearance();
}

// this implementation works fine since a Mallard duck is essentially just like any other duck
public class MallardDuck : DuckBase
{
    public override string DescribeAppearance()
    {
        return "Mallard";
    }
}

// this implementation breaks down as a rubber duck squeaks, cannot fly, and floats
public class RubberDuck : DuckBase
{
    public override string Fly()
    {
        return "No Action";
    }

    public override string Quack()
    {
        return "Squeak";
    }

    public override string DescribeAppearance()
    {
        return "Rubber Duck";
    }
    
    public override string Swim()
    {
        return "Floating";
    }
}

// this implementation breaks down as a DuckCall can only Quack
public class DuckCall : DuckBase
{
    public override string Fly()
    {
        return "No Action";
    }
    
    public override string Swim()
    {
        return "No Action";
    }

    public override string DescribeAppearance()
    {
        return "Duck Call";
    }
}

// if we were to implement additional features in the DuckBase we would need to modify every
// class that doesn't need the functionality. Consider a LayEgg method would be inappropriate
// for DuckCall and RubberDuck