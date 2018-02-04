using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPFprojects.Data
{
    class GameElement
    {
        private Point location;

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
        private Geometry shape;

        public Geometry Shape
        {
            get { return shape; }
            set { shape = value; }
        }
        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public bool IsClicked { get; set; }

        public GameElement()
        {
            IsClicked = false;
        }
        public Geometry GetTransformedGeometry()
        {
            Geometry copy = Shape.Clone();
            copy.Transform = new TranslateTransform(Location.X, Location.Y);
            return copy.GetFlattenedPathGeometry();
        }


    }
}
