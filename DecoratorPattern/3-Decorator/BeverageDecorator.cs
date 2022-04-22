namespace DecoratorPattern._3_Decorator;

public abstract record BeverageDecorator(Beverage Beverage) : Beverage
{
    protected readonly Beverage Beverage = Beverage;

    public override ICollection<string> GetDescription()
    {
        var ingredients = Beverage.GetDescription();
        ingredients.Add(IngredientDescription);
        return ingredients;
    }

    public override decimal GetCost()
    {
        return Cost + Beverage.GetCost();
    }
}

public record Whip(Beverage Beverage) : BeverageDecorator(Beverage)
{
    protected override decimal Cost => 1.25m;

    protected override string IngredientDescription => "Whipped Cream";
}

public record Mocha(Beverage Beverage) : BeverageDecorator(Beverage)
{
    protected override string IngredientDescription => "Mocha";

    protected override decimal Cost => 1.00m;
}
