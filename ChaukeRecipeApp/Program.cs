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
       

        static void Main(string[] args)
        {
            

            ConsoleColor red = ConsoleColor.Red;

            Console.ForegroundColor = red;
            Console.WriteLine("********************************************************************\n");
            Console.ResetColor();

            Console.ForegroundColor = red;
            Console.WriteLine("**********************Sanele RECIPE JOURNAL*************************\n");
            Console.ResetColor();

            Program.mainMenu();

        }

        //First menu is the main program menu that will cpature user input, display, reset, and clear also has exist option

        public static void mainMenu()
        {
            //The menu will prompt the user to select an option
            Console.WriteLine("Choose an option: \n" +
                "1. Create Recipe \n" +
                "2. Diplay Recipe \n" +
                "3. Clear Data \n" +
                "4. Reset Quantities \n" +
                "5. Exist \n");

            int menuOption = Convert.ToInt16(Console.ReadLine());//Reads the user input into variable menuOption 

            if(menuOption == 1)
            {
                //Calling the method to capture the recipe

                RecipeMethods.captureRecipe();
            }
            else if(menuOption == 2)
            {
                //Calling the method to diplay the recipe

                RecipeMethods.displayRecipe();


            }else if (menuOption == 3)
            {
                //Calling the method to clear data

                RecipeMethods.clearRecipeData();
            }
            else if (menuOption == 4)
            {
                //Calling the method to reset quantities

                RecipeMethods.resetQuantities();
            }
            else if (menuOption == 5)
            {
                //The Program will exist

                Environment.Exit(0);
            }



        }

        //In method menu will be used inside the methods in the RecipeMethod

        public static void in_methodMenu()
        {
            Console.WriteLine("Enter (1) to lauch menu else to exist ");
            int menu = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n");

            if (menu == 1)
            {
                //main program menu 
                Program.mainMenu();


            }
            else if (menu != 1)
            {
                //Exit program
                System.Environment.Exit(0);

            }

        }




    }
}
