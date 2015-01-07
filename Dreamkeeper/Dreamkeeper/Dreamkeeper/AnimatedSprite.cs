using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int currentFrame;
        private int totalFrames;
        private int fps;
        private int fpsc;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            fps = 30 / totalFrames;
        }

        public void Update()
        {
            fpsc++;
            if (fpsc == fps)
            {
                currentFrame++;
                fpsc = 0;
            }
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, float scale)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, (int)(width * scale), (int)(height * scale));

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
