using System.Collections.ObjectModel;

namespace DecoratorPattern._3b_DecoratorWithSizes;

public enum BeverageSize
{
    Small,
    Medium,
    Large,
    OhLawdHeComin
}

public abstract record Beverage(BeverageSize Size)
{
    protected readonly BeverageSize Size = Size;

    protected abstract decimal Cost { get; }
    protected abstract string IngredientDescription { get; }

    public virtual decimal GetCost()
    {
        return Cost;
    }

    public virtual ICollection<string> GetDescription()
    {
        var ingredients = new Collection<string> { IngredientDescription };

        return ingredients;
    }
}

public record DarkRoast(BeverageSize Size = BeverageSize.Medium) : Beverage(Size)
{
    protected override string IngredientDescription => "Dark Roast";

    protected override decimal Cost =>
        Size switch
        {
            BeverageSize.Small => 2.00m,
            BeverageSize.Medium => 2.25m,
            BeverageSize.Large => 2.50m,
            BeverageSize.OhLawdHeComin => 35.20m,
            _ => 2.25m
        };
}
