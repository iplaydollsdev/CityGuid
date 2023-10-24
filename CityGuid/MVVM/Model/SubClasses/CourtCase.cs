using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuid.MVVM.Model.SubClasses
{
    public class CourtCase
    {
        public DateTime CaseDate { get; set; }
        public string Claimant {  get; set; }
        public string DefedantCosts { get; set; }
        public string ClaimantCosts { get; set; }

        public CourtCase(string claimant, string defedantCost, string claimantCosts, DateTime caseDate)
        {
            Claimant = claimant;
            DefedantCosts = defedantCost;
            ClaimantCosts = claimantCosts;
            CaseDate = caseDate;
        }
    }
}
