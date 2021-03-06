﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dreamkeeper
{
    public class Button
    {
        #region Variables
        public Texture2D texture { get; internal set; }
        public SpriteFont spriteFont { get; internal set; }
        public string text { get; internal set; }
        public Color color { get; set; }
        public int positionEndX { get; internal set; }
        public int positionEndY { get; internal set; }
        public int positionX { get; internal set; }
        public int positionY { get; internal set; }
        public int width { get; internal set; }
        public int height { get; internal set; }
        #endregion

        #region Constructors
        public Button(Texture2D txtr, Rectangle rect, Color clr)
        {
            texture = txtr;
            color = clr;
            positionX = rect.X;
            positionY = rect.Y;
            width = rect.Width;
            height = rect.Height;
            positionEndX = positionX + width;
            positionEndY = positionY + height;
        }
        public Button(SpriteFont sprt, string txt, Color clr, Vector2 vec)
        {
            spriteFont = sprt;
            text = txt;
            color = clr;
            positionX = (int)vec.X;
            positionY = (int)vec.Y;
            width = (int)spriteFont.MeasureString(text).X;
            height = (int)spriteFont.MeasureString(text).Y;
            positionEndX = positionX + width;
            positionEndY = positionY + height;
        }
        #endregion

        #region Draw Methods
        public void Draw(SpriteBatch spritebatch)
        {
            if (texture != null)
                spritebatch.Draw(texture, new Rectangle(positionX, positionY, width, height), Color.White);
            else
                spritebatch.DrawString(spriteFont, text, new Vector2(positionX, positionY), color);
        }
        #endregion

        #region Mouse Methods
        public bool IsClicked(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed &&
               (mouseState.X > positionX) && (mouseState.Y > positionY) &&
               (mouseState.X < positionEndX) && (mouseState.Y < positionEndY))
                return true;
            else
                return false;
        }
        public bool Hover(MouseState mouseState)
        {
            if ((mouseState.X > positionX) && (mouseState.Y > positionY) &&
               (mouseState.X < positionEndX) && (mouseState.Y < positionEndY))
                return true;
            else
                return false;
        }
        #endregion
    }
}
