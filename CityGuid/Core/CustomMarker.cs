using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace CityGuid.Core
{
    public class CustomMarker : GMapMarker
    {
        public Organization Organization { get; set; }
        public UIElement MarkerShape { get; set; }

        public delegate void MouseEnterEventHandler(CustomMarker sender);
        public event MouseEnterEventHandler? MouseEnterEvent;

        public delegate void MouseLeaveEventHandler(CustomMarker sender);
        public event MouseEnterEventHandler? MouseLeaveEvent;

        public delegate void MouseClickEventHandler(CustomMarker sender);
        public event MouseClickEventHandler? MouseClickEvent;

        public CustomMarker(PointLatLng pos, Organization organization, UIElement shape) : base(pos)
        {
            Organization = organization;
            MarkerShape = shape;
            Shape = shape;
            MarkerShape.MouseLeftButtonUp += MarkerClick;
            MarkerShape.MouseEnter += MarkerMouseEnter;
            MarkerShape.MouseLeave += MarkerMouseLeave;
        }

        private void MarkerMouseLeave(object sender, MouseEventArgs e)
        {
            MouseLeaveEvent?.Invoke(this);
        }

        private void MarkerMouseEnter(object sender, MouseEventArgs e)
        {
            MouseEnterEvent?.Invoke(this);
        }

        private void MarkerClick(object sender, MouseButtonEventArgs e)
        {
            MouseClickEvent?.Invoke(this);
        }
    }
}
