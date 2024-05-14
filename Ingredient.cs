// Defining a namespace for the RecipeApp
namespace RecipeApp
{
    // Defining the Ingredient class
    public class Ingredient
    {
        // Declaring properties for ingredient details: name, quantity, unit, calories, and food group
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string Unit { get; set; } // Unit of measurement for the ingredient
        public double Calories { get; set; } // Calorie content of the ingredient
        public string FoodGroup { get; set; } // Food group to which the ingredient belongs
    }
}
