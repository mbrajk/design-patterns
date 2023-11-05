namespace FactoryPattern._3_AbstractPizzaStore;

public abstract record Pizza
{
    public abstract AbstractPizzaType PizzaType { get; }
    internal abstract void Prepare();
    internal abstract void Bake();
    internal abstract void Cut();
    internal abstract void Box();
}