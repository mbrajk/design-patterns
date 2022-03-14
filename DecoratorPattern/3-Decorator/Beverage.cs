namespace DecoratorPattern._3_Decorator;

public abstract record Beverage
{
    protected abstract decimal Cost { get; }
    protected abstract string IngredientDescription { get; }

    public virtual decimal GetCost()
    {
        return Cost;
    }

    public virtual string GetDescription()
    {
        return IngredientDescription;
    }
}

public record DarkRoast : Beverage
{
    protected override string IngredientDescription => "Dark Roast";

    protected override decimal Cost => 2.50m;
}