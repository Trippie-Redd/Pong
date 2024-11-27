using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Ball
    {
        private Texture2D texture;
        private Rectangle rectangle = new Rectangle(390, 230, 20, 20);
        private Vector2 velocity = new Vector2(1, 1);
        private Color color = Color.White;

        public Rectangle Rectangle
        {
            get{return rectangle;}
        }

        public Ball(Texture2D t)
        {
            texture = t;
        }

        public void Update()
        {
            rectangle.X += (int)velocity.X;
            rectangle.Y += (int)velocity.Y;

            // Checks for player collisions

            // Checks for floor/roof collisions
            if (rectangle.Y < 0 || rectangle.Y + rectangle.Height >= 480)
            {
                velocity.Y *= -1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }

        // Resets ball to og location
        public void Reset()
        {
            rectangle.X = 390;
            rectangle.Y = 230;
            velocity.X = 2;
            velocity.Y = 2;
        }
    }
}