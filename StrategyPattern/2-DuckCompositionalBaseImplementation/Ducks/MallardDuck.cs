using StrategyPattern._2_DuckCompositionalBaseImplementation.Interfaces;

namespace StrategyPattern._2_DuckCompositionalBaseImplementation.Ducks;

/* This Mallard duck implements all of the features of a duck. However we still
 * have WET, repeated code since Quacking was already implemented in the Duck Call before.
 * Secondly a alternate kind of duck that implementes all of the features of a duck would 
 * need to re-implement all of the features of a duck. There are some other workarounds 
 * for this but we still have other problems with this solution.
 */
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