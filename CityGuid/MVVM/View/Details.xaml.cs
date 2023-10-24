﻿using CityGuid.MVVM.Model;
using GMap.NET.MapProviders;
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
using System.Windows.Shapes;

namespace CityGuid.MVVM.View
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public Details(List<Contacts> contacts)
        {
            InitializeComponent();
            FillContacts(contacts);
        }
        public Details(List<string> addresses)
        {
            InitializeComponent();
            FillAddresses(addresses);
        }

        private void FillAddresses(List<string> addresses)
        {
            addresses.Reverse();
            bool first = true;
            foreach (var address in addresses)
            {
                TextBlock textBlock = new();
                textBlock.Text = address;
                Label label = new();
                label.Content = first ? "Актуальный адрес:" : "Старый адрес:";
                first = false;
                DetailsStackPanel.Children.Add(label);
                DetailsStackPanel.Children.Add(textBlock);
            }
        }

        private void FillContacts(List<Contacts> contacts)
        {
            contacts.Reverse();
            bool first = true;
            foreach (var contact in contacts)
            {
                List<string> contactStr = new();
                contactStr.Add($"Email: {contact.Email}" ?? "Email не указан");
                contactStr.Add($"Сайт: {contact.WebSiteLink}" ?? "Сайт не указан");
                contactStr.Add($"Телефон: {contact.PhoneNumber}" ?? "Телефон не указан");

                ListBox listBox = new ListBox();
                foreach (string contactProp in contactStr)
                {
                    ListBoxItem item = new ListBoxItem() { Content = contactProp };
                    listBox.Items.Add(item);
                }
                Label label = new();
                label.Content = first ? "Актуальные контакты:" : "Старые контакты:";
                first = false;
                DetailsStackPanel.Children.Add(label);
                DetailsStackPanel.Children.Add(listBox);
            }
        }
    }
}
