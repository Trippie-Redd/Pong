using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FirstProject
{
    public class Scoreboard
    {
        private int score = 0;
        private int winScore = 2;
        private Vector2 location;
        private Color color;
        private SpriteFont font;
        private string player;

        public Scoreboard(Vector2 l, SpriteFont f, Color c, string p)
        {
            location = l;
            color = c;
            player = p;
            font = f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (score >= winScore)
            {
                spriteBatch.DrawString(font, player + " wins!", location, color);
            }

            else
            {
                spriteBatch.DrawString(font, Convert.ToString(score), location, color);
            }
        }

        public void UpdateScore(int s)
        {
            score += s;
        }
    }
}