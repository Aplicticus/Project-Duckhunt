using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Highscore_Save
{
    class MenuGameplayOptions : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private GraphicsDeviceManager graphics;

        private Texture2D background;

        private MouseState oldState;

        private SpriteFont font;

        // Buttons
        private Button btnDisplayEnemyHealthbars;
        private Button btnDisplayEnemyHealthbarnumbers;
        private Button btnDisplayDamageDealt;
        private Button btnBack;

        public bool displayEnemyHealthbars = true;
        public bool displayEnemyHealthbarnumbers = true;
        public bool displayDamageDealt = true;

        public MenuGameplayOptions(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Mountains4");

            font = theContent.Load<SpriteFont>("MenuFont");

            // Buttons
            btnDisplayEnemyHealthbars = new Button(font, "Display Enemy Healthbars", Color.Green, new Vector2(30, 100));
            btnDisplayEnemyHealthbarnumbers = new Button(font, "Display Enemy Healthbarnumbers", Color.Green, new Vector2(30, 140));
            btnDisplayDamageDealt = new Button(font, "Display Damage Dealth", Color.Green, new Vector2(30, 180));
            btnBack = new Button(font, "Back", Color.White, new Vector2(graphics.PreferredBackBufferWidth - 100, graphics.PreferredBackBufferHeight - 80));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnDisplayEnemyHealthbars.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (displayEnemyHealthbars)
                {
                    displayEnemyHealthbars = false;
                    btnDisplayEnemyHealthbars.color = Color.Red;
                }
                else
                {
                    displayEnemyHealthbars = true;
                    btnDisplayEnemyHealthbars.color = Color.Green;
                }
            }

            if (btnDisplayEnemyHealthbarnumbers.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (displayEnemyHealthbarnumbers)
                {
                    displayEnemyHealthbarnumbers = false;
                    btnDisplayEnemyHealthbarnumbers.color = Color.Red;
                }
                else
                {
                    displayEnemyHealthbarnumbers = true;
                    btnDisplayEnemyHealthbarnumbers.color = Color.Green;
                }
            }

            if (btnDisplayDamageDealt.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (displayDamageDealt)
                {
                    displayDamageDealt = false;
                    btnDisplayDamageDealt.color = Color.Red;
                }
                else
                {
                    displayDamageDealt = true;
                    btnDisplayDamageDealt.color = Color.Green;
                }
            }

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(0));
            }

            oldState = newState;

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Buttons
            btnDisplayEnemyHealthbars.Draw(theBatch);
            btnDisplayEnemyHealthbarnumbers.Draw(theBatch);
            btnDisplayDamageDealt.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
