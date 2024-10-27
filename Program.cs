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

    while (true)
    {
      Console.WriteLine("\nRecipe Manager");
      Console.WriteLine("1. View Recipes");
      Console.WriteLine("2. Add Recipe");
      Console.WriteLine("3. Exit");
      Console.WriteLine("Choose an option: ");

      string? choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          ViewRecipes(repository);
          break;
        case "2":
          AddRecipe(repository);
          break;
        case "3":
          Console.WriteLine("Goodbye.");
          return;
        default:
          Console.WriteLine("Invalid choice, try again.");
          break;

      }
    }
  }
    
    

  static void ViewRecipes(RecipeRepository repository)
  {
    var recipes = repository.LoadRecipes();
    Console.WriteLine("All Recipes");

    if (recipes.Count == 0)
    {
      Console.WriteLine("No Recipes Found!");
      return;
    }

    foreach (var recipe in recipes)
    {
      Console.WriteLine($"- {recipe.Title}");
    }

    Console.WriteLine("\nEnter name of recipe to view details, or press Enter to return to menu:");
    string? selectedTitle = Console.ReadLine();

    var selectedRecipe = recipes.Find(r => r.Title != null && r.Title.Equals(selectedTitle, StringComparison.OrdinalIgnoreCase));

    if (selectedRecipe != null)
    {
      Console.WriteLine($"\nTitle: {selectedRecipe.Title}");
      Console.WriteLine("Ingredients");
      foreach (var ingredient in selectedRecipe.Ingredients)
      {
        Console.WriteLine($"- {ingredient.Trim()}");
      }

      Console.WriteLine("Instructions");
      Console.WriteLine(selectedRecipe.Instructions);
    }
    else if (!string.IsNullOrEmpty(selectedTitle))
    {
      Console.WriteLine("Recipe not found");
    }



  }

  static void AddRecipe(RecipeRepository repository)
  {
    Console.WriteLine("Enter recipe title:");
    string? title = Console.ReadLine();

    Console.WriteLine("Enter ingredients (comma separated):");
    string? ingredientsInput = Console.ReadLine();
    var ingredients = new List<string>(ingredientsInput?.Split(',') ?? Array.Empty<string>());

    Console.WriteLine("Enter instructions:");
    string? instructions = Console.ReadLine();

    Recipe newRecipe = new Recipe
    {
      Title = title,
      Ingredients = ingredients,
      Instructions = instructions
    };

    var recipes = repository.LoadRecipes();
    recipes.Add(newRecipe);
    repository.SaveRecipes(recipes);

    Console.WriteLine("Recipe added");
  } 

  static void DeleteRecipe(RecipeRepository repository)
  {
    Console.WriteLine("Enter the title of the recipe you want to delete:");
    string? titleToDelete = Console.ReadLine();

    var recipes = repository.LoadRecipes();
    var recipeToDelete = Recipe.Find(r => r.Title != null && r.Title.Equals(titleToDelete, StringComparison.OrdinalIgnoreCase));

    if (recipeToDelete != null)
    {
      recipes.Remove(recipeToDelete);
      repository.SaveRecipes(recipes);
      Console.WriteLine("Recipe Deleted Succsessfully!");
    }
    else
    {
      Console.WriteLine("Recipe Not Found!");
    }
  }
      

  
}