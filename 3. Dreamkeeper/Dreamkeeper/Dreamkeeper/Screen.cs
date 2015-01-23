using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreamkeeper
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
            Program.game.levelselect = new LevelSelect(Program.game.Content, Program.game.MenuSwitchEvent, graphics);

            // Intros
            Program.game.intro1_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level1"), "TextFiles\\Intro1_1.txt", Color.Black);
            Program.game.intro1_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level1"), "TextFiles\\Intro1_2.txt", Color.Black);
            Program.game.intro2_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level2"), "TextFiles\\Intro2_1.txt", Color.Black);
            Program.game.intro2_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level2"), "TextFiles\\Intro2_2.txt", Color.Black);
            Program.game.intro3_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level3Wip"), "TextFiles\\Intro3_1.txt", Color.Black);
            Program.game.intro3_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level3Wip"), "TextFiles\\Intro3_2.txt", Color.Black);
            Program.game.intro4_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level4"), "TextFiles\\Intro4_1.txt", Color.Black);
            Program.game.intro4_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level4"), "TextFiles\\Intro4_2.txt", Color.Black);
            Program.game.intro5_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level5"), "TextFiles\\Intro5_1.txt", Color.Black);
            Program.game.intro5_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level5"), "TextFiles\\Intro5_2.txt", Color.Black);
            Program.game.intro6_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level6"), "TextFiles\\Intro6_1.txt", Color.Black);
            Program.game.intro6_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level6"), "TextFiles\\Intro6_2.txt", Color.Black);
            Program.game.intro7_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level7"), "TextFiles\\Intro7_1.txt", Color.Black);
            Program.game.intro7_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level7"), "TextFiles\\Intro7_2.txt", Color.Black);
            Program.game.intro8_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level8"), "TextFiles\\Intro8_1.txt", Color.Black);
            Program.game.intro8_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level8"), "TextFiles\\Intro8_2.txt", Color.Black);
            Program.game.intro9_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level9"), "TextFiles\\Intro9_1.txt", Color.Black);
            Program.game.intro9_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level9"), "TextFiles\\Intro9_2.txt", Color.Black);
            Program.game.intro10_1 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level10"), "TextFiles\\Intro10_1.txt", Color.Black);
            Program.game.intro10_2 = new Intro(Program.game.MenuSwitchEvent, graphics, Program.game.spriteBatch, Program.game.Content.Load<SpriteFont>("MenuFont"), Program.game.Content.Load<Texture2D>("Level10"), "TextFiles\\Intro10_2.txt", Color.Black);

            // Levels
            Program.game.level1 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level1"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 1, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
            Program.game.level2 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level2"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 2, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
            Program.game.level3 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level3Wip"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
            Program.game.level4 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level4"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
            Program.game.level5 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level5"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
            Program.game.level6 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level6"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
            Program.game.level7 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level7"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
            Program.game.level8 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level8"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
            Program.game.level9 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level9"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
            Program.game.level10 = new Level(Program.game.Content, Program.game.MenuSwitchEvent, graphics, Program.game.Content.Load<Texture2D>("Level10"), Program.game.difficulty, new Enemy("Crow", Program.game.Content.Load<Texture2D>("Crow-Fly-Right"), Program.game.Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Program.game.Content, graphics.GraphicsDevice), 1000, 60);
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
