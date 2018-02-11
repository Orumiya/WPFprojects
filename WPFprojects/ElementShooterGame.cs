using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFprojects.Data;

namespace WPFprojects
{
    class ElementShooterGame
    {
        private static Random rnd = new Random();
        private List<GameElement> gameElementList;
        private double ScreenWidth { get; set; }
        private double ScreenHeight { get; set; }

        private int Dx { get; set; }
        private int Dy { get; set; }

        public GameElement TheChoosenOne { get; set; }


        public List<GameElement> GameElementList
        {
            get { return gameElementList; }
            set { gameElementList = value; }
        }

        public ElementShooterGame(double screenWidth, double screenHeight)
        {
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;
            GameElementList = new List<GameElement>();
            GameElementList.Add(GenerateRandomElement(80,80));
            GenerateTheChoosenOne();

        }

        private GameElement GenerateRandomElement(int width, int height)
        {
            int number = rnd.Next(1, 101);
            int colornumber = rnd.Next(1, 101);
            int whereIsmyElementOnY = 300;
            if (number <= 25)
            {
                return new Circle(width, height, colornumber) { Location = new Point(ScreenWidth, whereIsmyElementOnY) };
            }
            else if (number > 25 && number <= 50)
            {
                return new Cross(width, height, colornumber) { Location = new Point(ScreenWidth, whereIsmyElementOnY) };
            }
            else if (number > 50 && number <= 75)
            {
                return new Triangle(width, height, colornumber) { Location = new Point(ScreenWidth, whereIsmyElementOnY) };
                
            }
            else
            {
                return new Rectangle(width, height, colornumber) { Location = new Point(ScreenWidth, whereIsmyElementOnY) };
            }

        }

        public bool DoTurn()
        {
            if (!DoLose(GameElementList))
            {
                for (int i = 0; i < GameElementList.Count; i++)
                {
                    if (GameElementList[i].Location.X < (int)(ScreenWidth * 0.9) + 3 && GameElementList[i].Location.X >= (int)(ScreenWidth * 0.9) - 2)
                    {
                        GameElementList.Add(GenerateRandomElement(80, 80));
                    }
                    if (!GameElementList[i].IsClicked)
                    {
                        GameElementList[i].Location = new Point(GameElementList[i].Location.X - 5, GameElementList[i].Location.Y);
                    }
                    

                    if (GameElementList[i].Location.X == 0 - GameElementList[i].Width)
                    {
                        GameElementList.Remove(GameElementList[i]);
                    }
                }

            }
            else
            {
                MessageBox.Show("You lost!");
                return false;

            }

            return true;
            

            
        }

        public bool DoFall(List<GameElement> elementList)
        {
            if (elementList != null || elementList.Count != 0)
            {
                for (int i = 0; i < elementList.Count; i++)
                {
                    if (elementList[i].Location.Y <= ScreenHeight)
                    {
                        elementList[i].Location = new Point(elementList[i].Location.X, elementList[i].Location.Y + 2);
                    }
                    else
                    {
                        elementList.Remove(elementList[i]);
                    }
                }
                return true;
            }else
            {
                return false;
            }
            
            
            
        }

        public void GenerateTheChoosenOne()
        {
            TheChoosenOne = GenerateRandomElement(150,150);
            TheChoosenOne.Location = new Point(ScreenWidth / 2 - TheChoosenOne.Width / 2, 10);
        }

        public bool ClickedOnTheProperElement(GameElement element)
        {
            if (element is Circle && TheChoosenOne is Circle)
            {
                if (element.Color == TheChoosenOne.Color)
                {
                    Console.WriteLine("circle");
                    return true;
                }
                return false;
            }
            else if (element is Triangle && TheChoosenOne is Triangle)
            {
                if (element.Color == TheChoosenOne.Color)
                {
                    Console.WriteLine("haromszog");
                    return true;
                }
                return false;
            }
            else if (element is Rectangle && TheChoosenOne is Rectangle)
            {
                if (element.Color == TheChoosenOne.Color)
                {
                    Console.WriteLine("negyzet");
                    return true;
                }
                return false;
            }
            else if (element is Cross && TheChoosenOne is Cross)
            {
                
                if (element.Color == TheChoosenOne.Color)
                {
                    Console.WriteLine("cross");
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }

        public bool DoLose(List<GameElement> elementList)
        {
            int i = 0;
            while (i < elementList.Count && !ClickedOnTheProperElement(elementList[i]))
            {
                i++;
            }

            if (i < elementList.Count && ClickedOnTheProperElement(elementList[i]))
            {
                if (elementList[i].Location.X < 0) //&& !elementList[i].IsClicked
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        
    }
}
