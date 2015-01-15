using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    public class MenuSoundOptions : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private Texture2D background;
        private MouseState oldState;
        private SpriteFont font;

        // Buttons
        private Button btnMasterVolumeDescrease;
        private Button btnMasterVolumeIncrease;
        private Button btnBack;

         public MenuSoundOptions(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Mountains4");

            font = theContent.Load<SpriteFont>("MenuFont");

            // Buttons
            btnMasterVolumeDescrease = new Button(font, "<", Color.Black, new Vector2(300, 100));
            btnMasterVolumeIncrease = new Button(font, ">", Color.Black, new Vector2(360, 100));
            btnBack = new Button(font, "Terug", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnMasterVolumeDescrease.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                MediaPlayer.Volume -= 0.1f;

            if (btnMasterVolumeIncrease.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                MediaPlayer.Volume += 0.1f;

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.OPTIONS));
            }

            oldState = newState;

            // Change objects to resolution
            btnMasterVolumeDescrease = new Button(font, "<", (btnMasterVolumeDescrease.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3 + 300, 100));
            btnMasterVolumeIncrease = new Button(font, ">", (btnMasterVolumeIncrease.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3 + 360, 100));
            btnBack = new Button(font, "Terug", (btnBack.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3 , 140));

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            // Text
            theBatch.DrawString(font, "Volume", new Vector2(graphics.PreferredBackBufferWidth / 3, 100), Color.Black);
            theBatch.DrawString(font, Math.Round(MediaPlayer.Volume * 10).ToString(), new Vector2(graphics.PreferredBackBufferWidth / 3 + 320, 100), Color.Black);

            //Buttons
            btnMasterVolumeDescrease.Draw(theBatch);
            btnMasterVolumeIncrease.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
