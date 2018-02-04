using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFprojects.Data
{
    class Rectangle : GameElement
    {
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
            Shape = new RectangleGeometry(new Rect(0, 0, Width, Height));       
        }
    }
}
