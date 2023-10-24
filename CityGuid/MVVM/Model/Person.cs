using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuid.MVVM.Model
{
    public class Person
    {
        public string FirstName { get; private set; }
        public List<string> LastName { get; private set; } = new();
        public string MiddleName { get; private set; }
        public DateTime Birthday { get; private set; }
        public List<Contacts> Contacts { get; private set; } = new();
        public List<Person> Relatives { get; private set; } = new();
        public PersonFinance? Finance { get; private set; }
        public DateTime RelevanceDate { get; private set; }

        public Person(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName.Add(lastName);
            MiddleName = middleName;
        }
        public Person(string firstName, string lastName, string middleName, 
                      DateTime birthday, Contacts contacts, PersonFinance finance,
                      DateTime relevanceDate, params Person[] people)
        {
            FirstName = firstName;
            LastName.Add(lastName);
            MiddleName = middleName;
            Birthday = birthday;
            Contacts.Add(contacts);
            Finance = finance;
            RelevanceDate = relevanceDate;
            foreach (Person person in people)
            {
                Relatives.Add(person);
            }
        }
        
        public string GetFullName()
        {
            return $"{LastName.Last()} {FirstName} {MiddleName}";
        }
    }
}
