using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Cally.App.ViewModels;

public class MainPageViewModel : ObservableObject
{
    public ObservableCollection<FoodEntryViewModel> Entries { get; private set; }

    public MainPageViewModel()
    {
        var entries = new ObservableCollection<FoodEntry>
        {
            new FoodEntry
            {
                AmountOfUnits = 25,
                Food = new Food { Name = "kaas", Unit = new Unit { Calories = 111, Amount = 30}}
            },
            new FoodEntry
            {
                AmountOfUnits = 1,
                Food = new Food { Name = "croissant", Unit = new Unit { Calories = 161, Amount = 1}}
            },
            new FoodEntry
            {
                AmountOfUnits = 10,
                Food = new Food { Name = "granola", Unit = new Unit { Calories = 216, Amount = 45}}
            },
            new FoodEntry
            {
                AmountOfUnits = 35,
                Food = new Food { Name = "volkoren snee", Unit = new Unit { Calories = 234, Amount = 100}}
            },
            new FoodEntry
            {
                AmountOfUnits = 1.5,
                Food = new Food { Name = "yoghurt", Unit = new Unit { Calories = 84, Amount = 1}}
            },
            new FoodEntry
            {
                AmountOfUnits = 25,
                Food = new Food { Name = "kaas", Unit = new Unit { Calories = 111, Amount = 30}}
            },
        };

        Entries = new ObservableCollection<FoodEntryViewModel>(entries.Select(e => new FoodEntryViewModel(e)));
    }
}
