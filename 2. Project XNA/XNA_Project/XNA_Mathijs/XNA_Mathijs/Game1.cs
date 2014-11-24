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

namespace XNA_Mathijs
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 mPosition = new Vector2(0, 0);
        Texture2D mSpriteTexture;
        SoundEffect mSoundEffect;

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

            // TODO: use this.Content to load your game content here
            mSpriteTexture = this.Content.Load<Texture2D>("Isaac_form1");
            mSoundEffect = this.Content.Load<SoundEffect>("Isaac_sounds");
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

            // TODO: Add your update logic here
            UpdateMouse();

            //checkMouseClick();

            if (leftMouseClicked == true) // Don't bother collision checking unless mouse is clicked
            {
                OnMouseOver(); // Check if mouse is inside texture area
                if (MouseOverSprite == true)
                {
                    PixelCheck(); // Check if individual pixel is non Alpha
                    if (PixelDetected == true)
                        mSoundEffect.Play();
                }
            } 

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(mSpriteTexture, mPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

         // Mouse coordinates are initialized at 0, 0
        Vector2 mousePosition = Vector2.Zero;
        void UpdateMouse()
        {
            MouseState mouseState = Mouse.GetState();
            IsMouseVisible = true; // Show the mouse cursor ( default is false )

            // The mouse X and Y positions are returned relative to the top-left of the game window.
            mousePosition.X = mouseState.X;
            mousePosition.Y = mouseState.Y;

        } // end UpdateMouse

        bool MouseOverSprite = false;
        void OnMouseOver()
        {
            if ((mousePosition.X >= mPosition.X) && mousePosition.X <= (mPosition.X + mSpriteTexture.Width) &&
                    mousePosition.Y >= mPosition.Y && mousePosition.Y <= (mPosition.Y + mSpriteTexture.Height))
                MouseOverSprite = true;
            else MouseOverSprite = false;
        } // end OnMouseOver


        bool PixelDetected = false;
        Vector2 pixelPosition = Vector2.Zero;
        uint[] PixelData = new uint[1]; // Delare an Array of 1 just to store data for one pixel
        void PixelCheck()
        {
            // Get Mouse position relative to top left of Texture
            pixelPosition = mousePosition - mPosition;

            // I know. I just checked this condition at OnMouseOver or we wouldn't be here
            // but just to be sure the spot we're checking is within the bounds of the texture...
            if (pixelPosition.X >= 0 && pixelPosition.X < mSpriteTexture.Width &&
                pixelPosition.Y >= 0 && pixelPosition.Y < mSpriteTexture.Height)
            {
                // Get the Texture Data within the Rectangle coords, in this case a 1 X 1 rectangle
                // Store the data in pixelData Array
                mSpriteTexture.GetData<uint>(0, new Rectangle((int)pixelPosition.X, (int)pixelPosition.Y, (1), (1)), PixelData, 0, 1);

                // Check if pixel in Array is non Alpha, give or take 20
                if (((PixelData[0] & 0xFF000000) >> 24) > 20)
                    PixelDetected = true;
                else PixelDetected = false;
            }
        } // end PixelCheck

        bool leftMouseClicked = false;
        void checkMouseClick()
        {
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed) 
                leftMouseClicked = true;
            else leftMouseClicked = false;
        } // end checkMouseClick
    }
    
}
