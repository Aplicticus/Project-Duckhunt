using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace XNA_Tommy
{
    class MenuOptions : Screen
    {
        public event EventHandler<SwitchEventArgs> theScreenEvent;
        private GraphicsDeviceManager graphics;

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

            btnGameplayOptions = new Button(font, "Gameplay Options", Color.Black, new Vector2(30, 100));
            btnGraphicsOptions = new Button(font, "Graphics Options", Color.Black, new Vector2(30, 140));
            btnSoundOption = new Button(font, "Sound Options", Color.Black, new Vector2(30, 180));
            btnBack = new Button(font, "Back", Color.White, new Vector2(graphics.PreferredBackBufferWidth - 100, graphics.PreferredBackBufferHeight - 80));
        }
        
        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnGameplayOptions.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(1));
            }

            if (btnGraphicsOptions.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(2));
            }

            if (btnSoundOption.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(3));
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
            btnGameplayOptions.Draw(theBatch);
            btnGraphicsOptions.Draw(theBatch);
            btnSoundOption.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
