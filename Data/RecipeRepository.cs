using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RecipeManager.Models;

namespace RecipeManager.Data
{
  public class RecipeRepository
  {
    private readonly string filePath = "Data/recipes.json";

    public void SaveRecipes(List<Recipe> recipes)
    {
      string json = JsonConvert.SerializeObject(recipes, Formatting.Indented);
      File.WriteAllText(filePath, json);
    }

    public List<Recipe> LoadRecipes()
    {
      if (!File.Exists(filePath))
      {
        return new List<Recipe>();
      }

      string json = File.ReadAllText(filePath);
      return JsonConvert.DeserializeObject<List<Recipe>>(json) ?? new List<Recipe>();
    }
  }

}