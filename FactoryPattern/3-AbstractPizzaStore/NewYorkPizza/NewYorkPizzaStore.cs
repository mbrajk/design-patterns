using FactoryPattern._3_AbstractPizzaStore.NewYorkPizza;

namespace FactoryPattern._3_AbstractPizzaStore.NewYorkPizza;

public class NewYorkPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(AbstractPizzaType pizzaType)
    {
        return pizzaType switch
        {
            AbstractPizzaType.Pepperoni => new NewYorkPepperoniPizza(),
            AbstractPizzaType.Veggie => new NewYorkVeggiePizza(),
            AbstractPizzaType.Cheese => new NewYorkCheesePizza(),
            _ => throw new Exception("No pizza for you!")
        };
    }
}