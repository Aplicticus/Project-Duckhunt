using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StateSwitchTest
{
    public class Screen
    {
        //The event associated with the Screen. This event is used to raise events
        //back in the main game class to notify the game that something has changed
        //or needs to be changed
        protected EventHandler ScreenEvent;
        protected event EventHandler<SwitchEventArgs> CustomScreenEvent;
        protected GraphicsDeviceManager graphics;

        public Screen(EventHandler theScreenEvent)
        {
            ScreenEvent = theScreenEvent;
        }
        public Screen(EventHandler<SwitchEventArgs> theScreenEvent)
        {
            CustomScreenEvent = theScreenEvent;
        }

        public Screen(EventHandler theScreenEvent, GraphicsDeviceManager graphics)
        {
            ScreenEvent = theScreenEvent;
            this.graphics = graphics;
        }

        public Screen(EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
        {
            CustomScreenEvent = theScreenEvent;
            this.graphics = graphics;
        }

        public virtual void ReloadContent()
        {
            //Program.game.menuMain = new MenuMain(Program.game.Content, Program.game.MenuMainEvent, graphics);
            //Program.game.menuGamemodeSelect = new MenuGamemodeSelect(Program.game.Content, Program.game.MenuGamemodeSelectEvent, graphics);
            //Program.game.menuOptions = new MenuOptions(Program.game.Content, Program.game.MenuOptionsEvent, graphics);
            //Program.game.menuGameplayOptions = new MenuGameplayOptions(Program.game.Content, Program.game.MenuGameplayOptionsEvent, graphics);
            //Program.game.menuGraphicsOptions = new MenuGraphicsOptions(Program.game.Content, Program.game.MenuGraphicsOptionsEvent, graphics);
            //Program.game.menuSoundOptions = new MenuSoundOptions(Program.game.Content, Program.game.MenuSoundOptionsEvent, graphics);
            Program.game.level1 = new Level(Program.game.Content, Program.game.LevelEvent, graphics, Program.game.Content.Load<Texture2D>("Level1"), Difficulty.EASY, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 2, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice));
        }

        //Update any information specific to the screen
        public virtual void Update(GameTime theTime)
        {
        }

        //Draw any objects specific to the screen
        public virtual void Draw(SpriteBatch theBatch)
        {
        }
    }
}
