using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_Test
{
    internal class recipe
    {
        //Property for capture method
        private List<string> recipeName;//field
        private List<string> ingredientName;//field
        private List<int> ingredientQuantity;//field
        private List<string> ingredientUnitMeasurement;//field
        private List<int> numberOfCalories;//field
        private List<int> selectFoodGroup;//field
        private List<string> stepsDescription;//field

        //*************************************************************

        //Properties for reset method
        private string newUnitMeasurement;//field
        private double newQuantityDouble;//field
        private int newQuantityInt;//field

        //*************************************************************

        //Properties for calculate calories
        private int calculateCalories;//field /to reset

        //*************************************************************


        //Getters and setters for capture method fields

        //Automatic Properties for recipeName
        public List<string> RecipeName
        {
            get;set;
        }

        //Automatic Properties for ingredientName
        public List<string> IngredientName
        {
            get; set;
        }

        //Automatic Properties for ingredientQuantity 
        public List<int> IngredientQuantity
        {
            get; set;
        }

        //Automatic Properties for ingredientUnitMeasurement
        public List<string> IngredientUnitMeasurement
        {
            get; set;
        }

        //Automatic Properties for numberOfCalories
        public List<int> NumberOfCalories
        {
            get; set;
        }

        //Automatic Properties for selectFoodGroup
        public List<int> SelectFoodGroup
        {
            get; set;
        }

        //Automatic Properties for stepsDescription 
        public List<string> StepsDescription
        {
            get; set;
        }

        //*************************************************************

        //Getters and setters for reset method fields

        //Automatic Properties for newUnitMeasurement
        public string NewUnitMeasurement
        {
            get;set;
        }

        //Automatic Properties for newQuantityDouble
        public double NewQuantityDouble
        {
            get;set;
        }

        //Automatic Properties for newQuantityInt
        public int NewQuantityInt
        {
            get;set;
        }

        //*************************************************************

        //Getters and setters for calculateCalories method

        //Automatic Properties for calculateCalories
        public int CalculateCalories
        {
            get;set;
        }



    }
}
