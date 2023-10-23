using CityGuid.MVVM.Model;
using System;
using System.Collections.Generic;
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
        public PersonsView(MainWindow mainWindow)
        {
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                Persons.Add(MakePerson());
            }
            foreach (Person person in Persons)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = person.GetFullName();
                PersonsListBox.Items.Add(textBlock);
            }
        }

        private Person MakePerson()
        {
            string[] names = { "Владимир", "Максим", "Виктор", "Константин", "Иван", "Данил", "Александр" };
            Random rnd = new Random();
            PersonFinance personFinance = new PersonFinance();
            Person result = new Person(names[rnd.Next(0, names.Length - 1)], $"{names[rnd.Next(0, names.Length - 1)]}ов", $"{names[rnd.Next(0, names.Length - 1)]}вич",
                                        DateTime.Now.AddYears(-rnd.Next(20, 50)), new Contacts(), personFinance, DateTime.Now.AddDays(-rnd.Next(1, 20)));

            return result;
        }
    }
}
