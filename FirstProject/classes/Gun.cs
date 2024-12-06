using System.Collections.Generic;
using FirstProject;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Gun
    {
        private List<Bullet> list;
        private int ammo = 10;

        public Gun()
        {
            list = new List<Bullet>();
        }

        public void Update()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Dead)
                    list.RemoveAt(i);
                else
                    list[i].Update();
            }
        }

        public void Shoot(Bullet b)
        {
            if (ammo > 0)
            {
                list.Add(b);
                ammo--;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet b in list)
                b.Draw(spriteBatch);
        }

    }
}