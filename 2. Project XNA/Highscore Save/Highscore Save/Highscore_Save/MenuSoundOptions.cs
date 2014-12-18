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
    class MenuSoundOptions : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private GraphicsDeviceManager graphics;

        private Texture2D background;

        private MouseState oldState;

        private SpriteFont font;

        // Buttons
        private Button btnMasterVolumeDescrease;
        private Button btnMasterVolumeIncrease;
        private Button btnMusicVolumeDescrease;
        private Button btnMusicVolumeIncrease;
        private Button btnEffectVolumeDescrease;
        private Button btnEffectVolumeIncrease;
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
            btnMasterVolumeIncrease = new Button(font, ">", Color.Black, new Vector2(340, 100));
            btnMusicVolumeDescrease = new Button(font, "<", Color.Black, new Vector2(300, 140));
            btnMusicVolumeIncrease = new Button(font, ">", Color.Black, new Vector2(340, 140));
            btnEffectVolumeDescrease = new Button(font, "<", Color.Black, new Vector2(300, 180));
            btnEffectVolumeIncrease = new Button(font, ">", Color.Black, new Vector2(340, 180));
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

            // Text
            theBatch.DrawString(font, "Master Volume", new Vector2(30, 100), Color.Black);
            theBatch.DrawString(font, "Music Volume", new Vector2(30, 140), Color.Black);
            theBatch.DrawString(font, "Effect Volume", new Vector2(30, 180), Color.Black);

            //Buttons
            btnMasterVolumeDescrease.Draw(theBatch);
            btnMasterVolumeIncrease.Draw(theBatch);
            btnMusicVolumeDescrease.Draw(theBatch);
            btnMusicVolumeIncrease.Draw(theBatch);
            btnEffectVolumeDescrease.Draw(theBatch);
            btnEffectVolumeIncrease.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
    }
}
