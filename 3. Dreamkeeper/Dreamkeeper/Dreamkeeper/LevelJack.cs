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
    public class LevelJack : Level
    {
        public LevelJack(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics, Texture2D background, Difficulty difficulty, EnemyJack enemy, int targetScore, int time)
            : base(theContent, theScreenEvent, graphics, background, difficulty, enemy, targetScore, time)
        {
            this.startEnemy = enemy;
            this.enemy = new EnemyJack(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);
        }

        public override void Update(GameTime theTime)
        {
            ammo.Update(Mouse.GetState());
            enemy.Update(ammo);

            if (enemy.dead)
            {
                enemy = new EnemyJack(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);
                score = score + (enemy.health * 100);
            }

            if (hud.GetTimeState(time * 120) || score >= targetScore)
            {
                Program.game.score += score;
                score = 0;
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Program.game.stateswitch + 1));
            }
        }
    }
}
