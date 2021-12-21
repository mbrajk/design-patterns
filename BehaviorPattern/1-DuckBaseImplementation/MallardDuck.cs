namespace BehaviorPattern._1_DuckBaseImplementation;

// this implementation works fine since a Mallard duck is essentially just like any other duck
public class MallardDuck : DuckBase
{
    public override string DescribeAppearance()
    {
        return "Mallard";
    }
}