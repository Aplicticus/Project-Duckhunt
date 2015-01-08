using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNA_Kevin
{
    class HUD
    {        
        // Volumes
        public float width { get; set;}
        public float height { get; set; }

        // Positions
        public float positionX { get; set; }
        public float positionY { get; set; }
        public float positionEndX { get; set; }

        // Time variables
        private float time { get; set; }
        private float timelaps { get; set; }


        // Global variables
        private ContentManager content;
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

        private float stonePositionX = 50f;
        private float stonePositionY = 1.23f;

        private float gravelPositionX = 12f;
        private float gravelPositionY = 1.20f;

        private float mudPositionX = 8f;
        private float mudPositionY = 1.14f;

        private float metalPositionX = 6f;
        private float metalPositionY = 1.08f;
        
        // HUDS
        private HUD score;
        private HUD timeline;
        private HUD timepointer;
        private HUD ammoswap;
        private HUD stone;
        private HUD gravel;
        private HUD mud;
        private HUD metal;
        private HUD tempwep;

        // Sprite Fonts
        //private SpriteFont currentScore;
        
        // Texture2Ds
        private Texture2D bgScore;
        private Texture2D bgTimeline;
        private Texture2D bgTimepointer;
        private Texture2D bgammoswap;

        private Texture2D bgStone;
        private Texture2D bgGravel;
        private Texture2D bgMud;
        private Texture2D bgMetal;

        // Constructors
        public HUD(ContentManager theContent)
        {
            content = theContent;
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
            score = new HUD(bgScore, positionX / scorePositionX, positionY / scorePositionY, width / scoreWidth, height / scoreHeight);
            timeline = new HUD(bgTimeline, positionX / timelinePositionX, positionX / timelinePositionY, width / timelineWidth, height / timelineHeight);
            timepointer = new HUD(bgTimepointer, positionX / timepointerPositionX, positionY / timepointerPositionY, width / timepointerWidth, height / timepointerHeight);
            timepointer.positionEndX = timeline.positionEndX - timeline.positionEndX / 80f; // End position of the timepointer
            ammoswap = new HUD(bgammoswap, positionX / ammoswapPositionX, positionY / ammoswapPositionY, width / ammoswapWidth, height / ammoswapHeight);

            stone = new HUD(bgStone, positionX / stonePositionX, positionY / stonePositionY, width / 30f, height / 50f); // Temp
            gravel = new HUD(bgGravel, positionX / gravelPositionX, positionY / gravelPositionY, width / 30f, height / 50f);
            mud = new HUD(bgMud, positionX / mudPositionX, positionY / mudPositionY, width / 30f, height / 50f);
            metal = new HUD(bgMetal, positionX / metalPositionX, positionY / metalPositionY, width / 30f, height / 50f);
            tempwep = new HUD(texture, positionX / stonePositionX, positionY / stonePositionY, width / 30f, height / 50f);            
        }

        // Load Contents 
        private void loadContent()
        {
            bgScore = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureBlack");
            bgTimeline = content.Load<Texture2D>("Assets\\Global\\Sprites\\HUD_Timeline");
            bgTimepointer = content.Load<Texture2D>("Assets\\Global\\Sprites\\HUD_TimePointer");
            bgammoswap = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureBlack");
            bgStone = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgGravel = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgMud = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgMetal = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
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
        public void DrawHUDS(SpriteBatch theBatch)
        {
            score.Draw(theBatch);
            timeline.Draw(theBatch);
            timepointer.Draw(theBatch);
            ammoswap.Draw(theBatch);


            stone.Draw(theBatch);
            gravel.Draw(theBatch);
            mud.Draw(theBatch);
            metal.Draw(theBatch);
        }
        private void DrawSprites(SpriteBatch theBatch)
        {

        }
        public void DrawFONTS(SpriteBatch theBatch)
        {

        }
                
        // Timeline Method
        public bool GetTimeState()
        {
            timelaps = 950; // 1 minute = ~5700
            time = timepointer.positionEndX / timelaps;

            if (timepointer.positionX >= timepointer.positionEndX)
                return true;
            else
            {
                timepointer.positionX += time;
                return false;
            }
        }

        public void NextWeapon()
        {           
            stone.positionX = gravel.positionX;
            stone.positionY = gravel.positionY;

            gravel.positionX = mud.positionX;
            gravel.positionY = mud.positionY;

            mud.positionX = metal.positionX;
            mud.positionY = metal.positionY;

            metal.positionX = tempwep.positionX;
            metal.positionY = tempwep.positionY;

            tempwep.positionX = stone.positionX;
            tempwep.positionY = stone.positionY;
        }
        public void LastWeapon()
        {
            

            tempwep.positionX = metal.positionX;
            tempwep.positionY = metal.positionY;

            metal.positionX = mud.positionX;
            metal.positionY = mud.positionY;

            mud.positionX = gravel.positionX;
            mud.positionY = gravel.positionY;

            gravel.positionX = stone.positionX;
            gravel.positionY = stone.positionY;

            stone.positionX = tempwep.positionX;
            stone.positionY = tempwep.positionY;
        }



       

        















        
       
    }
}
