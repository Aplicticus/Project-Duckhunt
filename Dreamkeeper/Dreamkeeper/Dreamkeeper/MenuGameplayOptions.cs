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
    public class MenuGameplayOptions : Screen
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
            btnDisplayEnemyHealthbars = new Button(font, "Laat monster levensbalk zien", Color.Green, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnDisplayEnemyHealthbarnumbers = new Button(font, "Laat monster levens zien", Color.Green, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnDisplayDamageDealt = new Button(font, "Laat schade zien", Color.Green, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Terug", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnDisplayEnemyHealthbars.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (displayEnemyHealthbars)
                    displayEnemyHealthbars = false;
                else
                    displayEnemyHealthbars = true;
            }

            if (btnDisplayEnemyHealthbarnumbers.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (displayEnemyHealthbarnumbers)
                    displayEnemyHealthbarnumbers = false;
                else
                    displayEnemyHealthbarnumbers = true;
            }

            if (btnDisplayDamageDealt.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (displayDamageDealt)
                    displayDamageDealt = false;
                else
                    displayDamageDealt = true;
            }

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.OPTIONS));
            }

            oldState = newState;

            // Change objects to resolution
            btnDisplayEnemyHealthbars = new Button(font, "Laat monster levensbalk zien", (displayEnemyHealthbars) ? (btnDisplayEnemyHealthbars.Hover(Mouse.GetState())) ? Color.LightGreen : Color.Green : (btnDisplayEnemyHealthbars.Hover(Mouse.GetState())) ? Color.LightSalmon : Color.Red, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnDisplayEnemyHealthbarnumbers = new Button(font, "Laat monster levens zien", (displayEnemyHealthbarnumbers) ? (btnDisplayEnemyHealthbarnumbers.Hover(Mouse.GetState())) ? Color.LightGreen : Color.Green : (btnDisplayEnemyHealthbarnumbers.Hover(Mouse.GetState())) ? Color.LightSalmon : Color.Red, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnDisplayDamageDealt = new Button(font, "Laat schade zien", (displayDamageDealt) ? (btnDisplayDamageDealt.Hover(Mouse.GetState())) ? Color.LightGreen : Color.Green : (btnDisplayDamageDealt.Hover(Mouse.GetState())) ? Color.LightSalmon : Color.Red, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Terug", (btnBack.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));

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
