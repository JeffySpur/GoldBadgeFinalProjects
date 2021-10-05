using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDept
{
    class ClaimsDepoRepo
    //Try number 2
    {   //Using a queue instead 
        //Newing the Queue
        public Queue<ClaimsDept> _claimsQueue = new Queue<ClaimsDept>();
        //Create, Add to queue //Enqueue??<--Research-->
        //This is the enqueue method 
        public bool AddClaimToQueue(ClaimsDept claims)
        { //Calling the queue //the new queue
            int startingCount = _claimsQueue.Count;
            _claimsQueue.Enqueue(claims);
            bool wasAdded = (_claimsQueue.Count > startingCount) ? true : false;
            return wasAdded;
        }
 
        public ClaimsDept DisplayNextClaim() 
        {
            //returns first claim in queue
            //peek will display the item that is on top in the queue 
            return _claimsQueue.Peek();
        }
            //-------------!!This method returns the claim id number and will be helpful elsewhere!!--------------------//
        public ClaimsDept GetClaimByClaimIdNumber(int claimIDNumber)
        {
            //for each loop like we did for our MickeyMouseMurderHouse

            foreach (ClaimsDept claims in _claimsQueue)
            {
                if (claims.ClaimIDNumber == claimIDNumber)
                {
                    return claims;
                }
            }
            Console.WriteLine("That's not a valid option please input a valid claim id number:");
            return null;
        }

 

        //This method will display all claims
        public Queue<ClaimsDept> DisplayAllClaims()
        {
            return _claimsQueue;
        }

        


        public ClaimsDept RemoveFromQueue()
        {
            return _claimsQueue.Dequeue();
            
        }
      

        //This was try number 1 then i realized i needed to use a queue

/*        private List<ClaimsDept> _listOfClaims = new List<ClaimsDept>();

        //Create
        public void AddClaimToList(ClaimsDept claims)
        {
            _listOfClaims.Add(claims);
        }

        //Read 
        public List<ClaimsDept> ViewClaims()
        {
            return _listOfClaims;
        }
        //Update
        public bool UpdateAClaim(int ori, ClaimsDept newClaim)
        {
            ClaimsDept oldClaim = GetClaimbyClaimIdNumber(originalClaimType);

            if (oldClaim != null)
            {
                oldClaim.TypeOfClaim = newClaim.TypeOfClaim;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.ClaimIsValid = newClaim.ClaimIsValid;
                oldClaim.ClaimIDNumber = newClaim.ClaimIDNumber;
                oldClaim.ClaimDescription = newClaim.ClaimDescription;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncendent = newClaim.DateOfIncendent;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveClaimsFromList(string claimType)
        {
            ClaimsDept claims = GetClaimbyClaimIdNumber(claimType);
            if (claims == null)
            {
                return false;
            }

            int initialCount = _listOfClaims.Count;
            _listOfClaims.Remove(claims);
            if (initialCount > _listOfClaims.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Helper */
        //This was my attempt number 1 then i realized i needed a queue here instead fun stuff//

    }
}
                

            



        
            
            

        
        













        
