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
            SeedData();
        }

        public void BadgesMainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Sec Admin and welcome to the Main Menu what would you like to do?" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadgeMenu();
                        break;
                    case "3":
                        Console.Clear();
                        DisplayAllBadges();
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


        public void AddABadge()
        {
            Console.Clear();

            Badges newBadge = new Badges();

            Console.WriteLine("What is the number on the Badge?");
            newBadge.BadgeIdNumber = Convert.ToInt32(Console.ReadLine()); 

            List<string> doorAccess = new List<string>();

            string userInput = default;

            do
            {
                Console.WriteLine("List a door that it needs access to:");
                string input = Console.ReadLine().ToUpper();
                doorAccess.Add(input);


                Console.WriteLine("Any other doors(y/n)?");
                userInput = Console.ReadLine();

                if (userInput == "n")
                {
                    break;
                }
            }
            while (userInput == "y");
            newBadge.DoorAccess = doorAccess;
            bool accessWasAdded = _badgesRepo.AddANewBadge(newBadge);
            if (accessWasAdded)
            {
                Console.WriteLine("This Badge has successfully been added.");
            }
            else
            {
                Console.WriteLine("Unfortunately the badge could not be added.");
            }

        }
        public void EditABadgeMenu()
        {
            Console.Clear();
            DisplayAllBadges();

            Console.WriteLine("Please enter the badge Id number of the badge you would like to update.");
            int userInput = Convert.ToInt32(Console.ReadLine());

            Badges theBadge = _badgesRepo.GetBadgeByIdNumber(userInput);
            string door = _badgesRepo.GetDoorsByIdNumber(userInput);
            Console.WriteLine($"{theBadge.BadgeIdNumber} this badge has access to these doors {door}.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Hello Sec Admin please choose an option:\n" +
                  "1. Remove Door Access\n" +
                  "2. Add Door Access\n" +
                  "3. Return to the main menu");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("What Door Access do you want to remove for this Badge?");
                    string doorOneInput = Console.ReadLine().ToUpper();

                    bool doorAccessRemoved = _badgesRepo.RemoveDoorAccess(theBadge.BadgeIdNumber, doorOneInput);
                    if (doorAccessRemoved)
                    {
                        Console.WriteLine("Access to that door has been removed");
                        string doorList = _badgesRepo.GetDoorsByIdNumber(userInput);
                        Console.WriteLine($"{theBadge.BadgeIdNumber}this badge has access to these doors.");
                    }
                    else 
                    {
                        Console.WriteLine("Unfortunately Access to that door could not be removed.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Please enter the Door Access you would like to grant.");

                    string doorTwoInput = Console.ReadLine().ToUpper();


                    bool doorAccessGranted = _badgesRepo.AddDoorAccess(theBadge.BadgeIdNumber, doorTwoInput);
                    if (doorAccessGranted)
                    {
                        Console.WriteLine("Access to that door has been added.");
                        string doorTwoList = _badgesRepo.GetDoorsByIdNumber(userInput);
                        Console.WriteLine($"{theBadge.BadgeIdNumber} this badge has access to these doors {doorTwoList}");
                    }
                    else
                    {
                        Console.WriteLine("Access to that door could not be added");
                    }
                        break;
                    case "3":
                        BadgesMainMenu();
                        break;
                        default:
                    Console.WriteLine("Please enter a valid option");
                    break;

            }


        }

        private void SeedData()
        {
            Badges redbadge = new Badges(12345, new List<string> { "A7" });
            Badges yellowbadge = new Badges(19946, new List<string> { "A1", "A4", "B1", "B2" });
            Badges bluebadge = new Badges(17389, new List<string> { "B2", "B4", });

            _badgesRepo.AddANewBadge(redbadge);
            _badgesRepo.AddANewBadge(yellowbadge);
            _badgesRepo.AddANewBadge(bluebadge);

        }


        private void DisplayAllBadges()
        {
            Dictionary<int, Badges> listOfBadges = _badgesRepo.PresentAllBadges();

            string[] objects = new string[] { "BadgeIdNumber", "DoorAccess" };
            Console.WriteLine($"{objects[0], -10}{objects[1]}");

            foreach (KeyValuePair<Int32, Badges> badge in listOfBadges)
            {
                Console.Write($"{badge.Key,-10}");
                for (int i = 0; i < badge.Value.DoorAccess.Count; i++)
                {
                    Console.Write($"{badge.Value.DoorAccess[i]}");

                }
            }
        }







            





    }

}
