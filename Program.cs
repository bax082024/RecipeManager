using RecipeManager.Models;
using System;

class Program
{
  public static void Main(string[] args)
  {
    Recipe testRecipe = new Recipe
    {
      Title = "Pancakes",
      Ingredients = new List<string> {"Flour", "Milk", "Eggs", "Sugar"},
      Instructions = "mix and cook"
    };

    Console.WriteLine($"Recipe: {testRecipe.Title}");
  }
}