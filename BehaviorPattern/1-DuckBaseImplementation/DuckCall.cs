namespace BehaviorPattern._1_DuckBaseImplementation;

/* this implementation breaks down as a DuckCall can only Quack. We need to override the 
 * functionality for any method where the functionality is different or unnecessary and 
 * we have to duplicate functionality in many classes/methods
 */
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