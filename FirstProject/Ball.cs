using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Ball
    {
        private Texture2D texture;
        private Rectangle rectangle = new Rectangle(390, 230, 20, 20);
        private Vector2 velocity = new Vector2(2, 2);
        private Color color = Color.White;
        private Vector2 position;

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
            position.X = velocity.X; 
            position.Y = velocity.Y;

            rectangle.X += (int)position.X;
            rectangle.Y += (int)position.Y;

            // Checks for player collisions

            // Checks for floor/roof collisions
            if (rectangle.Y < 0 || rectangle.Y + rectangle.Height >= 480)
            {
                velocity.Y *= -1.05f;
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
            velocity.X = 3;
            velocity.Y = 2;
        }

        public void Bounce()
        {
            velocity.X *= -1.05f;
        }
    }
}