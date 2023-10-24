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
using static CityGuid.Core.CustomMarker;

namespace CityGuid.MVVM.View
{


    public partial class OrganizationPropView : UserControl
    {
        private Organization Organization { get; }
        public List<string> Contacts { get; private set; } = new();
        public string HeadManager { get; private set; }
        public string OrgName { get; private set; }
        public MapLink MapLink { get; private set; }
        public string Address { get; private set; }
        public List<string> FinanceProfile { get; private set; } = new();

        public string RelevanceDate { get; private set; }

        public delegate void MouseClickEventHandler(string sender);
        public event MouseClickEventHandler? HeadManagerMouseClickEvent;
        public delegate void MouseClickLinkEventHandler(MapLink sender);
        public event MouseClickLinkEventHandler? MapLinkClickEvent;
        public OrganizationPropView(Organization organization)
        {
            InitializeComponent();

            DataContext = this;
            Organization = organization;

            FillContacts(organization);
            OrgName = organization.Name;
            HeadManager = organization.HeadManager.GetFullName();
            MapLink = organization.MapLink;
            Address = organization.Address.Last();
            if (organization.Address.Count > 1)
            {
                AddressLabel.Content = "Адреса *";
                AddressLabel.Foreground = Brushes.Blue;
                AddressLabel.MouseUp += OnAddressesClick;
            }

            FillFinanceProfile(organization);
            RelevanceDate = organization.RelevanceDate.ToString("dd/M/yyyy");
        }



        private void FillContacts(Organization organization)
        {
            if (organization.Contacts.Count > 1)
            {
                ContactsLabel.Content = "Контакты *";
                ContactsLabel.Foreground = Brushes.Blue;
                ContactsLabel.MouseUp += OnContactsClick;
            }
                
            Contacts contacts = organization.Contacts.Last();
            Contacts.Add($"Email: {contacts.Email ?? "не указан"}");
            Contacts.Add($"Сайт: {contacts.WebSiteLink ?? "не указан"}");
            Contacts.Add($"Телефон: {contacts.PhoneNumber ?? "не указан"}");

            foreach (string contactProp in Contacts)
            {
                ListBoxItem item = new ListBoxItem() { Content = contactProp };
                ContactsListBox.Items.Add(item);
            }
        }
        private void OnAddressesClick(object sender, MouseButtonEventArgs e)
        {
            Details contactsWindow = new Details(Organization.Address);
            contactsWindow.Show();
        }

        private void OnContactsClick(object sender, MouseButtonEventArgs e)
        {
            Details contactsWindow = new Details(Organization.Contacts);
            contactsWindow.Show();
        }

        private void FillFinanceProfile(Organization organization)
        {
            FinanceProfile financeProfile = organization.FinanceProfile;
            FinanceProfile.Add($"ОГРН: {financeProfile.OGRN}");
            FinanceProfile.Add($"ИНН: {financeProfile.INN}");
            FinanceProfile.Add($"КПП: {financeProfile.KPP}");
            FinanceProfile.Add($"Дата регистрации: {financeProfile.RegistranionDate.ToString("dd/M/yyyy")}");
            FinanceProfile.Add($"Деятельность: {financeProfile.MainActivity}");
            OrganizationFinance orgFinance = financeProfile.OrganizationFinance;

            FinanceProfile.Add($"Долги: {orgFinance.Debts}");
            FinanceProfile.Add($"Уставный капитал: {orgFinance.AuthorizedCapital}");
            FinanceProfile.Add($"Доход: {orgFinance.Revenue}");
            FinanceProfile.Add($"Расходы: {orgFinance.Expenses}");
            FinanceProfile.Add($"Прибыль: {orgFinance.Profit}");
            FinanceProfile.Add($"Количество сотрудников: {orgFinance.NumberOfEmployees}");



            foreach (string financeProp in FinanceProfile)
            {
                Label item = new() { Content = financeProp };
                MainStackPanel.Children.Add(item);
            }
            foreach (var cCase in financeProfile.CourtCases)
            {
                ListBox listBox = new();
                listBox.IsEnabled = false;

                listBox.Items.Add($"Судебное дело от {cCase.CaseDate.ToString("dd/M/yyyy")}");
                listBox.Items.Add($"Истец - {cCase.Claimant}");
                listBox.Items.Add($"Расходы исца: {cCase.ClaimantCosts}");
                listBox.Items.Add($"Расходы ответчика: {cCase.DefedantCosts}");
                MainStackPanel.Children.Add(listBox);
            }
            foreach (var gProcurement in financeProfile.GovProcurements)
            {
                ListBox listBox = new();
                listBox.IsEnabled = false;

                listBox.Items.Add($"Госсзаказ от {gProcurement.Date.ToString("dd/M/yyyy")}");
                listBox.Items.Add(gProcurement.Name);
                listBox.Items.Add($"На выполнение получено: {gProcurement.Revenue} рублей");
                MainStackPanel.Children.Add(listBox);
            }
        }

        private void HeadManagerMouseUp(object sender, MouseButtonEventArgs e)
        {
            HeadManagerMouseClickEvent?.Invoke(HeadManager);
        }

        private void MapLinkMouseUp(object sender, MouseButtonEventArgs e)
        {
            MapLinkClickEvent?.Invoke(MapLink);
        }

    }
}
