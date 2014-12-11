using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateSwitchTest
{
    class Enemy
    {
        public string name { get; protected set; }
        public Texture2D texture { get; protected set; }
        public int health { get; set; }
        public Vector2 velocity { get; protected set; }

        public bool dead;
        private Vector2 position;
        private SpriteFont font;

        public Enemy(string name, Texture2D texture, Vector2 position, int health, Vector2 velocity, ContentManager theContent)
        {
            this.name = name;
            this.texture = texture;
            this.health = health;
            this.velocity = velocity;
            this.position = position;

            font = theContent.Load<SpriteFont>("MenuFont");
        }

        public void Update(Ammonition ammo)
        {
            if (IsHit(ref ammo))
            {
                health -= ammo.damage;
            }

            dead = health < 1;

            if (!dead)
                position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!dead)
            {
                spriteBatch.Draw(texture, position, Color.White);
                spriteBatch.DrawString(font, health.ToString(), new Vector2(position.X + texture.Width, position.Y), Color.White);
            }
        }

        protected bool IsHit(ref Ammonition ammo)
        {
            if (ammo.hit && new Rectangle((int)ammo.position.X, (int)ammo.position.Y, (int)(ammo.texture.Width / 5 * ammo.scale), (int)(ammo.texture.Height / 2 * ammo.scale)).Intersects(new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height)))
            {
                ammo.enemyHit = true;
                return true;
            }
            else
                return false;
        }
    }
}
