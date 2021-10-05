using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinalProjects
{
    class CafeMenuRepo
    {
        public List<CafeMenu> _listOfMenuContent = new List<CafeMenu>();

        //create
        public void AddMenuItemsToList(CafeMenu menuItems)
        {
            _listOfMenuContent.Add(menuItems);
        }
        //Read
        public List<CafeMenu> GetCafeMenu()
        {
            return _listOfMenuContent;
        }


        //we dont need an update here 
        //Delete
        public bool RemoveItemFromMenu(string mealName)
        {
            CafeMenu menuItems = GetMenuItemsByMealName(mealName);
            if (menuItems == null)
            {
                return false;

            }
            int initialCount = _listOfMenuContent.Count;
            _listOfMenuContent.Remove(menuItems);

            if (initialCount > _listOfMenuContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //Helper Methods
        public CafeMenu GetMenuItemsByMealName(string mealName) 
        {
            foreach (CafeMenu menuItems in _listOfMenuContent)
            {
                if (menuItems.MealName.ToLower() == mealName.ToLower())
                {
                    return menuItems;
                }
            }
            return null;
        }
    }
}

