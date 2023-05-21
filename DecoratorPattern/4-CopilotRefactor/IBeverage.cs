// this entire class was created by Copilot Chat by simply prompting it to improve DecoratorPattern._1_DerivedClasses/BeverageDerived.cs
namespace DecoratorPattern._4_CopilotRefactor;  

public interface IBeverage
{
    string Description { get; }
    decimal Cost();
}

public class DarkRoast : IBeverage
{
    public string Description => "A lovely, strong dark roast";

    public decimal Cost()
    {
        return 3.00m;
    }
}

public abstract class CondimentDecorator : IBeverage
{
    protected readonly IBeverage _beverage;

    public CondimentDecorator(IBeverage beverage)
    {
        _beverage = beverage;
    }

    public abstract decimal Cost();

    public abstract string Description {get;}
}

public class MilkDecorator : CondimentDecorator
{
    public MilkDecorator(IBeverage beverage)
        : base(beverage)
    {
    }

    public override decimal Cost()
    {
        return _beverage.Cost() + 0.65m;
    }

    public override string Description => $"{_beverage.Description}, with milk";
}

public class SugarDecorator : CondimentDecorator
{
    public SugarDecorator(IBeverage beverage)
        : base(beverage)
    {
    }

    public override decimal Cost()
    {
        return _beverage.Cost() + 0.15m;
    }

    public override string Description => $"{_beverage.Description}, with sugar";
}
