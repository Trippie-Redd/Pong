using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Paddle
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private int speed = 1;
        private Color color = Color.White;
        private Keys up;
        private Keys down;

        public Paddle(Texture2D t)
        {
            texture = t;
        }

        public void Update()
        {
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(up))
            {
                rectangle.Y -= speed;
            }

            if (kState.IsKeyDown(down))
            {
                rectangle.Y += speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}