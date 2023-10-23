using System;
using System.Collections.Generic;
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

            for (int i = 0; i < 10; i++)
            {
                Organizations.Add(MakeOrganization());
            }
            foreach (Organization organization in Organizations)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = organization.Name;
                OrganizationsListBox.Items.Add(textBlock);
            }
        }

        private Organization MakeOrganization()
        {
            Random rnd = new Random();
            Contacts contacts = new Contacts()
            {
                Email = $"{rnd.Next(10, 20)}org@gmail.com",
                PhoneNumber = $"+7-{rnd.Next(100,900)}-{rnd.Next(100, 900)}-{rnd.Next(1000, 2000)}",
                WebSiteLink = $"{rnd.Next(10, 20)}org.com"
            };
            Person person = _mainWindow.PersonsView.Persons[rnd.Next(0, _mainWindow.PersonsView.Persons.Count - 1)];
            OrganizationFinance organizationFinance = new OrganizationFinance();
            FinanceProfile financeProfile = new($"{rnd.Next(10000000, int.MaxValue)}", $"{rnd.Next(10000000, int.MaxValue)}", $"{rnd.Next(10000000, int.MaxValue)}", 
                                            DateTime.Now.AddMonths(-rnd.Next(20, 100)), $"{rnd.Next(10,100)} activity", organizationFinance);
            Organization result = new Organization(contacts, person, $"{rnd.Next(10, 300)} Бычков", null, financeProfile, DateTime.Now.AddDays(-rnd.Next(1, 20)));

            return result;
        }
    }
}
