using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    public class Badges
    {
        public int BadgeIdNumber { get; set; }
        public List<string> DoorAccess { get; set; }


        public Badges() { }

        public Badges(int badgeIdNumber, List<string> doorAccess)
        {
            BadgeIdNumber = badgeIdNumber;
            DoorAccess = doorAccess;
  
        }

    }
}
