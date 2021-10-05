using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinalProjects
{
    public class CafeMenuUI
    {
        private CafeMenuRepo _cafeMenuRepo = new CafeMenuRepo();
        //Single method that starts the UI
        public void Run()
        {
            SeedCafeMenuList();
            StartupMenu();
        }

        //Menu 
        private void StartupMenu()
        {
            bool keepRunning = true;
                while (keepRunning)
            {
                //Display options to user 
                Console.WriteLine("Hello and welcome to The Cafe Menu please choose an option\n" +
                    "1.Add a Menu Item\n" +
                    "2.View Menu \n" +
                    "3.View Ingredients for a Menu Item\n" +
                    "4.Delete a Menu Item\n" +
                    "5.Exit Cafe Menu\n");

                //Get users input 
                string input = Console.ReadLine();
                //Elvaluate user input and act 
                switch (input)
                {
                    case "1":
                        //Add a menu item 
                        CreateNewMenuItem();
                        break;
                    case "2":
                        //View Menu  
                        DisplayMenu();
                        break;
                    case "3":
                        //view ingredients of a menu item 
                        Viewingredientslist();
                        break;

                    case "4":
                        //Delete a menu item
                        DeleteAMenuItem();
                        break;
                    case "5":
                        Console.WriteLine("Have a great day. Goodbye.");
                        keepRunning = false;
                        //Exit the Menu
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();

            }
        }
        //Add a new menu item 
        public void CreateNewMenuItem()
        {
            Console.Clear();
            CafeMenu newMenuItem = new CafeMenu();
            //MealName
            Console.WriteLine("Please enter the name of the new menu item.");
            newMenuItem.MealName = Console.ReadLine();
            //MealNumber
            Console.WriteLine("Please enter the number that you would like to assign to the new menu item ex(4)");
            string mealNumberAsString = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(mealNumberAsString);
            //MealDescription
            Console.WriteLine("Please enter a desciption for the new menu item.");
            newMenuItem.MealDescription = Console.ReadLine();
            //MealPrice
            Console.WriteLine("Please enter the price of the new menu item in the following format (6.24)");
            string mealPriceAsString = Console.ReadLine();
            newMenuItem.MealPrice = double.Parse(mealPriceAsString);
            //Ingredients 
            Console.WriteLine("Please enter a list of ingredients for the menu item please use this format (burger, cheese,etc..");
            string mealIngredients = Console.ReadLine();
            newMenuItem.MealIngredients = mealIngredients.Split(',').ToList();
            


            _cafeMenuRepo.AddMenuItemsToList(newMenuItem);

                        


            //--------------------------THIS IS WHERE YOU LEFT OFF------------------------------------//
            //-------YOURE THOUGHTS BEFORE LEAVING WERE: PUTTING THE INGREDIENTS LIST IN AN ENUM------// 


        }

        //View menu  
        public void DisplayMenu() 
        {
            List<CafeMenu> listOfItems = _cafeMenuRepo.GetCafeMenu();
            foreach (CafeMenu cafeMenu in listOfItems)
            {
                Console.WriteLine($"1. Meal Name: {cafeMenu.MealName}\n" +
                                  $"2. Meal Number: {cafeMenu.MealNumber}\n" +
                                  $"3. Meal Description: {cafeMenu.MealDescription}\n" +
                                  $"4. Meal Price: {cafeMenu.MealPrice}");
                List<string> mealIngredients = cafeMenu.MealIngredients;

                foreach (string mealIngredient in mealIngredients)
                    Console.Write(mealIngredient);


            }
        }

        private void Viewingredientslist()
        {
            Console.Clear();

            Console.WriteLine("Enter the Name of the item you would like to see and ingredients list for:");
            string mealName = Console.ReadLine();
            CafeMenu cafeMenu = _cafeMenuRepo.GetMenuItemsByMealName(mealName);
            if (cafeMenu != null)
            {
                Console.WriteLine($"Meal Name: {cafeMenu.MealName}\n" +
                    $"Meal Number: {cafeMenu.MealNumber}\n" +
                    $"Meal Description: {cafeMenu.MealDescription}\n" +
                    $"Meal Price: {cafeMenu.MealPrice}");

                foreach (string mealIngredient in cafeMenu.MealIngredients)
                    Console.WriteLine(mealIngredient); 

            }
            else
            {
                Console.WriteLine("There is nothing with that name yet please enter a valid option");
                Console.ReadLine();
            }
        }






        //Delete a menu Item 
        public void DeleteAMenuItem()
        {
            Console.Clear();
            // get title you want to remove 
            DisplayMenu();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("please enter the name of the menu item you wish to delete");

            string input = Console.ReadLine();
            bool wasDeleted = _cafeMenuRepo.RemoveItemFromMenu(input);

            if (wasDeleted)
            {
                Console.WriteLine("the menu item was succesffuly deleted");
            }
            else
            {
                Console.WriteLine("The content could not be deleted");
            }


            

        }

        //seed method
        private void SeedCafeMenuList()
        {
            List<string> ingredientsList = new List<string> { "burger\n", "bun\n" }; 
            CafeMenu theJeffreyBurger = new CafeMenu("The Jeffrey Burger", 1, "A no nonsense Burger and bun", 3.07, ingredientsList);
            List<string> kistaBurgerInged = new List<string> { "burger\n", "bun\n", "ketchup\n", "cheese\n", "mayo" };
            CafeMenu theKristaBurger = new CafeMenu("The Krista Burger", 2, "A Burger with ketchup, mayo, cheese", 4.57, kistaBurgerInged);
            List<string> ozzieburgerIngredientsList = new List<string> { "burger\n", "bun\n", "cheese\n", "bacon\n", "BBq Sauce\n" };
            CafeMenu theOzzieBurger = new CafeMenu("The Ozzie Burger", 3, "A burger with cheese bacon and BBQ sauce", 6.09, ozzieburgerIngredientsList);

            

            _cafeMenuRepo.AddMenuItemsToList(theJeffreyBurger);
            _cafeMenuRepo.AddMenuItemsToList(theKristaBurger);
            _cafeMenuRepo.AddMenuItemsToList(theOzzieBurger);

            //------------------------------this is where you left off everything is working----------------------------//
            //-----------------------------Added seed data and view function in UI-------------------------------------//
            //----------------------------Next Steps: View Ingredients List & Add Delete method for UI-----------------//
        }

    }

}




