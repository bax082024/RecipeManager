using RecipeManager.Models;
using RecipeManager.Data;
using System.Collections.Generic;
using System;

class Program
{
  public static void Main(string[] args)
  {

    RecipeRepository repository = new RecipeRepository();

    Recipe testRecipe = new Recipe
    {
      Title = "Pancakes",
      Ingredients = new List<string> {"Flour", "Milk", "Eggs", "Sugar"},
      Instructions = "mix and cook"
    };

    Console.WriteLine($"Recipe: {testRecipe.Title}");
  }
}