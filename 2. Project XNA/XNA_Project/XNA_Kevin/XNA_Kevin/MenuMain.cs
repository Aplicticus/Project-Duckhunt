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

        //private HUD allhud;
        private LevelSelect alllevels;
        
        public MenuMain(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {   
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;

            //allhud = new HUD(theContent);
            //allhud.Initialize(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            ////allhud.NextWeapon();

            alllevels = new LevelSelect(theContent, graphics);
           
            background = theContent.Load<Texture2D>("Assets\\Menus\\Mountains1");
            font = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");
           

           }


        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();
            oldState = newState;




            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            //allhud.DrawHUDS(theBatch);

            alllevels.DrawLevels(theBatch);
            

            
            base.Draw(theBatch);
        }
    }
}
