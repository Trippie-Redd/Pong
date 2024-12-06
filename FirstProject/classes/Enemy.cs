using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstProject
{
    public class Enemy
    {
        private Texture2D texture;
        private Color color = Color.Red;
        private Rectangle rectangle = new Rectangle(780, 460, 20, 20);

        private int speed = 1;

        public Rectangle Rectangle
        {
            get{return rectangle;}
        }

        public Enemy(Texture2D t)
        {
            texture = t;
        }

        public void Update(Vector2 target)
        {
            Move(target);
        }

        private void Move(Vector2 target)
        {
            if (rectangle.Y > target.Y)
            {
                rectangle.Y -= speed;
            }

            else if (rectangle.Y < target.Y) 
            {
                rectangle.Y += speed;
            }

            if (rectangle.X > target.X)
            {
                rectangle.X -= speed;
            }

            else if (rectangle.X < target.X) 
            {
                rectangle.X += speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }
    }
}