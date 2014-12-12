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
        private SpriteFont stopfont;
        private SpriteFont scoreFont;
        private SpriteFont fontTimeline;

        private Texture2D background;
        private Texture2D bgTimeline;
        private Texture2D bgScore;

        private Button btnPlay;
        private Button btnOptions;
        private Button btnQuit;
        private Button boxStop;

        private HUD highscoreHUD;
        private HUD bgTimelineHUD;
        private HUD bgScoreHUD;
        private HUD bgTargetScoreHUD;
        private HUD bgScoresHUD;
        private HUD timePointer;
        private HUD bgAmmoHUD;
        private Texture2D timepointer;

        private bool isOnEnd = false;

        private HUD bgRightCloud;

        public MenuMain(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {   
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;


            background = theContent.Load<Texture2D>("Assets\\Menus\\Mountains1");
            font = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");
            stopfont = theContent.Load<SpriteFont>("Assets\\Menus\\StopFont");
            timepointer = theContent.Load<Texture2D>("Assets\\Global\\Sprites\\HUD_TimePointer");

            bgScore = theContent.Load<Texture2D>("Assets\\Global\\Sprites\\cloud");
            scoreFont = theContent.Load<SpriteFont>("Assets\\Menus\\ScoreFont");
            bgTimeline = theContent.Load<Texture2D>("Assets\\Global\\Sprites\\HUD_Timeline");
            fontTimeline = theContent.Load<SpriteFont>("Assets\\Menus\\MenuFont");


            
           
            

            btnPlay = new Button(font, "Play", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnOptions = new Button(font, "Options", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnQuit = new Button(font, "Quit", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 250));



            // Backgrounds of scores has to be changed ( transparant )
            bgScoreHUD = new HUD(bgScore, new FloatRectangle(graphics.PreferredBackBufferWidth / 20f, graphics.PreferredBackBufferHeight / 40f, graphics.PreferredBackBufferWidth / 10f, graphics.PreferredBackBufferHeight / 15f));
            bgTargetScoreHUD = new HUD(bgScore, new FloatRectangle(graphics.PreferredBackBufferWidth / 20f, graphics.PreferredBackBufferHeight / 10f, graphics.PreferredBackBufferWidth / 6f, graphics.PreferredBackBufferHeight / 15f));
            bgScoresHUD = new HUD(bgScore, new FloatRectangle(graphics.PreferredBackBufferWidth / 33f, graphics.PreferredBackBufferHeight / 80f, graphics.PreferredBackBufferWidth / 5f, graphics.PreferredBackBufferHeight / 6f));
            highscoreHUD = new HUD(scoreFont, "Score" + "\n" + "00000000" + "\n" + "Target Score" + "\n" + "00000000", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 20, graphics.PreferredBackBufferHeight / 40));
            
            // Right cloud
            bgRightCloud = new HUD(bgScore, new FloatRectangle(graphics.PreferredBackBufferWidth / 1.3f, graphics.PreferredBackBufferHeight / 80.0f, graphics.PreferredBackBufferWidth / 5f, graphics.PreferredBackBufferHeight / 6f));

            
            bgTimelineHUD = new HUD(bgTimeline, new FloatRectangle(graphics.PreferredBackBufferWidth / 4f, graphics.PreferredBackBufferHeight / 80f, graphics.PreferredBackBufferWidth / 2f, graphics.PreferredBackBufferHeight / 10f));
           
            timePointer = new HUD(timepointer, new FloatRectangle(graphics.PreferredBackBufferWidth / 4f, graphics.PreferredBackBufferHeight / 11f, graphics.PreferredBackBufferWidth / 100f, graphics.PreferredBackBufferHeight / 40f));
            timePointer.positionEndX = bgTimelineHUD.positionX + bgTimelineHUD.width - 12;
            

            bgAmmoHUD = new HUD(bgTimeline, new FloatRectangle(graphics.PreferredBackBufferWidth / 33f, graphics.PreferredBackBufferHeight / 1.35f, graphics.PreferredBackBufferWidth / 4f, graphics.PreferredBackBufferHeight / 4f));
            
                        
             boxStop = new Button(background, new Rectangle(graphics.PreferredBackBufferWidth / 3 - 25, graphics.PreferredBackBufferHeight / 3, graphics.PreferredBackBufferWidth / 3 + 50, graphics.PreferredBackBufferHeight / 3));   
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

            if (boxStop.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                Environment.Exit(0);

            oldState = newState;

            // Change objects to resolution
            btnPlay = new Button(font, "Play", (btnPlay.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnOptions = new Button(font, "Options", (btnOptions.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));

           
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
            
            //Buttons
            btnPlay.Draw(theBatch);
            btnOptions.Draw(theBatch);
            btnQuit.Draw(theBatch);
            if (isOnEnd == true)
            {
                boxStop.Draw(theBatch);
            }
            bgRightCloud.Draw(theBatch);
            bgScoresHUD.Draw(theBatch);
            bgScoreHUD.Draw(theBatch);
            bgTargetScoreHUD.Draw(theBatch);
            highscoreHUD.Draw(theBatch);
            
            bgTimelineHUD.Draw(theBatch);
            timePointer.Draw(theBatch);
            bgAmmoHUD.Draw(theBatch);
            base.Draw(theBatch);
        }
    }
}
