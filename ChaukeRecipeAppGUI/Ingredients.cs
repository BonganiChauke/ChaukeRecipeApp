using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaukeRecipeAppGUI
{
    internal class Ingredients
    {
        //Declaring properties variables 
        private string ingredientName;//field
        private double ingredientQuantity;//field
        private string ingredientUnitMeasurement;//field
        private int ingredientCalories;//field
        private string ingredientFoodGroup;//field
        private double scaleQuantity;//field
        private string unitMeasurementUpdate;//field

        private double quantityScaled;

        //Automatic property for ingredient name

        public string IngredientName
        {
            get; set;
        }

        //Automatic property for ingredient quantity

        public double IngredientQuantity
        {
            get; set;
        }

        //Automatic property for ingredient unit measurement 

        public string IngredientUnitMeasurement
        {
            get; set;
        }

        //Automatic property for number of calories

        public int IngredientCalories
        {
            get; set;
        }

        //Automatic property for select food group

        public string IngredientFoodGroup
        {
            get; set;
        }

        //Automatic property for scale Quantity

        public double ScaleQuantity
        {
            get; set;
        }

        //Automatic property for UnitMeasurementUpdate

        public string UnitMeasurementUpdate
        {
            get; set;
        }

        //Automatic property for quantity Scaled

        public double QuantityScaled
        {
            get; set;
        }

        //Overloaded constructor that will pass the values 

        public Ingredients(string ingredientName, double ingredientQuantity, string ingredientUnitMeasurement, int ingredientCalories, string ingredientFoodGroup)
        {
            //setting the values for automatic properties

            IngredientName = ingredientName;
            IngredientQuantity = ingredientQuantity;
            IngredientUnitMeasurement = ingredientUnitMeasurement;
            IngredientCalories = ingredientCalories;
            IngredientFoodGroup = ingredientFoodGroup;
        }
        public Ingredients()
        {
            //IngredientCalories = ingredientCalories;
        }
        //Override the constructor with the values

        public override string ToString()
        {
            return $"Ingredient Name: {IngredientName} Ingredient Quantity: {IngredientQuantity} Ingredient Unit Measurement: {IngredientUnitMeasurement} Ingredient Calories: {IngredientCalories} Ingredient Food Group: {IngredientFoodGroup}";
        }
    }
}
