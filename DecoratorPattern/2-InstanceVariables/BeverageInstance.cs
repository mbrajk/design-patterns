namespace DecoratorPattern._2_InstanceVariables;

/*
 * We now look at an alternative solution where there is a single abstract beverage class
 * that the different beverage types can inherit from. It is in this main Beverage class
 * where we will keep track of ingredients in the drinks. This lets us break beverages
 * into more manageable top-level only classes (e.g. DarkRoast, LightRoast). Then the
 * base class handles the rest.
 */
public abstract record BeverageInstance(
    bool hasMilk,
    bool hasSoy,
    bool hasMocha,
    bool hasSugar)
{
    public abstract string GetDescription { get; }

    public decimal GetCost()
    {
        var cost = 0.00m;
        if (hasMilk)
        {
            cost += 0.15m;
        }

        if (hasMocha)
        {
            cost += 0.65m;
        }
        
        if (hasSugar)
        {
            cost += 0.10m;
        }
        
        if (hasSoy)
        {
            cost += 1.15m;
        }

        return cost;
    }
}