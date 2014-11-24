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

namespace XNA_MainProject
{
    enum ScreenState { MainMenu, Gamemode}
    class StateSwitcher : Microsoft.Xna.Framework.Game
    {

        /// <summary>
        /// This starting class exists to switch between states/screens
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
        /// 

        //Indicate starting state here
        ScreenState CurrentState = ScreenState.MainMenu;
        protected override void Update(GameTime gametime)
        {
            switch (CurrentState)
            {
                case ScreenState.MainMenu:
                    {
                        using(MainMenu mainMenu = new MainMenu())
                        {
                            mainMenu.Run();
                        }
                        break;
                    }
                case ScreenState.Gamemode:
                    {
                        break;
                    }
            }
            base.Update(gametime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
        }

    }
}
