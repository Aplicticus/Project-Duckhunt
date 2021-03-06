﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    public class Enemy
    {
        public string name { get; protected set; }
        public Texture2D texture { get; protected set; }
        public Texture2D rightTexture { get; protected set; }
        public Texture2D leftTexture { get; protected set; }
        public int health { get; set; }
        public Vector2 velocity;

        public bool dead;
        public Vector2 position;
        protected SpriteFont font;
        protected AnimatedSprite travelingAnimation;
        protected ContentManager theContent;
        protected GraphicsDevice graphics;

        public Enemy(string name, Texture2D rightTexture, Texture2D leftTexture, Vector2 position, int health, Vector2 velocity, ContentManager theContent, GraphicsDevice graphics)
        {
            this.name = name;
            this.rightTexture = rightTexture;
            this.leftTexture = leftTexture;
            this.health = health;
            this.velocity = new Vector2(velocity.X / 800 * graphics.Viewport.Width, velocity.Y);
            travelingAnimation = new AnimatedSprite(this.leftTexture, 3, 6, true);
            this.position = new Vector2((new Random().Next(0, 2) == 0) ? -((travelingAnimation.Texture.Width / travelingAnimation.Columns) * ((1f / 800) * graphics.Viewport.Width)) : graphics.Viewport.Width, new Random().Next(0, (int)(graphics.Viewport.Height * 0.4f)));
            this.theContent = theContent;
            this.graphics = graphics;

            font = theContent.Load<SpriteFont>("MenuFont");
        }

        public virtual void Update(Ammonition ammo)
        {
            health -= (IsHit(ref ammo)) ? ammo.damage : 0;
            velocity *= (position.X + (travelingAnimation.Texture.Width / travelingAnimation.Columns) * ((1f / 800) * graphics.Viewport.Width) < 0 || position.X > graphics.Viewport.Width) ? -1 : 1;
            travelingAnimation.Texture = (velocity.X > 0) ? rightTexture : leftTexture;
            dead = health < 1;

            travelingAnimation.Update();

            position += (!dead) ? velocity : Vector2.Zero;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (!dead)
            {
                travelingAnimation.Draw(spriteBatch, position, 1f / 800 * graphics.Viewport.Width);
                spriteBatch.DrawString(font, health.ToString(), new Vector2(position.X + travelingAnimation.Texture.Width / travelingAnimation.Columns, position.Y), Color.White);
            }
        }

        protected bool IsHit(ref Ammonition ammo)
        {
            if (ammo.hit && new Rectangle((int)ammo.position.X, (int)ammo.position.Y, (int)(ammo.texture.Width / 5 * ammo.scale), (int)(ammo.texture.Height / 2 * ammo.scale)).Intersects(new Rectangle((int)position.X, (int)position.Y, (int)(travelingAnimation.Texture.Width / travelingAnimation.Columns * (1f / 800 * graphics.Viewport.Width)), (int)(travelingAnimation.Texture.Height / travelingAnimation.Rows * (1f / 800 * graphics.Viewport.Width)))))
            {
                ammo.enemyHit = true;
                return true;
            }
            else
                return false;
        }
    }
}
