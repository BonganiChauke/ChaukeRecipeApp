using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_Test
{
    internal class methods
    {
        //Global Variables

        //Class reference object

        static recipe Recipe = new recipe();

        public static int numberOfRecipe;//
        public static int numberOfIngredients;//
        public static int numberOFSteps;//

        //A method to capture the recipe
        public static void captureRecipe()
        {
            String captureRecipe = "";//

            
            Console.WriteLine("Enter number of recipe:");//
            numberOfRecipe = int.Parse(Console.ReadLine());//

            //
            for (int i = 0; i < numberOfRecipe; i++)
            {
                Console.WriteLine("Enter a recipe name: ");
                Recipe.RecipeName.Add(Console.ReadLine());

                

            }

            //return captureRecipe;
        }

    }
}
