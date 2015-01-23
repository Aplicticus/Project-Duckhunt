using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    public class Intro : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private Texture2D background;
        private TextBox txtbox;
        private LevelEndState levelendstate;

        public Intro(EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont spriteFont, Texture2D background, string textFile, Color textColor)
            : base(theScreenEvent, graphics)
        {
            this.theScreenEvent += theScreenEvent;
            this.graphics = graphics;
            this.background = background;
            txtbox = new TextBox(graphics.GraphicsDevice, spriteBatch, spriteFont, textFile, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.Black);
            levelendstate = new LevelEndState(Program.game.Content, theScreenEvent, graphics);
        }

        public override void Update(GameTime theTime)
        {
            
            txtbox.Update();
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && (int)Program.game.stateswitch == (int)Stateswitch.INTRO10_2)
            {
                levelendstate.SetResultState(true);
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVELENDSTATE));
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Program.game.stateswitch + 1));
            }            

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            txtbox.Draw();

            base.Draw(theBatch);
        }
    }
}
