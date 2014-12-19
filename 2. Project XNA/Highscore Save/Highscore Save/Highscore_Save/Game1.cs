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

namespace Highscore_Save
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MenuMain menuMain;
        MenuGamemodeSelect menuGamemodeSelect;
        MenuOptions menuOptions;
        MenuGameplayOptions menuGameplayOptions;
        MenuGraphicsOptions menuGraphicsOptions;
        MenuSoundOptions menuSoundOptions;
        Screen currentScreen;
        MenuHighscore highscore;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

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
            currentScreen = menuMain;
            highscore = new MenuHighscore(Content, HighscoreEvent, graphics);

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
            switch (e.current)
            {
                case 0:

                    break;
                case 1:
                    currentScreen = menuGamemodeSelect;
                    break;
                case 2:
                    currentScreen = menuOptions;
                    break;
                case 3:
                    currentScreen = highscore;
                    break;
                default:
                    break;
            }
            System.Threading.Thread.Sleep(100);
        }

        public void MenuGamemodeSelectEvent(object sender, SwitchEventArgs e)
        {
            switch (e.current)
            {
                case 0:
                    currentScreen = menuMain;
                    break;
                case 1:

                    break;
                case 2:

                    break;
                default:
                    break;
            }
            System.Threading.Thread.Sleep(100);
        }

        public void MenuOptionsEvent(object sender, SwitchEventArgs e)
        {
            switch (e.current)
            {
                case 0:
                    currentScreen = menuMain;
                    break;
                case 1:
                    currentScreen = menuGameplayOptions;
                    break;
                case 2:
                    currentScreen = menuGraphicsOptions;
                    break;
                case 3:
                    currentScreen = menuSoundOptions;
                    break;
                default:
                    break;
            }
            System.Threading.Thread.Sleep(100);
        }

        public void MenuGameplayOptionsEvent(object sender, SwitchEventArgs e)
        {
            switch (e.current)
            {
                case 0:
                    currentScreen = menuOptions;
                    break;
                default:
                    break;
            }
            System.Threading.Thread.Sleep(100);
        }

        public void MenuGraphicsOptionsEvent(object sender, SwitchEventArgs e)
        {
            switch (e.current)
            {
                case 0:
                    currentScreen = menuOptions;
                    break;
                default:
                    break;
            }
            System.Threading.Thread.Sleep(100);
        }

        public void MenuSoundOptionsEvent(object sender, SwitchEventArgs e)
        {
            switch (e.current)
            {
                case 0:
                    currentScreen = menuOptions;
                    break;
                default:
                    break;
            }
            System.Threading.Thread.Sleep(100);
        }

        public void HighscoreEvent(object sender, SwitchEventArgs e)
        {
            switch (e.current)
            {
                case 0:
                    currentScreen = menuMain;
                    break;
                default:
                    break;
            }
            System.Threading.Thread.Sleep(100);
        }
    }
}
