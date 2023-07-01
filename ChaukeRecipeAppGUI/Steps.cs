using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaukeRecipeAppGUI
{
    internal class Steps
    {
        //Declaring properties variables
        private string ingredientStepsDescription;//field

        //Automatic property for ingredientStepsDescription field
        public string IngredientStepsDescription
        {
            get; set;
        }

        //Declaring Ingredient class as list
        public List<Ingredients> IngredientsClass
        {
            get; set;
        }

        public Steps() { }


        //Overloaded Constructor for setting values to the  attributes
        public Steps(string ingredientStepsDescription)
        {
            IngredientStepsDescription = ingredientStepsDescription;
            IngredientsClass = new List<Ingredients>();
        }

        //Override the constructor with the values
        public override string ToString()
        {
            return $"Step Description: {IngredientStepsDescription}";
        }
    }
}
