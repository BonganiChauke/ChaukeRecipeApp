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

        private String [] ingredientNameProperty; //field
        private String [] ingredientUnitMeasurementProperty;//field
        private int[] ingredientQuantityProperty;//field
        private String [] ingredientStepDescriptionProperty;//field
        private int updateQuantityInt;//field
        private double updateQuantityDouble;//field

            

        //Overloaded Constructor for setting values to the  attributes

        //Automatic Property for ingredientName

        public string [] IngredientNameProperty
        {
            get;set;
        }

        //Automatic Property for ingredientUnitMeasuremnt

        public string [] IngredientUnitMeasurementProperty
        {
            get;set;
        }

        //Automatic Property for ingredientQuantity 

        public int [] IngredientQuantityProperty
        {
            get;set;
        }

        //Automatic Property for ingredientStepDescription

        public string [] IngredientStepDescriptionProperty
        {
            get;set;
        }

        //Automatic Property for updateQuantityInt

        public int UpdateQuantityInt
        {
            get;set;
        }

        //Automatic Property for updateQuantityDouble

        public double UpdateQuantityDouble
        {
            get;set;
        }

        //Automatic Property for 

        //ingredientQuantityArray[a] = ingredientQuantityArray[a] - ingredientQuantityArray[a];

        //Console.Write("Gone " + ingredientQuantityArray[a]);


        //ingredientQuantityArray[g] = 0;
        //        ingredientNameArray[g] = null;


        //        Console.Write("Gone " + ingredientQuantityArray[g]);
        //        Console.Write("Gone " + ingredientNameArray[g]);




        //return ingredientNameArray;
    }
}
