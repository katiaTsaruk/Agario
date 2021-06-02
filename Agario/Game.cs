using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Agario
{
    public class Game
    {
        private const int windowWidth = 1280;
        private const int windowHeight = 720;
        public List<Circle> AllCircles = new List<Circle>();
        private Circle circle = new Circle(windowWidth, windowHeight);
        private int amountOfCircles = 0;

        public Game()
        {
            
        }

        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(windowWidth, windowHeight), "Game window");
            window.Closed += WindowClosed;

            while (amountOfCircles <= 100)
            {
                window.Draw(circle.circleShape);
                circle.SetCircle();
                amountOfCircles++;
            }

            while (window.IsOpen)
            {
               window.Clear();

               window.DispatchEvents();
               window.Display();
            }
        }
        
        private void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }
    }
}