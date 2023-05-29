using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ChaukeRecipeApp
{
    public class RecipeMethods
    {
        //Declaring a delegate to warm the user 
        public delegate int warningCalories();

        //
        public static RecipeMethods objectClass = new RecipeMethods();

        //Declaring a object reference to link the delegate to calculate calories
        public warningCalories warnUser = objectClass.calculateTotalCalories;

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
                Console.WriteLine("**************************** " + createRecipe.ToUpper() + " ***************************\n");
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
                        Console.WriteLine("************************ " + foodCalories.ToUpper() + " *********************\n");
                        Console.ResetColor();

                        var descriptionOfFoodGroupCalories = new Table();//Declaring the an instance of a table class in spectre class      

                        descriptionOfFoodGroupCalories.AddColumn(new TableColumn(header: "Calories"));//A header for calories 
                        descriptionOfFoodGroupCalories.AddColumn(new TableColumn(header: "Food Group"));//A header Food Group

                        //Table style
                        descriptionOfFoodGroupCalories.BorderColor(color: Color.Chartreuse2);//Adding color to table Border
                        descriptionOfFoodGroupCalories.Width(70);//setting a width for the table
                        descriptionOfFoodGroupCalories.Border(TableBorder.Horizontal);//Setting the border style

                        //An explanation of what a food group is and what are calories
                        descriptionOfFoodGroupCalories.AddRow("Calories are amounts of energy from food and drinks measured in kcals," +
                        " Calories put energy into our bodies to perform normal bodily functions and physical activity", "A food group is a collection of foods that share similar nutritional properties or biological classifications" +
                        "List of nutrition guides typically divide foods into food groups and Recommended Dietary Allowance recommend daily servings of each group for a healthy diet");

                        AnsiConsole.Write(descriptionOfFoodGroupCalories);//Displays to the console

                        Console.WriteLine("\n");

                        Console.WriteLine($"Enter number of calories for: {ingredientName} ingredient ");//Prompts user for number of calories
                        ingredientCalories = Convert.ToInt32(Console.ReadLine());//Reads user input into ingredientCalories

                        //Calling the delegate
                        Console.WriteLine(objectClass.warnUser);

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
                        foodGroup.BorderColor(color: Color.DarkOrange3_1);//Adding a color for table border
                        foodGroup.Width(70);//Setting a width for the table
                        foodGroup.Border(TableBorder.Horizontal);//Setting the table border style

                        AnsiConsole.Write(foodGroup);//Displays to the console

                        selectFoodGroup = Convert.ToInt32(Console.ReadLine());//Reads user input into variable ingredientFoodGroup

                        Console.WriteLine("\n");

                        var foodGroupDetails = new Table();//Declaring the an instance of a table class in spectre class
                        //foodGroupDetails.AddColumn("Food Group Brieft");//Column for brieft
                        foodGroupDetails.BorderColor(color: Color.DarkGoldenrod);//Setting the table color
                        foodGroupDetails.Width(70);//Setting a width for the table
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
                    Console.WriteLine("**************************** " + stepss.ToUpper() + " ************************************\n");
                    Console.ResetColor();

                    Console.WriteLine("\n");

                    //---------------------------------------Steps section

                    Console.WriteLine("Enter number of steps");//Prompts the user for number of steps
                    numberOfSteps = Convert.ToInt32(Console.ReadLine());//Reads user input into number of steps variable

                    Console.WriteLine("\n");

                    for (int g = 0; g < numberOfSteps; g++)
                    {//numberOfSteps loop [S]

                        Console.Write($"Enter a description for step {g + 1}: ");//Prompts the user for step(s) description
                        ingredientStepsDescription = Console.ReadLine();//Reads user input into ingredientStepsDescription variable

                        //Declaring the overloaded constructor of the Steps class
                        Steps stepsAdd = new Steps(ingredientStepsDescription);
                        recipeAdd.StepsClass.Add(stepsAdd);//Adding to the list



                    }//numberOfSteps loop [E]
                    Console.WriteLine("\n");



                }//numberOfRecipes loop [E]


            }// try [E]
            catch (Exception)//
            {// catch [S]

                throw;
            }// catch [E]

            Program.in_methodMenu();//Displays menu


        }//Capture Method [E]
        public static void displayRecipe()//Void method because we return a value
        {//display method [S]

            try//
            {//try [S]

                String recipe = "The Recipe";
                Console.ForegroundColor = red;
                Console.WriteLine("*************************** " + recipe.ToUpper() + " *******************************\n");
                Console.ResetColor();

                var chooseDisplayTable = new Table();//Declaring the an instance of a table class in spectre class 
                chooseDisplayTable.AddColumn("Select an option");//Prompts the user
                chooseDisplayTable.AddRow("1. Show all recipes");
                chooseDisplayTable.AddRow("2. Choose a recicpe");

                //Table style

                chooseDisplayTable.BorderColor(color: Color.DarkOrange);//Adding color to table
                chooseDisplayTable.Width(70);//Adding width to the table
                chooseDisplayTable.Border(TableBorder.Horizontal);//Setting the border style

                AnsiConsole.Write(chooseDisplayTable);//Displays to the console

                chooseDisplay = Convert.ToInt32(Console.ReadLine());//Read user into chooseDisplay variable

                switch (chooseDisplay)
                {//Switch case [S]
                    case 1:

                        //Sorting recipe names in recipes class list
                        recipeClassObject.Sort((x, y) => string.Compare(x.RecipeName, y.RecipeName));

                        //For each loop through the collection
                        foreach (Recipe displayRecipeName in recipeClassObject)
                        {//1st foreach loop [S]

                            //nested foreach loops to loop through the items in the collections
                            foreach (Ingredients printIngredients in displayRecipeName.IngredientsClass)
                            {//Ingredient foreach loop [S]

                                var ingredientTable = new Table();//Declaring the an instance of a table class in spectre class

                                ingredientTable.AddColumn(new TableColumn(header: $"{displayRecipeName.RecipeName.ToUpper()} Recipe"));//Header displays recipe name
                                ingredientTable.AddColumn(new TableColumn(header: "Ingredients"));//Header for ingredients
                                ingredientTable.AddRow("Ingredient Name", printIngredients.IngredientName.ToUpper());//Adding row to diplay ingredient name
                                ingredientTable.AddRow("Quantity and Measurement", printIngredients.IngredientQuantity + " " + printIngredients.IngredientUnitMeasurement.ToUpper());//Adding row to diplay quantity and unit measurement
                                ingredientTable.AddRow("Calories", printIngredients.IngredientCalories + "");//Adding row to diplay calories
                                ingredientTable.AddRow("Food Group", printIngredients.IngredientFoodGroup.ToUpper());//Adding row to diplay food group

                                //Table style
                                ingredientTable.BorderColor(color: Color.BlueViolet);//Adding color to table Border
                                ingredientTable.Width(70);//setting a width for the table
                                ingredientTable.Border(TableBorder.Horizontal);//Setting the border style

                                Console.WriteLine("\n");

                                AnsiConsole.Write(ingredientTable);//Diplay table to console


                            }//Ingredient foreach loop [E]


                            int stepCounter = 1;//To count each steps
                            var tableSteps = new Table();//Declaring the an instance of a table class in spectre class

                            tableSteps.AddColumn(new TableColumn(header: "Steps"));//Header for steps

                            //
                            foreach (Steps printSteps in displayRecipeName.StepsClass)
                            {
                                //Adding row to diplay steps
                                tableSteps.AddRow($"Step {stepCounter}: " + printSteps.IngredientStepsDescription);
                                stepCounter++;

                                //Table Style
                                tableSteps.BorderColor(color: Color.DarkRed);//color to the border
                                tableSteps.Width(70);//Setting width size of the table
                                tableSteps.Border(TableBorder.Horizontal);//Setting the border style

                            }

                            AnsiConsole.Write(tableSteps);//Display table to console

                        }//1st foreach loop [E]


                        break;
                    case 2:

                        Console.WriteLine("\n");

                        var availableRecipes = new Table();//Declaring the an instance of a table class in spectre class
                        availableRecipes.AddColumn(new TableColumn(header: "  Recipes saved"));//Header for recipes saved

                        //nested foreach loops to loop through the collection and add to new variable that will used in for loops
                        foreach (Recipe recipeAvailable in recipeClassObject)
                        {//foreach loop [S]

                            newRecipeNameVariable.Add(recipeAvailable.RecipeName);//Adding recipe
                            availableRecipes.AddRow(recipeAvailable.RecipeName + " Recipe ");
                            //Table style
                            availableRecipes.BorderColor(color: Color.DarkMagenta);//Adding color to table
                            availableRecipes.Width(70);//Adding width to table
                            availableRecipes.Border(TableBorder.HeavyHead);//Adding border style to table

                            //loop through the collection 
                            foreach (Ingredients addIngredients in recipeAvailable.IngredientsClass)
                            {
                                //adding user input to the new variables so i can used them on for loops
                                newIngredientNameVariable.Add(addIngredients.IngredientName);
                                newIngredientQuantityVariable.Add(addIngredients.IngredientQuantity);
                                newIngredientUnitMeasurementVariable.Add(addIngredients.IngredientUnitMeasurement);
                                newIngredientCaloriesVariable.Add(addIngredients.IngredientCalories);
                                newIngredientFoodGroupVariable.Add(addIngredients.IngredientFoodGroup);

                            }

                            //loop through the collection and adding user input to the new variable
                            foreach (Steps addSteps in recipeAvailable.StepsClass)
                            {
                                newIngredientStepsDescriptionVariable.Add(addSteps.IngredientStepsDescription);
                            }

                        }//foreach loop [E]

                        //AnsiConsole.Write(recipes);//Diplays into console
                        AnsiConsole.Write(availableRecipes);

                        Console.WriteLine("\n");

                        Console.WriteLine("Enter recipe name ");//Prompts user for recipe name
                        chooseRecipe = Console.ReadLine();//Reads user input into the variable serachRecipeName

                        Console.WriteLine("\n");

                        var tableStep = new Table();//Declaring the an instance of a table class in spectre class for steps

                        tableStep.AddColumn(new TableColumn(header: "Steps "));//Column for steps header

                        int stepCounterr = 1;//To count each steps

                        var choosenRecipe = new Table();//Declaring the an instance of a table class in spectre class
                        //for loop to search for the recipe 

                        //Find function to serach through the elements that finds matching values and return corresponding values
                        Recipe recipeFind = recipeClassObject.Find(r => r.RecipeName == chooseRecipe);

                        for (int i = 0; i < newRecipeNameVariable.Count; i++)
                        {
                            if (chooseRecipe.Contains(newRecipeNameVariable[i]))//if user input matches the saved recipe
                            {
                                //foreach to loop through the collection
                                foreach (Ingredients item in recipeFind.IngredientsClass)
                                {
                                    var tableChoosenRecipe = new Table();//Declaring the an instance of a table class in spectre class

                                    tableChoosenRecipe.AddColumn(new TableColumn(header: recipeFind.RecipeName + " Recipe "));//Adding header for recipe name
                                    tableChoosenRecipe.AddColumn(new TableColumn(header: "Ingredients"));//adding for ingredients name

                                    //Table Style
                                    tableChoosenRecipe.BorderColor(color: Color.DarkRed);//Adding color to table
                                    tableChoosenRecipe.Width(70);//Adding width to table
                                    tableChoosenRecipe.Border(TableBorder.Horizontal);//Adding border style to table

                                    //To diplay user inputs
                                    tableChoosenRecipe.AddRow("Ingredient Name: ", item.IngredientName);
                                    tableChoosenRecipe.AddRow("Ingredient Quantity and Measureemt: ", item.IngredientQuantity + " " + item.IngredientUnitMeasurement);
                                    tableChoosenRecipe.AddRow("Calories ", item.IngredientCalories + "");
                                    tableChoosenRecipe.AddRow("Food Group", item.IngredientFoodGroup);
                                    tableChoosenRecipe.AddRow("");


                                    int counterStep = 1;//To count steps
                                    //foreach loop to loop through the collection 
                                    foreach (Steps showSteps in recipeFind.StepsClass)
                                    {
                                        tableChoosenRecipe.AddRow($"Step {counterStep}: ", showSteps.IngredientStepsDescription.ToUpper());//Adding row to diplay steps
                                        counterStep++;
                                    }

                                    AnsiConsole.Write(tableChoosenRecipe);//Display table to console
                                }

                            }
                            else
                            {

                            }

                        }

                        break;
                }//Switch case [E]

                Console.WriteLine("\n");

                Console.ForegroundColor = red;
                Console.WriteLine("**********************************************************************\n");
                Console.ResetColor();

                Program.in_methodMenu();//Calls in_menu method

            }//try [E]
            catch (Exception)
            {//catch [S]

                throw;
            }//catch [E]



        }//Diplay method [E]
        public static void scaleQuantities()
        {
            Console.WriteLine("\n");

            Console.ForegroundColor = red;
            Console.WriteLine("**********************************************************************\n");
            Console.ResetColor();

            var scaleTable = new Table();//

            scaleTable.AddColumn(new TableColumn(header: "Do you want to scale the quantities"));//

            //Menu to prompt the user to scale quantities
            scaleTable.AddRow("1. YES");
            scaleTable.AddRow("2. NO");
            scaleTable.BorderColor(color: Color.Chartreuse4);//
            scaleTable.Width(70);//Setting table width
            scaleTable.Border(TableBorder.Horizontal);//

            AnsiConsole.Write(scaleTable);//

            int option = Convert.ToInt16(Console.ReadLine());//Read user input to option variable

            Console.WriteLine("\n");
            Console.ForegroundColor = red;
            Console.WriteLine("**********************************************************************\n");
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
                scaleMenu.Width(70);//setting table width
                scaleMenu.Border(TableBorder.Horizontal);//setting table border

                AnsiConsole.Write(scaleMenu);//Diplays the table to console

                int scaleOption = Convert.ToInt16(Console.ReadLine());//Reads the user input to scaleOption variable

                var ingredientQuantityUpdate = new Table();//Declaring the an instance of a table class in spectre class for ingredient

                ingredientQuantityUpdate.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients 
                ingredientQuantityUpdate.AddColumn(new TableColumn(header: "Recipe "));//A header Recipe

                ingredientQuantityUpdate.BorderColor(color: Color.BlueViolet);//Adding color to table Border

                ingredientQuantityUpdate.Width(70);//setting a width for the table

                ingredientQuantityUpdate.Border(TableBorder.Horizontal);//Setting the border style

                String recipe = "Scale";
                Console.ForegroundColor = red;
                Console.WriteLine("******************************* " + recipe.ToUpper() + " *********************************\n");
                Console.ResetColor();

                foreach (Recipe recipeAvailable in recipeClassObject)
                {//foreach loop [S]

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


                if (scaleOption == 1)
                {//if scaleOption 1 [S]

                    for (int b = 0; b < newIngredientQuantityVariable.Count; b++)
                    {//option for loop [S]
                        ingredientsUpdateClassObject.ScaleQuantity = newIngredientQuantityVariable[b] * 0.5;//ingredientQuantityArray will be scale by 0.5 using double data type 


                        if (newIngredientUnitMeasurementVariable[b].Contains("cup") || newIngredientUnitMeasurementVariable[b].Contains("CUP"))
                        {
                            if (ingredientsUpdateClassObject.ScaleQuantity < 2)
                            {
                                ingredientsUpdateClassObject.UnitMeasurementUpdate = " Cup";//changes the units Measurement

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[b].ToUpper());//Adding row for ingredientName

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + "" + ingredientsUpdateClassObject.UnitMeasurementUpdate.ToUpper());//Adding row for ingredientQuantity and ingredientUnitMeasurement

                                ingredientQuantityUpdate.AddRow("Calories ", ingredientCalories + "");

                                ingredientQuantityUpdate.AddRow("Food Gruop ", ingredientFoodGroup);


                            }
                        }

                        else if (newIngredientUnitMeasurementVariable[b].Contains("tablespoons") || newIngredientUnitMeasurementVariable[b].Contains("tablespoon"))
                        {
                            if (ingredientsUpdateClassObject.ScaleQuantity >= 8)
                            {
                                ingredientsUpdateClassObject.UnitMeasurementUpdate = "24 teaspoons";//changes the units Measurement

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[b].ToUpper());//Adding row for ingredientName

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + " " + ingredientsUpdateClassObject.UnitMeasurementUpdate.ToUpper());//Adding row for ingredientQuantity and ingredientUnitMeasurement

                                ingredientQuantityUpdate.AddRow("Calories ", ingredientCalories + "");

                                ingredientQuantityUpdate.AddRow("Food Gruop ", ingredientFoodGroup);
                            }


                        }
                        else
                        {//else 1st option [S]

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[b].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + " " + newIngredientUnitMeasurementVariable[b].ToUpper());//Adding row for ingredientQuantity and ingredientUnitMeasurement 

                            ingredientQuantityUpdate.AddRow("Calories ", ingredientCalories + "");

                            ingredientQuantityUpdate.AddRow("Food Gruop ", ingredientFoodGroup);

                            AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console

                        }//else 1st option [E]



                    }//option for loop [E]
                    AnsiConsole.Write(ingredientQuantityUpdate);//Display the quantity to console
                    Console.WriteLine("\n");
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

                                ingredientsUpdateClassObject.UnitMeasurementUpdate = "1 Cup";//ingredientUnitMeasurementArray will have a new updated value

                                ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[o].ToUpper());//Adding row for ingredientNameArray

                                ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + "" + ingredientsUpdateClassObject.UnitMeasurementUpdate);//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                                ingredientQuantityUpdate.AddRow("Calories ", ingredientCalories + "");

                                ingredientQuantityUpdate.AddRow("Food Gruop ", ingredientFoodGroup);


                            }

                        }
                        else
                        {

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[o].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + " " + newIngredientUnitMeasurementVariable[o]);//Adding row for ingredient quantity and unit measurement

                            ingredientQuantityUpdate.AddRow("Calories ", ingredientCalories + "");

                            ingredientQuantityUpdate.AddRow("Food Gruop ", ingredientFoodGroup);

                        }

                    }
                    AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                    Console.WriteLine("\n");
                    Program.in_methodMenu();//Displays menu

                }// if Scale Option 2 [E]


                else if (scaleOption == 3)
                {//scaleOption 3 [S]
                    //for loop to search through the loop to the length of array
                    for (int n = 0; n < newIngredientQuantityVariable.Count; n++)
                    {
                        ingredientsUpdateClassObject.ScaleQuantity = newIngredientQuantityVariable[n] * 3;//ingredientQuantityArray will be scale to 3 using int data type 

                        if (ingredientsUpdateClassObject.ScaleQuantity > 1)//
                        {
                            ingredientsUpdateClassObject.UnitMeasurementUpdate = " Cups";//

                            ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[n].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + " " + ingredientsUpdateClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                            ingredientQuantityUpdate.AddRow("Calories ", ingredientCalories + "");

                            ingredientQuantityUpdate.AddRow("Food Gruop ", ingredientFoodGroup);

                            AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                        }
                        else
                        {
                            ingredientQuantityUpdate.AddRow("Ingredient Name ", newIngredientNameVariable[n].ToUpper());//Adding row for ingredientNameArray

                            ingredientQuantityUpdate.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + " " + newIngredientUnitMeasurementVariable[n] + "\n");//Adding row for ingredient and unit measurement

                            ingredientQuantityUpdate.AddRow("Calories ", ingredientCalories + "");

                            ingredientQuantityUpdate.AddRow("Food Gruop ", ingredientFoodGroup);

                            AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                        }
                    }
                    AnsiConsole.Write(ingredientQuantityUpdate);//Diplay table to console
                    Console.WriteLine("\n");
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

            var confirmation = new Table();

            //Prompts the user 
            confirmation.AddColumn(new TableColumn(header: "Confirm : Are you sure ??!!"));//
            confirmation.AddRow("1.Yes");
            confirmation.AddRow("2.No");
            

            //Table Style
            confirmation.BorderColor(color: Color.LightSlateGrey);//Adding color to table Border
            confirmation.Width(70);//setting a width for the table
            confirmation.Border(TableBorder.Horizontal);//Setting the border style
            AnsiConsole.Write(confirmation);//Diplays the console

            int confirm = Convert.ToInt16(Console.ReadLine());//user input save in the variable

            Console.WriteLine("\n");




            if (confirm == 1)
            {//if confirm [S]

                Console.WriteLine("\n");

                //for each to loop through
                foreach (Recipe recipeAvailable in recipeClassObject.ToList())
                {//foreach loop [S]

                    recipeClassObject.Clear();//Clears the list

                    //Check if the values are too default values
                    if (recipeAvailable.RecipeName == "")
                    {
                        Console.WriteLine("Recipe Cleared");//Alerts user
                    }

                    //for each to loop through 
                    foreach (Ingredients addIngredients in ingredientsClassObject.ToList())
                    {
                        ingredientsClassObject.Remove(addIngredients);//Clears the list

                        //Check if the values are too default values
                        if (addIngredients.IngredientName == "" && addIngredients.IngredientQuantity == 0 && addIngredients.IngredientUnitMeasurement == "" && addIngredients.IngredientCalories == 0 && addIngredients.IngredientFoodGroup == "")
                        {

                            Console.WriteLine("All Ingredients cleared");//Alerts user
                            
                        }
                        
                    }

                    //for each to loop through
                    foreach (Steps addSteps in stepsClassObject.ToList())
                    {
                        
                        stepsClassObject.Clear();//Clears the list

                        if (addSteps.IngredientStepsDescription == "")
                        {
                            Console.WriteLine("All Steps cleared");//Alerts the user
                        }
                    }

                }//foreach loop [E]


                clearTable.AddColumn(new TableColumn(header: "re"));//A header for recipe Name 
                clearTable.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients

                clearTable.BorderColor(color: Color.DarkRed);//Adding color to table Border
                clearTable.Width(70);//setting a width for the table
                clearTable.Border(TableBorder.Horizontal);//Setting the border style

                

                //clearTable.AddRow("Ingredient Name ", newIngredientNameVariable[i]);//Diplays the cleared input
                //clearTable.AddRow("Quantity  ", clearIngredient.IngredientQuantity + "");//Diplays the cleared input
                //clearTable.AddRow("Unit Measurement ", clearIngredient.IngredientUnitMeasurement);//Diplays the cleared input


                AnsiConsole.Write(clearTable);//Display the table

                Console.WriteLine("\n");

                var newRecipe = new Table();// 

                newRecipe.AddColumn(new TableColumn(header: "Recipe Cleared: Enter a new recipe "));
                newRecipe.AddRow("1. Yes");
                newRecipe.AddRow("2. No");

                newRecipe.BorderColor(color: Color.DarkSeaGreen1);//Adding color to table Border
                newRecipe.Width(70);//setting a width for the table
                newRecipe.Border(TableBorder.Horizontal);//Setting the border style
                AnsiConsole.Write(newRecipe);//Displays to console

                int enterNewRecipe = int.Parse(Console.ReadLine());//reads the user input to the variable
                Console.WriteLine("\n");

                switch (enterNewRecipe)
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
        {//reset Quantities [S]
            var confirmation = new Table();//Declaring the an instance of a table class in spectre class

            //Prompts the user 
            confirmation.AddColumn(new TableColumn(header: "Reset the quantities : Are you sure ??!!"));//
            confirmation.AddRow("1.Yes");
            confirmation.AddRow("2.No");

            //Table Style
            confirmation.BorderColor(color: Color.LightSlateGrey);//Adding color to table Border
            confirmation.Width(70);//setting a width for the table
            confirmation.Border(TableBorder.Horizontal);//Setting the border style
            AnsiConsole.Write(confirmation);//Diplays the console


            int reset = int.Parse(Console.ReadLine());//Read user input

            Console.WriteLine("\n");

            var resetTable = new Table();//Declaring the an instance of a table class in spectre class 
            resetTable.AddColumn(new TableColumn(header: "Ingredients "));//A header for ingredients 
            resetTable.AddColumn(new TableColumn(header: "Recipe "));//A header Recipe

            //Table style
            resetTable.BorderColor(color: Color.Magenta1);//Adding color to table Border
            resetTable.Width(70);//setting a width for the table
            resetTable.Border(TableBorder.Horizontal);//Setting the border style


            switch (reset)
            {
                case 1:
                    //Reset the quantities

                    foreach (Recipe recipeAvailable in recipeClassObject)
                    {//foreach loop [S]

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

                    //for loop to search the loop
                    for (int a = 0; a < newIngredientQuantityVariable.Count; a++)
                    {

                        ingredientsUpdateClassObject.ScaleQuantity = newIngredientQuantityVariable[a];//reseting scaleQuantity property to newIngredientQuantityVariable original user input

                        ingredientsUpdateClassObject.UnitMeasurementUpdate = newIngredientUnitMeasurementVariable[a];//reseting the UnitMeasurementUpdate property to newIngredientUnitMeasurementVariable

                        resetTable.AddRow("Ingredient Name ", newIngredientNameVariable[a].ToUpper());//Adding row for ingredientNameArray

                        resetTable.AddRow("Quantity and Unit Measurement ", ingredientsUpdateClassObject.ScaleQuantity + " " + ingredientsUpdateClassObject.UnitMeasurementUpdate.ToUpper() + "\n");//Adding row for ingredientQuantityArray and ingredientUnitMeasurementArray

                    }
                    AnsiConsole.Write(resetTable);//Displays to the console
                    Console.WriteLine("\n");
                    Program.in_methodMenu();//Displays menu
                    break;


                case 2:
                    //Call the menu

                    Program.in_methodMenu();//Displays menu

                    break;

            }




        }//reset Quantities

        public int calculateTotalCalories()//Method to calculate the total calories in a single recipe
        {//calculate calories [S]

            //Decalring the total value 
            int totalCalories = 0;

            foreach (Ingredients caloriesTotal in ingredientsClassObject)
            {
                //calculates the total in the recipe
                totalCalories += caloriesTotal.IngredientCalories;
                //totalCalories = ingredientsClassObject.Sum(x => Convert.ToInt32(x));

                if (totalCalories > 300)//Checks the if totalCalories exceeds 300
                {
                    Console.WriteLine("This recipe has more than 300 coalories");//Warms the user
                }
            }

            

            return totalCalories;//return int statement


        }//calculate calories [E]
    }
}


