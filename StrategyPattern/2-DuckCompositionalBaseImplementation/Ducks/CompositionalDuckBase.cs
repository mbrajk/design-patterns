namespace StrategyPattern._2_DuckCompositionalBaseImplementation.Ducks;

/* interfaces are impractical here as every class needs to implement very
 * similar functionality and if functionality changes it would need to be
 * updated in every class. Consider adding a new interface for "Nesting" INestable.
 * Every appropriate duck needs to be updated to reference this interface, but even
 * more frustratingly we have to implement the nesting implementation in every derived
 * duck (where nesting is appropriate). There is no built in functionality to share
 * the nesting behavior across multiple duck implementations.
 * 
 * furthermore, our ducks are not interchangeable with one another at runtime
 * if we swap out a MallardDuck for a DuckCall we can no longer call Swim() on the "duck"
 * as it does not exist as a feature of a DuckCall and would violate the Liskov Substitution Principle
 * 
 * We are also unable to change an individual duck's behavior at runtime with this solution.
 */
public abstract class CompositionalDuckBase
{
    public abstract string DescribeAppearance();
}