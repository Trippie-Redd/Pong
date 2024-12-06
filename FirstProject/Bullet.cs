using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstProject
{
    public class Bullet
    {
        private Texture2D texture;
        private Color color = Color.Orange;
        private Rectangle rectangle;

        private Vector2 target;

        public Bullet(Vector2 t, Vector2 l, Texture2D te)
        {
            target = t;
            texture = te;
            rectangle = new Rectangle(Convert.ToInt32(l.X), Convert.ToInt32(l.Y), 20, 20);
            Update();
        }

        private void Update()
        {
            while (rectangle.X != target.X && rectangle.Y != target.Y)
            {
                // Moves bullet
                if (rectangle.X > target.X)
                    rectangle.X++;
                else if (rectangle.X < target.X)
                    rectangle.X--;
                if (rectangle.Y > target.Y)
                    rectangle.Y--;
                else if (rectangle.Y < target.Y)
                    rectangle.Y++;
            }
        }
    }
}