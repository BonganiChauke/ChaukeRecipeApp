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
        static List<Recipe> recipeClassObject = new List<Recipe>();
        
        //Declaring object reference for Ingredient Class as List and also an object reference to add user input into
        static List<Ingredients> ingredientsClassObject = new List<Ingredients>();
        static Ingredients ingredientsUpdateClassObject = new Ingredients(ingredientName, ingredientQuantity, ingredientUnitMeasurement, ingredientCalories, ingredientFoodGroup);


        //Decalring object reference for Steps Class as list to add user input into
        static List<Steps> stepsClassObject = new List<Steps>();

        //Declaring variables for user inputs 
        static string recipeName;
        static string ingredientName;
        static string ingredientUnitMeasurement;
        static double ingredientQuantity;
        static int ingredientCalories;
        static string ingredientFoodGroup;
        static string ingredientStepsDescription;

        //variable to get number of ingredient from user
        static int numberOfIngredient;

        //variable to get number of steps from user
        static int numberOfSteps;

        //variable to get number of recipe from user
        static int numberOfRecipes;

        //variable to get the user food group choice
        static int selectFoodGroup;

        //variable to get user to get the recipe
        static string chooseRecipe;

        //variable to get the user choose display
        static int chooseDisplay;

        //Declaring variables new Variable 
        static List<string> newRecipeNameVariable = new List<string>(recipeClassObject.Count);
        static List<string> newIngredientNameVariable = new List<string>(ingredientsClassObject.Count);
        static List<string> newIngredientUnitMeasurementVariable = new List<string>(recipeClassObject.Count);
        static List<double> newIngredientQuantityVariable = new List<double>(ingredientsClassObject.Count);
        static List<int> newIngredientCaloriesVariable = new List<int>(ingredientsClassObject.Count);
        static List<string> newIngredientFoodGroupVariable = new List<string>(ingredientsClassObject.Count);
        static List<string> newIngredientStepsDescriptionVariable = new List<string>(stepsClassObject.Count);
        
        //To change color in console when executing 
        static ConsoleColor red = ConsoleColor.Red;

        public static void captureRecipe()
        {//captureRecipe method [S]
           
            try//
            {//try [S]

                Console.WriteLine("\n");
                String createRecipe = "Create Recipe";
                Console.ForegroundColor = red;
                Console.WriteLine("**************** " + createRecipe.ToUpper() + " *******************\n");
                Console.ResetColor();


                Console.WriteLine("Enter number of recipe(s)");//Prompt user for recipe name
                numberOfRecipes = Convert.ToInt32(Console.ReadLine());//Reads user input into the variable numberOfRecipes

                Console.WriteLine("\n");

                //for loop to the numberOfRecipes
                for (int i = 0; i < numberOfRecipes; i++)
                {//numberOfRecipes loop [S]

                    //-------------------------------------------Recipe Name Section

                    Console.WriteLine($"Enter Recipe Name {i + 1}: ");
                    recipeName = Console.ReadLine();

                    //Declaring the overloaded constructor of the Recipe Class
                    Recipe recipeAdd = new Recipe(recipeName);

                    Console.WriteLine("\n");

                    //--------------------------------------------Ingredients Section

                    Console.WriteLine($"Enter the number of ingredient for : {recipeName.ToUpper()} Recipe");//Prompts the user for number of ingredient
                    numberOfIngredient = Convert.ToInt16(Console.ReadLine());//Reads the input into the numberOfIngredient variable  

                    Console.WriteLine("\n");

                    //nested for loop to the number of ingredients inside number of ingredients loop

                    for (int n = 0; n < numberOfIngredient; n++)
                    {//numberOfIngredient loop [S]

                        Console.WriteLine($"Enter ingredient name {n + 1}:");//Prompts the user ingredient name
                        ingredientName = Console.ReadLine();//Reads user input into ingredient name variable

                        Console.WriteLine("Enter ingredient quantity ");//Prompts user for ingredient quantity
                        ingredientQuantity = Convert.ToInt32(Console.ReadLine());//Reads the user input into ingredient quantity variable

                        Console.WriteLine("Enter ingredient unit measurement ");//Prompts the user input for unit measurement
                        ingredientUnitMeasurement = Console.ReadLine();//Reads the user input into variable ingredientUnitMeasurement

                        Console.WriteLine("\n");

                        //---------------------------------------Calories and Food Group

                        String foodCalories = "Food Group and Calories";
                        Console.ForegroundColor = red;
                        Console.WriteLine("********* " + foodCalories.ToUpper() + " ****************\n");
                        Console.ResetColor();

                        var descriptionOfFoodGroupCalories = new Table();//Declaring the an instance of a table class in spectre class      

                        descriptionOfFoodGroupCalories.AddColumn(new TableColumn(header: "Calories"));//A header for calories 
                        descriptionOfFoodGroupCalories.AddColumn(new TableColumn(header: "Food Group"));//A header Food Group

                        //Table style
                        descriptionOfFoodGroupCalories.BorderColor(color: Color.Chartreuse2);//Adding color to table Border
                        descriptionOfFoodGroupCalories.Width(50);//setting a width for the table
                        descriptionOfFoodGroupCalories.Border(TableBorder.Horizontal);//Setting the border style

                        //An explanation of what a food group is and what are calories
                        descriptionOfFoodGroupCalories.AddRow("Calories are amounts of energy from food and drinks measured in kcals," +
                        " Calories put energy into our bodies to perform normal bodily functions and physical activity", "A food group is a collection of foods that share similar nutritional properties or biological classifications" +
                        "List of nutrition guides typically divide foods into food groups and Recommended Dietary Allowance recommend daily servings of each group for a healthy diet");

                        AnsiConsole.Write(descriptionOfFoodGroupCalories);//Displays to the console

                        Console.WriteLine("\n");

                        Console.WriteLine($"Enter number of calories for: {ingredientName} ingredient ");//Prompts user for number of calories
                        ingredientCalories = Convert.ToInt32(Console.ReadLine());//Reads user input into ingredientCalories

                        Console.WriteLine("\n");

                        var foodGroup = new Table();//Declaring the an instance of a table class in spectre class

                        //Prompts user for a food group with options to select
                        foodGroup.AddColumn("Select a choice ");
                        foodGroup.AddRow("1. Starchy Foods");
                        foodGroup.AddRow("2. Vegetable and Fruit");
                        foodGroup.AddRow("3. Dry Beans, Peas, Lentils, and Soya");
                        foodGroup.AddRow("4. Chicken, Fish, Meat, and Eggs");
                        foodGroup.AddRow("5. Milk and Dairy Products");
                        foodGroup.AddRow("6. Fats and Oil");
                        foodGroup.AddRow("7. Water");

                        //Table style
                        foodGroup.BorderColor(color: Color.BlueViolet);//Adding a color for table border
                        foodGroup.Width(50);//Setting a width for the table
                        foodGroup.Border(TableBorder.Horizontal);//Setting the table border style

                        AnsiConsole.Write(foodGroup);//Displays to the console

                        selectFoodGroup = Convert.ToInt32(Console.ReadLine());//Reads user input into variable ingredientFoodGroup

                        Console.WriteLine("\n");

                        var foodGroupDetails = new Table();//Declaring the an instance of a table class in spectre class
                        //foodGroupDetails.AddColumn("Food Group Brieft");//Column for brieft
                        foodGroupDetails.BorderColor(color: Color.Blue1);//Setting the table color
                        foodGroupDetails.Width(50);//Setting a width for the table
                        foodGroupDetails.Border(TableBorder.HeavyHead);//setting the table border

                        switch (selectFoodGroup)//To check user input
                        {//Switch case[S]

                            case 1:
                                ingredientFoodGroup = "Starchy Food";//Assigning value to string
                                foodGroupDetails.AddColumn(ingredientFoodGroup);//To Diplay the choosen food group
                                foodGroupDetails.AddRow("Main Source of carbohydrates, they are good source of energy and main source of nutrients good for managing diabetes");//Food group brieft
                                AnsiConsole.Write(foodGroupDetails);//Diplays to the console 
                                Console.WriteLine("\n");
                                break;

                            case 2:
                                ingredientFoodGroup = "Vegetables and Fruits";//Assigning value to string
                                foodGroupDetails.AddColumn(ingredientFoodGroup);//To Diplay the choosen food group
                                foodGroupDetails.AddRow("Try to eat at least 5 portions of fruits and vegetables a day, vegetable and fruit contain vitamins and minerals and packed with fibre to lower cholesteral and help to prevent diseases");//Food group brieft
                                AnsiConsole.Write(foodGroupDetails);//Displays to the console 
                                Console.WriteLine("\n");
                                break;

                            case 3:
                                ingredientFoodGroup = "Dry beans, peas, lentils and Soya";//Assigning value to string
                                foodGroupDetails.AddColumn(ingredientFoodGroup);//To Diplay the choosen food group
                                foodGroupDetails.AddRow("Used as an alternatives for meat or chicken they have good source of protein and reduce amount of fat and carbohydrates");//Food group brieft
                                AnsiConsole.Write(foodGroupDetails);//To Diplay the choosen food group 
                                Console.WriteLine("\n");
                                break;

                            case 4:
                                ingredientFoodGroup = "Meat, Chicken, Eggs and Fish";//Assigning value to string
                                foodGroupDetails.AddColumn(ingredientFoodGroup);//To Diplay the choosen food group
                                foodGroupDetails.AddRow("A good source of protein, vitamins, and minerals meat has vitamins B12 found from animals. Some contain saturated high fat. Eating a lot of fat can increase blood cholesterol level increase risk of heart disease");//Food group brieft
                                AnsiConsole.Write(foodGroupDetails);//To Diplay the choosen food group 
                                Console.WriteLine("\n");
                                break;

                            case 5:
                                ingredientFoodGroup = "Milk and Dairy Products";//Assigning value to string
                                foodGroupDetails.AddColumn(ingredientFoodGroup);//To Diplay the choosen food group
                                foodGroupDetails.AddRow("Milk and Dairy products are good sources of protein and vitamin and contain calcium which keep our bones healthy and strong");//Food group brieft
                                AnsiConsole.Write(foodGroupDetails);//To Diplay the choosen food group 
                                Console.WriteLine("\n");
                                break;

                            case 6:
                                ingredientFoodGroup = "Fats and Oil";//Assigning value to string
                                foodGroupDetails.AddColumn(ingredientFoodGroup);//To Diplay the choosen food group
                                foodGroupDetails.AddRow("Some fats are healthier than others choose unsaturated fats with are plant based instead of based");//Food group brief
                                AnsiConsole.Write(foodGroupDetails);//To Diplay the choosen food group
                                Console.WriteLine("\n");
                                break;

                            case 7:
                                ingredientFoodGroup = "Water";//Assigning value to string
                                foodGroupDetails.AddColumn(ingredientFoodGroup);//To Diplay the choosen food group
                                foodGroupDetails.AddRow("Aim to drink 6 to 8 glasses of water each day to keep your body hydrated");//Food group brieft 
                                AnsiConsole.Write(foodGroupDetails);//To Diplay the choosen food group
                                Console.WriteLine("\n");
                                break;


                        }//Switch case[E]

                        //Decalring the overloaded contructor of the Ingredient class
                        Ingredients ingredientsAdd = new Ingredients(ingredientName, ingredientQuantity, ingredientUnitMeasurement, ingredientCalories, ingredientFoodGroup);
                        recipeAdd.IngredientsClass.Add(ingredientsAdd);//Adding to the list

                    }//numberOfIngredient loop [E]

                    recipeClassObject.Add(recipeAdd);//Adding to the list

                    Console.WriteLine("\n");

                    String stepss = "Steps";
                    Console.ForegroundColor = red;
                    Console.WriteLine("****************** " + stepss.ToUpper() + " *************************\n");
                    Console.ResetColor();

                    Console.WriteLine("\n");

                    //---------------------------------------Steps section

                    Console.WriteLine("Enter number of steps");//Prompts the user for number of steps
                    numberOfSteps = Convert.ToInt32(Console.ReadLine());//Reads user input into number of steps variable

                    Console.WriteLine("\n");

                    for (int g = 0; g < numberOfSteps; g++)
                    {//numberOfSteps loop [S]

                        Console.WriteLine($"Enter a description for step {g + 1}:");//Prompts the user for step(s) description
                        ingredientStepsDescription = Console.ReadLine();//Reads user input into ingredientStepsDescription variable

                        //Declaring the overloaded constructor of the Steps class
                        Steps stepsAdd = new Steps(ingredientStepsDescription);
                        recipeAdd.StepsClass.Add(stepsAdd);//Adding to the list

                        Console.WriteLine("\n");

                    }//numberOfSteps loop [E]




                }//numberOfRecipes loop [E]


            }// try [E]
            catch (Exception)//
            {// catch [S]

                throw;
            }// catch [E]

            Program.in_methodMenu();//Displays menu


        }//Capture Method [E]
        public static void displayRecipe()//Void method because we return a value
        {

            try//
            {//try [S]

                String recipe = "The Recipe";
                Console.ForegroundColor = red;
                Console.WriteLine("****************** " + recipe.ToUpper() + " ********************\n");
                Console.ResetColor();

                var chooseDisplayTable = new Table();//Declaring the an instance of a table class in spectre class 
                chooseDisplayTable.AddColumn("Select an option");//Prompts the user
                chooseDisplayTable.AddRow("1. Show all recipes");
                chooseDisplayTable.AddRow("2. Choose a recicpe");

                //Table style

                chooseDisplayTable.BorderColor(color: Color.DarkOrange);//Adding color to table
                chooseDisplayTable.Width(50);//Adding width to the table
                chooseDisplayTable.Border(TableBorder.Horizontal);//Setting the border style

                AnsiConsole.Write(chooseDisplayTable);//Displays to the console

                chooseDisplay = Convert.ToInt32(Console.ReadLine());//Read user into chooseDisplay variable

                switch (chooseDisplay)
                {//Switch case [S]
                    case 1:

                        //Sorting recipe names in recipes class list
                        recipeClassObject.Sort((x, y) => string.Compare(x.RecipeName, y.RecipeName));

                        var ingredientTable = new Table();//Declaring the an instance of a table class in spectre class for ingredient

                        //For each loop 
                        foreach (Recipe displayRecipeName in recipeClassObject)
                        {//1st foreach loop [S]

                            ingredientTable.AddColumn(new TableColumn(header: displayRecipeName.RecipeName));//A header for ingredients 


                            foreach (Ingredients printIngredients in displayRecipeName.IngredientsClass)
                            {//Ingredient foreach loop [S]

                                ingredientTable.AddColumn(new TableColumn(header: "Ingredients "));//A header Recipe

                                ingredientTable.AddRow("Ingredient Name ", printIngredients.IngredientName.ToUpper());//
                                ingredientTable.AddRow("Ingredient Quantity and Unit Measurement ", printIngredients.IngredientQuantity + "" + printIngredients.IngredientUnitMeasurement.ToUpper());//
                                ingredientTable.AddRow("Calories " + printIngredients.IngredientCalories);//
                                ingredientTable.AddRow("Food Group ", printIngredients.IngredientFoodGroup.ToUpper());//

                                //Table style

                                ingredientTable.BorderColor(color: Color.BlueViolet);//Adding color to table Border

                                ingredientTable.Width(50);//setting a width for the table

                                ingredientTable.Border(TableBorder.Horizontal);//Setting the border style

                            }//Ingredient foreach loop [E]

                            var tableSteps = new Table();//Declaring the an instance of a table class in spectre class for steps

                            tableSteps.AddColumn(new TableColumn(header: "Steps "));//Column for steps header

                            int stepCounter = 1;//To count each steps

                            //
                            foreach (Steps printSteps in displayRecipeName.StepsClass)
                            {
                                tableSteps.AddRow($"Step {stepCounter}: ", printSteps.IngredientStepsDescription);//
                                stepCounter++;

                                tableSteps.BorderColor(color: Color.DarkRed);//color to the border

                                tableSteps.Width(50);//Setting width size of the table

                                tableSteps.Border(TableBorder.Horizontal);//Setting the border style

                            }

                            AnsiConsole.Write(ingredientTable);//Diplay table to console
                            AnsiConsole.Write(tableSteps);//Diplay table to console

                        }//1st foreach loop [E]

                        break;
                    case 2:

                        int recipeCouter = 1;

                        var recipes = new Table();//

                        recipes.AddColumn(new TableColumn(header: "Recipes Recorded"));//

                        //
                        foreach (Recipe recipeAvailable in recipeClassObject)
                        {//foreach loop [S]
                            recipes.AddRow($"Recipe {recipeCouter}: ", recipeAvailable.RecipeName + " ");
                            recipeCouter++;
                            recipes.BorderColor(color: Color.DarkTurquoise);//color to the border
                            recipes.Width(50);//Setting width size of the table
                            recipes.Border(TableBorder.Horizontal);//Setting the border style
                            newRecipeNameVariable.Add(recipeAvailable.RecipeName);//Adding recipe

                            //
                            foreach (Ingredients addIngredients in recipeAvailable.IngredientsClass)
                            {
                                //
                                newIngredientNameVariable.Add(addIngredients.IngredientName);
                                newIngredientQuantityVariable.Add(addIngredients.IngredientQuantity);
                                newIngredientUnitMeasurementVariable.Add(addIngredients.IngredientUnitMeasurement);
                                newIngredientCaloriesVariable.Add(addIngredients.IngredientCalories);
                                newIngredientFoodGroupVariable.Add(addIngredients.IngredientFoodGroup);

                            }

                            //
                            foreach (Steps addSteps in recipeAvailable.StepsClass)
                            {
                                newIngredientStepsDescriptionVariable.Add(addSteps.IngredientStepsDescription);
                            }

                        }//foreach loop [E]

                        AnsiConsole.Write(recipes);//Diplays into console

                        Console.WriteLine("\n");

                        Console.WriteLine("Enter recipe name ");//Prompts user for recipe name
                        chooseRecipe = Console.ReadLine();//Reads user input into the variable serachRecipeName

                        Console.WriteLine("\n");

                        var tableStep = new Table();//Declaring the an instance of a table class in spectre class for steps

                        tableStep.AddColumn(new TableColumn(header: "Steps "));//Column for steps header

                        int stepCounterr = 1;//To count each steps

                        var choosenRecipe = new Table();
                        //for loop to search for the recipe 
                        for (int g = 0; g < newRecipeNameVariable.Count; g++)
                        {//for loop [S]
                            
                            if (chooseRecipe.Contains(newRecipeNameVariable[g]))
                            {
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
                            }
                            

                        }//for loop [E]                  
                        break;
                }//Switch case [E]

                Console.WriteLine("\n");

                Console.ForegroundColor = red;
                Console.WriteLine("**************************************************\n");
                Console.ResetColor();

                Program.in_methodMenu();//Calls in_menu method

            }//try [E]
            catch (Exception)
            {//catch [S]

                throw;
            }//catch [E]

                           

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
            {//if option 1 [S]
                var scaleMenu = new Table();

                //Prompts the user to select a scale
                scaleMenu.AddColumn("Choose a scale");
                scaleMenu.AddRow("1. First Scale by: 0.5");
                scaleMenu.AddRow("2. Second Scale by: 2");
                scaleMenu.AddRow("3. Third Scale by: 3");

                //Table style
                scaleMenu.BorderColor(color: Color.DarkGoldenrod);//setting the border color
                scaleMenu.Width(50);//setting table width
                scaleMenu.Border(TableBorder.Horizontal);//setting table border

                AnsiConsole.Write(scaleMenu);

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
                {//if scaleOption 1 [S]

                    for (int b = 0; b < newIngredientQuantityVariable.Count; b++)
                    {
                        ingredientsUpdateClassObject.ScaleQuantity = newIngredientQuantityVariable[b] * 0.5;//ingredientQuantityArray will be scale by 0.5 using double data type 


                        if (newIngredientUnitMeasurementVariable[b].Contains("cup") || newIngredientUnitMeasurementVariable[b].Contains("CUP"))
                        {
                            if (ingredientsUpdateClassObject.ScaleQuantity < 2)
                            {
                                ingredientsUpdateClassObject.UnitMeasurementUpdate = " Cup";//changes the units Measurement

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[b].ToUpper());//Adding row for ingredientName

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + "" + ingredientsUpdateClassObject.UnitMeasurementUpdate.ToUpper());//Adding row for ingredientQuantity and ingredientUnitMeasurement

                                AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console
                            }
                            


                        }
                        
                        else if(newIngredientUnitMeasurementVariable[b].Contains("tablespoons") || newIngredientUnitMeasurementVariable[b].Contains("tablespoon"))
                        {
                            if (ingredientsUpdateClassObject.ScaleQuantity >= 8)
                            {
                                ingredientsUpdateClassObject.UnitMeasurementUpdate = "24 teaspoons";//changes the units Measurement

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[b].ToUpper());//Adding row for ingredientName

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + " " + ingredientsUpdateClassObject.UnitMeasurementUpdate.ToUpper());//Adding row for ingredientQuantity and ingredientUnitMeasurement

                            }
                            AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console

                        }
                        else
                        {

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[b].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", newIngredientQuantityVariable[b] + " " + newIngredientUnitMeasurementVariable[b].ToUpper());//Adding row for ingredientQuantity and ingredientUnitMeasurement 

                            AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                        }

                        AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console

                    }
                    Program.in_methodMenu();//call to diplay menu

                }//if scaleOption 1 [E]

                else if (scaleOption == 2)
                {// if Scale Option 2 [S]
                    for (int o = 0; o < newIngredientQuantityVariable.Count; o++)
                    {
                        ingredientsUpdateClassObject.ScaleQuantity = newIngredientQuantityVariable[o] * 2;//ingredientQuantityArray will be scale by 2 using double data type

                        if (newIngredientUnitMeasurementVariable[o].Contains("tablespoon") || newIngredientUnitMeasurementVariable[o].Contains("tablespoons"))//if teaspoon found from user input the program will do the following calculation and update units measurements
                        {
                            if (ingredientsUpdateClassObject.ScaleQuantity <= 8)
                            {

                                ingredientsUpdateClassObject.UnitMeasurementUpdate = "1/2 Cup";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement " + ingredientsUpdateClassObject.ScaleQuantity + "" + ingredientsUpdateClassObject.UnitMeasurementUpdate);//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console

                            }

                        }else
                        {

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[o].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", newIngredientQuantityVariable[o] + " " + newIngredientUnitMeasurementVariable[o]);//Adding row for ingredient quantity and unit measurement

                            AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                        }

                    }
                    
                    Program.in_methodMenu();//Displays menu

                }// if Scale Option 2 [E]


                else if (scaleOption == 3)
                {//scaleOption 3 [S]
                    //for loop to search through the loop to the length of array
                    for (int n = 0; n < newIngredientQuantityVariable.Count; n++)
                    {
                        ingredientsUpdateClassObject.ScaleQuantity = newIngredientQuantityVariable[n] * 3;//ingredientQuantityArray will be scale to 3 using int data type 

                        if(ingredientsUpdateClassObject.ScaleQuantity > 1)//
                        {
                            ingredientsUpdateClassObject.UnitMeasurementUpdate = " Cups";//

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[n].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + " " + ingredientsUpdateClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                            AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console


                        }
                        else
                        {

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[n].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", newIngredientQuantityVariable[n] + " " + newIngredientUnitMeasurementVariable[n] + "\n");//Adding row for ingredient and unit measurement

                            AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console

                        }


                    }

                    Program.in_methodMenu();//Displays menu

                }//scaleOption 3 [E]

            }//if option 1 [E]
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
            {//if confirm [S]
                Console.WriteLine("\n");

                 

                for (int i = 0; i < newIngredientNameVariable.Count; i++)
                {

                    clearTable.AddColumn(new TableColumn(header: newRecipeNameVariable[i]));//A header for recipe Name 
                    clearTable.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients

                    clearTable.BorderColor(color: Color.DarkRed);//Adding color to table Border

                    clearTable.Width(60);//setting a width for the table

                    clearTable.Border(TableBorder.Horizontal);//Setting the border style

                    foreach (Recipe clear in recipeClassObject)
                    {
                        newRecipeNameVariable.Clear();
                        recipeClassObject.Clear();
                       

                    }

                    foreach(Ingredients clear in ingredientsClassObject)
                    {
                        ingredientsClassObject.Clear();
                    }

                    foreach (Steps clear in stepsClassObject)
                    {
                        stepsClassObject.Clear();

                    }

                    clearTable.AddRow("Ingredient Name : " + newIngredientNameVariable[i]);//Diplays the cleared input
                    clearTable.AddRow("Quantity : " + newIngredientQuantityVariable[i]);//Diplays the cleared input
                    clearTable.AddRow("Unit Measurement: " + newIngredientUnitMeasurementVariable[i]);//Diplays the cleared input



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


            }//if confirm [E]
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
                    for (int a = 0; a < newIngredientQuantityVariable.Count; a++)
                    {

                        if (ingredientsUpdateClassObject.ScaleQuantity == newIngredientQuantityVariable[a])//reseting the double object to original quantities
                        {
                            ingredientsUpdateClassObject.ScaleQuantity = newIngredientQuantityVariable[a];//reseting scaleQuantity property to newIngredientQuantityVariable original user input

                            ingredientsUpdateClassObject.UnitMeasurementUpdate = newIngredientUnitMeasurementVariable[a];//reseting the UnitMeasurementUpdate property to newIngredientUnitMeasurementVariable

                            resetTable.AddRow("Ingredient Name ", newIngredientNameVariable[a].ToUpper());//Adding row for ingredientNameArray

                            resetTable.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + " " + ingredientsUpdateClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray
                            
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


