// Importing necessary libraries
using System;
using System.Collections.Generic;
using System.Linq;

// Defining the namespace for the RecipeApp
namespace RecipeApp
{
    // Defining the Program class
    class Program
    {
        // Main method
        static void Main(string[] args)
        {
            // Initializing a list to store recipes
            List<Recipe> recipes = new List<Recipe>();
            // Prompting user to enter a recipe
            string choice;
            do
            {
                // Creating a new recipe instance
                Recipe recipe = new Recipe();
                // Subscribing to the ExceedsCaloriesEvent event
                recipe.ExceedsCaloriesEvent += DisplayWarningMessage;
                // Entering recipe details
                recipe.EnterRecipe();
                // Adding the recipe to the list
                recipes.Add(recipe);

                // Asking user if they want to enter another recipe
                Console.WriteLine("\nDo you want to enter another recipe? (yes/no)");
                choice = Console.ReadLine().ToLower();
            } while (choice == "yes");

            // Displaying the list of entered recipes if any
            if (recipes.Any())
            {
                // Sorting recipes by name
                Console.WriteLine("\nList of Recipes:");
                recipes = recipes.OrderBy(r => r.Name).ToList();
                foreach (var recipe in recipes)
                {
                    Console.WriteLine(recipe.Name);
                }

                // Loop to allow user to view recipe details or exit
                bool exit = false;
                do
                {
                    // Prompting user to enter the name of the recipe to display details
                    Console.WriteLine("\nEnter the name of the recipe to display details:");
                    string recipeName = Console.ReadLine();
                    Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
                    if (selectedRecipe != null)
                    {
                        selectedRecipe.DisplayRecipe();
                    }
                    else
                    {
                        Console.WriteLine("Recipe not found.");
                    }

                    // Asking user if they want to enter another recipe or exit
                    Console.WriteLine("\nDo you want to enter another recipe or exit? (enter/exit)");
                    string userChoice = Console.ReadLine().ToLower();
                    if (userChoice == "exit")
                    {
                        exit = true;
                    }
                } while (!exit);
            }
            else
            {
                Console.WriteLine("No recipes entered.");
            }

            // Exiting the program
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Method to display warning message for exceeding calories
        static void DisplayWarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
