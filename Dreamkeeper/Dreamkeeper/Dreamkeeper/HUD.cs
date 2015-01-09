using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dreamkeeper
{
    class HUD
    {        
        // Volumes
        private float width { get; set;}
        private float height { get; set; }

        // Positions
        public float positionX { get; set; }
        public float positionY { get; set; }
        public float positionEndX { get; set; }

        // Time variables
        private float time { get; set; }
        private float timelaps { get; set; }


        // Global variables
        private ContentManager content;
        private GraphicsDevice graphics;
        private SpriteFont spriteFont { get;  set; }
        private string text { get; set; }
        private Color color { get; set; }
        private Texture2D texture { get; set; }

        // -- Alter Variable Changes
        // Header Width & Heights
        private float scoreWidth = 5f;
        private float scoreHeight = 6f;
        private float timelineWidth = 2.5f;
        private float timelineHeight = 6f;
        private float timepointerWidth = 95f;
        private float timepointerHeight = 25f;
        private float ammoswapWidth = 5f;
        private float ammoswapHeight = 6f;

        // Header Positions
        private float scorePositionX = 95f;
        private float scorePositionY = 95f;
        private float timelinePositionX = 3f;
        private float timelinePositionY = 95f;
        private float timepointerPositionX = 3f;
        private float timepointerPositionY = 7f;
        private float ammoswapPositionX = 95f;
        private float ammoswapPositionY = 1.25f;
        
        // HUDS
        private HUD score;
        private HUD timeline;
        public HUD timepointer;
        private HUD ammoswap;

        // Sprite Fonts
        //private SpriteFont currentScore;
        
        // Texture2Ds
        private Texture2D bgScore;
        private Texture2D bgTimeline;
        private Texture2D bgTimepointer;
        private Texture2D bgammoswap;
        private Texture2D bgOverlay;

        // Constructors
        public HUD(ContentManager theContent, GraphicsDevice graphics)
        {
            content = theContent;
            this.graphics = graphics;
        }
        public HUD(Texture2D texture, float positionX, float positionY, float width, float height)
        {
            this.texture = texture;
            this.positionX = positionX;
            this.positionY = positionY;
            this.width = width;
            this.height = height;
            positionEndX = positionX + width;
        }
        
        // Initializers
        public void Initialize(float positionX, float positionY, float width, float height)
        {   
            loadContent();
            InitializeHUD(positionX, positionY, width, height);            
        }
        private void InitializeHUD(float positionX, float positionY, float width, float height)
        {
            score = new HUD(bgScore, (width / 10) - (width / scoreWidth / 3.5f), (height / 1.2f) - (height / scoreHeight / 3.5f), width / scoreWidth, height / scoreHeight);
            timeline = new HUD(bgTimeline, positionX / timelinePositionX, height - (height / 5) - timelineHeight, width / timelineWidth, height / timelineHeight);
            timepointer = new HUD(bgTimepointer, positionX / timepointerPositionX, (height - (height / 5) - timelineHeight) + ((height / timelineHeight) / 1.3f), width / timepointerWidth, height / timepointerHeight);
            timepointer.positionEndX = timeline.positionEndX - timeline.positionEndX / 80f; // End position of the timepointer
            ammoswap = new HUD(bgammoswap, positionX / ammoswapPositionX, positionY / ammoswapPositionY, width / ammoswapWidth, height / ammoswapHeight);
        }

        // Load Contents
        private void loadContent()
        {
            bgScore = content.Load<Texture2D>("cloud");
            bgTimeline = content.Load<Texture2D>("HUD_Timeline");
            bgTimepointer = content.Load<Texture2D>("HUD_TimePointer");
            bgammoswap = content.Load<Texture2D>("HUD_Timeline");
            bgOverlay = content.Load<Texture2D>("DreamHud");
        }
               
        // Draw Methods
        private void Draw(SpriteBatch theBatch)
        {
            if (texture != null)
                theBatch.Draw(texture, new Rectangle((int)positionX, (int)positionY, (int)width, (int)height), Color.White);
            else
            {
                theBatch.DrawString(spriteFont, text, new Vector2(positionX, positionY), color);
            }
        }
        public void DrawHUD(SpriteBatch theBatch)
        {
            theBatch.Draw(bgOverlay, new Rectangle(0, 0, graphics.Viewport.Width, graphics.Viewport.Height), Color.White);
            score.Draw(theBatch);
            timeline.Draw(theBatch);
            timepointer.Draw(theBatch);
            //ammoswap.Draw(theBatch);
        }
        public void DrawSprites(SpriteBatch theBatch)
        {

        }
                
        // Timeline Method
        public bool GetTimeState(int levelTime)
        {
            timelaps = levelTime; // 1 minute = ~5700
            time = timepointer.positionEndX / timelaps;

            if (timepointer.positionX >= timepointer.positionEndX)
                return true;
            else
            {
                timepointer.positionX += time;
                return false;
            }
        }

      
        
        















        
       
    }
}
