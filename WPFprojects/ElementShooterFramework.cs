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
        private DispatcherTimer FallingAnimTimer;

        public List<GameElement> ClickedElementList { get; set; }

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
                        bool goodShoot = ElementShooterGame.ClickedOnTheProperElement(ElementShooterGame.GameElementList[i]);

                        if (goodShoot)
                        {
                            ClickedElementList.Add(ElementShooterGame.GameElementList[i]);
                            ElementShooterGame.GameElementList[i].IsClicked = true;
                            FallingAnimTimer.Start();
                            ElementShooterGame.GenerateTheChoosenOne();
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
                timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
                timer.Tick += Timer_Tick;
                timer.Start();
                FallingAnimTimer = new DispatcherTimer();
                FallingAnimTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                FallingAnimTimer.Tick += FallingAnimTimer_Tick;
                ClickedElementList = new List<GameElement>();
                this.InvalidateVisual();
                this.Focusable = true;
                this.Focus();
            }
        }

        private void FallingAnimTimer_Tick(object sender, EventArgs e)
        {
            bool falling = ElementShooterGame.DoFall(ClickedElementList);
            if (!falling)
            {
                FallingAnimTimer.Stop();
            }
            this.InvalidateVisual();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            bool isGame = ElementShooterGame.DoTurn();
            if (!isGame)
            {
                timer.Stop();
            }
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (ElementShooterGame != null)
            {
                Geometry backgroundGeometry = new RectangleGeometry(new Rect(0, 280, ScreenWidth, 130));
                drawingContext.DrawGeometry(Brushes.LightGray, new Pen(Brushes.LightGray, 1), backgroundGeometry);

                for (int i = 0; i < ElementShooterGame.GameElementList.Count; i++)
                {
                    if (ElementShooterGame.GameElementList[i] is Cross)
                    {
                        Brush brush = WhichColorIsMyBrush(ElementShooterGame.GameElementList[i]);
                        drawingContext.DrawGeometry(Brushes.Azure, new Pen(brush, 25), ElementShooterGame.GameElementList[i].GetTransformedGeometry());
                    }
                    else
                    {
                        Brush brush = WhichColorIsMyBrush(ElementShooterGame.GameElementList[i]);
                        
                        drawingContext.DrawGeometry(brush, new Pen(Brushes.Black, 4), ElementShooterGame.GameElementList[i].GetTransformedGeometry());
                    }
                    

                }

                if (ElementShooterGame.TheChoosenOne is Cross)
                {
                    Brush brush = WhichColorIsMyBrush(ElementShooterGame.TheChoosenOne);
                    drawingContext.DrawGeometry(Brushes.Azure, new Pen(brush, 25), ElementShooterGame.TheChoosenOne.GetTransformedGeometry());
                }
                else
                {
                    Brush brush = WhichColorIsMyBrush(ElementShooterGame.TheChoosenOne);
                    drawingContext.DrawGeometry(brush, new Pen(Brushes.Black, 4), ElementShooterGame.TheChoosenOne.GetTransformedGeometry());
                }

               
            }
        }

        private Brush WhichColorIsMyBrush(GameElement element)
        {
            Brush brush;
            if (element.Color == Data.Color.Blue)
            {
                brush = Brushes.Blue;
                
            }
            else if (element.Color == Data.Color.Red)
            {
                brush = Brushes.Red;
            }
            else
            {
                brush = Brushes.Yellow;
            }
            return brush;
        }
    }
}
