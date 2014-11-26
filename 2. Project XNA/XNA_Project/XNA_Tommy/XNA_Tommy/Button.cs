using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Tommy
{
    class Button
    {
        public Texture2D texture { get; internal set; }
        public int positionEndX { get; internal set; }
        public int positionEndY { get; internal set; }
        public int positionX { get; internal set; }
        public int positionY { get; internal set; }
        public int width { get; internal set; }
        public int height { get; internal set; }

        public Button(Texture2D txtr, Rectangle rect)
        {
            texture = txtr;
            positionX = rect.X;
            positionY = rect.Y;
            width = rect.Width;
            height = rect.Height;
            positionEndX = positionX + width;
            positionEndY = positionY + height;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, new Rectangle(positionX, positionY, width, height), Color.White);
        }

        public bool IsClicked(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed &&
               (mouseState.X > positionX) && (mouseState.Y > positionY) &&
               (mouseState.X < positionEndX) && (mouseState.Y < positionEndY))
                return true;
            else
                return false;
        }
    }
}
