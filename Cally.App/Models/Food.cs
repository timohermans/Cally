using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cally.App;

public class Unit
{
    public string Name { get; set; } = "Grams"; // TODO: prolly not gonna use
    public required double Amount { get; set; } = 100;
    public required double Calories { get; set; }
}

public class Food
{
    public string? Name { get; set; }
    public required Unit Unit { get; set; }
}

public class FoodEntry
{
    public required Food Food { get; set; }
    public required double AmountOfUnits { get; set; }
}
