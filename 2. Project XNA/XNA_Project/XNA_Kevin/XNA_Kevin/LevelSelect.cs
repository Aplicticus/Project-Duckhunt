using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Kevin
{
    class LevelSelect
    {
        // Global Variables
        private ContentManager content;
        private GraphicsDeviceManager graphics;
        private Texture2D texture { get; set; }

        // position, width, height
        private Vector2 position;
        private float width;
        private float height;

        // Levels
        LevelSelect globalBorder;
        LevelSelect global;
        LevelSelect level1;
        LevelSelect level2;
        LevelSelect level3;
        LevelSelect level4;
        LevelSelect level5;
        LevelSelect level6;
        LevelSelect level7;
        LevelSelect level8;
        LevelSelect level9;

        // Level backgrounds
        Texture2D bgGlobalBorder;
        Texture2D bgGlobal;
        Texture2D bgLevel1;
        Texture2D bgLevel2;
        Texture2D bgLevel3;
        Texture2D bgLevel4;
        Texture2D bgLevel5;
        Texture2D bgLevel6;
        Texture2D bgLevel7;
        Texture2D bgLevel8;
        Texture2D bgLevel9;

        // Positions
        private float globalBorderPosX;
        private float globalBorderPosY;
        private float globalPosX;
        private float globalPosY;
        private float level1PosX;
        private float level1PosY;
        private float level2PosX;
        private float level2PosY;
        private float level3PosX;
        private float level3posY;
        private float level4PosX;
        private float level4posY;
        private float level5PosX;
        private float level5posY;
        private float level6PosX;
        private float level6posY;
        private float level7PosX;
        private float level7posY;
        private float level8PosX;
        private float level8posY;
        private float level9PosX;
        private float level9posY;

        // Width & Height
        private float globalBorderWidth;
        private float globalBorderHeight;
        private float globalWidth;
        private float globalHeight;
        private float levelWidth;
        private float levelHeight;

        // Constructors
        public LevelSelect(ContentManager content, GraphicsDeviceManager graphics)
        {
            this.content = content;
            this.graphics = graphics;
        }
        private LevelSelect(Texture2D texture, Vector2 position, float width, float height)
        {
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.height = height;
        }

        // Initialize
        public void Initialize()
        {
            LoadContent();
            ScreenInitialize();
            Calculate();

            globalBorder = new LevelSelect(bgGlobalBorder, new Vector2(globalBorderPosX, globalBorderPosY), globalBorderWidth, globalBorderHeight);
            global = new LevelSelect(bgGlobal, new Vector2(globalPosX, globalPosY), globalWidth, globalHeight);
            level1 = new LevelSelect(bgLevel1, new Vector2(level1PosX, level1PosY), levelWidth, levelHeight);
            level2 = new LevelSelect(bgLevel2, new Vector2(level2PosX, level2PosY), levelWidth, levelHeight);
            level3 = new LevelSelect(bgLevel3, new Vector2(level3PosX, level3posY), levelWidth, levelHeight);
            level4 = new LevelSelect(bgLevel4, new Vector2(level4PosX, level4posY), levelWidth, levelHeight);
            level5 = new LevelSelect(bgLevel5, new Vector2(level5PosX, level5posY), levelWidth, levelHeight);
            level6 = new LevelSelect(bgLevel6, new Vector2(level6PosX, level6posY), levelWidth, levelHeight);
            level7 = new LevelSelect(bgLevel7, new Vector2(level7PosX, level7posY), levelWidth, levelHeight);
            level8 = new LevelSelect(bgLevel8, new Vector2(level8PosX, level8posY), levelWidth, levelHeight);
            level9 = new LevelSelect(bgLevel9, new Vector2(level9PosX, level9posY), levelWidth, levelHeight);
        
        
        }

        public void Calculate()
        {
            // Positions X
            globalBorderPosX = position.X / 9f;
            globalPosX = globalBorderPosX / 0.88f;


            level1PosX = globalPosX / 0.9f;
            level2PosX = globalPosX / 0.328f;
            level3PosX = globalPosX / 0.2f;
            level4PosX = globalPosX / 0.9f;
            level5PosX = globalPosX / 0.328f;
            level6PosX = globalPosX / 0.2f;
            level7PosX = globalPosX / 0.9f;
            level8PosX = globalPosX / 0.328f;
            level9PosX = globalPosX / 0.2f;
            

            // Positions Y
            globalBorderPosY = position.Y / 9f;
            globalPosY = globalBorderPosY / 0.85f;
            level1PosY = globalPosY / 0.9f;
            level2PosY = globalPosY / 0.9f;
            level3posY = globalPosY / 0.9f;
            level4posY = globalPosY / 0.336f;
            level5posY = globalPosY / 0.336f;
            level6posY = globalPosY / 0.336f;
            level7posY = globalPosY / 0.206f;
            level8posY = globalPosY / 0.206f;
            level9posY = globalPosY / 0.206f;

            // Widths
            globalBorderWidth = width / 1.3f;
            globalWidth = globalBorderWidth / 1.06f;
            levelWidth = globalWidth / 3.5f;            

            // Heights
            globalBorderHeight = height / 1.3f;
            globalHeight = globalBorderHeight / 1.06f;
            levelHeight = globalHeight / 3.5f;
        }

        // Screen resolution
        private void ScreenInitialize()
        {
            position.X = graphics.PreferredBackBufferWidth;
            position.Y = graphics.PreferredBackBufferHeight;
            width = graphics.PreferredBackBufferWidth;
            height = graphics.PreferredBackBufferHeight;
        }
       
        // Load Content
        private void LoadContent()
        {
            bgGlobalBorder = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgGlobal = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureBlack");
            bgLevel1 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgLevel2 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgLevel3 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgLevel4 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgLevel5 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgLevel6 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgLevel7 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgLevel8 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
            bgLevel9 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureWhite");
        }
        
        // Draw Methods
        private void Draw(SpriteBatch theBatch)
        {
                theBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height), Color.White);         
        }
        public void DrawLevels(SpriteBatch theBatch)
        {
            globalBorder.Draw(theBatch);
            global.Draw(theBatch);
            level1.Draw(theBatch);
            level2.Draw(theBatch);
            level3.Draw(theBatch);
            level4.Draw(theBatch);
            level5.Draw(theBatch);
            level6.Draw(theBatch);
            level7.Draw(theBatch);
            level8.Draw(theBatch);
            level9.Draw(theBatch);
        }

    }
}
