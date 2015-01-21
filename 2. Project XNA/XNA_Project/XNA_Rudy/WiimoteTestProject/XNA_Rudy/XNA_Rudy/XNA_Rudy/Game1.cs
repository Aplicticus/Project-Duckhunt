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

namespace XNA_Rudy
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        Controller controller;
        Texture2D crosshair;

        Vector2 currPos;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1377;
            IsMouseVisible = true;
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
            controller = new Controller();

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
            crosshair = this.Content.Load<Texture2D>("crosshair");
            spriteFont = this.Content.Load<SpriteFont>("Courier New");

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || controller.GetPressedButton(controller.wiiM1) == "Home")
            {
                controller.wiiM1.Dispose();
                controller.wiiM1.Disconnect();
                this.Exit();
            }


            // TODO: Add your update logic here

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

            spriteBatch.DrawString(spriteFont, "IR Values0" + controller.GetIRResultsS1(controller.wiiM1).ToString(), new Vector2(10, 50), Color.Black);
            spriteBatch.DrawString(spriteFont, "IR Values1" + controller.GetIRResultsS2(controller.wiiM1).ToString(), new Vector2(10, 100), Color.Black);
            spriteBatch.DrawString(spriteFont, "IR ValuesM" + controller.GetIRResultsMidpoint(controller.wiiM1).ToString(), new Vector2(10, 150), Color.Black);
            spriteBatch.DrawString(spriteFont, "yTest Values" + controller.GetPos0(controller.wiiM1, graphics).Y.ToString(), new Vector2(10, 250), Color.Black);
            spriteBatch.DrawString(spriteFont, "Pressed button: " + controller.GetPressedButton(controller.wiiM1), new Vector2(10, 200), Color.Black);
            
            spriteBatch.DrawString(spriteFont, "IR Size" + controller.GetWiimote(controller.wiiM1).WiimoteState.IRState.IRSensors[0].Size.ToString(), new Vector2(10, 300), Color.Black);

            /*if(controller.GetPos0(controller.GetPos0(controller.wiiM1, graphics).X <= controller.GetPos0(controller.wiiM1, graphics).X / 2)
            {

            }*/
            spriteBatch.Draw(crosshair, controller.GetPos0(controller.wiiM1, graphics), null, Color.Black, 0.0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(crosshair, controller.GetPos1(controller.wiiM1, graphics), null, Color.Black, 0.0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0.0f);
            spriteBatch.Draw(crosshair, controller.GetPosM(controller.wiiM1, graphics), null, Color.Black, 0.0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0.0f);
           
            spriteBatch.End();

 
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
