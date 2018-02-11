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
        
        public Cross(int height, int width, int number)
        {
            GeometryGroup group = new GeometryGroup();
            Height = height;
            Width = width;
            RandomColor(number);
            group.Children.Add(new LineGeometry(Location, new Point(Location.X + Width, Location.Y + Height)));
            group.Children.Add(new LineGeometry(new Point(Location.X, Location.Y + Height), new Point(Location.X + Width, Location.Y)));
           
            Shape = group;
        }

        private void RandomColor(int number)
        {
            if (number <= 33)
            {
                Color = Color.Red;
            }
            else if (number > 33 && number <= 67)
            {
                Color = Color.Yellow;
            }
            else 
            {
                Color = Color.Blue;
            }

        }
    }
}
