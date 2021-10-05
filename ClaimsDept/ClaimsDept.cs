using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsDept
{
    class ClaimsDept
    {
        public int ClaimIDNumber { get; set; }
        public ClaimType TypeOfClaim { get; set; }

        public string ClaimDescription { get; set; }

        public double ClaimAmount { get; set; }

        public DateTime DateOfIncendent { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool ClaimIsValid
            //Understanding get  
            
        {
            get
            {  //type //object//certaindate//subtract//otherdate//count
                double days = (DateOfClaim - DateOfIncendent).TotalDays;
                //return //correct day count 
                return (days > 0 && days <= 30);
            }
        }
         



        public ClaimsDept() { }

        public ClaimsDept(int claimIDNumber, ClaimType claim, string claimDescription, double claimAmount, DateTime DateOfIncedent, DateTime dateOfClaim)
        {
            ClaimIDNumber = claimIDNumber;
            TypeOfClaim = claim;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncendent = DateOfIncedent;
            DateOfClaim = dateOfClaim;
            
            
        }
    }
    public enum ClaimType {CarClaim , HomeClaim, TheftClaim}
}
        
        

