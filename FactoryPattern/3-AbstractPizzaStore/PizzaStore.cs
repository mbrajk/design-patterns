namespace FactoryPattern._3_AbstractPizzaStore;

public abstract class PizzaStore
{
    /*
     * We ensure consistency in pizza ordering by creating a base class where the pizza
     * prep steps all live. However as different pizzas may require different actions in
     * each step, we allow the steps themselves to be customizable by the pizza
     * implementation. For example a deep dish chicago pizza takes 45 minutes to cook
     * where as a thin crust pizza may take 10 or less.
     */
    public Pizza OrderPizza(AbstractPizzaType pizzaType)
    {
        var pizza = CreatePizza(pizzaType);

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }

    protected abstract Pizza CreatePizza(AbstractPizzaType pizzaType);
}