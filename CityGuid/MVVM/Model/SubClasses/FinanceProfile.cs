using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuid.MVVM.Model.SubClasses
{
    public class FinanceProfile
    {
        public string OGRN {  get; private set; }
        public string INN { get; private set; }
        public string KPP { get; private set; }
        public DateTime RegistranionDate { get; private set; }
        public string MainActivity {  get; private set; }
        public OrganizationFinance OrganizationFinance { get; private set; }
        public List<CourtCase> CourtCases { get; private set; } = new();
        public List<GovProcurement> GovProcurements { get; private set; } = new();

        public FinanceProfile(string ogrn, string inn, string kpp, DateTime registrationDate, string mainActivity, OrganizationFinance organizationFinance) 
        {
            OGRN = ogrn;
            INN = inn;
            KPP = kpp;
            RegistranionDate = registrationDate;
            MainActivity = mainActivity;
            OrganizationFinance = organizationFinance;
        }

        public void AddCourtCases(params CourtCase[] courtCases)
        {
            foreach (var c in courtCases)
            {
                CourtCases.Add(c);
            }
        }
        public void AddGovProcurements(params GovProcurement[] govProcurements)
        {
            foreach (var p in govProcurements)
            {
                GovProcurements.Add(p);
            }
        }
    }
}
