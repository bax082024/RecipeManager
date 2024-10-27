using RecipeManager.Models;
using RecipeManager.Data;
using System.Collections.Generic;
using System.Linq;
using System;


class Program
{
  public static void Main(string[] args)
  {

    RecipeRepository repository = new RecipeRepository();

    while (true)
    {
      Console.WriteLine("\nRecipe Manager");
      Console.WriteLine("1. View Recipes");
      Console.WriteLine("2. Add Recipe");
      Console.WriteLine("3. Delete Recipe");
      Console.WriteLine("4. Exit");
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
          DeleteRecipe(repository);
          break;
        case "4":
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
    var recipeToDelete = recipes.Find(r => r.Title != null && r.Title.Equals(titleToDelete, StringComparison.OrdinalIgnoreCase));

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

  static void EditRecipe(RecipeRepository repository)
  {
    Console.WriteLine("Title of the recipe you want to edit:");
    string? titleToEdit = Console.ReadLine();

    var recipes = repository.LoadRecipes();
    var recipeToEdit = recipes.Find(r => r.Title != null && r.Title.Equals(titleToEdit, StringComparison.OrdinalIgnoreCase));

    if (recipeToEdit != null)
    {
      Console.WriteLine($"Current tirle: {recipeToEdit.Title}");
      Console.Write("Enter New Title (press Enter to keep current title):");
      string? newTitle = Console.ReadLine();
      if (!string.IsNullOrEmpty(newTitle)) recipeToEdit.Title = newTitle;
    

      Console.WriteLine("Current ingredients: " + string.Join(", ", recipeToEdit.Ingredients));
      Console.Write("Enter new ingredients ( seperate with comma. or press Enter to keep current ingredients)");
      string? newIngredients = Console.ReadLine();
      if (!string.IsNullOrEmpty(newIngredients))
      {
        recipeToEdit.Ingredients = new List<string>(newIngredients.Split(',').Select(i => i.Trim()));
      }

      Console.WriteLine($"Current instructions: {recipeToEdit.Instructions}");
      Console.Write("Enter new instructions (press Enter to keep current instructions)");
      string? newInstructions = Console.ReadLine();
      if (string.IsNullOrEmpty(newInstructions)) recipeToEdit.Instructions = newInstructions;

      repository.SaveRecipes(recipes);
      Console.WriteLine("recipe succsefully updated!");
    }
    else
    {
      Console.WriteLine("Recipe not found!");
    }



  }
      

  
}