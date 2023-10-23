using GMap.NET;
using GMap.NET.WindowsPresentation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;

namespace CityGuid.MVVM.View
{
    /// <summary>
    /// Interaction logic for MapView.xaml
    /// </summary>
    public partial class MapView : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private MainWindow _mainWindow;

        public MapView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            string pathToMap = System.IO.Path.GetFullPath(@"Files\GMap.NET");
            gmap.MapProvider = GMapProviders.OpenStreetMap;
            gmap.Manager.Mode = AccessMode.CacheOnly;
            gmap.CacheLocation = pathToMap;

            gmap.ShowCenter = false;
            gmap.DragButton = MouseButton.Left;
            gmap.Position = new PointLatLng(58.6041, 49.6704);
            gmap.MinZoom = 15;
            gmap.MaxZoom = 17;
            gmap.Zoom = 15;

            foreach(var organization in _mainWindow.OrganizationsView.Organizations)
            {
                gmap.Markers.Add(new GMapMarker(new PointLatLng(organization.MapLink.Y, organization.MapLink.X)));
            }
        }
    }
}
