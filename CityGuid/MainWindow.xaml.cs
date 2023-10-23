using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using GMap.NET;
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
using System.IO;
using CityGuid.MVVM.View;

namespace CityGuid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MapView MapView { get; private set; }
        public PersonsView PersonsView { get; private set; }
        public OrganizationsView OrganizationsView { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Person person1 = new Person("1", "1", "1");
            Person person2 = new Person("2", "2", "2");
            Person person = new Person("a", "b", "c", DateTime.Now, contacts: new Contacts(), new PersonFinance(), DateTime.Now);

            PersonsView = new PersonsView(this);
            OrganizationsView = new OrganizationsView(this);
            MapView = new MapView(this);
            TabPersons.Content = PersonsView;
            TabOrganizations.Content = OrganizationsView;
            TabMap.Content = MapView;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
