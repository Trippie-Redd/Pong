using System;
using FirstProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    public class Player
    {
        private Texture2D texture;
        private Color color = Color.White;
        private Rectangle rectangle = new Rectangle(390, 230, 20, 20);
        
        // stamina vars
        private int max_stamina = 100;
        private int stamina_regen = 5;
        private int stamina_drain = 1;
        private int stamina = 100;
        
        // Speed vars
        private int walk_speed = 3;
        private int sprint_speed = 9;
        private int speed;
        bool is_still;

        // All inputs
        private Keys up = Keys.W;
        private Keys down = Keys.S;
        private Keys left = Keys.A;
        private Keys right = Keys.D;
        private Keys sprint = Keys.LeftShift;

        public Rectangle Rectangle
        {
            get{return rectangle;}
        }

        public Player(Texture2D t)
        {
            texture = t;
        }

        public void Update()
        {
            KeyboardState kState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            Console.WriteLine(stamina);
            Run(kState);
            Move(kState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, color);
        }

        public bool IsDead(Enemy enemy)
        {
            return rectangle.Intersects(enemy.Rectangle);
        }

        // Handles WASD movement
        private void Move(KeyboardState kState)
        {
            // Movement input
            if (kState.IsKeyDown(up))
            {
                if (rectangle.Y > 0)
                    rectangle.Y -= speed;
            } 

            if (kState.IsKeyDown(down))
            {
                if (rectangle.Y < 460)
                    rectangle.Y += speed;
            } 

            if (kState.IsKeyDown(left))
            {
                if (rectangle.X > 0)
                    rectangle.X -= speed;
            }

            if (kState.IsKeyDown(right))
            {
                if (rectangle.X < 780)
                    rectangle.X += speed;
            }
        }

        // Handles sprinting and stamina logic
        private void Run(KeyboardState kState)
        {
            // Checks if the player is standing still
            if (!kState.IsKeyDown(up) && !kState.IsKeyDown(down) && !kState.IsKeyDown(left) && !kState.IsKeyDown(right)){ is_still = true;} 
            else { is_still = false;}

            // When player sprints
            if (kState.IsKeyDown(sprint) && stamina > 0 && !is_still)
            {
                speed = sprint_speed;
                stamina -= stamina_drain;
            }
           
            // When player tries sprining but can't
            else if (kState.IsKeyDown(sprint) && stamina <= 0)
            {
                speed = walk_speed;
            }
                
            // When player walks
            else
            {
                speed = walk_speed;
                if (stamina <= max_stamina)
                    stamina += stamina_regen;
            }
        }
    }
}