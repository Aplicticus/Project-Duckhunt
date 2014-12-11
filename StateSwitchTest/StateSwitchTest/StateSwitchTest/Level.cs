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
    class Level : Screen
    {
        Difficulty difficulty;
        Enemy enemy;
        Texture2D txtr;
        ContentManager theContent;
        Ammonition ammo;

        public Level(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics, Difficulty difficulty)
            : base(theScreenEvent, graphics)
        {
            this.theContent = theContent;
            this.graphics = graphics;
            this.difficulty = difficulty;
            ammo = new Ammonition(theContent, graphics.GraphicsDevice, "Gravel", Ammonitions.GRAVEL);

            txtr = theContent.Load<Texture2D>("Bat");
            enemy = new Enemy("Bat", txtr, new Vector2(graphics.PreferredBackBufferWidth, 100), 2, new Vector2(-2, 0), theContent);
        }

        public override void Update(GameTime theTime)
        {
            ammo.Update(Mouse.GetState());
            enemy.Update(ammo);

            if (enemy.dead)
            {
                enemy = new Enemy("Bat", txtr, new Vector2(graphics.PreferredBackBufferWidth, 100), 2, new Vector2(-2, 0), theContent);
            }
        }

        //Draw any objects specific to the screen
        public override void Draw(SpriteBatch theBatch)
        {
            enemy.Draw(theBatch);
            ammo.Draw(theBatch);
        }
    }
}
