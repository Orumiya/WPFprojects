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

        public Circle(int height, int width, int number)
        {
            Height = height;
            Width = width;
            RandomColor(number);
            Shape = new EllipseGeometry(new Rect(0, 0, Width, Height));
        }

        private void RandomColor(int number)
        {
            if (number <= 33)
            {
                Color = Color.Blue;
            }
            else if (number > 33 && number <= 67)
            {
                Color = Color.Red;
            }
            else
            {
                Color = Color.Yellow;
            }
        }
    }
}
