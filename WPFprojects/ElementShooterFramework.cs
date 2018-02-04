using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using WPFprojects.Data;

namespace WPFprojects.ElementShooter
{
    class ElementShooterFramework : FrameworkElement
    {
        public ElementShooterGame ElementShooterGame { get; set; }
        private double ScreenWidth { get; set; }
        private double ScreenHeight { get; set; }

        private DispatcherTimer timer;

        public ElementShooterFramework()
        {
            this.Loaded += ElementShooterFramework_Loaded;
            this.MouseDown += ElementShooterFramework_MouseDown;
        }

        private void ElementShooterFramework_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);
            for (int i = 0; i < ElementShooterGame.GameElementList.Count; i++)
            {
                if (ElementShooterGame.GameElementList[i].Location.X <= point.X && ElementShooterGame.GameElementList[i].Location.X + ElementShooterGame.GameElementList[i].Width >= point.X)
                {
                    if (ElementShooterGame.GameElementList[i].Location.Y <= point.Y && ElementShooterGame.GameElementList[i].Location.Y + ElementShooterGame.GameElementList[i].Height >= point.Y)
                    {
                        if (ElementShooterGame.GameElementList[i] is Circle)
                        {
                            Console.WriteLine("circle");
                        }
                    }
                }
            }
            
        }

        private void ElementShooterFramework_Loaded(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this) == false)
            {
                ScreenHeight = this.ActualHeight;
                ScreenWidth = this.ActualWidth;
                ElementShooterGame = new ElementShooterGame(ScreenWidth, ScreenHeight);
                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                timer.Tick += Timer_Tick;
                timer.Start();
                
                this.InvalidateVisual();
                this.Focusable = true;
                this.Focus();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ElementShooterGame.DoTurn();
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (ElementShooterGame != null)
            {
                for (int i = 0; i < ElementShooterGame.GameElementList.Count; i++)
                {
                    if (ElementShooterGame.GameElementList[i] is Cross)
                    {
                        drawingContext.DrawGeometry(Brushes.Azure, new Pen(Brushes.Black, 25), ElementShooterGame.GameElementList[i].GetTransformedGeometry());
                    }
                    else
                    {
                        drawingContext.DrawGeometry(Brushes.Azure, new Pen(Brushes.Black, 4), ElementShooterGame.GameElementList[i].GetTransformedGeometry());
                    }
                    

                }
                if (ElementShooterGame.TheChoosenOne is Cross)
                {
                    drawingContext.DrawGeometry(Brushes.Azure, new Pen(Brushes.Black, 25), ElementShooterGame.TheChoosenOne.GetTransformedGeometry());
                }
                else
                {
                    drawingContext.DrawGeometry(Brushes.Azure, new Pen(Brushes.Black, 4), ElementShooterGame.TheChoosenOne.GetTransformedGeometry());
                }
            }
        }
    }
}
