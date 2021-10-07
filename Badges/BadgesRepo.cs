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

        public void AddABadge(int badgeIdNumber, List<string> doorAccess )
        {
            Badges newBadge = new Badges(badgeIdNumber, doorAccess);

            int startingCount = _badgesDictionary.Count;

            _badgesDictionary.Add(badgeIdNumber, newBadge);

            

            
        }
        //  Read   Show all badges and get badge by id number 
        public Dictionary<int, Badges> DisplayAllBadges()
        {
            return _badgesDictionary;
        }

        public Badges GetBadgeByIdNumber(int badgeIdNumber)
        {
            return _badgesDictionary[badgeIdNumber];
        }

        //Add Door access
        public bool AddDoorAccess(int badgeIdNumber, List<string> newDoorAccess) 
        {
            Badges theBadge = GetBadgeByIdNumber(badgeIdNumber);
            int startingCount = theBadge.DoorAccess.Count();

            theBadge.DoorAccess.AddRange(newDoorAccess);

            bool wasAdded = (theBadge.DoorAccess.Count > startingCount) ? true : false;

            return wasAdded;

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


     






        
            

