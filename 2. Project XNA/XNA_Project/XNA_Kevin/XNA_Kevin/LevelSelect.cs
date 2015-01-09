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
        private Texture2D texture { get; set; }
        private Vector2 position { get; set; }
        private float width { get; set; }
        private float height { get; set; }

        // Levels
        LevelSelect level1;

        // Level backgrounds
        Texture2D bgLevel1;

        // Alter variable changes
        private float lvl1PositionX = 2f;
        private float lvl1PositionY = 2f;
        private float lvl1Width = 5f;
        private float lvl1Height = 5f;

        public LevelSelect(ContentManager theContent)
        {
            content = theContent;
        }

        private LevelSelect(Texture2D texture, Vector2 position, float width, float height)
        {
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public void Initialize(Vector2 position, float width, float height)
        {
            LoadContent();
            level1 = new LevelSelect(bgLevel1, new Vector2(position.X / lvl1PositionX, position.Y / lvl1PositionY), width / lvl1Width, height / lvl1Height);
        }

        private void LoadContent()
        {
            bgLevel1 = content.Load<Texture2D>("Assets\\Global\\Sprites\\missingTextureBlack");
        }
        
        private void Draw(SpriteBatch theBatch)
        {
            if (texture != null)
                theBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height), Color.White);
            //else
            //{
            //    theBatch.DrawString(spriteFont, text, new Vector2(positionX, positionY), color);
            //}
        }
        public void DrawLevels(SpriteBatch theBatch)
        {
            level1.Draw(theBatch);
        }

    }
}
