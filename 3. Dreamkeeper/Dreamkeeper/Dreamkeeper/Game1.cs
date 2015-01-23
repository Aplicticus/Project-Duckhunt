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
    public enum Stateswitch { INTRO, MAIN, PAUSESCREEN, GAMEMODE, OPTIONS, HIGHSCORE, GAMEPLAYOPTS, GRAPHICSOPTS, SOUNDOPTS, STORY, ARCADE, BOSS, DIFFICULTY, LEVELSELECT, LEVELENDSTATE, INTRO1_1, LEVEL1, INTRO1_2, INTRO2_1, LEVEL2, INTRO2_2, INTRO3_1, LEVEL3, INTRO3_2, INTRO4_1, LEVEL4, INTRO4_2, INTRO5_1, LEVEL5, INTRO5_2, INTRO6_1, LEVEL6, INTRO6_2, INTRO7_1, LEVEL7, INTRO7_2, INTRO8_1, LEVEL8, INTRO8_2, INTRO9_1, LEVEL9, INTRO9_2, INTRO10_1, LEVEL10, INTRO10_2 }

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Player player;

        public int score;

        public MenuMain menuMain;
        public MenuGamemodeSelect menuGamemodeSelect;
        public MenuOptions menuOptions;
        public MenuGameplayOptions menuGameplayOptions;
        public MenuGraphicsOptions menuGraphicsOptions;
        public MenuSoundOptions menuSoundOptions;
        public MenuDifficultySelect menuDifficultySelect;
        public MenuHighscore menuHighscore;       
        public LevelSelect levelselect;
        public LevelEndState levelendstate;
        public PauseScreen pauseScreen;
        public Intro intro1_1, intro1_2, intro2_1, intro2_2, intro3_1, intro3_2, intro4_1, intro4_2, intro5_1, intro5_2, intro6_1, intro6_2, intro7_1, intro7_2, intro8_1, intro8_2, intro9_1, intro9_2, intro10_1, intro10_2;
        public Level level1, level2, level3, level4, level5, level6, level7, level8, level9, level10;
        Screen currentScreen;
        public Stateswitch stateswitch = Stateswitch.MAIN;
        public Stateswitch oldStateswitch;
        public Difficulty difficulty;
        

        private static KeyboardState lastKeyboardState;

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
            levelendstate = new LevelEndState(Content, MenuSwitchEvent, graphics);
            levelselect = new LevelSelect(Content, MenuSwitchEvent, graphics);
            pauseScreen = new PauseScreen(Content, MenuSwitchEvent, graphics);

            // Intros
            intro1_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level1"), "TextFiles\\Intro1_1.txt", Color.Black);
            intro1_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level1"), "TextFiles\\Intro1_2.txt", Color.Black);
            intro2_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level2Wip"), "TextFiles\\Intro2_1.txt", Color.Black);
            intro2_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level2Wip"), "TextFiles\\Intro2_2.txt", Color.Black);
            intro3_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level3Wip"), "TextFiles\\Intro3_1.txt", Color.Black);
            intro3_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level3Wip"), "TextFiles\\Intro3_2.txt", Color.Black);
            intro4_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level4Wip"), "TextFiles\\Intro4_1.txt", Color.Black);
            intro4_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level4Wip"), "TextFiles\\Intro4_2.txt", Color.Black);
            intro5_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level5Wip"), "TextFiles\\Intro5_1.txt", Color.Black);
            intro5_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level5Wip"), "TextFiles\\Intro5_2.txt", Color.Black);
            intro6_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level6Wip"), "TextFiles\\Intro6_1.txt", Color.Black);
            intro6_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level6Wip"), "TextFiles\\Intro6_2.txt", Color.Black);
            intro7_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level7Wip"), "TextFiles\\Intro7_1.txt", Color.Black);
            intro7_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level7Wip"), "TextFiles\\Intro7_2.txt", Color.Black);
            intro8_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level8Wip"), "TextFiles\\Intro8_1.txt", Color.Black);
            intro8_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level8Wip"), "TextFiles\\Intro8_2.txt", Color.Black);
            intro9_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level9Wip"), "TextFiles\\Intro9_1.txt", Color.Black);
            intro9_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level9Wip"), "TextFiles\\Intro9_2.txt", Color.Black);
            intro10_1 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level10Wip-Recovered"), "TextFiles\\Intro10_1.txt", Color.Black);
            intro10_2 = new Intro(MenuSwitchEvent, graphics, spriteBatch, Content.Load<SpriteFont>("MenuFont"), Content.Load<Texture2D>("Level10Wip-Recovered"), "TextFiles\\Intro10_2.txt", Color.Black);

            // Levels
            level1 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level1"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 1, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            level2 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level2Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 2, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            level3 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level3Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            level4 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level4Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            level5 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level5Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            level6 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level6Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            level7 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level7Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            level8 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level8Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            level9 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level9Wip"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            level10 = new Level(Content, MenuSwitchEvent, graphics, Content.Load<Texture2D>("Level10Wip-Recovered"), difficulty, new Enemy("Crow", Content.Load<Texture2D>("Crow-Fly-Right"), Content.Load<Texture2D>("Crow-Fly-Left"), new Vector2(graphics.PreferredBackBufferWidth, 100), 3, new Vector2(-2, 0), Content, graphics.GraphicsDevice), 1000, 60);
            currentScreen = menuMain;

            graphics.PreferredBackBufferWidth = menuGraphicsOptions.graphicsOptions.Width;
            graphics.PreferredBackBufferHeight = menuGraphicsOptions.graphicsOptions.Height;
            graphics.IsFullScreen = menuGraphicsOptions.graphicsOptions.Fullscreen;
            graphics.PreferMultiSampling = menuGraphicsOptions.graphicsOptions.AntiAliasing;

            graphics.ApplyChanges();
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

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //pause
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.P) && lastKeyboardState.IsKeyUp(Keys.P) && currentScreen != pauseScreen
               && currentScreen != menuMain && currentScreen != menuGraphicsOptions && currentScreen != menuGameplayOptions
               && currentScreen != menuOptions && currentScreen != menuHighscore && currentScreen != menuGamemodeSelect
               && currentScreen != menuDifficultySelect && currentScreen != menuSoundOptions && currentScreen != levelselect)
            {
                MenuSwitch((int)Stateswitch.PAUSESCREEN);
            }
            else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.P) && lastKeyboardState.IsKeyUp(Keys.P) && currentScreen == pauseScreen)
            {
                MenuSwitch((int)oldStateswitch);
            }
            lastKeyboardState = Keyboard.GetState(PlayerIndex.One);
            currentScreen.Update(gameTime);

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
            oldStateswitch = stateswitch;
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
                case Stateswitch.PAUSESCREEN:
                    currentScreen = pauseScreen;
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
                    currentScreen = menuDifficultySelect;
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
                case Stateswitch.LEVELSELECT:
                    currentScreen = levelselect;
                    break;
                case Stateswitch.LEVELENDSTATE:
                    currentScreen = levelendstate;
                    break;
                case Stateswitch.INTRO1_1:
                    currentScreen = intro1_1;
                    break;
                case Stateswitch.LEVEL1:
                    currentScreen = level1;
                    break;
                case Stateswitch.INTRO1_2:
                    currentScreen = intro1_2;
                    break;
                case Stateswitch.INTRO2_1:
                    currentScreen = intro2_1;
                    break;
                case Stateswitch.LEVEL2:
                    currentScreen = level2;
                    break;
                case Stateswitch.INTRO2_2:
                    currentScreen = intro2_2;
                    break;
                case Stateswitch.INTRO3_1:
                    currentScreen = intro3_1;
                    break;
                case Stateswitch.LEVEL3:
                    currentScreen = level3;
                    break;
                case Stateswitch.INTRO3_2:
                    currentScreen = intro3_2;
                    break;
                case Stateswitch.INTRO4_1:
                    currentScreen = intro4_1;
                    break;
                case Stateswitch.LEVEL4:
                    currentScreen = level4;
                    break;
                case Stateswitch.INTRO4_2:
                    currentScreen = intro4_2;
                    break;
                case Stateswitch.INTRO5_1:
                    currentScreen = intro5_1;
                    break;
                case Stateswitch.LEVEL5:
                    currentScreen = level5;
                    break;
                case Stateswitch.INTRO5_2:
                    currentScreen = intro5_2;
                    break;
                case Stateswitch.INTRO6_1:
                    currentScreen = intro6_1;
                    break;
                case Stateswitch.LEVEL6:
                    currentScreen = level6;
                    break;
                case Stateswitch.INTRO6_2:
                    currentScreen = intro6_2;
                    break;
                case Stateswitch.INTRO7_1:
                    currentScreen = intro7_1;
                    break;
                case Stateswitch.LEVEL7:
                    currentScreen = level7;
                    break;
                case Stateswitch.INTRO7_2:
                    currentScreen = intro7_2;
                    break;
                case Stateswitch.INTRO8_1:
                    currentScreen = intro8_1;
                    break;
                case Stateswitch.LEVEL8:
                    currentScreen = level8;
                    break;
                case Stateswitch.INTRO8_2:
                    currentScreen = intro8_2;
                    break;
                case Stateswitch.INTRO9_1:
                    currentScreen = intro9_1;
                    break;
                case Stateswitch.LEVEL9:
                    currentScreen = level9;
                    break;
                case Stateswitch.INTRO9_2:
                    currentScreen = intro9_2;
                    break;
                case Stateswitch.INTRO10_1:
                    currentScreen = intro10_1;
                    break;
                case Stateswitch.LEVEL10:
                    currentScreen = level10;
                    break;
                case Stateswitch.INTRO10_2:
                    currentScreen = intro10_2;
                    break;
                default:
                    stateswitch = Stateswitch.MAIN;
                    currentScreen = menuMain;
                    break;
            }
            System.Threading.Thread.Sleep(300);
        }
    }
}
