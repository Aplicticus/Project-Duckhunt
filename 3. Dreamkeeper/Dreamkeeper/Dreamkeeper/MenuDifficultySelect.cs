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
    public class MenuDifficultySelect : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private MouseState oldState;
        private SpriteFont font;
        private Texture2D background;
        private Button btnEasy;
        private Button btnMedium;
        private Button btnHard;
        private Button btnBack;

        public MenuDifficultySelect(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("MenuBG");
            font = theContent.Load<SpriteFont>("MenuFont");            
            btnEasy = new Button(font, "Makkelijk", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnMedium = new Button(font, "Normaal", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnHard = new Button(font, "Moeilijk", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Terug", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnEasy.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVELSELECT));
            }

            if (btnMedium.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVELSELECT));
            }

            if (btnHard.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVELSELECT));
            }

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.GAMEMODE));
            }

            oldState = newState;

            // Change objects to resolution
            btnEasy = new Button(font, "Makkelijk", (btnEasy.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnMedium = new Button(font, "Normaal", (btnMedium.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnHard = new Button(font, "Moeilijk", (btnHard.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Terug", (btnBack.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Buttons
            btnEasy.Draw(theBatch);
            btnMedium.Draw(theBatch);
            btnHard.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
