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
    public class MenuGamemodeSelect : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private Texture2D background;
        private MouseState oldState;
        private SpriteFont font;

        // Buttons
        private Button btnStory;
        private Button btnArcade;
        private Button btnBoss;
        private Button btnBack;

         public MenuGamemodeSelect(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Mountains4");
            
            font = theContent.Load<SpriteFont>("MenuFont");
            
            // Buttons
            btnStory = new Button(font, "Verhaal", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnArcade = new Button(font, "Arcade", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnBoss = new Button(font, "Baas", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Terug", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnStory.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.STORY));
            }

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.MAIN));
            }

            oldState = newState;

            // Change objects to resolution
            btnStory = new Button(font, "Verhaal", (btnStory.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnArcade = new Button(font, "Arcade", (btnArcade.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnBoss = new Button(font, "Baas", (btnBoss.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Terug", (btnBack.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Buttons
            btnStory.Draw(theBatch);
            btnArcade.Draw(theBatch);
            btnBoss.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
