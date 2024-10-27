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
  }

}