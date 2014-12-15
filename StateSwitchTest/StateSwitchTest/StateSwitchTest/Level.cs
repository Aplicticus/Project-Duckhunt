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
    public class Level : Screen
    {
        Difficulty difficulty;
        Enemy startEnemy;
        Enemy enemy;
        ContentManager theContent;
        Ammonition ammo;
        Texture2D background;

        public Level(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics, Texture2D background, Difficulty difficulty, Enemy enemy)
            : base(theScreenEvent, graphics)
        {
            this.theContent = theContent;
            this.graphics = graphics;
            this.difficulty = difficulty;
            ammo = new Ammonition(theContent, graphics.GraphicsDevice, "Gravel", Ammonitions.GRAVEL);
            this.background = background;

            startEnemy = enemy;
            startEnemy.health *= (int)difficulty + 1;
            this.enemy = new Enemy(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);
        }

        public override void Update(GameTime theTime)
        {
            ammo.Update(Mouse.GetState());
            enemy.Update(ammo);

            if (enemy.dead)
                enemy = new Enemy(startEnemy.name, startEnemy.rightTexture, startEnemy.leftTexture, startEnemy.position, startEnemy.health, startEnemy.velocity, theContent, graphics.GraphicsDevice);
        }

        //Draw any objects specific to the screen
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            enemy.Draw(theBatch);
            ammo.Draw(theBatch);
        }
    }
}
