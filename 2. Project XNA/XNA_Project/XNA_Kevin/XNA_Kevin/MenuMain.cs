using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Kevin
{
    class MenuMain : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        //private GraphicsDeviceManager graphics;

        private MouseState oldState;

        private SpriteFont font;

        private Texture2D background;

        private HUD allhud;
        private LevelSelect alllevels;
        
        public MenuMain(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {   
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;

            allhud = new HUD(theContent);
            allhud.Initialize(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            //allhud.NextWeapon();

            alllevels = new LevelSelect(theContent);
            alllevels.Initialize(new Vector2((float)graphics.PreferredBackBufferWidth, (float)graphics.PreferredBackBufferHeight), graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            background = theContent.Load<Texture2D>("Assets\\Menus\\Mountains1");
            font = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");
           

           }

        int countDown = 0;
        int countUp = 0;

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();
            oldState = newState;

            if (allhud.GetTimeState() == true)
            {
                // Message box  show ( Game over )....
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                if (countDown == 0)
                    countDown = 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2))
            {
                if (countUp == 0)
                    countUp = 1;
            }


            if (Keyboard.GetState().IsKeyUp(Keys.D1))
            {
                if (countDown == 1)
                    countDown = 2;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.D2))
            {
                if (countUp == 1)
                    countUp = 2;
            }



            if (countDown == 2)
            {
                allhud.NextWeapon();
                countDown = 0;
            }

            if (countUp == 2)
            {
                allhud.LastWeapon();
                countUp = 0;
            }

            
          




            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            allhud.DrawHUDS(theBatch);

            alllevels.DrawLevels(theBatch);

            
            base.Draw(theBatch);
        }
    }
}
