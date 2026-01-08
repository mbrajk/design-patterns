# The Evolution of the Decorator Pattern: A Journey Through Refactoring

## Introduction

The Decorator Pattern is a structural design pattern that allows behavior to be added to individual objects, either statically or dynamically, without affecting the behavior of other objects from the same class. This blog post walks through the evolution of a beverage ordering system, showing how different approaches to handling beverage customizations lead us to the elegant Decorator Pattern.

## Version 1: The Derived Classes Explosion

### The Problem

In the initial implementation (`1-DerivedClasses`), every possible combination of a beverage and its ingredients required a separate class. This approach quickly leads to a class explosion problem.

### Implementation

```csharp
public abstract record Beverage
{
    public abstract string Description { get; }
    public virtual decimal Cost()
    {
        return 3.00m; // base value
    }
}

public record DarkRoast : Beverage
{
    public override string Description => "A lovely, strong dark roast";
    public override decimal Cost() => base.Cost();
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
```

### Issues

1. **Exponential Class Growth**: Every combination of beverage and ingredients requires a new class
2. **Maintenance Nightmare**: If milk price changes, we need to update every milk-related class
3. **Inflexibility**: Adding new ingredients means creating classes for all possible combinations
4. **Code Duplication**: Ingredient costs are duplicated across multiple classes

## Version 2: Instance Variables Approach

### The Improvement

The second iteration (`2-InstanceVariables`) introduces a single abstract beverage class where ingredient flags are tracked as instance variables. This significantly reduces the number of classes needed.

> **Note**: Pricing differs between versions as each iteration represents a different implementation approach with recalibrated pricing logic.

### Implementation

```csharp
public abstract record Beverage(bool hasMilk, bool hasSoy, bool hasMocha, bool hasSugar)
{
    public abstract string GetDescription { get; }
    
    public virtual decimal GetCost()
    {
        var cost = 0.00m;
        if (hasMilk) cost += 0.15m;
        if (hasMocha) cost += 0.65m;
        if (hasSugar) cost += 0.10m;
        if (hasSoy) cost += 1.15m;
        return cost;
    }
}

record DarkRoastBeverage(bool hasMilk, bool hasSoy, bool hasMocha, bool hasSugar)
    : Beverage(hasMilk, hasSoy, hasMocha, hasSugar)
{
    public override string GetDescription => "A lovely, strong dark roast";
    
    public override decimal GetCost()
    {
        var costOfThisBeverage = 4.00m;
        return base.GetCost() + costOfThisBeverage;
    }
}
```

### Advantages

1. **Centralized Price Management**: Ingredient prices are defined in one place
2. **Reduced Classes**: Only need one class per beverage type, not per combination
3. **Easier Maintenance**: Price changes only require updating the base class

### Remaining Issues

1. **Not Extensible**: Cannot handle multiple quantities (e.g., double milk)
2. **Constructor Complexity**: Every beverage needs to handle all possible ingredients
3. **Open/Closed Principle Violation**: Adding new ingredients requires modifying all existing classes
4. **Irrelevant Parameters**: Beverages may have ingredient parameters they don't use

## Version 3: The Decorator Pattern

### The Game Changer

Version 3 (`3-Decorator`) introduces the actual Decorator Pattern. This approach uses composition instead of inheritance to add responsibilities dynamically.

### Implementation

**Base Beverage:**
```csharp
public abstract record Beverage
{
    protected abstract decimal Cost { get; }
    protected abstract string IngredientDescription { get; }
    
    public virtual decimal GetCost() => Cost;
    
    public virtual ICollection<string> GetDescription()
    {
        var ingredients = new Collection<string> { IngredientDescription };
        return ingredients;
    }
}

public record DarkRoast : Beverage
{
    protected override string IngredientDescription => "Dark Roast";
    protected override decimal Cost => 2.50m;
}
```

**Decorator:**
```csharp
public abstract record BeverageDecorator(Beverage Beverage) : Beverage
{
    public override ICollection<string> GetDescription()
    {
        var ingredients = Beverage.GetDescription();
        ingredients.Add(IngredientDescription);
        return ingredients;
    }
    
    public override decimal GetCost()
    {
        return Cost + Beverage.GetCost();
    }
}

public record Whip(Beverage Beverage) : BeverageDecorator(Beverage)
{
    protected override decimal Cost => 1.25m;
    protected override string IngredientDescription => "Whipped Cream";
}

public record Mocha(Beverage Beverage) : BeverageDecorator(Beverage)
{
    protected override string IngredientDescription => "Mocha";
    protected override decimal Cost => 1.00m;
}
```

### Usage

```csharp
// Create a Dark Roast with Mocha and double Whip
var baseBeverage = new DarkRoast();           // $2.50
var mocha = new Mocha(baseBeverage);          // $2.50 + $1.00 = $3.50
var whip = new Whip(mocha);                   // $3.50 + $1.25 = $4.75
var doubleWhip = new Whip(whip);              // $4.75 + $1.25 = $6.00
```

### Advantages

1. **Open/Closed Principle**: Open for extension, closed for modification
2. **Dynamic Composition**: Add/remove decorators at runtime
3. **Single Responsibility**: Each class has one reason to change
4. **Unlimited Combinations**: Can stack decorators as needed (e.g., double or triple ingredients)
5. **No Class Explosion**: Adding new ingredients only requires one new decorator class

### Considerations

- **Removal Complexity**: Removing a decorator from the middle of the chain is complex
- **Order Dependency**: Decorators wrap objects in a specific order

