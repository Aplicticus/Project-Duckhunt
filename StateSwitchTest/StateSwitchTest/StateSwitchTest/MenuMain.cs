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
    public class MenuMain : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private GraphicsDeviceManager graphics;

        private MouseState oldState;

        private SpriteFont font;

        private Texture2D background;

        private Button btnPlay;
        private Button btnOptions;
        private Button btnQuit;

        public MenuMain(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Mountains4");

            font = theContent.Load<SpriteFont>("MenuFont");
            
            btnPlay = new Button(font, "Play", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnOptions = new Button(font, "Options", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnQuit = new Button(font, "Quit", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnPlay.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(2));
            }

            if (btnOptions.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(3));
            }

            if (btnQuit.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                Environment.Exit(0);

            oldState = newState;

            // Change objects to resolution
            btnPlay = new Button(font, "Play", (btnPlay.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnOptions = new Button(font, "Options", (btnOptions.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnQuit = new Button(font, "Quit", (btnQuit.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Buttons
            btnPlay.Draw(theBatch);
            btnOptions.Draw(theBatch);
            btnQuit.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
