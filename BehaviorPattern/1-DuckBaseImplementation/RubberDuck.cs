namespace BehaviorPattern._1_DuckBaseImplementation;

/* this implementation breaks down as a rubber duck squeaks, cannot fly, and floats. 
 * We need to override the  functionality for any method where the functionality is 
 * different or unnecessary and we have to duplicate functionality in many classes/methods
 */
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