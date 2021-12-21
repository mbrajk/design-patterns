namespace BehaviorPattern._2_DuckCompositionalBaseImplementation;

public interface IFlyable
{
    public string Fly();
}

public abstract class Quackable
{
    public string Quack()
    {
        return "Quacking";
    }
}

