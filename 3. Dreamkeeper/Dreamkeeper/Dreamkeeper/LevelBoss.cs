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
    public class LevelBoss : Level
    {
        private EnemyBoss startEnemy;

        public LevelBoss(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics, Texture2D background, Difficulty difficulty, EnemyBoss enemy, int targetScore, int time)
            : base(theContent, theScreenEvent, graphics, background, difficulty, enemy, targetScore, time)
        {
            this.startEnemy = enemy;
            this.enemy = new EnemyBoss(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.shieldTexture, startEnemy.armTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);
            hud = new HUD(theContent, graphics);
        }

        public override void Update(GameTime theTime)
        {
            enemy.Update(ammo);
            ammo.Update(Mouse.GetState());

            if (enemy.dead)
            {
                enemy = new Enemy(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);
                score = score + (enemy.health * 100);
            }

            if (hud.GetTimeState(time * 120) && score <= targetScore)
            {
                levelendstate.SetResultState(false);
                Program.game.score += score;
                score = 0;
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVELENDSTATE));
            }
            else if (hud.GetTimeState(time * 120) || score >= targetScore)
            {
                Program.game.score += score;
                score = 0;
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Program.game.stateswitch + 1));
            }
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            enemy.Draw(theBatch);
            ammo.Draw(theBatch);
            hud.Draw(theBatch);
            theBatch.DrawString(font, score.ToString(), new Vector2(graphics.PreferredBackBufferWidth / 10, graphics.PreferredBackBufferHeight / 1.2f), Color.Black);
        }
    }
}
