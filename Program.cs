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

    var loadedRecipes = repository.LoadRecipes();
    Console.WriteLine("Loaded Recipes:");
    foreach (var recipe in loadedRecipes)
    {
      Console.WriteLine($"Title: {recipe.Title}");
    }

    static void ViewRecipes(RecipeRepository repository)
    {
      var recipes = repository.LoadRecipes();
      Console.WriteLine();

      if (recipes.Count == 0)
      {
        Console.WriteLine("No Recipes Found!");
        return;
      }

      foreach (var recipe in recipes)
      {
        Console.WriteLine($"- {recipe.Title}");
      }
    }

    static void AddRecipe(RecipeRepository repository)
    {
      Console.WriteLine("Enter recipe title:");
      string title = Console.ReadLine();
    }

  }
}