using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDept
{
    class ClaimsDepoUI
    {
        //newing up a repo to use later 
        public ClaimsDepoRepo _claimsRepo = new ClaimsDepoRepo();

        public void Run() 
        {
            SeedData();
            ClaimsMenu();
        }

        //ClaimsMainMenu
        private void ClaimsMenu() 
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display the options
                Console.WriteLine("Hello Welcome to the claims menu please select what you would like to do:\n" +
                    "1. Display all Claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit the menu");

                //Take user input
                string input = Console.ReadLine();

                //Evaluate the users input and act 

                switch (input)
                {
                    case "1":
                        //See all claims
                        ShowAllClaims();
                        break;
                    case "2":
                        //take care of next claim
                        ShowNextClaim();
                        break;
                    case "3":
                        //Enter a new claim
                        AddNewClaimToQueue();
                        break;
                    case "4":
                        Console.WriteLine("Farewell Friend");
                        keepRunning = false;
                        //Exit
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        break;

                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();

            }
        }
        //Display claim method 
        private void DisplayClaim() 
        {
            ClaimsDept claims = _claimsRepo.DisplayNextClaim();
            Console.WriteLine($"1. Claim Id: {claims.ClaimIDNumber}\n" +
                              $"2. Claim Type: {claims.TypeOfClaim}\n" +
                              $"3. Claim Description: {claims.ClaimDescription}\n" +
                              $"4. Claim Amount: {claims.ClaimAmount}\n" +
                              $"5. Date of Incedent: {claims.DateOfIncendent:mm/dd/yyyy}\n" +
                              $"6. Date of Claim: {claims.DateOfClaim:mm/dd/yyyy}\n" +
                              $"7. Is this a valid claim? {claims.ClaimIsValid}\n");
        }
        //Display All Claims 
        private void DisplayAllClaims()
        {
            Queue<ClaimsDept> listOfClaims = _claimsRepo.DisplayAllClaims();

            //here we are newing up a string array and then using it to interpolate a string array the numbers in the [] refer to the string array stated above the cwriteline.. the -10 numbers determine there sapcing in the console
            string[] claimArray = new string[] { "ClaimId", "ClaimType", "ClaimDescription", "ClaimAmount", "DateOfIncedent", "DateOfClaim", "ClaimIsValid" };
            Console.WriteLine($" {claimArray[0],-8}{claimArray[1],-8}{claimArray[2],-27}{claimArray[3],-13}{claimArray[4],-17}{claimArray[5],-17}{claimArray[6],-13}");
            foreach (ClaimsDept claims in listOfClaims)
            {
                Console.Write($"{claims.ClaimIDNumber,-8}{claims.TypeOfClaim,-8}{claims.ClaimDescription,-27}{claims.ClaimAmount,-13}{claims.DateOfIncendent,-17:mm/dd/yyyy}{claims.DateOfClaim,-17:mm/dd/yyy}{claims.ClaimIsValid,-13}\n");
            }
            
        }


            
        //Show next claim
        private void ShowNextClaim()
        {

            Console.Clear();
            //This is my peek method established in my repo 
            DisplayClaim();
            //user display
            Console.WriteLine("Here are some details for the next claim to be handled would you like to handle the claim?\n");
            string input = Console.ReadLine();
            if (input == "y")
            {
                //retuen claims queue knock off the top of queue (Dequeue)
                _claimsRepo._claimsQueue.Dequeue();
            }
            else if (input == "n")
            {
                //Return claims menu
                ClaimsMenu();
            }
            else
            {
                //just a safety net if they are dumb 
                Console.WriteLine("Please enter a valid response ex: y or n");
                ShowNextClaim();
            }

            
        }

        //Show all Claims
        public void ShowAllClaims() 
        {
            Console.Clear();
            DisplayAllClaims();
        }
        //Enter a new claim
        private void AddNewClaimToQueue()
        {
            ClaimsDept newClaim = new ClaimsDept();
            //claimIdNumber
            Console.WriteLine("Please enter the Id number for the new claim:");
            string claimIdNumberAsString = Console.ReadLine();
            newClaim.ClaimIDNumber = int.Parse(claimIdNumberAsString);
            //ClaimType
            Console.WriteLine("Please enter the claim type:");
            ClaimType claimType = GetClaimType();
             

            //ClaimDescription
            Console.WriteLine("Please enter a Description of the claim:");
            newClaim.ClaimDescription = Console.ReadLine();
            //ClaimAmount
            Console.WriteLine("Please enter the claim amount:");
            string claimAmountAsStirng = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(claimAmountAsStirng);
            //DateOfIncedent
            Console.WriteLine("Please enter the date of the Incedent:");
            newClaim.DateOfIncendent = DateTime.Parse(Console.ReadLine());
            //DateOfClaim
            Console.WriteLine("Please enter the date the Claim was made:");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            //final statement if something was added then say so 

            bool wasAdded = _claimsRepo.AddClaimToQueue(newClaim);
            if (wasAdded)
            {
                Console.WriteLine("This claim was succesffully added");

            }
            else
            {
                Console.WriteLine("This claim could not be succesffully added");
            }
        }

        //Seed Data 

        public void SeedData()
        {
            ClaimsDept claimOne = new ClaimsDept(1, ClaimType.HomeClaim, "House fire on second floor", 650.00d, DateTime.Parse("11-10-1994"), DateTime.Parse("11-15-1994"));
            ClaimsDept claimTwo = new ClaimsDept(2, ClaimType.CarClaim, "Car crash head on collision", 750.00d, DateTime.Parse("12-19-1994"), DateTime.Parse("12-21-1994"));
            ClaimsDept claimThree = new ClaimsDept(1, ClaimType.TheftClaim, "Stolen Tvs home invasion", 950.00d,
                DateTime.Parse("01-15-1995"), DateTime.Parse("01-19-1995"));
            _claimsRepo.AddClaimToQueue(claimOne);
            _claimsRepo.AddClaimToQueue(claimTwo);
            _claimsRepo.AddClaimToQueue(claimThree);
        }

            //helper method for enum type 
            private ClaimType GetClaimType() 
            {
                Console.WriteLine("1. Car Claim\n" +
                                  "2. Home Claim\n" +
                                  "3. Theft Claim");
                while (true)
                {
                    switch (Console.ReadLine().ToLower())
                    {
                        case "1":
                        case "car":
                            return ClaimType.CarClaim;
                        case "2":
                        case "home":
                            return ClaimType.HomeClaim;
                        case "3":
                        case "theft":
                                return ClaimType.TheftClaim;
                        default:
                            Console.WriteLine("Please enter a valid claim ex: car, home, theft:");
                            break;
                            

                    }

                }
            }

    }
}


         

            


