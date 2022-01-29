﻿namespace BombasKitchen.Data.Definitions
{
    public class Day : ItemBase
    {
        public List<Recipe> Recipes { get; set; }

        public Day()
        {
            Recipes = new List<Recipe>();
        }
    }
}
