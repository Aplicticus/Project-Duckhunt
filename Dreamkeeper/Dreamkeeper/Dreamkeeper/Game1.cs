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

    public enum Difficulty { EASY, MEDIUM, HARD }
    public enum Stateswitch { INTRO, MAIN, GAMEMODE, OPTIONS, HIGHSCORE, GAMEPLAYOPTS, GRAPHICSOPTS, SOUNDOPTS, STORY, ARCADE, BOSS, DIFFICULTY, LEVEL1, LEVEL2, LEVEL3 }

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Player player;

        public MenuMain menuMain;
        public MenuGamemodeSelect menuGamemodeSelect;
        public MenuOptions menuOptions;
        public MenuGameplayOptions menuGameplayOptions;
        public MenuGraphicsOptions menuGraphicsOptions;
        public MenuSoundOptions menuSoundOptions;
        public MenuDifficultySelect menuDifficultySelect;
        public MenuHighscore menuHighscore;
        public Level level1;
        public Level level2;
        public Level level3;
        Screen currentScreen;
        public Stateswitch stateswitch = Stateswitch.MAIN;
        public Difficulty difficulty;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Window.Title = "Dreamkeeper";
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

            player = new Player("Hoi");
            difficulty = Difficulty.MEDIUM;

            menuMain = new MenuMain(Content, MenuSwitchEvent, graphics);
            menuGamemodeSelect = new MenuGamemodeSelect(Content, MenuSwitchEvent, graphics);
            menuOptions = new MenuOptions(Content, MenuSwitchEvent, graphics);
            menuGameplayOptions = new MenuGameplayOptions(Content, MenuSwitchEvent, graphics);
            menuGraphicsOptions = new MenuGraphicsOptions(Content, MenuSwitchEvent, graphics);
            menuSoundOptions = new MenuSoundOptions(Content, MenuSwitchEvent, graphics);
            menuDifficultySelect = new MenuDifficultySelect(Content, MenuSwitchEvent, graphics);
            menuHighscore = new MenuHighscore(Content, MenuSwitchEvent, graphics);
            level1 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level1"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 1, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000);
            level2 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level2Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 2, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000);
            level3 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level3Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000);
            currentScreen = menuMain;

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

        public void MenuSwitchEvent(object sender, SwitchEventArgs e)
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
                case Stateswitch.HIGHSCORE:
                    currentScreen = menuHighscore;
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
                    currentScreen = level1;
                    break;
                case Stateswitch.ARCADE:
                    // Arcade
                    break;
                case Stateswitch.BOSS:
                    // Boss
                    break;
                case Stateswitch.DIFFICULTY:
                    currentScreen = menuDifficultySelect;
                    break;
                case Stateswitch.LEVEL1:
                    currentScreen = level1;
                    break;
                case Stateswitch.LEVEL2:
                    currentScreen = level2;
                    break;
                case Stateswitch.LEVEL3:
                    currentScreen = level3;
                    break;
                default:
                    break;
            }

            System.Threading.Thread.Sleep(300);
        }
    }
}
