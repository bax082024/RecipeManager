using RecipeManager.Models;
using RecipeManager.Data;
using System.Collections.Generic;
using System;

class Program
{
  public static void Main(string[] args)
  {

    RecipeRepository repository = new RecipeRepository();

    List<Recipe> recipes = new List<Recipe>
    {
      new Recipe
      {
        Title = "Pancakes",
        Ingredients = new List<string> {"Flour", "Milk", "Eggs", "Sugar"},
        Instructions = "mix and cook"

      }
    };
      
    repository.SaveRecipes(recipes);
    Console.WriteLine("Recipe saved.");

    var LoadRecipes = repository.LoadRecipes();
    Console.WriteLine("Loaded Recipes:");
    foreach (var recipe in loadedRecipes)
    {
      Console.WriteLine($"Title: {recipe.Title}");
    }

    Console.WriteLine($"Recipe: {testRecipe.Title}");
  }
}