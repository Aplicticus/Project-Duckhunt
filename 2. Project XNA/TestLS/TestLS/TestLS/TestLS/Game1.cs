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
using System.Threading;
using GifAnimation;

namespace TestLS
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GifAnimation.GifAnimation animation;
        //public Texture2D Plaatje;
        ////int curruntstate = (int)Levels.INTRO;
        //Color color;

        //public enum GameState
        //{
        //    INTRO,
        //    LOADINGSCREEN,
        //    MAINMENU,
        //}

        //GameState currentstate = GameState.MAINMENU;

        

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

            animation = Content.Load<GifAnimation.GifAnimation>("LoadingBar");

            //Plaatje = Content.Load<Texture2D>("beastie-medium");

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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            animation.Update(gameTime.ElapsedGameTime.Ticks);

            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //    curruntstate++;
            //if (Keyboard.GetState().IsKeyDown(Keys.Tab))
            //    curruntstate--;

            //switch (curruntstate)
            //{
            //    case (int)Levels.INTRO:
            //        color = Color.Green;
            //        break;
            //    case (int)Levels.LOADINGSCREEN:
                    
            //        break;
            //    case (int)Levels.MAINMENU:
            //        color = Color.Black;
            //        break;
            //}


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(this.animation.GetTexture(), new Vector2(0, 0), Color.White);
            this.spriteBatch.End();

            //GraphicsDevice.Clear(color);
                

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
