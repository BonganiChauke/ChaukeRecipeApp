using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaukeRecipeApp
{
    internal class Recipe
    {
        //Declaring Properties Variables as private for recipe

        private String recipeName; //field
        

        //Declarinng a class Ingredient as a list
        public List<Ingredients> IngredientsClass
        {
            get;set;
        }

        //Declaring a class Steps as a list
        public List<Steps> StepsClass
        {
            get;set;
        }

        //Automatic Property for ingredientName

        public string RecipeName
        {
            get;set;
        }

        //Overloaded Constructor for setting values to the  attributes

        public Recipe(string recipeName)
        {
            RecipeName = recipeName;
            IngredientsClass = new List<Ingredients>();
            StepsClass = new List<Steps>();
        }

        //Override constructor with the values 

        public override string ToString()
        {
            return $"Recipe Name: {RecipeName}";
        }




    }
}
