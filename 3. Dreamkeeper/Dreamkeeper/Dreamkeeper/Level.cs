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
        public Difficulty difficulty;
        public Enemy startEnemy;
        public Enemy enemy;
        public ContentManager theContent;
        public Ammonition ammo;
        public Texture2D background;
        public SpriteFont font;
        public int score;
        public int targetScore;
        public EventHandler<SwitchEventArgs> theScreenEvent;
        public HUD hud;
        public LevelEndState levelendstate;
        public int time; // in seconds

        public Level(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics, Texture2D background, Difficulty difficulty, Enemy enemy, int targetScore, int time)
            : base(theScreenEvent, graphics)
        {
            this.theContent = theContent;
            this.graphics = graphics;
            this.difficulty = difficulty;
            ammo = new Ammonition(theContent, graphics.GraphicsDevice, "Gravel", Ammonitions.GRAVEL);
            this.background = background;
            font = theContent.Load<SpriteFont>("MenuFont");
            score = 0;
            this.targetScore = targetScore;
            this.theScreenEvent = theScreenEvent;
            this.time = time;

            startEnemy = enemy;
            startEnemy.health += (int)difficulty;
            startEnemy.velocity *= (int)difficulty + 1;
            this.enemy = new Enemy(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);

            Program.game.player.AddItemToInventory(ammo);

            hud = new HUD(theContent, graphics);
            levelendstate = new LevelEndState(theContent, theScreenEvent, graphics);
         }

        public override void Update(GameTime theTime)
        {
            ammo.Update(Mouse.GetState());
            enemy.Update(ammo);

            if (enemy.dead)
            {
                enemy = new Enemy(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);
                score = score + (enemy.health * 100);
            }         

            if(hud.GetTimeState(time * 120) && score <= targetScore)
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

        //Draw any objects specific to the screen
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
