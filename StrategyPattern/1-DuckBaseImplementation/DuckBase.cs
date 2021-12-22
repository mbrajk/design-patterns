namespace StrategyPattern._1_DuckBaseImplementation;

/* if we were to implement additional features in the DuckBase we would need to modify every
* class that doesn't need the functionality or where the functionality works differently.
* Consider a LayEgg method would be inappropriate for DuckCall and RubberDuck. Additionally  
* we have to duplicate functionality in many classes/methods. This is not a huge problem in
* this code base, but imagine if we had a significant number of derived classes.
* 
* We are also unable to change an individual duck's behavior at runtime with this solution.
*/
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