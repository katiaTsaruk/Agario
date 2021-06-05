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
        private RenderWindow window = new RenderWindow(new VideoMode(windowWidth, windowHeight), "Game window");
        public List<Circle> AllCircles = new List<Circle>();

        private void DrawCircles()
        {
            foreach(Circle circle in AllCircles)
            {
                window.Draw(circle.circleShape);
            }
        }
        
        private void CreateCircles()
        {
            while (AllCircles.Count <= 150)
            {
                Circle circle = new Circle(windowWidth, windowHeight);
                AllCircles.Add(circle);
            }
        }

        private bool IsIntersecting(int targetCircle,int currentCircle)
        {
            float targetX = AllCircles[targetCircle].circleShape.Position.X;
            float currentX = AllCircles[currentCircle].circleShape.Position.X;
            float targetY = AllCircles[targetCircle].circleShape.Position.Y;
            float currentY = AllCircles[currentCircle].circleShape.Position.Y;
            return targetX < currentX + AllCircles[currentCircle].circleShape.Radius &&
                   targetX > currentX - AllCircles[currentCircle].circleShape.Radius &&
                   targetY < currentY + AllCircles[currentCircle].circleShape.Radius &&
                   targetY > currentY - AllCircles[currentCircle].circleShape.Radius;
        }

        private void DeleteEatedAndIncrese(int targetCircle,int currentCircle)
        {
            if(IsIntersecting(targetCircle, currentCircle))
            {
                AllCircles[currentCircle].circleShape.Radius += AllCircles[targetCircle].circleShape.Radius/10;
                AllCircles.RemoveAt(targetCircle);
            }
        }

        

        private Vector2f FindMoveVector(int currentCircle)
        {
            int targetCircle = FindMoveTarget(currentCircle);
            Vector2f moveVector = new Vector2f(
                AllCircles[targetCircle].circleShape.Position.X - AllCircles[currentCircle].circleShape.Position.X,
                AllCircles[targetCircle].circleShape.Position.Y - AllCircles[currentCircle].circleShape.Position.Y);
            return moveVector;
        }

        private void BotMoveAndEat()
        {
            
            for (int currentCircle = 0; currentCircle < 15; currentCircle++)
            {
                int targetCircle = FindMoveTarget(currentCircle);
                AllCircles[currentCircle].circleShape.Position += FindMoveVector(currentCircle)/1000;
                DeleteEatedAndIncrese(targetCircle, currentCircle);
                
            }
        }

        private int FindMoveTarget(int currentCircle)
        {
            int targetCircle=currentCircle;
            float deltaX = AllCircles[currentCircle].circleShape.Position.X - AllCircles[currentCircle + 1].circleShape.Position.X;
            float deltaY = AllCircles[currentCircle].circleShape.Position.Y - AllCircles[currentCircle + 1].circleShape.Position.Y;
            float distance = deltaX * deltaX + deltaY * deltaY;
            for (int j = 0; j < AllCircles.Count; j++)
            {
                if (currentCircle != j)
                {
                    deltaX = AllCircles[currentCircle].circleShape.Position.X - AllCircles[j].circleShape.Position.X;
                    deltaY = AllCircles[currentCircle].circleShape.Position.Y - AllCircles[j].circleShape.Position.Y;
                    if (distance > deltaX * deltaX + deltaY * deltaY) 
                    {
                        distance = deltaX * deltaX + deltaY * deltaY;
                        targetCircle = j;
                    }
                }
            }
            return targetCircle;
        }

        public void Start()
        {
            window.Closed += WindowClosed;

            while (window.IsOpen)
            {
                window.Clear();
                CreateCircles();
                DrawCircles();
                BotMoveAndEat();
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