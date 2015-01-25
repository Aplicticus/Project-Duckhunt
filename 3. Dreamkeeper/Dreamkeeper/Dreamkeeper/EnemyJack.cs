using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    public class EnemyJack : Enemy
    {
        public EnemyJack(string name, Texture2D rightTexture, Texture2D leftTexture, Vector2 position, int health, Vector2 velocity, ContentManager theContent, GraphicsDevice graphics)
            : base(name, rightTexture, leftTexture, position, health, velocity, theContent, graphics)
        {
            this.position = new Vector2(new Random().Next(0, graphics.Viewport.Width), 0);
            travelingAnimation = new AnimatedSprite(this.leftTexture, 1, 3, true);
        }

        public override void Update(Ammonition ammo)
        {
            health -= (IsHit(ref ammo)) ? ammo.damage : 0;
            velocity.X *= (position.X + (travelingAnimation.Texture.Width / travelingAnimation.Columns) * ((1f / 800) * graphics.Viewport.Width) < 0 || position.X > graphics.Viewport.Width) ? -1 : 1;
            if (position.Y < graphics.Viewport.Height)
                velocity.Y += 0.3f * (1f / 600 * graphics.Viewport.Height);
            else if (position.Y > graphics.Viewport.Height)
                velocity.Y *= -1;
            travelingAnimation.Texture = (velocity.X > 0) ? rightTexture : leftTexture;
            dead = health < 1;

            travelingAnimation.Update();

            position += (!dead) ? velocity : Vector2.Zero;
        }
    }
}
