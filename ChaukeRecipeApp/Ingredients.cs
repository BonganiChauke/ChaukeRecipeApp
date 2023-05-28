using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaukeRecipeApp
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

        //Automatic property for ingredient name

        public string IngredientName
        {
            get;set;
        }

        //Automatic property for ingredient quantity

        public double IngredientQuantity
        {
            get;set;
        }

        //Automatic property for ingredient unit measurement 

        public string IngredientUnitMeasurement
        {
            get;set;
        }

        //Automatic property for number of calories

        public int IngredientCalories
        {
            get;set;
        }

        //Automatic property for select food group

        public string IngredientFoodGroup
        {
            get;set;
        }

        //Automatic property for scale Quantity

        public double ScaleQuantity
        {
            get;set;
        }

        //Automatic property for UnitMeasurementUpdate

        public string UnitMeasurementUpdate
        {
            get;set;
        }

        //Overloaded constructor that will pass the values 

        public Ingredients(string ingredientName, double ingredientQuantity, string ingredientUnitMeasurement,int ingredientCalories, string ingredientFoodGroup)
        {
            //setting the values for automatic properties

            IngredientName = ingredientName;
            IngredientQuantity = ingredientQuantity;
            IngredientUnitMeasurement = ingredientUnitMeasurement;
            IngredientCalories = ingredientCalories;
            IngredientFoodGroup = ingredientFoodGroup;
        }

        //Override the constructor with the values

        public override string ToString()
        {
            return $"Ingredient Name: {IngredientName} Ingredient Quantity: {IngredientQuantity} Ingredient Unit Measurement: {IngredientUnitMeasurement} Ingredient Calories: {IngredientCalories} Ingredient Food Group: {IngredientFoodGroup}";
        }

        /*
         
          //
                                choosenRecipe.AddColumn(new TableColumn(header: newRecipeNameVariable[g]));
                                choosenRecipe.AddColumn(new TableColumn(header: "Ingredients"));

                                //
                                choosenRecipe.AddRow("Ingredient Name ", newIngredientNameVariable[g]);
                                choosenRecipe.AddRow("Ingredient Quantity and Unit Measurement ", newIngredientQuantityVariable[g] + "" + newIngredientUnitMeasurementVariable[g]);
                                choosenRecipe.AddRow("Ingredient Calories " + newIngredientCaloriesVariable[g]);
                                choosenRecipe.AddRow("Ingredient Food Group ", newIngredientFoodGroupVariable[g]);

                                //Table style
                                choosenRecipe.BorderColor(color: Color.Cornsilk1);//color to the border
                                choosenRecipe.Width(50);//Setting width size of the table
                                choosenRecipe.Border(TableBorder.Horizontal);//Setting the border style

                                tableStep.AddRow($"Step {stepCounterr}: ", newIngredientStepsDescriptionVariable[g]);//
                                stepCounterr++;

                                //Table style
                                tableStep.BorderColor(color: Color.DarkRed);//color to the border
                                tableStep.Width(50);//Setting width size of the table
                                tableStep.Border(TableBorder.Horizontal);//Setting the border style
                    
                                AnsiConsole.Write(choosenRecipe);//Display to the console
                                AnsiConsole.Write(tableStep);//Display to the console
         
         
         */

    }
}
