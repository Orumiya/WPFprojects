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
            int whereIsmyElementOnY = 300;
            if (number <= 25)
            {
                return new Circle(width, height) { Location = new Point(ScreenWidth, whereIsmyElementOnY) };
            }
            else if (number > 25 && number <= 50)
            {
                return new Cross(width, height) { Location = new Point(ScreenWidth, whereIsmyElementOnY) };
            }
            else if (number > 50 && number <= 75)
            {
                return new Triangle(width, height) { Location = new Point(ScreenWidth, whereIsmyElementOnY) };
                
            }
            else
            {
                return new Rectangle(width, height) { Location = new Point(ScreenWidth, whereIsmyElementOnY) };
            }

        }

        public void DoTurn()
        {
            
            for (int i = 0; i < GameElementList.Count; i++)
            {
                if (GameElementList[i].Location.X == (int)(ScreenWidth*0.9))
                {   
                    GameElementList.Add(GenerateRandomElement(80,80));
                }
                
                GameElementList[i].Location = new Point(GameElementList[i].Location.X - 1, GameElementList[i].Location.Y);

                if (GameElementList[i].Location.X == 0 - GameElementList[i].Width)
                {
                    GameElementList.Remove(GameElementList[i]);
                }
            }

            
        }

        private void GenerateTheChoosenOne()
        {
            TheChoosenOne = GenerateRandomElement(150,150);
            TheChoosenOne.Location = new Point(ScreenWidth / 2 - TheChoosenOne.Width / 2, 10);
        }
    }
}
