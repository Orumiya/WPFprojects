﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFprojects.Data
{
    class Triangle : GameElement
    {
        public Triangle(int height, int width, int number)
        {
            Height = height;
            Width = width;
            RandomColor(number);
            PathGeometry pathGeometry = new PathGeometry();
            PathFigure figure1 = new PathFigure();
            figure1.StartPoint = new Point(Location.X + Width / 2, Location.Y);
            PathSegmentCollection segmentCollection = new PathSegmentCollection();
            segmentCollection.Add(new LineSegment() { Point = new Point(Location.X, Location.Y + Height) });
            segmentCollection.Add(new LineSegment() { Point = new Point(Location.X + Width, Location.Y + Height) });
            figure1.Segments = segmentCollection;
            figure1.IsClosed = true;
            pathGeometry.Figures.Add(figure1);
            Shape = pathGeometry;
        }

        private void RandomColor(int number)
        {
            if (number <= 33)
            {
                Color = Color.Yellow;
            }
            else if (number > 33 && number <= 67)
            {
                Color = Color.Red;
            }
            else 
            {
                Color = Color.Blue;
            }

        }
    }
}
