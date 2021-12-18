namespace BehaviorPattern._2_DuckCompositionalBaseImplementation;

public interface IFlyable
{
    public void Fly();
}

public abstract class Quackable
{
    public void Quack()
    {
        Console.WriteLine("Quacking");
    }
}

