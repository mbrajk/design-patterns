using FactoryPattern._3_AbstractPizzaStore.ChicagoPizza;

namespace FactoryPattern._3_AbstractPizzaStore;

/*
 * Each pizza store is what will ultimately be instantiated to manage pizza creation
 * We can consider these pizza store as our factory in this version.
 */
public class ChicagoPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(AbstractPizzaType pizzaType)
    {
        return pizzaType switch
        {
            AbstractPizzaType.Pepperoni => new ChicagoPepperoniPizza(),
            AbstractPizzaType.Veggie => new ChicagoVeggiePizza(),
            AbstractPizzaType.Cheese => new ChicagoCheesePizza(),
            _ => throw new Exception("No deep dish pizza for you!")
        };
    }
}