using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuid.MVVM.Model
{
    public class Organization
    {
        public Contacts Contacts { get; private set; }
        public Person HeadManager { get; private set; }
        public string Name { get; private set; }
        public string? MapLink { get; private set; }
        public FinanceProfile FinanceProfile { get; private set; }
        public DateTime RelevanceDate { get; private set; }

        public Organization(Contacts contacts, Person headManager, string name, string? mapLink, FinanceProfile financeProfile, DateTime relevanceDate)
        {
            Contacts = contacts;
            HeadManager = headManager;
            Name = name;
            MapLink = mapLink;
            FinanceProfile = financeProfile;
            RelevanceDate = relevanceDate;
        }
    }
}
