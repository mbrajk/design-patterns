namespace FactoryPattern._2_SimpleFactory;

/**
 * We can simplify the switch expression by moving it to a factory.
 * This simply moves the problem to another location but it means that we
 * would no longer have to modify this class if we add a new pizza type.
 * We would have to edit the pizza factory but further refactors will
 * help us to rectify that issue as well.
 *
 * We have only moved the problem from the previous example. We have not
 * yet solved in a more elegant way.
 */
public class PizzaOrderSystem
{
    public PizzaFactoryPizza OrderPizza(PizzaFactoryPizzaType pizzaType)
    {
        var pizza = PizzaFactory.CreatePizza(pizzaType);

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }
}

public record PizzaFactoryPizza
{
    internal void Bake()
    {
        Console.WriteLine("baking...");
    }

    internal void Cut()
    {
        Console.WriteLine("Cutting pizza in to 9 slices");
    }

    internal void Prepare()
    {
        Console.WriteLine("Pizza is being preppred");
    }

    internal void Box()
    {
        Console.WriteLine("Put into a fancy box with our name on it");
    }
}

public enum PizzaFactoryPizzaType
{
    Cheese,
    Greek,
    Pepperoni,
    Veggie
}

public static class PizzaFactory
{
    public static PizzaFactoryPizza CreatePizza(PizzaFactoryPizzaType pizzaType)
    {
        // our open closed principle violation from the previous example
        // is now encapsulated in this one factory
        return pizzaType switch
        {
            PizzaFactoryPizzaType.Pepperoni => new PepperoniPizza(),
            PizzaFactoryPizzaType.Greek => new GreekPizza(),
            PizzaFactoryPizzaType.Veggie => new VeggiePizza(),
            PizzaFactoryPizzaType.Cheese => new CheesePizza(),
            _ => throw new Exception("We don't know how to customize pizza")
        };
    }
}

public record CheesePizza : PizzaFactoryPizza { }

public record GreekPizza : PizzaFactoryPizza { }

public record PepperoniPizza : PizzaFactoryPizza { }

public record VeggiePizza : PizzaFactoryPizza { }
