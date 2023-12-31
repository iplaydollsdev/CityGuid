﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuid.MVVM.Model
{
    public class Organization
    {
        public List<Contacts> Contacts { get; private set; } = new();
        public Person HeadManager { get; private set; }
        public string Name { get; private set; }
        public MapLink MapLink { get; private set; }
        public List<string> Address { get; private set; } = new();
        public FinanceProfile FinanceProfile { get; private set; }
        public DateTime RelevanceDate { get; private set; }


        public Organization(Contacts contacts, Person headManager, string name, string address, FinanceProfile financeProfile, DateTime relevanceDate)
        {
            Random rnd = new Random();
            Contacts.Add(contacts);
            HeadManager = headManager;
            Name = name;
            Address.Add(address);
            MapLink = new() { X = (rnd.NextDouble() * (49.6820 - 49.6563) + 49.6563),
                              Y = (rnd.NextDouble() * (58.6104 - 58.5939) + 58.5939)};
            FinanceProfile = financeProfile;
            RelevanceDate = relevanceDate;
        }
    }
}
