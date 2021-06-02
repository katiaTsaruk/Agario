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
        private int startRadius=5;

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
            circleShape.Origin = new Vector2f(startRadius, startRadius);
            circleShape.OutlineColor=Color.Black;
            circleShape.OutlineThickness = 1f;
            circleShape.FillColor=Color.Yellow;
        }
    }
}