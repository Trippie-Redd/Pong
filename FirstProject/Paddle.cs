using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Paddle
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private int speed = 3;
        private Color color = Color.White;
        private Keys up;
        private Keys down;
        public bool AI = false;

        public Rectangle Rectangle
        {
            get{return rectangle;}
        }

        public Paddle(Texture2D t, Keys u, Keys d, Rectangle r)
        {
            texture = t;
            up = u;
            down = d;
            rectangle = r;
        }

        public void Update()
        {
            KeyboardState kState = Keyboard.GetState();
            
            if (!AI)
            {
                if (kState.IsKeyDown(up))
                {
                    if (rectangle.Y >= 0)
                    {
                        rectangle.Y -= speed;
                    }
                } 

                if (kState.IsKeyDown(down))
                {
                    if (rectangle.Y <= 380)
                    {
                        rectangle.Y += speed;
                    }
                }
            }

            else
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}