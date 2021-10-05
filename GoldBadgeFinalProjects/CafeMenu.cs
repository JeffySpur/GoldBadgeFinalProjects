using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinalProjects
{
    class CafeMenu
    {
        //Plain Old CCCCCCCCCCCCcc Shhhhhhhhhhhhharrrrrpppppp OBBBBBJEEEEEEEEEEEEEEEECCCCCCCCCTsss 

        public string MealName { get; set; }
        public int MealNumber { get; set; }
        public string MealDescription { get; set; }
        public double MealPrice { get; set; }
        public List<string> MealIngredients { get; set; }

        public CafeMenu() { }

        public CafeMenu(string mealName, int mealNumber, string mealDescription, double mealPrice, List<string> mealIngredients)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            MealIngredients = mealIngredients;
            
        }
    }
}






