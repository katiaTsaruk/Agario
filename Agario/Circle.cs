using System;
using SFML.Graphics;
using SFML.System;

namespace Agario
{
    public class Circle
    {
        private int windowWidth;
        private int windowHeight;
        public CircleShape circleShape = new CircleShape();
        public int startRadius=4;

        public Circle(int windowWidth,int windowHeight)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            SetCircle();
        }
        public void SetCircle()
        {
            Random random=new Random();
            circleShape.Position=new Vector2f(random.Next(0,windowWidth-startRadius),random.Next(0,windowHeight-startRadius));
            circleShape.Radius = startRadius;
            circleShape.Origin = new Vector2f(startRadius/2, startRadius/2);
            circleShape.OutlineColor=Color.Black;
            circleShape.OutlineThickness = 1f;
            circleShape.FillColor=new Color((byte)random.Next(0,256),(byte)random.Next(0,256),(byte)random.Next(0,256));
        }
        private bool TryToChangePosition(float deltaX, float deltaY)
        {
            float newY = circleShape.Position.Y + deltaY;
            float newX = circleShape.Position.X + deltaX;
            if (newX > startRadius / 2 && newX < windowWidth && newY > startRadius / 2 && newY < windowHeight)
            {
                return true;
            }
            else return false;
        }
        
    }
}