using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Kevin
{
    class MenuGraphicsOptions : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        //private GraphicsDeviceManager graphics;
        private ContentManager content;

        private Texture2D background;

        private MouseState oldState;

        private SpriteFont font;

        // Buttons
        private Button btnResultion;
        private Button btnFullscreen;
        private Button btnAntiAliasing;
        private Button btnBack;

        private int clickCountResolution = 0;

        public MenuGraphicsOptions(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            this.content = theContent;
            background = theContent.Load<Texture2D>("Assets\\Menus\\Mountains1");

            font = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");

            // Buttons
            btnResultion = new Button(font, "Resolution " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight, Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnFullscreen = new Button(font, "Fullscreen", (graphics.IsFullScreen) ? Color.Green : Color.Red, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnAntiAliasing = new Button(font, "Anti-aliasing", (graphics.PreferMultiSampling) ? Color.Green : Color.Red, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Back", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnResultion.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                clickCountResolution++;

                if (clickCountResolution == 0)
                {
                    graphics.PreferredBackBufferWidth = 800;
                    graphics.PreferredBackBufferHeight = 600;
                    btnResultion.text = "Resolution " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight;
                }

                if (clickCountResolution == 1)
                {
                    graphics.PreferredBackBufferWidth = 1280;
                    graphics.PreferredBackBufferHeight = 720;
                    btnResultion.text = "Resolution " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight;
                }

                if (clickCountResolution == 2)
                {
                    graphics.PreferredBackBufferWidth = 1920;
                    graphics.PreferredBackBufferHeight = 1080;
                    clickCountResolution = -1;
                    btnResultion.text = "Resolution " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight;
                }

                graphics.ApplyChanges();
            }

            if (btnFullscreen.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (graphics.IsFullScreen)
                    graphics.IsFullScreen = false;
                else
                    graphics.IsFullScreen = true;
                graphics.ApplyChanges();
            }

            if (btnAntiAliasing.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (graphics.PreferMultiSampling)
                    graphics.PreferMultiSampling = false;
                else
                    graphics.PreferMultiSampling = true;
                graphics.ApplyChanges();
            }

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(3));
            }

            oldState = newState;

            // Change objects to resolution
            btnResultion = new Button(font, "Resolution " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight, (btnResultion.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnFullscreen = new Button(font, "Fullscreen", (graphics.IsFullScreen) ? (btnFullscreen.Hover(Mouse.GetState())) ? Color.LightGreen : Color.Green : (btnFullscreen.Hover(Mouse.GetState())) ? Color.LightSalmon : Color.Red, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnAntiAliasing = new Button(font, "Anti-aliasing", (graphics.PreferMultiSampling) ? (btnAntiAliasing.Hover(Mouse.GetState())) ? Color.LightGreen : Color.Green : (btnAntiAliasing.Hover(Mouse.GetState())) ? Color.LightSalmon : Color.Red, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnBack = new Button(font, "Back", (btnBack.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            //Buttons
            btnResultion.Draw(theBatch);
            btnFullscreen.Draw(theBatch);
            btnAntiAliasing.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
