using CityGuid.MVVM.Model;
using CityGuid.MVVM.Model.SubClasses;
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
    /// Interaction logic for PersonPropView.xaml
    /// </summary>
    public partial class PersonPropView : UserControl
    {
        public string FirstName { get; set; }
        public List<string> LastName { get; set; } = new();
        public string MiddleName { get; set; }
        public string Birthday { get; set; }
        public List<string> Contacts { get; set; } = new();
        public List<string> Relatives { get; set; } = new();
        public List<string> Finance { get; set; } = new();
        public string RelevanceDate { get; private set; }
        
        private Person Person { get; }

        public delegate void MouseClickEventHandler(string sender);
        public event MouseClickEventHandler? RelativeMouseClick;
        public PersonPropView(Person person)
        {
            InitializeComponent();
            Person = person;
            FirstName = person.FirstName;
            LastName = person.LastName;
            if (person.LastName.Count > 1)
            {
                LastNameLabel.Content = "Фамилии *";
                LastNameLabel.Foreground = Brushes.Blue;
                LastNameLabel.MouseUp += OnLastNameClick;
            }
            MiddleName = person.MiddleName;
            Birthday = person.Birthday.ToString("dd/M/yyyy");

            FillContacts(person);
            FillFinance(person);
            FillRelatives(person);
            RelevanceDate = person.RelevanceDate.ToString("dd/M/yyyy");
            DataContext = this;
        }


        private void FillFinance(Person person)
        {
            if (person.Finance == null)
                return;

            foreach (var yearIncome in person.Finance.YearIncome)
            {
                string income = $"{yearIncome.Key} - {yearIncome.Value}";
                Label item = new() { Content = income };
                FinanceListBox.Items.Add(item);
            }
        }
        private void FillRelatives(Person person)
        {
            foreach (var relative in person.Relatives)
            {
                string name = $"{relative.GetFullName()}";
                Label item = new() { Content = name };
                item.Foreground = Brushes.Blue;
                item.MouseUp += (sender, e) => RelativeMouseClick?.Invoke(name);
                RelativesListBox.Items.Add(item);
            }
        }



        private void FillContacts(Person person)
        {
            if (person.Contacts.Count > 1)
            {
                ContactsLabel.Content = "Контакты *";
                ContactsLabel.Foreground = Brushes.Blue;
                ContactsLabel.MouseUp += OnContactsClick;
            }

            Contacts contacts = person.Contacts.Last();
            Contacts.Add($"Email: {contacts.Email ?? "не указан"}");
            Contacts.Add($"Сайт: {contacts.WebSiteLink ?? "не указан"}");
            Contacts.Add($"Телефон: {contacts.PhoneNumber ?? "не указан"}");

            foreach (string contactProp in Contacts)
            {
                ListBoxItem item = new ListBoxItem() { Content = contactProp };
                ContactsListBox.Items.Add(item);
            }
        }

        private void OnContactsClick(object sender, MouseButtonEventArgs e)
        {
            Details contactsWindow = new Details(Person.Contacts);
            contactsWindow.Show();
        }
        private void OnLastNameClick(object sender, MouseButtonEventArgs e)
        {
            Details contactsWindow = new Details(Person.LastName, isAddress: false);
            contactsWindow.Show();
        }
    }
}
