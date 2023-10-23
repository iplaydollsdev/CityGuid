using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGuid.MVVM.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birthday { get; set; }
        public Contacts? Contacts { get; set; }
        public List<Person> Relatives { get; set; } = new();
        public PersonFinance? Finance { get; set; }
        public DateTime RelevanceDate { get; private set; }

        public Person(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        public Person(string firstName, string lastName, string middleName, 
                      DateTime birthday, Contacts? contacts, PersonFinance finance,
                      DateTime relevanceDate, params Person[] people)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Birthday = birthday;
            Contacts = contacts;
            Finance = finance;
            RelevanceDate = relevanceDate;
            foreach (Person person in people)
            {
                Relatives.Add(person);
            }
        }
        
        public string GetFullName()
        {
            return $"{LastName} {FirstName} {MiddleName}";
        }
    }
}
