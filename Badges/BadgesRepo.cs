using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class BadgesRepo
    {
        //newing up a dicitonary looks like this 

        private Dictionary<int, Badges> _badgesDictionary = new Dictionary<int, Badges>();

        //Create this method will add a new badge to the dictionary

        public bool AddANewBadge(Badges badge)
        {
            

            int startingCount = _badgesDictionary.Count;

            _badgesDictionary.Add(badge.BadgeIdNumber, badge);

            bool badgeWasAdded = (_badgesDictionary.Count > startingCount) ? true : false;

            return badgeWasAdded;
        }

            
        //Add Door access
        public bool AddDoorAccess(int badgeIdNumber, List<string> newDoorAccess) 
        {
            Badges theBadge = GetBadgeByIdNumber(badgeIdNumber);
            int startingCount = theBadge.DoorAccess.Count();
                          //adds elements to the end of List T
            theBadge.DoorAccess.AddRange(newDoorAccess);

            bool wasAdded = (theBadge.DoorAccess.Count > startingCount) ? true : false;

            return wasAdded;

        }

            
        //  Read   Show all badges and get badge by id number 
        public Dictionary<int, Badges> PresentAllBadges()
        {
            return _badgesDictionary;
        }
        public Badges GetBadgeByIdNumber(int badgeIdNumber)
        {
            return _badgesDictionary[badgeIdNumber];
        }

        //Get Doors by Id Number
        public string GetDoorsByIdNumber(int badgeIdNumber)
        {
            Badges theBadge = GetBadgeByIdNumber(badgeIdNumber);
            if (theBadge != null)
            {       //will return the string values seperated all nice and fancy 
                return string.Join(" ", theBadge.DoorAccess);
            }
            return "We're sorry that Badge could not be found."; 

        }



        //Delete Door access
        public bool RemoveDoorAccess(int badgeIdNumber, string doorAccess)
        {
            Badges theBadge = GetBadgeByIdNumber(badgeIdNumber);
            int startingCount = theBadge.DoorAccess.Count();

            theBadge.DoorAccess.Remove(doorAccess);

            bool wasRemoved = (theBadge.DoorAccess.Count < startingCount) ? true : false;

            return wasRemoved;
        }
    }
}
    



     






        
            

