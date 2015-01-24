using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreamkeeper
{
    public class AnimatedSprite
    {
        #region Variables
        internal Texture2D Texture { get; set; }
        internal int Rows { get; private set; }
        internal int Columns { get; private set; }
        internal int currentFrame;
        private int totalFrames;
        private int fps;
        private int fpsc;
        #endregion

        #region Constructor
        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            fps = 30 / totalFrames;
        }
        #endregion

        #region Update
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
        #endregion

        #region Draw Methods
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
        #endregion
    }
}
