namespace DecoratorPattern._1_DerivedClasses
{
    /*
     * The following examples are showing the complexity that would be required
     * if we only created an abstract beverage class that every type of beverage
     * inherited from to calculate its cost. There are surely some changes we can
     * make here to let the abstractions be somewhat cleaner but the point of this
     * example it to highlight the complexity and exponential growth of derived
     * classes if we go this route. We will see how decorators help us here later.
     */
    public abstract record Beverage
    {
        public abstract string Description { get; }

        public virtual decimal Cost()
        {
            return 3.00m; // base value.
            //Another option would be to make this abstract and let every class decide its own total price
        }
    }

    public record DarkRoast : Beverage
    {
        public override string Description => "A lovely, strong dark roast";

        // ReSharper disable once RedundantOverriddenMember
        public override decimal Cost()
        {
            // redundant code as the dark roast is the same price but here for clarity
            return base.Cost();
        }
    }

    public record DarkRoastWithMilk : Beverage
    {
        public override string Description => "A lovely, strong dark roast.. with milk";

        public override decimal Cost()
        {
            var milkCost = 0.65m;
            return base.Cost() + milkCost;
        }
    }

    public record DarkRoastWithSugar : Beverage
    {
        public override string Description => "A lovely, strong dark roast.. with sugar";

        public override decimal Cost()
        {
            var sugarCost = 0.15m;
            return base.Cost() + sugarCost;
        }
    }

    public record DarkRoastWithSugarAndMilk : Beverage
    {
        public override string Description => "A lovely, strong dark roast.. with sugar and milk";

        public override decimal Cost()
        {
            var milkCost = 0.65m;
            var sugarCost = 0.15m;
            return base.Cost() + milkCost + sugarCost;
        }
    }

    /*
     * I stopped here for brevity but imagine a light roast, a decaf coffee, etc were added.
     * We would need a different record for every milk sugar combination. Furthermore, we would
     * need to add one class for every type of beverage if an extra ingredient was added (e.g.
     * soy milk).
     *
     * Secondly if the milk price changes in this example we would need to modify the milk cost
     * in every milk related class. We are safe in the base case but not in any other case.
     */
}
