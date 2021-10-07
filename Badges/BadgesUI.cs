using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    class BadgesUI
    {
        public BadgesRepo _badgesRepo = new BadgesRepo();
        public void Run() 
        {
            BadgesMainMenu();

        }

        public void BadgesMainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Admin and welcome to the Main Menu what would you like to do?" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        _badgesRepo.AddABadge();

                        break;
                    case "2":
                        EditBadgeAccess();
                        break;
                    case "3":
                        Console.Clear();
                        _badgesRepo.DisplayAllBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        return;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
            }
        }

        private void EditBadgeAccess()
        {
            Console.Clear();
            Console.WriteLine("Hello Admin please choose an option:\n" +
                              "1. Remove Door Access\n" +
                              "2. Add Door Access\n" +
                              "3. Return to the main menu");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    RemoveDoorAccess();
                    break;
                case "2":
                    AddDoorAccess();
                    break;
                case "3":
                    BadgesMainMenu();
                    break;
                default:
                     Console.WriteLine("Please enter a valid option");
                    break;
            }
        }
        public void AddABadge(int badgeIdNumber, List<string> doorAccess)
        {
            //Badge Id Number
            Badges newBadge = new Badges();
            Console.WriteLine("What is the number on the badge?");
            string badgeIdNumberAsString = Console.ReadLine();
            newBadge.BadgeIdNumber = int.Parse(badgeIdNumberAsString);

            //Badge Door Access
            Console.WriteLine("List a door that it needs access to:");
            string badgeDoorAccessAsString = Console.ReadLine();

            //Any other doors?
            Console.WriteLine("Any other doors( y / n )?");
            string otherDoorsAsString = Console.ReadLine();

            //List a door again if yes
            Console.WriteLine("List a door that it needs access to:");
            string badgeDoorAccessAsStringAgain = Console.ReadLine();

            //Any doors again 
            Console.WriteLine("Any other doors( y / n )?");
            string otherDoorsAsStringAgain = Console.ReadLine();

            bool badgeAdded = _badgesRepo.AddABadge();




        }




            





    }

}
