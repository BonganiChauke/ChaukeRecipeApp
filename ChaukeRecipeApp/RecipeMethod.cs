using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaukeRecipeApp
{
    internal class RecipeMethod
    {
        //Declaring Object reference for Recipe Class to get the attributes
        static Recipe recipeClassObject = new Recipe();

        //Declaring variables for user inputs 
        static string ingredientName;
        static string ingredientUnitMeasurement;
        static int ingredientQuantity;
        static string ingredientStepsDescription;

        //Single Arrays to assign them to properties in the Recipe class
        static string[] ingredientNameArray;
        static string[] ingredientUnitMeasurementArray;
        static int[] ingredientQuantityArray;
        static string[] ingredientStepsDescriptionArray;

        //Declaring the Recipe class as array
        //Recipe[] getIngredients;

        //variable to get number of ingredient from user
        static int numberOfIngredient;

        //variable to get number of steps from user
        static int numberOfSteps;

        //To change color in console when executing 
        static ConsoleColor red = ConsoleColor.Red;

        public static string captureRecipe()
        {
            
            Console.ForegroundColor = red;
            Console.WriteLine("********************************************************************\n");
            Console.ResetColor();

            Console.WriteLine("Enter the number of ingredient ");//Prompts the user for number of ingredient
            numberOfIngredient = Convert.ToInt16(Console.ReadLine());//Reads the input into the numberOfIngredient variable

            Console.WriteLine("\n");

            int nameCounter = 1;//To count the ingredient name

            String createRecipe = "Create Recipe";
            Console.ForegroundColor = red;
            Console.WriteLine("*********************** " + createRecipe.ToUpper() + " ******************************\n");
            Console.ResetColor();

            //for loop which will iterate to the numberOfIngredient which prompt the user for ingredient name, quantity and unit measurement
            for (int r = 0; r < numberOfIngredient; r++)
            {
                

                ingredientNameArray = new string[numberOfIngredient];//Assign ingredientNameArray to value of number of ingredient
                Console.WriteLine("Enter ingredient name: " + nameCounter++);//Prompts the user for ingredient name
                ingredientName = Console.ReadLine();//Reads the input into the ingredientName variable
                recipeClassObject.IngredientNameProperty = ingredientName;//Assigning property name to variable ingredientName
                ingredientNameArray[r] = recipeClassObject.IngredientNameProperty;//Assigning ingredientNameArray to property IngredientNameProperty


                ingredientQuantityArray = new int[numberOfIngredient];//Assign ingredientQuantityArray to value of number of ingredient
                Console.WriteLine("Enter the quantity: ");//Prompts the user for the quantity 
                ingredientQuantity = Convert.ToInt16 (Console.ReadLine());//Reads the input into the quantity variable
                recipeClassObject.IngredientQuantityProperty = ingredientQuantity;//Assigning property quantity to variable ingredientQuantity
                ingredientQuantityArray[r] = recipeClassObject.IngredientQuantityProperty;//Assigning ingredientNameArray to property ingredientQuantityArray


                ingredientUnitMeasurementArray = new string[numberOfIngredient];//Assigning ingredientUnitMeasurementArray to the value of number of ingredient 
                Console.WriteLine("Enter the unit measurement: ");//Prompts the user for unit measurement
                ingredientUnitMeasurement = Console.ReadLine();//Reads the input into the unit measurement variable
                recipeClassObject.IngredientUnitMeasurementProperty = ingredientUnitMeasurement;//Assigning property IngredientUnitMeasurementProperty to variable ingredientUnitMeasurement
                 

                Console.WriteLine("\n");

            }

            Console.ForegroundColor = red;
            Console.WriteLine("********************************************************************\n");
            Console.ResetColor();

            int stepCounter = 1;//To count each steps

            Console.WriteLine("Enter number of steps: ");//Prompts the user for number of steps
            numberOfSteps = Convert.ToInt16(Console.ReadLine());//Read user input into number of steps variable
            Console.WriteLine("\n");

            String steps = "Steps";
            Console.ForegroundColor = red;
            Console.WriteLine("*********************** " + steps.ToUpper() + " **************************************\n");
            Console.ResetColor();

            for (int o = 0; o < numberOfSteps; o++)
            {
                
                ingredientStepsDescriptionArray = new string[numberOfSteps];//Assign ingredientStepsDescriptionArray to value of number of steps
                Console.WriteLine("Enter a description for step " + stepCounter++  + ":");//Prompt the user for descriptions for a step or each step
                ingredientStepsDescription = Console.ReadLine();//Reads the value into ingredientStepsDescription
                recipeClassObject.IngredientStepDescriptionProperty = ingredientStepsDescription;//Assigning property IngredientStepDescription to variable ingredientStepsDescription
                ingredientStepsDescriptionArray[o] = recipeClassObject.IngredientStepDescriptionProperty;//Assigning ingredientStepsDescriptionArray to property IngredientStepDescriptionProperty

            }

            Console.ForegroundColor = red;
            Console.WriteLine("*******************************************************************\n");
            Console.ResetColor();
            Console.WriteLine("\n");

            return ingredientName;//A return statement to return a value when the execution of the block is completed
        }







    }
}
