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
    public class Level : Screen
    {
        Difficulty difficulty;
        Enemy startEnemy;
        Enemy enemy;
        ContentManager theContent;
        Ammonition ammo;
        Texture2D background;
        SpriteFont font;
        string score;
        int targetScore;
        EventHandler<SwitchEventArgs> theScreenEvent;

        public Level(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics, Texture2D background, Difficulty difficulty, Enemy enemy, int targetScore)
            : base(theScreenEvent, graphics)
        {
            this.theContent = theContent;
            this.graphics = graphics;
            this.difficulty = difficulty;
            ammo = new Ammonition(theContent, graphics.GraphicsDevice, "Gravel", Ammonitions.GRAVEL);
            this.background = background;
            font = theContent.Load<SpriteFont>("MenuFont");
            score = "0";
            this.targetScore = targetScore;
            this.theScreenEvent = theScreenEvent;

            startEnemy = enemy;
            startEnemy.health += (int)difficulty;
            startEnemy.velocity *= (int)difficulty + 1;
            this.enemy = new Enemy(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);

            Program.game.player.AddItemToInventory(ammo);
        }

        public override void Update(GameTime theTime)
        {
            ammo.Update(Mouse.GetState());
            enemy.Update(ammo);

            if (enemy.dead && (int.Parse(score) != targetScore))
            {
                enemy = new Enemy(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);
                score = (int.Parse(score) + enemy.health * 100).ToString();
            }
            
            if (int.Parse(score) >= targetScore)
            {
                score = "0";
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Program.game.stateswitch + 1));
            }
        }

        //Draw any objects specific to the screen
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            enemy.Draw(theBatch);
            ammo.Draw(theBatch);
            theBatch.DrawString(font, score + " / " + targetScore, new Vector2(30, 30), Color.White);
        }
    }
}
