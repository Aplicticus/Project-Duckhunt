using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Dreamkeeper
{
    class MenuGamemodeSelect : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private GraphicsDeviceManager graphics;

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
            background = theContent.Load<Texture2D>("Assets\\Menus\\Mountains1");

            font = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");
            
            // Buttons
            btnStory = new Button(font, "Story", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnArcade = new Button(font, "Arcade", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnBoss = new Button(font, "Boss", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Back", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(1));
            }

            oldState = newState;

            // Change objects to resolution
            btnStory = new Button(font, "Story", (btnStory.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnArcade = new Button(font, "Arcade", (btnArcade.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnBoss = new Button(font, "Boss", (btnBoss.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Back", (btnBack.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));

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
