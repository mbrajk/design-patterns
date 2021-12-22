using StrategyPattern._2_DuckCompositionalBaseImplementation.Interfaces;

namespace StrategyPattern._2_DuckCompositionalBaseImplementation.Ducks;

/*
 * Here we can see where our naming of interfaces breaks down somewhat as a 
 * rubber duck squeaks instead of quacking and floats instead of swimming.
 * The benefit of interfaces is we are free to re-implement the interface as
 * we see fit. Score one for composition via interfaces.
 */
public class RubberDuck : CompositionalDuckBase, IQuackable, ISwimmable
{
    public override string DescribeAppearance()
    {
        return "Rubber Duck";
    }

    // IQuackable is not really an appropriate name here because rubber ducks squeak
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