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
            background = theContent.Load<Texture2D>("Mountains4");
            
            font = theContent.Load<SpriteFont>("MenuFont");
            
            // Buttons
            btnStory = new Button(font, "Story", Color.Black, new Vector2(30, 100));
            btnArcade = new Button(font, "Arcade", Color.Black, new Vector2(30, 140));
            btnBoss = new Button(font, "Boss", Color.Black, new Vector2(30, 180));
            btnBack = new Button(font, "Back", Color.White, new Vector2(graphics.PreferredBackBufferWidth - 100, graphics.PreferredBackBufferHeight - 80));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

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
            btnStory.Draw(theBatch);
            btnArcade.Draw(theBatch);
            btnBoss.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
