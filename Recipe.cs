// Importing necessary libraries
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // Defining the Recipe class
    public class Recipe
    {
        // Declaring private fields for ingredients, original ingredients, steps, and scale status
        private List<Ingredient> ingredients;
        private List<Ingredient> originalIngredients;
        private List<Step> steps;
        private bool isScaled = false;

        // Declaring a public property for the recipe name
        public string Name { get; set; }

        // Declaring a delegate for handling exceeding calories event
        public delegate void ExceedsCaloriesHandler(string message);
        // Declaring an event for exceeding calories
        public event ExceedsCaloriesHandler ExceedsCaloriesEvent;

        // Method to enter recipe details
        public void EnterRecipe()
        {
            // Displaying header for entering recipe details
            Console.WriteLine("\n" + new string('=', Console.WindowWidth - 1));
            Console.WriteLine($"{new string(' ', (Console.WindowWidth - 20) / 2)}\x1bRECIPE INGREDIENTS STEPS\x1b");
            Console.WriteLine(new string('=', Console.WindowWidth - 1));

            // Entering recipe name
            Console.Write("\nEnter the name of the recipe: ");
            Name = Console.ReadLine();

            // Entering ingredients
            Console.WriteLine("\n\x1bIngredients\x1b");
            Console.WriteLine(new string('-', Console.WindowWidth - 1));

            // Entering number of ingredients
            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients;
            while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
            ingredients = new List<Ingredient>(numIngredients);
            originalIngredients = new List<Ingredient>(numIngredients);

            // Looping through ingredients and entering details
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter details for ingredient #{i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                double quantity;
                Console.Write("Quantity: ");
                while (!double.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                Console.Write("Calories: ");
                double calories;
                while (!double.TryParse(Console.ReadLine(), out calories) || calories <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();
                ingredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
                originalIngredients.Add(new Ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
            }

            // Entering steps
            Console.WriteLine("\n\x1b[1mSteps\x1b[0m");
            Console.WriteLine(new string('-', Console.WindowWidth - 1));

            // Entering number of steps
            Console.WriteLine("Enter the number of steps:");
            int numSteps;
            while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
            steps = new List<Step>(numSteps);

            // Looping through steps and entering descriptions
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step #{i + 1}:");
                string description = Console.ReadLine();
                steps.Add(new Step { Description = description });
            }

            // Displaying entered recipe
            DisplayRecipe();

            // Asking user if they want to scale the recipe
            string scaleChoice;
            do
            {
                Console.WriteLine("\nDo you want to scale the recipe? (yes/no)");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                scaleChoice = Console.ReadLine().ToLower();
                Console.ResetColor();
            } while (scaleChoice != "yes" && scaleChoice != "no");

            // Scaling the recipe if requested
            if (scaleChoice == "yes")
            {
                ScaleRecipe();
            }

            // Asking user if they want to reset the scale
            string resetChoice;
            do
            {
                Console.WriteLine("\nDo you want to reset the scale? (yes/no)");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                resetChoice = Console.ReadLine().ToLower();
                Console.ResetColor();
            } while (resetChoice != "yes" && resetChoice != "no");

            // Resetting the scale if requested
            if (resetChoice == "yes")
            {
                ResetScale();
            }

            // Asking user if they want to clear the recipe
            string clearChoice;
            do
            {
                Console.WriteLine("\nDo you want to clear the recipe? (yes/no)");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                clearChoice = Console.ReadLine().ToLower();
                Console.ResetColor();
            } while (clearChoice != "yes" && clearChoice != "no");

            // Clearing the recipe if requested
            if (clearChoice == "yes")
            {
                ClearRecipe();
            }

            // Congratulating user on creating the recipe
            Console.WriteLine("\nCongratulations on creating your recipe!");
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            // Displaying recipe details
            Console.WriteLine($"\n{new string('=', Console.WindowWidth - 1)}");
            Console.WriteLine($"\n\x1bRECIPE: {Name}\x1b");
            Console.WriteLine("\n\x1bIngredients\x1b");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
            }

            Console.WriteLine("\n\x1bSteps\x1b");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }

            // Calculating and displaying total calories
            double totalCalories = ingredients.Sum(i => i.Calories * i.Quantity);
            Console.WriteLine($"\nTotal Calories: {totalCalories}");

            // Raising event if total calories exceed 300
            if (totalCalories > 300)
            {
                ExceedsCaloriesEvent?.Invoke($"Warning: {Name} exceeds 300 calories!");
            }
        }

        // Method to scale the recipe
        public void ScaleRecipe()
        {
            // Scaling the recipe if not already scaled
            if (!isScaled)
            {
                Console.WriteLine("Enter scale factor (0.5, 2, or 3):");
                double factor;
                while (!double.TryParse(Console.ReadLine(), out factor) || (factor != 0.5 && factor != 2 && factor != 3))
                {
                    Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3.");
                }
                foreach (var ingredient in ingredients)
                {
                    ingredient.Quantity *= factor;
                }
                isScaled = true;
                Console.WriteLine("\nRecipe has been scaled.");
                DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe has already been scaled. Please reset scale to scale again.");
            }
        }

        // Method to reset the scale of the recipe
        public void ResetScale()
        {
            // Resetting the scale to original quantities
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalIngredients[i].Quantity;
            }
            isScaled = false;
            Console.WriteLine("\nScale reset.");
            DisplayRecipe();
        }

        // Method to clear the recipe
        public void ClearRecipe()
        {
            // Clearing ingredients and steps lists
            ingredients.Clear();
            steps.Clear();
            Console.WriteLine("\nRecipe cleared.");
        }
    }
}
