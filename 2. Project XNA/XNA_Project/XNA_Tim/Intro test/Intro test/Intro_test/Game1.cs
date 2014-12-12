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
using System.IO;

namespace Intro_test
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        TxtHandler intro = new TxtHandler();

        int width = 800;
        int height = 600;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = height;
            graphics.PreferredBackBufferWidth = width;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteFont = Content.Load<SpriteFont>("MyFont");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, intro.Partialtxt(graphics.PreferredBackBufferWidth, ((graphics.PreferredBackBufferWidth / 100) * 5), spriteFont, 0.8f), intro.CalcTextPos(spriteFont, intro.txt, graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth, 0.8f), Color.Black, 0.0f, new Vector2(), 0.8f, SpriteEffects.None, 0.0f);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}





        //        public void readText()
        //        {
        //            while (!reader.EndOfStream)
        //            {
        //                if (heightText <= 440)
        //                {
        //                    heightText += 45;
        //                    temp = reader.ReadLine();
        //                    spriteBatch.DrawString(font, "" + temp, new Vector2(20, heightText), Color.Black);
        //                }
        //            }
        //            reader.Close();
        //        
