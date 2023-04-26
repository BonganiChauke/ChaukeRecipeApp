using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ChaukeRecipeApp
{
    internal class Program
    {
        

        //color to style the program
        static ConsoleColor red = ConsoleColor.Red;

        //main to execute the program
        static void Main(string[] args)
        {
                      
            while (true)
            {
                Console.ForegroundColor = red;
                Console.WriteLine("**************************************************\n");
                Console.ResetColor();

                Console.ForegroundColor = red;
                Console.WriteLine("***************Sanele RECIPE JOURNAL**************\n");
                Console.ResetColor();               

                Program.mainMenu();//Calling the main method to prompt the user

            }
            

        }

        //First menu is the main program menu that will cpature user input, display, reset, and clear also has exist option

        public static void mainMenu()
        {
            //Declaring the an instance of a table class in spectre class for ingredient
            var tableMenu = new Table();

            //Adding content to the rows
            tableMenu.AddColumn("Menu Choose an option:");
            tableMenu.AddRow("1. Create Recipe ");
            tableMenu.AddRow("2. Diplay Recipe ");
            tableMenu.AddRow("3. Scale Quantities ");
            tableMenu.AddRow("4. Clear Data ");
            tableMenu.AddRow("5. Reset Quantities ");
            tableMenu.AddRow("6. Exist ");

            tableMenu.BorderColor(color: Color.BlueViolet);//Adding color to table Border

            tableMenu.Width(50);//setting a width for the table

            tableMenu.Border(TableBorder.Horizontal);//Setting the border style 

            AnsiConsole.Write(tableMenu);//diplay the table to the console


            int menuOption = Convert.ToInt16(Console.ReadLine());//Reads the user input into variable menuOption 

            if (menuOption == 1)
            {
                //Calling the method to capture the recipe

                RecipeMethods.captureRecipe();
            }
            else if (menuOption == 2)
            {
                //Calling the method to diplay the recipe

                RecipeMethods.displayRecipe();


            }
            else if (menuOption == 3)
            {
                //Calling the method to scale Quantities

                RecipeMethods.scaleQuantities();

                
            }
            else if (menuOption == 4)
            {
                //Calling the method to clear data

                RecipeMethods.clearRecipeData();


            }else if (menuOption == 5)
            {
                //Calling the method to reset quantities

                RecipeMethods.resetQuantities();
            }
            else if (menuOption == 6)
            {
                //The Program will exist

                Environment.Exit(0);
            }

            Console.ForegroundColor = red;
            Console.WriteLine("**************************************************\n");
            Console.ResetColor();



        }

        //In method menu will be used inside the methods in the RecipeMethod

        public static void in_methodMenu()
        {

            //Declaring the an instance of a table class in spectre class for ingredient
            var tableMenu = new Table();

            //Adding content to the table
            tableMenu.AddColumn("Menu Choose an option: ");
            tableMenu.AddRow("Enter (1) to lauch menu \n ---> Any number to exist ");
            

            tableMenu.BorderColor(color: Color.Aquamarine3);//Adding color to table Border

            tableMenu.Width(50);//setting a width for the table

            tableMenu.Border(TableBorder.Horizontal);//Setting the border style 

            AnsiConsole.Write(tableMenu);//Diplaying the table to the console

            
            int menu = Convert.ToInt32(Console.ReadLine());//reads user input to value
            

            Console.WriteLine("\n");

            if (menu == 1 )
            {
                //Calling the main program menu 
                Program.mainMenu();


            }
            else if (menu != 1 )
            {
                //Exit program
                System.Environment.Exit(0);

            }

            Console.ForegroundColor = red;
            Console.WriteLine("**************************************************\n");
            Console.ResetColor();

        }




    }
}
