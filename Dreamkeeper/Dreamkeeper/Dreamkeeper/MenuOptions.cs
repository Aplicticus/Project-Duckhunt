using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Dreamkeeper
{
    public class MenuOptions : Screen
    {
        public event EventHandler<SwitchEventArgs> theScreenEvent;
        MouseState oldState;
        private Texture2D background;
        private Button btnGameplayOptions;
        private Button btnGraphicsOptions;
        private Button btnSoundOption;
        private Button btnBack;
        private SpriteFont font;

        public MenuOptions(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent)
        {
            this.theScreenEvent = theScreenEvent;
            this.graphics = graphics;

            background = theContent.Load<Texture2D>("Mountains4");

            font = theContent.Load<SpriteFont>("MenuFont");

            btnGameplayOptions = new Button(font, "Spel opties", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnGraphicsOptions = new Button(font, "Grafische opties", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnSoundOption = new Button(font, "Geluid opties", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Terug", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));
        }
        
        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnGameplayOptions.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.GAMEPLAYOPTS));
            }

            if (btnGraphicsOptions.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.GRAPHICSOPTS));
            }

            if (btnSoundOption.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.SOUNDOPTS));
            }

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.MAIN));
            }

            oldState = newState;

            // Change objects to resolution
            btnGameplayOptions = new Button(font, "Spel opties", (btnGameplayOptions.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnGraphicsOptions = new Button(font, "Grafische opties", (btnGraphicsOptions.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnSoundOption = new Button(font, "Geluid opties", (btnSoundOption.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Terug", (btnBack.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Buttons
            btnGameplayOptions.Draw(theBatch);
            btnGraphicsOptions.Draw(theBatch);
            btnSoundOption.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
