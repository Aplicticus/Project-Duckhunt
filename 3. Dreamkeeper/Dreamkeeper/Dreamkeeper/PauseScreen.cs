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
    public class PauseScreen : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;

        private MouseState oldStateMouse;
        private KeyboardState oldStateKeyboard;

        private SpriteFont font;
        private Texture2D background;

        private Button btnDoorgaan;
        private Button btnExit;
       
        public PauseScreen(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Mountains4");
            font = theContent.Load<SpriteFont>("MenuFont");
            btnDoorgaan = new Button(font, "Doorgaan", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnExit = new Button(font, "Terug naar het menu", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();
            
            if (btnDoorgaan.IsClicked(newState) && keyboardState.IsKeyUp(Keys.P) && oldStateMouse.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Program.game.oldStateswitch));
            }

            else if (btnExit.IsClicked(newState) && oldStateMouse.LeftButton == ButtonState.Released)
            {
                
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.MAIN));
            } 
            oldStateMouse = newState;
            oldStateKeyboard = keyboardState;
            // Change objects to resolution
            btnDoorgaan = new Button(font, "Doorgaan", (btnDoorgaan.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnExit = new Button(font, "Terug naar het menu", (btnExit.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Buttons
            btnDoorgaan.Draw(theBatch);
            btnExit.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
