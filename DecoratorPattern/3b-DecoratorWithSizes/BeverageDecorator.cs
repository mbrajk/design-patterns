namespace DecoratorPattern._3b_DecoratorWithSizes;

public abstract record BeverageDecorator(Beverage Beverage) : Beverage(Beverage)
{
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
    protected override decimal Cost =>
        Size switch
        {
            BeverageSize.Small => 0.50m,
            BeverageSize.Medium => 0.75m,
            BeverageSize.Large => 1.00m,
            BeverageSize.OhLawdHeDrinkin => 5.20m,
            _ => 0.75m
        };

    protected override string IngredientDescription => "Whipped Cream";
}

public record Mocha(Beverage Beverage) : BeverageDecorator(Beverage)
{
    protected override string IngredientDescription => "Mocha";

    protected override decimal Cost =>
        Size switch
        {
            BeverageSize.Small => 0.50m,
            BeverageSize.Medium => 0.75m,
            BeverageSize.Large => 1.25m,
            BeverageSize.OhLawdHeDrinkin => 5.20m,
            _ => 0.75m
        };
}
