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
        private MainWindow _mainWindow;
        public PersonsView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            for (int i = 0; i < 10; i++)
            {
                Persons.Add(MakePerson());
            }
            foreach (Person person in Persons)
            {
                AddTextBlock(person);
            }
        }
        private Person? _selectedItem;
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
            Random rnd = new Random();
            PersonFinance personFinance = new PersonFinance();
            Person result = new Person(names[rnd.Next(0, names.Length - 1)], $"{names[rnd.Next(0, names.Length - 1)]}ов", $"{names[rnd.Next(0, names.Length - 1)]}ович",
                                        DateTime.Now.AddYears(-rnd.Next(20, 50)), new Contacts(), personFinance, DateTime.Now.AddDays(-rnd.Next(1, 20)));
            return result;
        }

        private PersonPropView SetProperties(Person person)
        {
            PersonPropView result = new(person);

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
