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
        private GraphicsDeviceManager graphics;

        private MouseState oldState;

        private SpriteFont font;
        private SpriteFont fontHighscore;
        private SpriteFont fontTimeline;

        private Texture2D background;
        private Texture2D bgTimeline;

        private Button btnPlay;
        private Button btnOptions;
        private Button btnQuit;

        private HUD fontHighscoreHUD;
        private HUD bgTimelineHUD;
        private HUD timePointer;
        private Texture2D timepointer;
       


        public MenuMain(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Assets\\Menus\\Mountains1");
            font = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");
            timepointer = theContent.Load<Texture2D>("Assets\\Global\\Sprites\\HUD_TimePointer");
            
            fontHighscore = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");
            bgTimeline = theContent.Load<Texture2D>("Assets\\Global\\Sprites\\HUD_Timeline");
            fontTimeline = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");


            btnPlay = new Button(font, "Play", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnOptions = new Button(font, "Options", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnQuit = new Button(font, "Quit", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            

            fontHighscoreHUD = new HUD(fontHighscore, "00000000", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 20, graphics.PreferredBackBufferHeight / 40));

            bgTimelineHUD = new HUD(bgTimeline, new Rectangle(graphics.PreferredBackBufferWidth / 4, graphics.PreferredBackBufferHeight / 80, graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 10));
            timePointer = new HUD(timepointer, new Rectangle(graphics.PreferredBackBufferWidth / 4, graphics.PreferredBackBufferHeight / 11, graphics.PreferredBackBufferWidth / 100, graphics.PreferredBackBufferHeight / 40));
            timePointer.positionEndPointerX = bgTimelineHUD.positionEndX - 10;
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnPlay.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(2));
            }

            if (btnOptions.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(3));
            }

            if (btnQuit.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                Environment.Exit(0);

            oldState = newState;

            // Change objects to resolution
            btnPlay = new Button(font, "Play", (btnPlay.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnOptions = new Button(font, "Options", (btnOptions.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnQuit = new Button(font, "Quit", (btnQuit.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            
            if (timePointer.GetTimeState()== true)
            {

            }
            

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            

            //Buttons
            btnPlay.Draw(theBatch);
            btnOptions.Draw(theBatch);
            btnQuit.Draw(theBatch);

            fontHighscoreHUD.Draw(theBatch);

            bgTimelineHUD.Draw(theBatch);
            timePointer.Draw(theBatch);
            
            base.Draw(theBatch);
        }
    }
}
