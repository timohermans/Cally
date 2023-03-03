using CommunityToolkit.Mvvm.ComponentModel;

namespace Cally.App.ViewModels;

public class FoodEntryViewModel : ObservableObject
{
    private readonly FoodEntry entry;

    public string? Name { 
        get => entry.Food.Name; 
        set => SetProperty(entry.Food.Name, value, entry, (e, n) => e.Food.Name = n); 
    }

    public double AmountOfUnits { 
        get => entry.AmountOfUnits; 
        set => SetProperty(entry.AmountOfUnits, value, entry, (e, n) => e.AmountOfUnits = n); 
    }

    public double UnitAmount { 
        get => entry.Food.Unit.Amount; 
        set => SetProperty(entry.Food.Unit.Amount, value, entry, (e, n) => e.Food.Unit.Amount = n); 
    }

    public double UnitCalories { 
        get => entry.Food.Unit.Calories; 
        set => SetProperty(entry.Food.Unit.Calories, value, entry, (e, n) => e.Food.Unit.Calories = n); 
    }

    public double Calories => AmountOfUnits * (UnitCalories / UnitAmount);

    public FoodEntryViewModel(FoodEntry entry)
    {
        this.entry = entry;
    }
}
