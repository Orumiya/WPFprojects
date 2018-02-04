using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFprojects.Data
{
    class Cross : GameElement
    {
        
        public Cross(int height, int width)
        {
            GeometryGroup group = new GeometryGroup();
            Height = height;
            Width = width;
            group.Children.Add(new LineGeometry(Location, new Point(Location.X + Width, Location.Y + Height)));
            group.Children.Add(new LineGeometry(new Point(Location.X, Location.Y + Height), new Point(Location.X + Width, Location.Y)));
           
            Shape = group;
        }
    }
}
