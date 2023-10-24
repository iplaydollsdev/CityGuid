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
    public partial class MapView : UserControl
    {
        private MainWindow _mainWindow;
        private Label _label;

        public MapView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            string pathToMap = System.IO.Path.GetFullPath(@"Files\GMap.NET");
            gmap.MapProvider = GMapProviders.OpenStreetMap;
            gmap.Manager.Mode = AccessMode.CacheOnly;
            gmap.CacheLocation = pathToMap;

            _label = new Label();
            _label.Content = "Some label text";
            _label.Visibility = Visibility.Hidden;
            _label.Background = Brushes.White;
            canvas.Children.Add(_label);

            gmap.ShowCenter = false;
            gmap.DragButton = MouseButton.Left;
            gmap.Position = new PointLatLng(58.6041, 49.6704);
            gmap.MinZoom = 15;
            gmap.MaxZoom = 17;
            gmap.Zoom = 15;

            foreach(var organization in _mainWindow.OrganizationsView.Organizations)
            {
                UIElement shape = new Image
                {
                    Width = 30,
                    Height = 30,
                    Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath(@"Files\Marker.png")))
                };

                CustomMarker marker = new CustomMarker(new PointLatLng(organization.MapLink.Y, organization.MapLink.X), organization, shape);
                gmap.Markers.Add(marker);
                marker.MouseEnterEvent += OnMouseEnter;
                marker.MouseLeaveEvent += OnMouseLeave;
                marker.MouseClickEvent += OnMouseClick;
            }
        }

        private void OnMouseClick(CustomMarker sender)
        {
            MessageBox.Show(sender.Organization.Name);
        }

        private void OnMouseLeave(CustomMarker sender)
        {
            _label.Visibility = Visibility.Hidden;
        }

        private void OnMouseEnter(CustomMarker sender)
        {
            
            Canvas.SetLeft(_label, Mouse.GetPosition(canvas).X + 10);
            Canvas.SetTop(_label, Mouse.GetPosition(canvas).Y + 10);
            _label.Content = sender.Organization.Name;
            _label.Visibility = Visibility.Visible;
        }
        public void CenterOnMarker(MapLink mapLink)
        {
            var position = gmap.Markers.Where(l => l.Position.Lat == mapLink.Y && l.Position.Lng == mapLink.X).FirstOrDefault();
            if (position != null)
            {
                gmap.Position = position.Position;
                gmap.Zoom = gmap.MaxZoom;
            }

        }
    }
}
