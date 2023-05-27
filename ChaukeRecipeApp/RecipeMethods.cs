using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
        //static string ingredientName;
        //static string ingredientUnitMeasurement;
        //static int ingredientQuantity;
        //static string ingredientStepsDescription;

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

        //
        static DataTable dtable = new DataTable();

        //static Table ingredientTable = new Table();



        public static void captureRecipe()
        {
            var table = new Table();
            Console.ForegroundColor = red;
            Console.WriteLine("**************************************************\n");
            Console.ResetColor();


            Console.WriteLine("Enter the number of ingredient ");//Prompts the user for number of ingredient
            numberOfIngredient = Convert.ToInt16(Console.ReadLine());//Reads the input into the numberOfIngredient variable


            ingredientNameArray = new string[numberOfIngredient];//Assign ingredientNameArray to value of number of ingredient
            ingredientQuantityArray = new int[numberOfIngredient];//Assign ingredientQuantityArray to value of number of ingredient
            ingredientUnitMeasurementArray = new string[numberOfIngredient];//Assigning ingredientUnitMeasurementArray to the value of number of ingredient

            recipeClassObject.IngredientNameProperty = new string[numberOfIngredient];//
            recipeClassObject.IngredientQuantityProperty = new int[numberOfIngredient];//
            recipeClassObject.IngredientUnitMeasurementProperty = new string[numberOfIngredient];//

            Console.WriteLine("\n");

            int nameCounter = 1;//To count the ingredient name

            String createRecipe = "Create Recipe";
            Console.ForegroundColor = red;
            Console.WriteLine("**************** " + createRecipe.ToUpper() + " *******************\n");
            Console.ResetColor();

            //for loop which will iterate to the numberOfIngredient which prompt the user for ingredient name, quantity and unit measurement
            for (int r = 0; r < numberOfIngredient; r++)
            {

                //Console.WriteLine("Enter ingredient name: " + nameCounter++);//Prompts the user for ingredient name
                //ingredientNameArray[r] = Console.ReadLine();//Reads the input into the ingredientName variable

                //Console.WriteLine("Enter the quantity: ");//Prompts the user for the quantity 
                //ingredientQuantityArray[r] = Convert.ToInt16(Console.ReadLine());//Reads the input into the quantity variable

                //Console.WriteLine("Enter the unit measurement: ");//Prompts the user for unit measurement
                //ingredientUnitMeasurementArray[r] = Console.ReadLine();//Reads the input into the unit measurement variable

                

                try//
                {
                    Console.WriteLine("Enter ingredient name: " + nameCounter++);//Prompts the user for ingredient name
                    ingredientNameArray[r] = Console.ReadLine();//Reads the input into the ingredientName variable

                    Console.WriteLine("Enter the quantity: ");//Prompts the user for the quantity 
                    ingredientQuantityArray[r] = Convert.ToInt16(Console.ReadLine());//Reads the input into the quantity variable

                    Console.WriteLine("Enter the unit measurement: ");//Prompts the user for unit measurement
                    ingredientUnitMeasurementArray[r] = Console.ReadLine();//Reads the input into the unit measurement variable

                }
                catch//
                {
                    //
                    if (ingredientNameArray[r] == null || ingredientUnitMeasurementArray[r] == null || ingredientQuantityArray[r] == 0)
                    {
                        Console.WriteLine("Can not be null");//
                        captureRecipe();

                    }

                }

                recipeClassObject.IngredientNameProperty[r] = ingredientNameArray[r]; //Assigning ingredientNameArray to property IngredientNameProperty
                recipeClassObject.IngredientQuantityProperty[r] = ingredientQuantityArray[r]; //Assigning ingredientNameArray to property ingredientQuantityArray
                recipeClassObject.IngredientUnitMeasurementProperty[r] = ingredientUnitMeasurementArray[r];//Assigning 


                Console.WriteLine("\n");

            }

            Console.ForegroundColor = red;
            Console.WriteLine("**************************************************\n");
            Console.ResetColor();

            int stepCounter = 1;//To count each steps

            Console.WriteLine("Enter number of steps: ");//Prompts the user for number of steps
            numberOfSteps = Convert.ToInt16(Console.ReadLine());//Read user input into number of steps variable
            Console.WriteLine("\n");

            ingredientStepsDescriptionArray = new string[numberOfSteps];//Assign ingredientStepsDescriptionArray to value of number of steps

            recipeClassObject.IngredientStepDescriptionProperty = new string[numberOfSteps];//

            String steps = "Steps";
            Console.ForegroundColor = red;
            Console.WriteLine("****************** " + steps.ToUpper() + " *************************\n");
            Console.ResetColor();

            for (int o = 0; o < numberOfSteps; o++)
            {


                Console.WriteLine("Enter a description for step " + stepCounter++ + ":");//Prompt the user for descriptions for a step or each step
                ingredientStepsDescriptionArray[o] = Console.ReadLine();//Reads the value into ingredientStepsDescription

                recipeClassObject.IngredientStepDescriptionProperty[o] = ingredientStepsDescriptionArray[o];//Assigning property IngredientStepDescription to variable ingredientStepsDescription
                ingredientStepsDescriptionArray[o] = recipeClassObject.IngredientStepDescriptionProperty[o];//Assigning ingredientStepsDescriptionArray to property IngredientStepDescriptionProperty

            }

            Console.ForegroundColor = red;
            Console.WriteLine("**************************************************\n");
            Console.ResetColor();
            Console.WriteLine("\n");

            Program.in_methodMenu();//

            //return ingredientName;//A return statement to return a value when the execution of the block is completed


        }
        public static void displayRecipe()//Void method because we return a value
        {

            String recipe = "The Recipe";
            Console.ForegroundColor = red;
            Console.WriteLine("****************** " + recipe.ToUpper() + " ********************\n");
            Console.ResetColor();

            var ingredientTable = new Table();//Declaring the an instance of a table class in spectre class for ingredient      

            ingredientTable.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients 
            ingredientTable.AddColumn(new TableColumn(header: "Recipe "));//A header Recipe


            //for loop search through the array to display all the saved values in an array
            for (int m = 0; m < ingredientNameArray.Length; m++)
            {
                //If the values saved on the arrays are not null the diplay will show the recipe
                if (ingredientNameArray[m] != null && ingredientStepsDescriptionArray != null && ingredientQuantityArray[m] != 0 && ingredientUnitMeasurementArray[m] != null)
                {
                    ingredientTable.AddRow("Ingredient Name ", ingredientNameArray[m].ToUpper());//Adding row for ingredientNameArray

                    ingredientTable.AddRow("Quantity and Unit Measurement ", ingredientQuantityArray[m] + " " + ingredientUnitMeasurementArray[m].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                    ingredientTable.BorderColor(color: Color.BlueViolet);//Adding color to table Border

                    ingredientTable.Width(50);//setting a width for the table

                    ingredientTable.Border(TableBorder.Horizontal);//Setting the border style


                }//if the value are null the clear method is called to show the user that there is no saved inputs
                else 
                {
                    //calling the clear method
                    clearRecipeData();

                }


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

            Console.WriteLine("\n");

            Console.ForegroundColor = red;
            Console.WriteLine("**************************************************\n");
            Console.ResetColor();

            Program.in_methodMenu();//Calls in_menu method               

        }
        public static void scaleQuantities()
        {
            Console.WriteLine("\n");

            Console.ForegroundColor = red;
            Console.WriteLine("**************************************************\n");
            Console.ResetColor();

            //Menu to prompt the user to scale quantities
            Console.WriteLine("Do you want to scale the quantities \n" +
                "1. YES \n" +
                "2. NO \n");

            int option = Convert.ToInt16(Console.ReadLine());//Read user input to option variable

            Console.ForegroundColor = red;
            Console.WriteLine("**************************************************\n");
            Console.ResetColor();

            if (option == 1)
            {
                //Prompts the user to select a scale
                Console.WriteLine("Choose a scale \n" +
                    "1. First Scale by: 0.5 \n" +
                    "2. Second Scale by: 2 \n" +
                    "3. Third Scale by: 3 \n");

                int scaleOption = Convert.ToInt16(Console.ReadLine());//Reads the user input to scaleOption variable

                var ingredientQuantityUpdate = new Table();//Declaring the an instance of a table class in spectre class for ingredient

                ingredientQuantityUpdate.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients 
                ingredientQuantityUpdate.AddColumn(new TableColumn(header: "Recipe "));//A header Recipe

                ingredientQuantityUpdate.BorderColor(color: Color.BlueViolet);//Adding color to table Border

                ingredientQuantityUpdate.Width(50);//setting a width for the table

                ingredientQuantityUpdate.Border(TableBorder.Horizontal);//Setting the border style

                String recipe = "Scale";
                Console.ForegroundColor = red;
                Console.WriteLine("*********************** " + recipe.ToUpper() + " *********************\n");
                Console.ResetColor();


                if (scaleOption == 1)
                {

                    for (int b = 0; b < ingredientQuantityArray.Length; b++)
                    {
                        recipeClassObject.UpdateQuantityDouble = ingredientQuantityArray[b] * 0.5;//ingredientQuantityArray will be scale by 0.5 using double data type 


                        if (ingredientUnitMeasurementArray[b].Contains("cup") || ingredientUnitMeasurementArray[b].Contains("CUP"))
                        {
                            if (recipeClassObject.UpdateQuantityDouble < 2)
                            {
                                ingredientUnitMeasurementArray[b] = " Cup";//changes the units Measurement

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[b].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UpdateQuantityDouble + "" + ingredientUnitMeasurementArray[b].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                            }
                            AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console


                        }
                        
                        

                        else if(ingredientUnitMeasurementArray[b].Contains("tablespoons") || ingredientUnitMeasurementArray[b].Contains("tablespoon"))
                        {
                            if (recipeClassObject.UpdateQuantityDouble >= 8)
                            {
                                ingredientUnitMeasurementArray[b] = "24 teaspoons";//changes the units Measurement

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[b].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UpdateQuantityDouble + " " + ingredientUnitMeasurementArray[b].ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                            }
                            AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console



                        }
                        else
                        {

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[b].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientQuantityArray[b] + " " + ingredientUnitMeasurementArray[0] + "\n");//Adding row for ingredie

                            AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                        }

                        //AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console



                    }

                    //AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console
                    Program.in_methodMenu();//call to diplay menu

                }
                else if (scaleOption == 2)
                {
                    for (int o = 0; o < ingredientQuantityArray.Length; o++)
                    {
                        recipeClassObject.UpdateQuantityInt = ingredientQuantityArray[o] * 2;//ingredientQuantityArray will be scale by 2 using double data type

                        if (ingredientUnitMeasurementArray[o].Contains("tablespoon") || ingredientUnitMeasurementArray[o].Contains("tablespoons"))//if teaspoon found from user input the program will do the following calculation and update units measurements
                        {
                            if (recipeClassObject.UpdateQuantityInt <= 8)
                            {

                                recipeClassObject.UnitMeasurementUpdate = "1/2 Cup";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console

                            }
                            else if (recipeClassObject.UpdateQuantityInt == 12 && recipeClassObject.UpdateQuantityInt > 8)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "3/4 Cup";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console
                            }
                            else if (recipeClassObject.UpdateQuantityInt > 12 && recipeClassObject.UpdateQuantityInt == 16)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "1 Cup";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console

                            }
                            else if (recipeClassObject.UpdateQuantityInt > 16 && recipeClassObject.UpdateQuantityInt <= 32)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "2 Cups";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console
                            }
                            else if (recipeClassObject.UpdateQuantityInt > 32 && recipeClassObject.UpdateQuantityInt <= 64)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "4 Cups";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredie

                                AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                            }

                            //AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console
                            //Program.in_methodMenu();//call to diplay menu


                        }else
                        {

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientQuantityArray[o] + " " + ingredientUnitMeasurementArray[0] + "\n");//Adding row for ingredie

                            AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                        }

                        AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                        if (ingredientUnitMeasurementArray[o].Contains("teaspoon") || ingredientUnitMeasurementArray[o].Contains("teaspoons"))//if teaspoon found from user input the program will do the following calculation and update units measurements 
                        {
                            if (recipeClassObject.UpdateQuantityInt <= 3)
                            {

                                recipeClassObject.UnitMeasurementUpdate = "1 tablespoon";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console


                            }
                            else if (recipeClassObject.UpdateQuantityInt == 6 && recipeClassObject.UpdateQuantityInt > 3)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "2 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                            }
                            else if (recipeClassObject.UpdateQuantityInt > 6 && recipeClassObject.UpdateQuantityInt == 12)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "4 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                            }
                            else if (recipeClassObject.UpdateQuantityInt > 12 && recipeClassObject.UpdateQuantityInt <= 16)
                            {
                                ingredientUnitMeasurementArray[o] = "5 1/3 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                            }
                            else if (recipeClassObject.UpdateQuantityInt > 16 && recipeClassObject.UpdateQuantityInt <= 24)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "8 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredie

                                AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                            }
                            else if (recipeClassObject.UpdateQuantityInt > 24 && recipeClassObject.UpdateQuantityInt <= 36)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "12 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredie

                                AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                            }
                            else if (recipeClassObject.UpdateQuantityInt > 36 && recipeClassObject.UpdateQuantityInt <= 48)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "16 tablespoons";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredient

                                AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                            }
                            else if (recipeClassObject.UpdateQuantityInt > 48 && recipeClassObject.UpdateQuantityInt <= 96)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "32 tablespoon";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredie

                                AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                            }
                            else if (recipeClassObject.UpdateQuantityInt > 96 && recipeClassObject.UpdateQuantityInt <= 196)
                            {
                                recipeClassObject.UnitMeasurementUpdate = "64 tablespoon";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredie

                                //AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                            }

                            

                        }

                        AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console


                    }
                    AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                    Program.in_methodMenu();//Displays menu

                }

            
                else if (scaleOption == 3)
                {
                    //for loop to search through the loop to the length of array
                    for (int n = 0; n < ingredientQuantityArray.Length; n++)
                    {
                        recipeClassObject.UpdateQuantityInt = ingredientQuantityArray[n] * 3;//ingredientQuantityArray will be scale to 3 using int data type 

                        if(recipeClassObject.UpdateQuantityInt > 1)//
                        {
                            recipeClassObject.UnitMeasurementUpdate = " Cups";//

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[n].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", recipeClassObject.UpdateQuantityInt + " " + recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray



                        }
                        else
                        {

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", ingredientNameArray[n].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientQuantityArray[n] + " " + ingredientUnitMeasurementArray[0] + "\n");//Adding row for ingredie

                            AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                        }


                    }

                    AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                    Program.in_methodMenu();//Displays menu

                }

            }
            else if (option == 2)
            {
                //Diplay Menu
                Program.in_methodMenu();

            }




        }
        //A method to clear the data
        public static void clearRecipeData()
        {
            //Prompt user to clear 
            var clearTable = new Table();//Declaring the an instance of a table class in spectre class for ingredient

            Console.WriteLine("Confirm : Are you sure ??!! \n" +
               "1.Yes\n" +
               "2.No\n");//prompts the user

            int confirm = Convert.ToInt16(Console.ReadLine());//user input save in the variable

            if (confirm == 1)
            {
                Console.WriteLine("\n");

                clearTable.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients 

                for (int i = 0; i < ingredientNameArray.Length; i++)
                {
                    
                    clearTable.BorderColor(color: Color.DarkRed);//Adding color to table Border

                    clearTable.Width(60);//setting a width for the table

                    clearTable.Border(TableBorder.Horizontal);//Setting the border style

                    Array.Clear(ingredientNameArray, 0, ingredientNameArray.Length);//Array Clear Method -- Clears all the content from 0 to the length of array
                    Array.Clear(ingredientQuantityArray, 0, ingredientQuantityArray.Length);//Array Clear Method -- Clears all the content from 0 to the length of array
                    Array.Clear(ingredientUnitMeasurementArray, 0, ingredientUnitMeasurementArray.Length);//Array Clear Method -- Clears all the content from 0 to the length of array
                    Array.Clear(ingredientStepsDescriptionArray, 0, ingredientStepsDescriptionArray.Length);//Array Clear Method -- Clears all the content from 0 to the length of array


                    clearTable.AddRow("Ingredient Name : " + ingredientNameArray[i]);//Diplays the cleared input
                    clearTable.AddRow("Quantity : " + ingredientQuantityArray[i]);//Diplays the cleared input
                    clearTable.AddRow("Unit Measurement: " + ingredientUnitMeasurementArray[i]);//Diplays the cleared input



                }
                AnsiConsole.Write(clearTable);//Display the table

                Console.WriteLine("\n");         

                //Prompts the user
                Console.WriteLine("Recipe Cleared : Enter a new recipe\n" +
                    "1. Yes \n" +
                    "2. No\n");
                int enterNewRecipe = int.Parse(Console.ReadLine());//reads the user input to the variable

                switch(enterNewRecipe)
                {
                    case 1:
                        captureRecipe();//Call the method can enter a new recipe
                        break;

                    case 2:
                        Program.in_methodMenu();//Call the menu method
                        break;

                }


            }
            else if (confirm == 2)
            {
                Program.in_methodMenu();//calls the displys menu

            }


        }

        //A method to reset the values 
        public static void resetQuantities()
        {

            //Prompts the user 
            Console.WriteLine("Reset the quantities :\n" +
                "1. Yes \n" +
                "2. No\n");

            int reset = int.Parse(Console.ReadLine());//Read user input

            var resetTable = new Table();//Declaring the an instance of a table class in spectre class for ingredient

            resetTable.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients 
            resetTable.AddColumn(new TableColumn(header: "Recipe "));//A header Recipe

            resetTable.BorderColor(color: Color.BlueViolet);//Adding color to table Border

            resetTable.Width(50);//setting a width for the table

            resetTable.Border(TableBorder.Horizontal);//Setting the border style


            switch (reset)
            {
                case 1:
                    //Reset the quantities

                    //for loop to search the loop
                    for (int a = 0; a < ingredientQuantityArray.Length; a++)
                    {

                        if (recipeClassObject.UpdateQuantityDouble == (int)ingredientQuantityArray[a])//reseting the double object to original quantities
                        {
                            recipeClassObject.UpdateQuantityDouble = (int)ingredientQuantityArray[a];//cast 

                            ingredientQuantityArray[a] = ingredientQuantityArray[a];//reseting the value ingredient name 

                            recipeClassObject.UnitMeasurementUpdate = ingredientUnitMeasurementArray[a];//reseting the units measurement

                            resetTable.AddRow("Ingredient Name ", ingredientNameArray[a].ToUpper());//Adding row for ingredientNameArray

                            resetTable.AddRow("Quantity and Unit Measurement ", recipeClassObject.UpdateQuantityDouble + " " + recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray
                            
                        }
                        
                        else 
                        {
                            recipeClassObject.UpdateQuantityInt = ingredientQuantityArray[a];//reseting the int object to original quantities

                            ingredientQuantityArray[a] = ingredientQuantityArray[a];//reseting the value ingredient name

                            recipeClassObject.UnitMeasurementUpdate = ingredientUnitMeasurementArray[a];//reseting the units measurement

                            resetTable.AddRow("Ingredient Name ", ingredientNameArray[a].ToUpper());//Adding row for ingredientNameArray

                            resetTable.AddRow("Quantity and Unit Measurement ", ingredientQuantityArray[a] + " " + recipeClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                        }
                        AnsiConsole.Write(resetTable);//Displays to the console


                    }

                    Program.in_methodMenu();//Displays menu
                    break;
                    

                case 2:
                    //Call the menu
                    
                    Program.in_methodMenu();//Displays menu

                    break;

            }

           
            

        }
    }
}


