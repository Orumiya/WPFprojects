using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFprojects.Data
{
    class Circle : GameElement
    {
        public Circle(int height, int width)
        {
            Height = height;
            Width = width;
            Shape = new EllipseGeometry(new Rect(0, 0, Width, Height));
        }
    }
}
