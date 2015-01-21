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
    public enum Stateswitch { INTRO, MAIN,PAUSESCREEN, GAMEMODE, OPTIONS, HIGHSCORE, GAMEPLAYOPTS, GRAPHICSOPTS, SOUNDOPTS, STORY, ARCADE, BOSS, DIFFICULTY, LEVELSELECT, LEVEL1, LEVEL2, LEVEL3, LEVEL4, LEVEL5, LEVEL6, LEVEL7, LEVEL8, LEVEL9, LEVEL10 }
    
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
        public LevelSelect levelselect;
        public PauseScreen pauseScreen;
        public Level level1;
        public Level level2;
        public Level level3;
        public Level level4;
        public Level level5;
        public Level level6;
        public Level level7;
        public Level level8;
        public Level level9;
        public Level level10;
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
            levelselect = new LevelSelect(Content, MenuSwitchEvent, graphics);
            pauseScreen = new PauseScreen(Content, MenuSwitchEvent, graphics);
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
                case Stateswitch.LEVEL1:
                    currentScreen = level1;
                    break;
                case Stateswitch.LEVEL2:
                    currentScreen = level2;
                    break;
                case Stateswitch.LEVEL3:
                    currentScreen = level3;
                    break;
                case Stateswitch.LEVEL4:
                    currentScreen = level4;
                    break;
                case Stateswitch.LEVEL5:
                    currentScreen = level5;
                    break;
                case Stateswitch.LEVEL6:
                    currentScreen = level6;
                    break;
                case Stateswitch.LEVEL7:
                    currentScreen = level7;
                    break;
                case Stateswitch.LEVEL8:
                    currentScreen = level8;
                    break;
                case Stateswitch.LEVEL9:
                    currentScreen = level9;
                    break;
                case Stateswitch.LEVEL10:
                    currentScreen = level10;
                    break;
                default:
                    break;
            }
            System.Threading.Thread.Sleep(300);
        }
    }
}
