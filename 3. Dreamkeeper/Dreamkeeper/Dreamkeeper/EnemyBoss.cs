using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    public enum BossStates { IDLE, SHIELD }

    public class EnemyBoss : Enemy
    {
        public BossStates bossState;

        public Texture2D Texture;
        public Texture2D shieldTexture;
        public Texture2D armTexture;

        public AnimatedSprite AnimatedTexture;
        public AnimatedSprite animatedShield;
        public AnimatedSprite animatedArm;

        public int StateTime { get; set; }

        public EnemyBoss(string name, Texture2D rightTexture, Texture2D leftTexture, Texture2D shieldTexture, Texture2D armTexture, Vector2 position, int health, Vector2 velocity, ContentManager theContent, GraphicsDevice graphics)
            : base(name, rightTexture, leftTexture, position, health, velocity, theContent, graphics)
        {
            this.position = new Vector2(graphics.Viewport.Width / 3, 0);
            this.Texture = rightTexture;
            this.shieldTexture = shieldTexture;
            this.armTexture = armTexture;
            this.AnimatedTexture = new AnimatedSprite(this.Texture, 3, 5, true);
            this.animatedShield = new AnimatedSprite(shieldTexture, 1, 5, false);
            bossState = BossStates.IDLE;
        }

        public override void Update(Ammonition ammo)
        {
            dead = health < 1;
            StateTime++;

            switch (bossState)
            {
                case BossStates.IDLE:
                    if (StateTime % 4 == 0)
                        AnimatedTexture.Update();
                    bool hit = IsHit(ref ammo);
                    health -= (hit) ? ammo.damage : 0;
                    if (hit)
                    {
                        bossState = BossStates.SHIELD;
                        StateTime = 0;
                    }
                    break;
                case BossStates.SHIELD:
                    if (StateTime % 2 == 0)
                        AnimatedTexture.Update();
                    if (StateTime < 30)
                        animatedShield.Update();
                    if (StateTime > 210 && StateTime < 240)
                        animatedShield.UpdateReverse();
                    if (StateTime > 240)
                    {
                        bossState = BossStates.IDLE;
                        StateTime = 0;
                    }
                    break;
                default:
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            switch (bossState)
            {
                case BossStates.IDLE:
                    AnimatedTexture.Draw(spriteBatch, position, 1f);
                    break;
                case BossStates.SHIELD:
                    AnimatedTexture.Draw(spriteBatch, position, 1f);
                    animatedShield.Draw(spriteBatch, Vector2.Zero, 1f / 400 * graphics.Viewport.Width);
                    break;
                default:
                    break;
            }

            if (Program.game.menuGameplayOptions.displayEnemyHealthbarnumbers)
                spriteBatch.DrawString(font, health.ToString(), new Vector2(position.X + travelingAnimation.Texture.Width / travelingAnimation.Columns, position.Y), Color.White);
        }
    }
}
