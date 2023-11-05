namespace FactoryPattern._1_SwitchStatements;

/**
 * For this version of creating a pizza we have to interrogate the type
 * passed in and return a pizza of the given type. This requires us to use
 * a switch statement to determine the type of pizza to instantiate.
 * The main issue with this approach is violation of the open closed
 * principle. If we add a pizza type we need to edit the enum and the
 * switch statement. Additionally custom pizzas would need their own
 * switch statement, meaning a custom pizza would require a code change. >:(
 */
public class PizzaOrderSystem
{
    public SwitchPizza OrderPizza(SwitchPizzaType pizzaType)
    {
        // This switch expression would need to be modified to add pizza types
        SwitchPizza pizza = pizzaType switch
        {
            SwitchPizzaType.Pepperoni => new PepperoniSwitchPizza(),
            SwitchPizzaType.Greek => new GreekSwitchPizza(),
            SwitchPizzaType.Veggie => new VeggieSwitchPizza(),
            SwitchPizzaType.Cheese => new CheeseSwitchPizza(),
            _ => throw new Exception("We don't know how to customize pizza")
        };

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }
}

public record SwitchPizza
{
    /*
     * if different pizzas require different baking times we need another switch or
     * we would need to make bake a virtual w/ default or abstract method.
     */
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

public enum SwitchPizzaType
{
    Cheese,
    Greek,
    Pepperoni,
    Veggie
}

record CheeseSwitchPizza : SwitchPizza { }

record GreekSwitchPizza : SwitchPizza { }

record PepperoniSwitchPizza : SwitchPizza { }

record VeggieSwitchPizza : SwitchPizza { }
