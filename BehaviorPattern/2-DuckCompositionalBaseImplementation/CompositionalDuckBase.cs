namespace BehaviorPattern._2_DuckCompositionalBaseImplementation;

public abstract class CompositionalDuckBase
{
    public abstract void DescribeAppearance();
}

public class MallardDuck : CompositionalDuckBase, IFlyable, IQuackable, ISwimmable
{
    public override void DescribeAppearance()
    {
        Console.WriteLine("Mallard Duck");
    }

    public void Fly()
    {
        Console.WriteLine("Flying");
    }

    public void Quack()
    {
        Console.WriteLine("Quacking");
    }

    public void Swim()
    {
        Console.WriteLine("Swimming");
    }
}

public class RubberDuck : CompositionalDuckBase, IQuackable, ISwimmable
{
    public override void DescribeAppearance()
    {
        Console.WriteLine("Rubber Duck");
    }

    // actually IQuackable is not really appropriate here because rubber ducks squeak
    public void Quack()
    {
        Console.WriteLine("Squeak");
    }

    // additionally ISwimmable is probably going to work slightly differently since a rubber duck can only float
    public void Swim()
    {
        Console.WriteLine("Floating");
    }
}

public class DuckCall : CompositionalDuckBase, IQuackable
{
    public override void DescribeAppearance()
    {
        Console.WriteLine("Duck Call");
    }

    public void Quack()
    {
        Console.WriteLine("Quacking");
    }
}

// interfaces are impractical here as every class needs to implement very
// similar functionality and if functionality changes it would need to be
// updated in every class

// furthermore, our ducks are not interchangeable with one another at runtime
// if we swap out a MallardDuck for a DuckCall we can no longer call Swim() on the "duck"
// as it does not exist as a feature of a DuckCall and would violate Liskov Substitution Principle