using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ChaukeRecipeApp
{
    internal class RecipeMethods
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


            ingredientNameArray = new string[numberOfIngredient];//Assign ingredientNameArray to value of number of ingredient
            ingredientQuantityArray = new int[numberOfIngredient];//Assign ingredientQuantityArray to value of number of ingredient
            ingredientUnitMeasurementArray = new string[numberOfIngredient];//Assigning ingredientUnitMeasurementArray to the value of number of ingredient

            Console.WriteLine("\n");

            int nameCounter = 1;//To count the ingredient name

            String createRecipe = "Create Recipe";
            Console.ForegroundColor = red;
            Console.WriteLine("*********************** " + createRecipe.ToUpper() + " ******************************\n");
            Console.ResetColor();

            //for loop which will iterate to the numberOfIngredient which prompt the user for ingredient name, quantity and unit measurement
            for (int r = 0; r < numberOfIngredient; r++)
            {

                Console.WriteLine("Enter ingredient name: " + nameCounter++);//Prompts the user for ingredient name
                ingredientName = Console.ReadLine();//Reads the input into the ingredientName variable

                Console.WriteLine("Enter the quantity: ");//Prompts the user for the quantity 
                ingredientQuantity = Convert.ToInt16(Console.ReadLine());//Reads the input into the quantity variable

                Console.WriteLine("Enter the unit measurement: ");//Prompts the user for unit measurement
                ingredientUnitMeasurement = Console.ReadLine();//Reads the input into the unit measurement variable


                recipeClassObject.IngredientNameProperty = ingredientName;//Assigning property name to variable ingredientName
                recipeClassObject.IngredientQuantityProperty = ingredientQuantity;//Assigning property quantity to variable ingredientQuantity
                recipeClassObject.IngredientUnitMeasurementProperty = ingredientUnitMeasurement;//Assigning property IngredientUnitMeasurementProperty to variable ingredientUnitMeasurement

                ingredientNameArray[r] = recipeClassObject.IngredientNameProperty;//Assigning ingredientNameArray to property IngredientNameProperty
                ingredientQuantityArray[r] = recipeClassObject.IngredientQuantityProperty;//Assigning ingredientNameArray to property ingredientQuantityArray
                ingredientUnitMeasurementArray[r] = recipeClassObject.IngredientUnitMeasurementProperty;//Assigning 

                if (ingredientNameArray[r] == null)
                {
                    Console.WriteLine("Invalid Input!!!! Try Again");

                }
                else if (ingredientQuantityArray[r] == null)
                {
                    Console.WriteLine("Invalid Input!!!! Try Again");

                }
                else if (ingredientUnitMeasurementArray[r] == null)
                {
                    Console.WriteLine("Invalid Input!!!! Try Again");
                }


                Console.WriteLine("\n");

            }

            Console.ForegroundColor = red;
            Console.WriteLine("********************************************************************\n");
            Console.ResetColor();

            int stepCounter = 1;//To count each steps

            Console.WriteLine("Enter number of steps: ");//Prompts the user for number of steps
            numberOfSteps = Convert.ToInt16(Console.ReadLine());//Read user input into number of steps variable
            Console.WriteLine("\n");

            ingredientStepsDescriptionArray = new string[numberOfSteps];//Assign ingredientStepsDescriptionArray to value of number of steps

            String steps = "Steps";
            Console.ForegroundColor = red;
            Console.WriteLine("*********************** " + steps.ToUpper() + " **************************************\n");
            Console.ResetColor();

            for (int o = 0; o < numberOfSteps; o++)
            {


                Console.WriteLine("Enter a description for step " + stepCounter++ + ":");//Prompt the user for descriptions for a step or each step
                ingredientStepsDescription = Console.ReadLine();//Reads the value into ingredientStepsDescription

                recipeClassObject.IngredientStepDescriptionProperty = ingredientStepsDescription;//Assigning property IngredientStepDescription to variable ingredientStepsDescription
                ingredientStepsDescriptionArray[o] = recipeClassObject.IngredientStepDescriptionProperty;//Assigning ingredientStepsDescriptionArray to property IngredientStepDescriptionProperty

            }

            Console.ForegroundColor = red;
            Console.WriteLine("********************************************************************\n");
            Console.ResetColor();
            Console.WriteLine("\n");

            Program.in_methodMenu();

            return ingredientName;//A return statement to return a value when the execution of the block is completed


        }
        public static void displayRecipe()//Void method because we return a value
        {
            String recipe = "The Recipe";
            Console.ForegroundColor = red;
            Console.WriteLine("*********************** " + recipe.ToUpper() + " *********************************\n");
            Console.ResetColor();

            var ingredientTable = new Table();//Declaring the an instance of a table class in spectre class for ingredient      

            ingredientTable.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients 
            ingredientTable.AddColumn(new TableColumn(header: "Recipe "));//A header Recipe



            //for loop search through the array to display all the saved values in an array
            for (int m = 0; m < ingredientNameArray.Length; m++)
            {

                ingredientTable.AddRow("Ingredient Name ", ingredientNameArray[m].ToUpper());//Adding row for ingredientNameArray

                ingredientTable.AddRow("Quantity and Unit Measurement ", ingredientQuantityArray[m] + " " + ingredientUnitMeasurementArray[m].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                ingredientTable.BorderColor(color: Color.BlueViolet);//Adding color to table Border

                ingredientTable.Width(50);//setting a width for the table

                ingredientTable.Border(TableBorder.Horizontal);//Setting the border style            
            }

            var tableSteps = new Table();//Declaring the an instance of a table class in spectre class for steps

            tableSteps.AddColumn(new TableColumn(header: "Steps "));//Column for steps header

            int stepCounter = 1;//To count each steps

            //for loop search through the array to diplay all saved inputs in an array
            for (int e = 0; e < ingredientStepsDescriptionArray.Length; e++)
            {
                tableSteps.AddRow("Step " + stepCounter++ + ": " + ingredientStepsDescriptionArray[e]);//Adding ingredientStepsDescriptionArray to row and diplay all steps in an array

                tableSteps.BorderColor(color: Color.DarkRed);//color to the border

                tableSteps.Width(50);//Setting width size of the table

                tableSteps.Border(TableBorder.Horizontal);//Setting the border style


            }
            AnsiConsole.Write(ingredientTable);//Diplay table to console
            AnsiConsole.Write(tableSteps);//Diplay table to console

            //Menu to prompt the user to scale quantities

            Console.WriteLine("\n");

            Console.ForegroundColor = red;
            Console.WriteLine("********************************************************************\n");
            Console.ResetColor();

            Console.WriteLine("Do you want to scale the quantities \n" +
                "1. YES \n" +
                "2. NO \n");

            int option = Convert.ToInt16(Console.ReadLine());//Read user input to option variable

            Console.ForegroundColor = red;
            Console.WriteLine("********************************************************************\n");
            Console.ResetColor();

            if (option == 1)
            {
                //Prompts the user to select a scale
                Console.WriteLine("Choose a scale \n" +
                    "1. 0.5 \n" +
                    "2. 2 \n" +
                    "3. 3 \n");

                int scaleOption = Convert.ToInt16(Console.ReadLine());//Reads the user input to scaleOption variable

                var ingredientQuantityUpdate = new Table();//

                ingredientQuantityUpdate.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients 
                ingredientQuantityUpdate.AddColumn(new TableColumn(header: "Recipe "));//A header Recipe

                ingredientQuantityUpdate.BorderColor(color: Color.BlueViolet);//Adding color to table Border

                ingredientQuantityUpdate.Width(80);//setting a width for the table

                ingredientQuantityUpdate.Border(TableBorder.Horizontal);//Setting the border style

                Console.ForegroundColor = red;
                Console.WriteLine("*********************** " + recipe.ToUpper() + " *********************************\n");
                Console.ResetColor();


                if (scaleOption == 1)
                {

                    for (int b = 0; b < ingredientQuantityArray.Length; b++)
                    {
                        double updateQuantity = ingredientQuantityArray[b] * 0.5;//ingredientQuantityArray will be scale by 0.5 using double data type 

                        ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[b].ToUpper());//Adding row for ingredientNameArray

                        ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", updateQuantity + " " + ingredientUnitMeasurementArray[b].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray




                    }

                    AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console

                }
                else if (scaleOption == 2)
                {
                    for (int o = 0; o < ingredientQuantityArray.Length; o++)
                    {
                        int updateQuantity = ingredientQuantityArray[o] * 2;//ingredientQuantityArray will be scale by 2 using double data type

                        if (ingredientUnitMeasurementArray[o].Contains("tablespoon"))//if teaspoon found from user input the program will do the following calculation and update units measurements
                        {
                            if (updateQuantity <= 8)
                            {

                                ingredientUnitMeasurementArray[o] = "1/2 Cup";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray



                            }
                            else if (updateQuantity == 12 && updateQuantity > 8)
                            {
                                ingredientUnitMeasurementArray[o] = "3/4 Cup";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray


                            }
                            else if (updateQuantity > 12 && updateQuantity == 16)
                            {
                                ingredientUnitMeasurementArray[o] = "1 Cup";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray


                            }
                            else if (updateQuantity > 16 && updateQuantity <= 32)
                            {
                                ingredientUnitMeasurementArray[o] = "2 Cups";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                            }
                            else if (updateQuantity > 32 && updateQuantity <= 64)
                            {
                                ingredientUnitMeasurementArray[o] = "4 Cups";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredie


                            }


                        }
                        else if (ingredientUnitMeasurementArray[o].Contains("teaspoon"))//if teaspoon found from user input the program will do the following calculation and update units measurements 
                        {
                            if (updateQuantity <= 3)
                            {

                                ingredientUnitMeasurementArray[o] = "1 tablespoon";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray



                            }
                            else if (updateQuantity == 6 && updateQuantity > 3)
                            {
                                ingredientUnitMeasurementArray[o] = "2 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray


                            }
                            else if (updateQuantity > 6 && updateQuantity == 12)
                            {
                                ingredientUnitMeasurementArray[o] = "4 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray


                            }
                            else if (updateQuantity > 12 && updateQuantity <= 16)
                            {
                                ingredientUnitMeasurementArray[o] = "5 1/3 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                            }
                            else if (updateQuantity > 16 && updateQuantity <= 24)
                            {
                                ingredientUnitMeasurementArray[o] = "8 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredie


                            }
                            else if (updateQuantity > 24 && updateQuantity <= 36)
                            {
                                ingredientUnitMeasurementArray[o] = "12 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredie


                            }
                            else if (updateQuantity > 36 && updateQuantity <= 48)
                            {
                                ingredientUnitMeasurementArray[o] = "16 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredient

                            }
                            else if (updateQuantity > 48 && updateQuantity <= 96)
                            {
                                ingredientUnitMeasurementArray[o] = "32 tablespoon";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredie


                            }
                            else if (updateQuantity > 96 && updateQuantity <= 196)
                            {
                                ingredientUnitMeasurementArray[o] = "64 tablespoon";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientUnitMeasurementArray[o].ToUpper() + "\n");//Adding row for ingredie


                            }

                        }

                    }
                    AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                }
                else if (scaleOption == 3)
                {
                    //for loop to search through the loop to the length of array
                    for (int n = 0; n < ingredientQuantityArray.Length; n++)
                    {
                        int updateQuantity = ingredientQuantityArray[n] * 3;//ingredientQuantityArray will be scale to 3 using int data type 

                        ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[n].ToUpper());//Adding row for ingredientNameArray

                        ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", updateQuantity + " " + ingredientUnitMeasurementArray[n].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                    }

                    AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                }

            }
            else if (option == 2)
            {
                //Diplay Menu

            }


        }
        public static void clearRecipeData()
        {
            for (int g = 0; g < ingredientNameArray.Length; g++)
            {

                ingredientQuantityArray[g] = 0;
                ingredientNameArray[g] = null;
                 

                    Console.Write("Gone " + ingredientQuantityArray[g]);
                Console.Write("Gone " + ingredientNameArray[g]);
                //return ingredientNameArray;
                Program.in_methodMenu();

            }

            

        }
        public static int resetQuantities()
        {
            int reset;//variable will be used to reset the quantities
            int returnStatement = 1;

            for (int a = 0; a < ingredientQuantityArray.Length; a++)
            {
                ingredientQuantityArray[a] = ingredientQuantityArray[a] - ingredientQuantityArray[a];

                Console.Write("Gone " + ingredientQuantityArray[a]);
            }

            return returnStatement;
        } 
    }
}


