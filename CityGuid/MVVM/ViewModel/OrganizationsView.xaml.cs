using CityGuid.MVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
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
    /// Interaction logic for OrganizationsView.xaml
    /// </summary>
    public partial class OrganizationsView : UserControl
    {
        public List<Organization> Organizations { get; private set; } = new();

        private MainWindow _mainWindow;
        public OrganizationsView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            Random random = new Random();
            for (int i = 0; i < random.Next(10, 20); i++)
            {
                Organizations.Add(MakeOrganization());
            }
            foreach (Organization organization in Organizations)
            {
                AddTextBlock(organization);
            }
        }
        private Organization? _selectedItem;

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (TextBlock)OrganizationsListBox.SelectedItem;
            _selectedItem = (Organization)selectedItem.Tag;
            Properties.Children.Clear();
            Properties.Children.Add(SetProperties(_selectedItem));
        }

        private Organization MakeOrganization()
        {
            Random random = new Random();

            //Контакты
            Contacts contacts = new Contacts()
            {
                Email = $"{random.Next(10, 20)}org@gmail.com",
                PhoneNumber = $"+7-{random.Next(100,900)}-{random.Next(100, 900)}-{random.Next(1000, 2000)}",
                WebSiteLink = $"{random.Next(10, 20)}org.com"
            };
            Contacts newContacts = new Contacts()
            {
                Email = $"{random.Next(10, 20)}org@gmail.com",
                WebSiteLink = $"{random.Next(10, 20)}org.com"
            };
            //Случайный человек
            Person person = _mainWindow.PersonsView.Persons[random.Next(0, _mainWindow.PersonsView.Persons.Count - 1)];

            //Финансы организации
            OrganizationFinance organizationFinance = new((uint)random.Next(0, 20000), 10000); 
            for (int i = 2019; i <= 2023; i++)
            {
                KeyValuePair<string, int> revenue = new KeyValuePair<string, int>(i.ToString(), random.Next(5000, 200000));
                organizationFinance.Revenue.Add(revenue);
                KeyValuePair<string, int> expenses = new KeyValuePair<string, int>(i.ToString(), random.Next(5000, 200000));
                organizationFinance.Expenses.Add(expenses);
                organizationFinance.Profit.Add(new KeyValuePair<string, int>(i.ToString(), (revenue.Value-expenses.Value)));
            }


            //Финансовый профиль
            FinanceProfile financeProfile = new($"{random.Next(10000000, int.MaxValue)}", $"{random.Next(10000000, int.MaxValue)}", $"{random.Next(10000000, int.MaxValue)}", 
                                            DateTime.Now.AddMonths(-random.Next(20, 100)), $"{random.Next(10,100)}-я деятельность", organizationFinance);

            //Организация
            Organization result = new(contacts, person, $"{random.Next(10, 300)} Бычков", $"г.Киров, ул. Свободы {random.Next(1,9)} Собрания, д. {random.Next(10, 100)}", 
                                                    financeProfile, DateTime.Now.AddDays(-random.Next(1, 20)));

            //Судебные дела
            for (int i = 0; i < random.Next(0, 4); i++)
            {
                if (random.Next(0, 2) == 1)
                    continue;
                string claimant = random.Next(0, 2) == 1 ? result.Name : $"{random.Next(10, 300)} Пони";
                CourtCase courtCase = new(claimant, $"{random.Next(10000, 1000000)}", $"{random.Next(10000, 1000000)}", DateTime.Now.AddMonths(-random.Next(2, 40)));
                result.FinanceProfile.CourtCases.Add(courtCase);
            }

            //Госзакупки
            for (int i = 0;i < random.Next(0, 10); i++)
            {
                if (random.Next(0, 2) == 1)
                    continue;
                int count = random.Next(100, 6000);
                GovProcurement govProcurement = new(DateTime.Now.AddMonths(-random.Next(2, 40)), $"Закупка {count} кг. мяса", $"{count * 400}");
                result.FinanceProfile.GovProcurements.Add(govProcurement);
            }

            //Случайные элементы
            if (random.Next(0, 2) == 1) result.Address.Insert(0, $"г.Киров, ул. Ленина, д. {random.Next(10, 100)}");
            if (random.Next(0, 2) == 1) result.Contacts.Add(newContacts);

            return result;
        }
        private OrganizationPropView SetProperties(Organization organization)
        {
            OrganizationPropView result = new(organization);
            result.HeadManagerMouseClickEvent += HeadManagerMouseClick;
            result.MapLinkClickEvent += MapLinkMouseClick;
            return result;
        }

        private void MapLinkMouseClick(MapLink sender)
        {
            _mainWindow.MainTabControl.SelectedIndex = 2;
            _mainWindow.MapView.CenterOnMarker(sender);
        }

        private void HeadManagerMouseClick(string sender)
        {
            _mainWindow.MainTabControl.SelectedIndex = 1;
            _mainWindow.PersonsView.SelectPerson(sender);
        }

        private void AddTextBlock(Organization organization)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = organization.Name;
            textBlock.Tag = organization;
            OrganizationsListBox.Items.Add(textBlock);
        }

        public void SelectOrganization(Organization organization)
        {
            _selectedItem = Organizations.Where(o => o == organization).FirstOrDefault();
            Properties.Children.Clear();
            if (_selectedItem != null)
                Properties.Children.Add(SetProperties(_selectedItem));
        }

    }
}
