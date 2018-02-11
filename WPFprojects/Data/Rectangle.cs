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
        public Rectangle(int height, int width, int number)
        {
            Height = height;
            Width = width;
            RandomColor(number);
            Shape = new RectangleGeometry(new Rect(0, 0, Width, Height));       
        }

        private void RandomColor(int number)
        {
            if (number <= 33)
            {
                Color = Color.Blue;
            }
            else if (number > 33 && number <= 67)
            {
                Color = Color.Yellow;
            }
            else 
            {
                Color = Color.Red;
            }
        }
    }
}
