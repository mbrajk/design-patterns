namespace FactoryPattern._3_AbstractPizzaStore.NewYorkPizza;

public abstract record NewYorkPizzaBase : Pizza
{
    internal override void Prepare()
    {
        Console.WriteLine("Prep");
    }

    internal override void Bake()
    {
        Console.WriteLine("Bake");
    }

    internal override void Cut()
    {
        Console.WriteLine("Cut");
    }

    internal override void Box()
    {
        Console.WriteLine("Box");
    }
}
public record NewYorkCheesePizza : NewYorkPizzaBase
{
    public override AbstractPizzaType PizzaType => AbstractPizzaType.Cheese;
}
public record NewYorkVeggiePizza : NewYorkPizzaBase
{
    public override AbstractPizzaType PizzaType => AbstractPizzaType.Veggie;
}
public record NewYorkPepperoniPizza : NewYorkPizzaBase
{
    public override AbstractPizzaType PizzaType => AbstractPizzaType.Pepperoni;
}