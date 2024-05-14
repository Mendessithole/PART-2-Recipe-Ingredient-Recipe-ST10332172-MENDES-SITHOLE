Part 2 Recipe Ingredient Recipe ST10332172 MENDES SITHOLE

https://github.com/Mendessithole/Recipe-Ingredient-Recipe-ST10332172-MENDES-SITHOLE

UPDATES OR CHANGES MADE
Event Handling: Part 2 introduces event handling for warning users about recipes exceeding a certain calorie threshold. This feature is not present in Part 1.


Namespace Organization: In Part 2, the namespaces are defined more systematically. Each class (Recipe, Ingredient, Step) is enclosed in its own namespace (RecipeApp). This organization helps maintain clarity and avoids potential naming conflicts.


Display Methods: In Part 1, the DisplayRecipe() method is called automatically after entering the recipe details. In Part 2, the DisplayRecipe() method is separated from the recipe entry process and is called explicitly when the user chooses to view a recipe's details.


Clearing Recipe: In Part 1, the ClearRecipe() method simply sets the ingredients and steps arrays to null. In Part 2, the ClearRecipe() method actually clears the contents of the ingredients and steps lists, ensuring that memory is properly managed.


User Interface Styling: Part 2 introduces some styling elements to the user interface, such as using ANSI escape codes for text formatting (\x1b[1m for bold text) and changing text color for warning messages. These enhancements improve the visual presentation of the application.


Scale Recipe Method: While the functionality of scaling the recipe remains the same, the implementation of the ScaleRecipe() method is slightly different. Part 2 includes additional validation to ensure that the scale factor entered by the user is one of the specified values (0.5, 2, or 3).



**How to Compile and Run the Software**
Description
Part 2Recipe Ingredient Recipe ST10332172 MENDES SITHOLE is a simple console application that allows users to enter recipes, scale them, reset the scale, and clear the recipe details.

How to Run from GitHub in Visual Studio:
Clone the Repository:

Open Visual Studio.
Go to the "Team Explorer" tab.
Click on the "Clone Repository" option.
Enter the URL of the GitHub repository where the Recipe Ingredient Recipe ST10332172 MENDES SITHOLE code is hosted.
Choose the local directory where you want to clone the repository.
Click "Clone" to download the code to your local machine.
Open the Solution in Visual Studio:

Once the repository is cloned, navigate to the directory where it is located on your local machine.
Find the solution file (Recipe Ingredient Recipe ST10332172 MENDES SITHOLE.sln) and double-click to open it in Visual Studio.
Build and Run the Application:

After opening the solution, you can build and run the application by pressing F5 or selecting "Start Debugging" from the "Debug" menu.
This will compile the code and run the Recipe Ingredient Recipe ST10332172 MENDES SITHOLE console application within Visual Studio.
Follow the On-screen Instructions:

Once the application is running, follow the on-screen instructions to enter recipe details, scale the recipe, reset the scale, or clear the recipe.
Enjoy!

Requirements:
Visual Studio with the .NET development workload installed.
Notes:
Ensure that the necessary packages and dependencies are restored during the build process. Visual Studio typically handles this automatically, but you may need to manually restore packages if there are any issues.
Make sure your project settings are configured correctly, such as the target framework version and any necessary NuGet packages.

