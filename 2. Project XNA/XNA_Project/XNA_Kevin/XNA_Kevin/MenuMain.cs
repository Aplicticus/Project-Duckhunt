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
        private MouseState oldState;
        private SpriteFont font;
        private Texture2D background;  
        private ContentManager content;
        private HUD hud;
        
        public MenuMain(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.content = theContent;
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;

            
           
            background = theContent.Load<Texture2D>("Assets\\Menus\\Mountains1");
            font = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");

            hud = new HUD(content, graphics);
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




            hud.DrawHUD(theBatch);
            
            base.Draw(theBatch);
        }
    }
}
