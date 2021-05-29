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

        public Game()
        {
            
        }

        public void Start()
        {
            RenderWindow window = new RenderWindow(new VideoMode(windowWidth, windowHeight), "Game window");
            window.Closed += WindowClosed;

            while (window.IsOpen)
            {
                window.Clear(Color.Cyan);
               
                window.DispatchEvents();
                window.Display();
            }
        }
        
        private void WindowClosed(object sender, EventArgs e)
        {
            RenderWindow w = (RenderWindow)sender;
            w.Close();
        }

        // moglo bi bit krasivo no vidimo net(((
        // private void Background()
        // {
        //     Texture t=new Texture("picture");
        //     Image image=new Image("picture.jpg");
        //     Sprite sprite = new Sprite();
        //     sprite.Texture = new Texture(t);
        //     window.Draw(sprite);
        // }
    }
}