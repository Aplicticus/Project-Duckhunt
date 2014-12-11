using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    class HudTest : Screen
    {
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private GraphicsDeviceManager graphics;

        private MouseState oldState;

        private SpriteFont font;
        private SpriteFont stopfont;
        private SpriteFont fontHighscore;
        private SpriteFont fontTimeline;

        private Texture2D background;
        private Texture2D bgTimeline;
        private Button boxStop;

        private HUD fontHighscoreHUD;
        private HUD bgTimelineHUD;
        private HUD timePointer;
        private HUD bgAmmoHUD;
        private Texture2D timepointer;

        private bool isOnEnd;



        public HudTest(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            isOnEnd = false;
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Assets\\Menus\\Mountains1");
            font = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");
            stopfont = theContent.Load<SpriteFont>("Assets\\Menus\\StopFont");
            timepointer = theContent.Load<Texture2D>("Assets\\Global\\Sprites\\HUD_TimePointer");
            
            fontHighscore = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");
            bgTimeline = theContent.Load<Texture2D>("Assets\\Global\\Sprites\\HUD_Timeline");
            fontTimeline = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");
            
            fontHighscoreHUD = new HUD(fontHighscore, "00000000", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 20, graphics.PreferredBackBufferHeight / 40));
            bgTimelineHUD = new HUD(bgTimeline, new Rectangle(graphics.PreferredBackBufferWidth / 4, graphics.PreferredBackBufferHeight / 80, graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 10));
           
            timePointer = new HUD(timepointer, new Rectangle(graphics.PreferredBackBufferWidth / 4, graphics.PreferredBackBufferHeight / 11, graphics.PreferredBackBufferWidth / 100, graphics.PreferredBackBufferHeight / 40));
            timePointer.positionEndX = bgTimelineHUD.positionX + bgTimelineHUD.width - 12;
            

            bgAmmoHUD = new HUD(bgTimeline, new Rectangle(graphics.PreferredBackBufferWidth / 100 - 10, graphics.PreferredBackBufferHeight / 2 + 150, graphics.PreferredBackBufferWidth / 4, graphics.PreferredBackBufferHeight / 4));
            
                        
             boxStop = new Button(background, new Rectangle(graphics.PreferredBackBufferWidth / 3 - 25, graphics.PreferredBackBufferHeight / 3, graphics.PreferredBackBufferWidth / 3 + 50, graphics.PreferredBackBufferHeight / 3));   
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();            
            if (boxStop.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                Environment.Exit(0);

            oldState = newState;
            if (timePointer.GetTimeState() == true)
            {
                isOnEnd = true;                
            }
            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            
            if (isOnEnd == true) 
                boxStop.Draw(theBatch);

            fontHighscoreHUD.Draw(theBatch);

           
            bgTimelineHUD.Draw(theBatch);
            timePointer.Draw(theBatch);  
            bgAmmoHUD.Draw(theBatch);
            
            base.Draw(theBatch);
        }
    }
}
