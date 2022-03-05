namespace DecoratorPattern._2_InstanceVariables;

/*
 * We now look at an alternative solution where there is a single abstract beverage class
 * that the different beverage types can inherit from. It is in this main Beverage class
 * where we will keep track of ingredients in the drinks. This lets us break beverages
 * into more manageable top-level only classes (e.g. DarkRoast, LightRoast). Then the
 * base class handles the rest.
 */
public abstract record Beverage(
    bool hasMilk,
    bool hasSoy,
    bool hasMocha,
    bool hasSugar)
{
    public abstract string GetDescription { get; }

    /* The nice feature that this solution gives us is that we only need to modify the base class
     * if we want to change prices of ingredients.
     *
     * The downside is adding an ingredient requires a change to every single inherited class to handle
     * the new ingredient(s)
     */
    public virtual decimal GetCost()
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

/*
 * There are, of course, other ways that we can manage the ingredients instead of just using
 * a constructor but it doesn't change the design too much if we do.
 * The amount of ingredients may grow to become unwieldy eventually either way.
 */
record DarkRoastBeverage(
    bool hasMilk,
    bool hasSoy,
    bool hasMocha,
    bool hasSugar)
    : Beverage(hasMilk, hasSoy, hasMocha, hasSugar)
{
    public override string GetDescription => "A lovely, strong dark roast";

    public override decimal GetCost()
    {
        var costOfThisBeverage = 4.00m;
        return base.GetCost() + costOfThisBeverage;
    }
}

record LightRoastBeverage(
        bool hasMilk,
        bool hasSoy,
        bool hasMocha,
        bool hasSugar)
    : Beverage(hasMilk, hasSoy, hasMocha, hasSugar)
{
    public override string GetDescription => "A lovely, not strong light roast";
    
    public override decimal GetCost()
    {
        var costOfThisBeverage = 4.00m;
        return base.GetCost() + costOfThisBeverage;
    }
}

/*
 * As you can see this has definitely improved upon the previous derived class solution.
 * There are still some problems with this solution. For example ingredients are not extensible.
 * If I want double milk there is no way to handle that. There is also still the previous issue of
 * every class needing to change if the available ingredients change. Additionally if we add
 * another beverage that doesn't use these specific ingredients we will have a lot of unrelated
 * ingredients to ignore. Granted we can use another base beverage class for that but that is
 * bringing us into a similar issue like we had in the 1-DerivedClasses example. 
 */