using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    public enum Ammonitions { GRAVEL, MUD, METAL, HOLYPELLET, MAGICPELLET }
    
    public class Ammonition : Item
    {
        public Ammonitions ammo { get; set; }
        public int damage { get; private set; }
        public Texture2D texture { get; private set; }
        public Texture2D hitTexture { get; private set; }
        public bool hit { get; private set; }
        public bool enemyHit { get; set; }
        public AnimatedSprite travelAnimation { get; private set; }
        public AnimatedSprite hitAnimation { get; private set; }
        public float scale { get; private set; }

        public Vector2 position;
        private bool falling;
        private int fallingTimer;
        private bool traveling;
        private Vector2 velocity;
        private Vector2? destination;
        private Vector2 mouseClickDestination;
        private Vector2 distance;
        private float acceleration;
        private MouseState oldState;
        
        public Ammonition(ContentManager theContent, GraphicsDevice graphics, string name, Ammonitions ammo)
            : base(theContent, graphics, name)
        {
            this.ammo = ammo;
            this.texture = theContent.Load<Texture2D>((string)AmmonitionProperties()[0]);
            this.hitTexture = theContent.Load<Texture2D>((string)AmmonitionProperties()[0] + "Hit");
            this.damage = (int)AmmonitionProperties()[1];
            travelAnimation = new AnimatedSprite(this.texture, 1, 4);
            hitAnimation = new AnimatedSprite(this.hitTexture, 1, 5);
            position = new Vector2(graphics.Viewport.Width / 2 - (travelAnimation.Texture.Width / travelAnimation.Columns / 2) , graphics.Viewport.Height);
            acceleration = 0.3f;
            oldState = Mouse.GetState();
            traveling = false;
            scale = 0.4f * (1f / 800 * graphics.Viewport.Width);
        }
        
        // object { texturename, damage, velocity }
        private object[] AmmonitionProperties()
        {
            switch (ammo)
            {
                case Ammonitions.GRAVEL:
                    return new object[] { "gravel", 1, 180f };
                case Ammonitions.MUD:
                    return new object[] { "Mud", 2, 150f };
                case Ammonitions.METAL:
                    return new object[] { "Metal", 3, 120f };
                case Ammonitions.HOLYPELLET:
                    return new object[] { "Holypellet", 4, 90f };
                case Ammonitions.MAGICPELLET:
                    return new object[] { "Magicpellet", 5, 60f };
                default:
                    return null;
            }
        }

        public override void Update(MouseState mouseState)
        {
            hit = false;

            if (mouseState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released && !traveling && !falling && mouseState.Y < graphics.Viewport.Height * 0.66f)
            {
                destination = new Vector2(mouseState.X - (texture.Width / travelAnimation.Columns / 2 * scale), mouseState.Y - (texture.Height / travelAnimation.Rows / 2 * scale));
                mouseClickDestination = new Vector2(mouseState.X, mouseState.Y);
                distance = new Vector2(destination.Value.X - position.X, destination.Value.Y - position.Y);
                velocity = new Vector2(distance.X / (float)AmmonitionProperties()[2], distance.Y / (float)AmmonitionProperties()[2]);
                traveling = true;
            }

            if (destination != null && position.X > destination.Value.X - 5 && position.X < destination.Value.X + 5
                && position.Y > destination.Value.Y - 5 && position.Y < destination.Value.Y + 5)
            {
                traveling = false;
                destination = null;
                falling = true;
            }
            
            if (traveling && !falling)
            {
                if (position.Y < destination.Value.Y - (distance.Y / 2))
                {
                    velocity.Y += acceleration;
                    velocity.X += 1 / (distance.Y / distance.X) * acceleration;
                    scale -= 0.01f;
                }
                else
                {
                    velocity.Y -= acceleration;
                    velocity.X -= 1 / (distance.Y / distance.X) * acceleration;
                    scale += 0.01f;
                }

                position += velocity;
                travelAnimation.Update();
            }
            
            if (falling)
            {
                fallingTimer++;

                if (enemyHit)
                {
                    position.X = mouseClickDestination.X - (travelAnimation.Texture.Width / travelAnimation.Columns * scale / 2);
                    position.Y = mouseClickDestination.Y - (travelAnimation.Texture.Height / travelAnimation.Rows * scale / 2);
                    hitAnimation.Update();
                }
                else
                {
                    scale -= 0.01f;
                    velocity.X += (position.X > graphics.Viewport.Width / 2) ? 1 / (distance.Y / distance.X) * 0.3f : -1 / (distance.Y / distance.X) * 0.3f;
                    velocity.Y += 0.3f;
                    position += velocity;
                    travelAnimation.Update();
                }

                if (fallingTimer == 30)
                {
                    falling = false;
                    position = new Vector2(graphics.Viewport.Width / 2 - (travelAnimation.Texture.Width / travelAnimation.Columns / 2), graphics.Viewport.Height);
                    fallingTimer = 0;
                    travelAnimation.currentFrame = 0;
                    enemyHit = false;
                    scale = 0.4f * (1f / 800 * graphics.Viewport.Width);
                }
                else if (fallingTimer == 1)
                    hit = true;
            }

            oldState = mouseState;

            base.Update(mouseState);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (traveling || falling && !enemyHit)
                travelAnimation.Draw(spriteBatch, position, scale);
            else if (falling && enemyHit)
                hitAnimation.Draw(spriteBatch, position, scale);

            base.Draw(spriteBatch);
        }
    }
}
