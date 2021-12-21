namespace BehaviorPattern._2_DuckCompositionalBaseImplementation;

public abstract class CompositionalDuckBase
{
    public abstract string DescribeAppearance();
}

public class MallardDuck : CompositionalDuckBase, IFlyable, IQuackable, ISwimmable
{
    public override string DescribeAppearance()
    {
        return "Mallard Duck";
    }

    public string Fly()
    {
        return "Flying";
    }

    public string Quack()
    {
        return "Quacking";
    }

    public string Swim()
    {
        return "Swimming";
    }
}

public class RubberDuck : CompositionalDuckBase, IQuackable, ISwimmable
{
    public override string DescribeAppearance()
    {
        return "Rubber Duck";
    }

    // actually IQuackable is not really appropriate here because rubber ducks squeak
    public string Quack()
    {
        return "Squeak";
    }

    // additionally ISwimmable is probably going to work slightly differently since a rubber duck can only float
    public string Swim()
    {
        return "Floating";
    }
}

public class DuckCall : CompositionalDuckBase, IQuackable
{
    public override string DescribeAppearance()
    {
        return "Duck Call";
    }

    public string Quack()
    {
        return "Quacking";
    }
}

// interfaces are impractical here as every class needs to implement very
// similar functionality and if functionality changes it would need to be
// updated in every class

// furthermore, our ducks are not interchangeable with one another at runtime
// if we swap out a MallardDuck for a DuckCall we can no longer call Swim() on the "duck"
// as it does not exist as a feature of a DuckCall and would violate Liskov Substitution Principle