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
    public class MenuMain : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private MouseState oldState;
        private SpriteFont font;
        private Texture2D background;
        private Button btnPlay;
        private Button btnHighscore;
        private Button btnOptions;
        private Button btnQuit;

        public MenuMain(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("MenuBG");

            font = theContent.Load<SpriteFont>("MenuFont");
            
            btnPlay = new Button(font, "Spelen", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnHighscore = new Button(font, "Highscores", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnOptions = new Button(font, "Opties", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnQuit = new Button(font, "Stoppen", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnPlay.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.GAMEMODE));
            }
            if (btnHighscore.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.HIGHSCORE));
            }

            if (btnOptions.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.OPTIONS));
            }

            if (btnQuit.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                // Missing Messagebox ( Are you sure to exit the game? ) ....
                Environment.Exit(0);

            oldState = newState;

            // Change objects to resolution
            btnPlay = new Button(font, "Spelen", (btnPlay.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnHighscore = new Button(font, "Highscores", (btnHighscore.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnOptions = new Button(font, "Opties", (btnOptions.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnQuit = new Button(font, "Stoppen", (btnQuit.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Buttons
            btnPlay.Draw(theBatch);
            btnHighscore.Draw(theBatch);
            btnOptions.Draw(theBatch);
            btnQuit.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
