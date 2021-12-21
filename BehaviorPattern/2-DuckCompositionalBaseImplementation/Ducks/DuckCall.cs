using BehaviorPattern._2_DuckCompositionalBaseImplementation.Interfaces;

namespace BehaviorPattern._2_DuckCompositionalBaseImplementation.Ducks;

/* This is a duck call which can only quack, the nice feature of composing via interfaces
 * is that we only implement the interfaces we need. The downside is a violation of Liskov 
 * Substitution Principle as well as WET, repeated code.
 */
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