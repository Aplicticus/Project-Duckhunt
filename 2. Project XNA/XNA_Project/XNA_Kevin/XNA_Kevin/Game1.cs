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

namespace XNA_Kevin
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {       
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;        
        Song songs;
        Texture2D background;

        // Texture2D
        Texture2D btnPlay;
        Texture2D btnOptions;
        Texture2D btnHighscore;
        Texture2D btnQuit;
        Texture2D btnBack; 
       
        //Buttons
        Button play = new Button();
        Button options = new Button();
        Button highscore = new Button();
        Button quit = new Button();
        Button back = new Button();


        public Game1()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
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
            IsMouseVisible = true;

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
            LoadBackground();
            LoadSongs();
            LoadButtonBackgrounds();           
        }

        private void LoadBackground()
        {
            background = Content.Load<Texture2D>(@"images\background");
        }
        private void LoadSongs()
        {
            songs = Content.Load<Song>(@"songs\song1");
        }
        private void LoadButtonBackgrounds()
        {
            btnPlay = Content.Load<Texture2D>(@"images\background");
            btnOptions = Content.Load<Texture2D>(@"images\background");
            btnHighscore = Content.Load<Texture2D>(@"images\background");
            btnQuit = Content.Load<Texture2D>(@"images\background");
            btnBack = Content.Load<Texture2D>(@"images\background");
        }

        
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            UnloadSongs();
            //UnloadBackground();
            //UnLoadButtonBackgrounds();
        }

        private void UnloadSongs()
        {
            songs.Dispose();
        }
        private void UnloadBackground()
        {
            background.Dispose();
        }
        private void UnLoadButtonBackgrounds()
        {
            btnPlay.Dispose();
            btnOptions.Dispose();
            btnHighscore.Dispose();
            btnQuit.Dispose();
            btnBack.Dispose();
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
            GetMouseStates();

            MouseState mouseState;

            mouseState = Mouse.GetState();
            
            if  (mouseState.X > play.GetPositionBeginX() && mouseState.Y > play.GetPositionBeginY() &&
                 mouseState.X < play.GetPositionEndX() && (mouseState.Y < play.getPositionEndY())
                ) 
                {
                    btnPlay = Content.Load<Texture2D>(@"images\background2");
                    songs = Content.Load<Song>(@"songs\song2");
                    DrawOnHover();
                    PlayOnHover();                 
                }

            base.Update(gameTime);
        }

        private void GetMouseStates()
        {
            if
               (Mouse.GetState().LeftButton == ButtonState.Pressed &&
               (Mouse.GetState().X > play.GetPositionBeginX()) && (Mouse.GetState().Y > play.GetPositionBeginY()) &&
               (Mouse.GetState().X < play.GetPositionEndX()) && (Mouse.GetState().Y < play.getPositionEndY()))
            {                
                MediaPlayer.Play(songs);
            }
            else if
               (Mouse.GetState().LeftButton == ButtonState.Pressed &&
               (Mouse.GetState().X > options.GetPositionBeginX()) && (Mouse.GetState().Y > options.GetPositionBeginY()) &&
               (Mouse.GetState().X < options.GetPositionEndX()) && (Mouse.GetState().Y < options.getPositionEndY()))
            {
                MediaPlayer.Play(songs);
            }
            else if
               (Mouse.GetState().LeftButton == ButtonState.Pressed &&
               (Mouse.GetState().X > highscore.GetPositionBeginX()) && (Mouse.GetState().Y > highscore.GetPositionBeginY()) &&
               (Mouse.GetState().X < highscore.GetPositionEndX()) && (Mouse.GetState().Y < highscore.getPositionEndY()))
            {
                MediaPlayer.Play(songs);
            }
            else if
               (Mouse.GetState().LeftButton == ButtonState.Pressed &&
               (Mouse.GetState().X > quit.GetPositionBeginX()) && (Mouse.GetState().Y > quit.GetPositionBeginY()) &&
               (Mouse.GetState().X < quit.GetPositionEndX()) && (Mouse.GetState().Y < quit.getPositionEndY()))
            {
                MediaPlayer.Play(songs);
            }
            else if
               (Mouse.GetState().LeftButton == ButtonState.Pressed &&
               (Mouse.GetState().X > back.GetPositionBeginX()) && (Mouse.GetState().Y > back.GetPositionBeginY()) &&
               (Mouse.GetState().X < back.GetPositionEndX()) && (Mouse.GetState().Y < back.getPositionEndY()))
            {
                MediaPlayer.Play(songs);
            }                
        }
       

       

        
     

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
            spriteBatch.End();
            

            // Draw Main Menu
            spriteBatch.Begin();
            spriteBatch.Draw(btnPlay, play.GetButton(325, 100, 150, 50), Color.White);
            spriteBatch.Draw(btnOptions, options.GetButton(325, 155, 150, 50), Color.White);
            spriteBatch.Draw(btnHighscore, highscore.GetButton(325, 210, 150, 50), Color.White);
            spriteBatch.Draw(btnQuit, quit.GetButton(325, 265, 150, 50), Color.White);
            spriteBatch.Draw(btnBack, back.GetButton(325, 320, 150, 50), Color.White);
            spriteBatch.End();     
            
            base.Draw(gameTime);
        }
        private void DrawOnHover()
        {
            spriteBatch.Begin();            
            spriteBatch.Draw(btnPlay, play.GetButton(325, 100, 150, 50), Color.LightBlue);
            spriteBatch.End();
        }
        private void PlayOnHover()
        {
            MediaPlayer.Play(songs);
        }
    }
}
