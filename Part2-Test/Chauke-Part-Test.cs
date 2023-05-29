using ChaukeRecipeApp;

namespace Part2_Test
{
    [TestClass]
    public class UnitTest1
    {
        //declaring object reference
        RecipeMethods recipeMethods = new RecipeMethods();
        Ingredients ingredientClass = new Ingredients();
        Recipe recipeClass = new Recipe();
        Steps stepsClass = new Steps();
        [TestMethod]
        public void TestMethod1()
        {
            //condition to test
            recipeClass.RecipeName = "Cheese Cake";
            ingredientClass.IngredientName = "Salt";
            ingredientClass.IngredientQuantity = 5;
            ingredientClass.IngredientUnitMeasurement = "cups";
            ingredientClass.IngredientFoodGroup = "Starchy";
            ingredientClass.IngredientCalories = 301;

            stepsClass.IngredientStepsDescription = "Add Salt to chedder";
            assertEquals(299, 301);
            recipeMethods.calculateTotalCalories();

        }

        private void assertEquals(int v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}