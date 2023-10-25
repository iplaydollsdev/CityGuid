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

        public delegate void MouseLeftClickEventHandler(CustomMarker sender);
        public event MouseLeftClickEventHandler? MouseLeftClickEvent;

        public delegate void MouseRightClickEventHandler(CustomMarker sender);
        public event MouseRightClickEventHandler? MouseRightClickEvent;

        public CustomMarker(PointLatLng pos, Organization organization, UIElement shape) : base(pos)
        {
            Organization = organization;
            MarkerShape = shape;
            Shape = shape;
            MarkerShape.MouseLeftButtonUp += MarkerLeftClick;
            MarkerShape.MouseRightButtonUp += MarkerRightClick;
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

        private void MarkerLeftClick(object sender, MouseButtonEventArgs e)
        {
            MouseLeftClickEvent?.Invoke(this);
        }
        private void MarkerRightClick(object sender, MouseButtonEventArgs e)
        {
            MouseRightClickEvent?.Invoke(this);
        }
    }
}
