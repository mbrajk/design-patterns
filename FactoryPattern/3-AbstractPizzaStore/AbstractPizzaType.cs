namespace FactoryPattern._3_AbstractPizzaStore;

/*
 * We still have a problem using this enum where pizza types would have to exist
 * across all pizza stores, but that may make sense for a franchised pizza place.
 * Additionally we do not allow for customizable pizza, but that is a concern
 * that we have solved or could solve with other design patterns e.g. decorator.
 * A pizza is not a perfect analogy for the factory pattern here so we can ignore
 * that problem for now.
 */
public enum AbstractPizzaType
{
    Cheese,
    Pepperoni,
    Veggie
}