using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Dreamkeeper
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class DreamkeeperGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        HudTest hudTest;

        MenuMain menuMain;
        MenuGamemodeSelect menuGamemodeSelect;
        MenuOptions menuOptions;
        MenuGameplayOptions menuGameplayOptions;
        MenuGraphicsOptions menuGraphicsOptions;
        MenuSoundOptions menuSoundOptions;
        Screen currentScreen;
        private Stateswitch stateswitch = Stateswitch.MAIN;

        public DreamkeeperGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        private enum Stateswitch { INTRO, MAIN, GAMEMODE, OPTIONS, GAMEPLAYOPTS, GRAPHICSOPTS, SOUNDOPTS, STORY, ARCADE, BOSS, TEST}

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            menuMain = new MenuMain(Content, MenuMainEvent, graphics);
            menuGamemodeSelect = new MenuGamemodeSelect(Content, MenuGamemodeSelectEvent, graphics);
            menuOptions = new MenuOptions(Content, MenuOptionsEvent, graphics);
            menuGameplayOptions = new MenuGameplayOptions(Content, MenuGameplayOptionsEvent, graphics);
            menuGraphicsOptions = new MenuGraphicsOptions(Content, MenuGraphicsOptionsEvent, graphics);
            menuSoundOptions = new MenuSoundOptions(Content, MenuSoundOptionsEvent, graphics);
            hudTest = new HudTest(Content, HudTest, graphics);

            currentScreen = hudTest;

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            currentScreen.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void MenuMainEvent(object sender, SwitchEventArgs e)
        {
            MenuSwitch(e.current);
        }

        public void MenuGamemodeSelectEvent(object sender, SwitchEventArgs e)
        {
            MenuSwitch(e.current);
        }

        public void MenuOptionsEvent(object sender, SwitchEventArgs e)
        {
            MenuSwitch(e.current);
        }

        public void MenuGameplayOptionsEvent(object sender, SwitchEventArgs e)
        {
            MenuSwitch(e.current);
        }

        public void MenuGraphicsOptionsEvent(object sender, SwitchEventArgs e)
        {
            MenuSwitch(e.current);
        }

        public void MenuSoundOptionsEvent(object sender, SwitchEventArgs e)
        {
            MenuSwitch(e.current);
        }

        public void HudTest(object sender, SwitchEventArgs e)
        {
            MenuSwitch(e.current);
        }

        private void MenuSwitch(int i)
        {
            stateswitch = (Stateswitch)i;

            switch (stateswitch)
            {
                case Stateswitch.INTRO:
                    break;
                case Stateswitch.MAIN:
                    currentScreen = menuMain;
                    break;
                case Stateswitch.GAMEMODE:
                    currentScreen = menuGamemodeSelect;
                    break;
                case Stateswitch.OPTIONS:
                    currentScreen = menuOptions;
                    break;
                case Stateswitch.GAMEPLAYOPTS:
                    currentScreen = menuGameplayOptions;
                    break;
                case Stateswitch.GRAPHICSOPTS:
                    currentScreen = menuGraphicsOptions;
                    break;
                case Stateswitch.SOUNDOPTS:
                    currentScreen = menuSoundOptions;
                    break;
                case Stateswitch.STORY:
                    // Story
                    break;
                case Stateswitch.ARCADE:
                    // Arcade
                    break;
                case Stateswitch.BOSS:
                    // Boss
                    break;
                case Stateswitch.TEST:
                    currentScreen = hudTest;
                    // TEST HUD
                    break;
                default:
                    break;
            }

            System.Threading.Thread.Sleep(300);
        }
    }    
}