## Version 3b: Adding Size Support

### The Enhancement

Version 3b (`3b-DecoratorWithSizes`) extends the decorator pattern to support different beverage sizes, demonstrating how the pattern can be enhanced without breaking its structure.

### Implementation

```csharp
public enum BeverageSize
{
    Small,
    Medium,
    Large,
    OhLawdHeDrinkin
}

public abstract record Beverage(BeverageSize Size)
{
    protected readonly BeverageSize Size = Size;
    protected abstract decimal Cost { get; }
    protected abstract string IngredientDescription { get; }
    
    public virtual decimal GetCost() => Cost;
    
    public virtual ICollection<string> GetDescription()
    {
        var ingredients = new Collection<string> { IngredientDescription };
        return ingredients;
    }
}

public record DarkRoast(BeverageSize Size = BeverageSize.Medium) : Beverage(Size)
{
    protected override string IngredientDescription => "Dark Roast";
    
    protected override decimal Cost =>
        Size switch
        {
            BeverageSize.Small => 2.00m,
            BeverageSize.Medium => 2.25m,
            BeverageSize.Large => 2.50m,
            BeverageSize.OhLawdHeDrinkin => 35.20m,
            _ => 2.25m
        };
}
```

**Size-Aware Decorators:**
```csharp
public record Whip(Beverage Beverage) : BeverageDecorator(Beverage)
{
    protected override decimal Cost =>
        Size switch
        {
            BeverageSize.Small => 0.50m,
            BeverageSize.Medium => 0.75m,
            BeverageSize.Large => 1.00m,
            BeverageSize.OhLawdHeDrinkin => 5.20m,
            _ => 0.75m
        };
    
    protected override string IngredientDescription => "Whipped Cream";
}
```

### Key Improvement

- **Context-Aware Decorators**: Decorators can access the size property from the wrapped beverage
- **Scalable Pricing**: Both base beverages and add-ons can have size-based pricing
- **Pattern Integrity**: The decorator pattern structure remains intact while adding new functionality

## Version 4: Copilot Refactor

### AI-Assisted Design

Version 4 (`4-CopilotRefactor`) represents an interesting experiment where GitHub Copilot was asked to improve the original Version 1 code. Copilot independently arrived at a decorator pattern solution using interfaces instead of abstract classes.

### Implementation

```csharp
public interface IBeverage
{
    string Description { get; }
    decimal Cost();
}

public class DarkRoast : IBeverage
{
    public string Description => "A lovely, strong dark roast";
    public decimal Cost() => 3.00m;
}

public abstract class CondimentDecorator : IBeverage
{
    protected readonly IBeverage _beverage;
    
    public CondimentDecorator(IBeverage beverage)
    {
        _beverage = beverage;
    }
    
    public abstract decimal Cost();
    public abstract string Description { get; }
}

public class MilkDecorator : CondimentDecorator
{
    public MilkDecorator(IBeverage beverage) : base(beverage) { }
    
    public override decimal Cost() => _beverage.Cost() + 0.65m;
    public override string Description => $"{_beverage.Description}, with milk";
}

public class SugarDecorator : CondimentDecorator
{
    public SugarDecorator(IBeverage beverage) : base(beverage) { }
    
    public override decimal Cost() => _beverage.Cost() + 0.15m;
    public override string Description => $"{_beverage.Description}, with sugar";
}
```

### Key Differences from Version 3

1. **Interface vs Abstract Class**: Uses `IBeverage` interface instead of abstract `Beverage` class
2. **Traditional Classes**: Uses traditional classes instead of C# records
3. **String Concatenation**: Builds description through string concatenation rather than collections
4. **Field-Based**: Uses protected fields instead of constructor parameters in records

### Insight

This version demonstrates that the Decorator Pattern is a well-established solution to this problem domain—so much so that AI tools naturally converge to it when analyzing the problem space.

## Key Takeaways

### Evolution Summary

1. **Derived Classes** → Too many classes, maintenance nightmare
2. **Instance Variables** → Better, but inflexible and violates Open/Closed
3. **Decorator Pattern** → Flexible, maintainable, follows SOLID principles
4. **Size Enhancement** → Shows pattern extensibility
5. **Interface Approach** → Alternative implementation style

### When to Use the Decorator Pattern

✅ **Use when:**
- You need to add responsibilities to objects dynamically
- Extension by subclassing is impractical
- You want to add functionality without affecting other objects
- You need combinations of behaviors

❌ **Avoid when:**
- You need to frequently remove decorators from the middle of a chain
- The order of decoration doesn't matter (consider other patterns)
- Simple inheritance would suffice

### Design Principles Demonstrated

1. **Open/Closed Principle**: Open for extension, closed for modification
2. **Single Responsibility**: Each class has one job
3. **Dependency Inversion**: Depend on abstractions, not concretions
4. **Composition over Inheritance**: Build functionality through composition

## Conclusion

The journey from Version 1 to the final implementation illustrates how design patterns emerge from real problems. The Decorator Pattern provides an elegant solution to the challenge of adding behavior dynamically while maintaining clean, maintainable code. Each version taught us something valuable:

- Version 1 showed us what to avoid
- Version 2 showed us that centralization helps but isn't enough
- Version 3 introduced the pattern that solves our problems
- Version 3b showed the pattern's extensibility
- Version 4 confirmed the pattern's status as a standard solution

The Decorator Pattern remains a powerful tool in a developer's arsenal for creating flexible, maintainable object-oriented systems.
