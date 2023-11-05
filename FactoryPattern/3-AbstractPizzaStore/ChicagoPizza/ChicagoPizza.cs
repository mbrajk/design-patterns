namespace FactoryPattern._3_AbstractPizzaStore.ChicagoPizza;

/*
 * We have the ability to modify things such as baking time now that each
 * regional pizza must implement from Pizza. We could provide a default implementation
 * but regardless in order for a pizza to be created we require all of the pizza creation
 * steps be implemented. This is in comparison to the previous version of our factory that
 * did not require the steps to be implemented if another factory were to be created.
 */
public abstract record ChicagoPizzaBase : Pizza {
    internal override void Bake()
    {
        Console.WriteLine("Baking for 45 mins...");
    }
    
    internal override void Prepare()
    {
        Console.WriteLine("Prepping.");
    }
    
    internal override void Cut()
    {
        Console.WriteLine("Cutting into dinner sized pieces");
    }
    
    internal override void Box()
    {
        Console.WriteLine("Boxing");
    }
}

public record ChicagoCheesePizza : ChicagoPizzaBase
{
    public override AbstractPizzaType PizzaType => AbstractPizzaType.Cheese;
}

public record ChicagoVeggiePizza : ChicagoPizzaBase
{
    public override AbstractPizzaType PizzaType => AbstractPizzaType.Veggie;
}

public record ChicagoPepperoniPizza : ChicagoPizzaBase
{
    public override AbstractPizzaType PizzaType => AbstractPizzaType.Pepperoni;
}