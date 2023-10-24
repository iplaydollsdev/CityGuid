using CityGuid.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CityGuid.MVVM.View
{
    /// <summary>
    /// Interaction logic for PersonsView.xaml
    /// </summary>
    public partial class PersonsView : UserControl
    {
        public List<Person> Persons { get; private set; } = new();
        private Person? _selectedItem;
        public PersonsView(MainWindow mainWindow)
        {
            InitializeComponent();
            //* Наполнение
            Random random = new Random();
            for (int i = 0; i < random.Next(6, 20); i++)
            {
                Persons.Add(MakePerson());
            }
            //*
            //* Пример со сменой фамилии
            Persons.Add(MakeJanna());
            //*
            foreach (Person person in Persons)
            {
                //* Наполнение
                if (random.Next(0, 2) == 1) 
                    person.Relatives.Add(Persons.Where(p => p != person).ToList()[random.Next(0, Persons.Count - 1)]);
                //*
                AddTextBlock(person);
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (TextBlock)PersonsListBox.SelectedItem;
            _selectedItem = (Person)selectedItem.Tag;
            Properties.Children.Clear();
            Properties.Children.Add(SetProperties(_selectedItem));
        }

        private Person MakePerson()
        {
            string[] names = { "Владимир", "Максим", "Виктор", "Константин", "Иван", "Данил", "Александр" };
            Random random = new Random();
            string randomName = names[random.Next(0, names.Length - 1)];

            PersonFinance personFinance = new PersonFinance();
            for (int i = 0; i < random.Next(1, 6); i++)
            {
                personFinance.YearIncome.Add($"{2023-i}", $"{random.Next(1000, 1000000)}");
            }

            Contacts contacts = new Contacts()
            {
                Email = $"{randomName}{random.Next(10, 20)}@gmail.com",
                PhoneNumber = $"+7-{random.Next(100, 900)}-{random.Next(100, 900)}-{random.Next(1000, 2000)}",
            };
            Contacts newContacts = new Contacts()
            {
                Email = $"{random.Next(10, 20)}org@gmail.com",
                WebSiteLink = $"{randomName}{random.Next(0, 100)}.com"
            };

            Person result = new Person(randomName, $"{names[random.Next(0, names.Length - 1)]}ов", $"{names[random.Next(0, names.Length - 1)]}ович",
                                        DateTime.Now.AddYears(-random.Next(20, 50)), contacts, personFinance, DateTime.Now.AddDays(-random.Next(1, 20)));

            if (random.Next(0, 2) == 1) result.Contacts.Add(newContacts);

            return result;
        }
        private Person MakeJanna()
        {
            Random random = new Random();

            PersonFinance personFinance = new PersonFinance();
            for (int i = 0; i < random.Next(1, 6); i++)
            {
                personFinance.YearIncome.Add($"{2023 - i}", $"{random.Next(1000, 1000000)}");
            }

            Contacts contacts = new Contacts()
            {
                Email = $"janna@gmail.com",
                PhoneNumber = $"+7-{random.Next(100, 900)}-{random.Next(100, 900)}-{random.Next(1000, 2000)}",
            };
            Contacts newContacts = new Contacts()
            {
                Email = $"janna_org@gmail.com",
                WebSiteLink = $"jannaportfolio.com",
                PhoneNumber = $"+7-{random.Next(100, 900)}-{random.Next(100, 900)}-{random.Next(1000, 2000)}"
            };

            Person result = new Person("Жанна", "Малевич", "Казимировна",
                                        DateTime.Now.AddYears(-random.Next(20, 50)), contacts, personFinance, DateTime.Now.AddDays(-random.Next(1, 20)));

            result.LastName.Add("Репина");
            return result;
        }


        private PersonPropView SetProperties(Person person)
        {
            PersonPropView result = new(person);
            result.RelativeMouseClick += SelectPerson;

            return result;
        }
        private void AddTextBlock(Person person)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = person.GetFullName();
            textBlock.Tag = person;
            PersonsListBox.Items.Add(textBlock);
        }

        public void SelectPerson(string fullName)
        {
            _selectedItem = Persons.Where(p => p.GetFullName() == fullName).FirstOrDefault();
            Properties.Children.Clear();
            if (_selectedItem != null)
                Properties.Children.Add(SetProperties(_selectedItem));
        }
    }
}
