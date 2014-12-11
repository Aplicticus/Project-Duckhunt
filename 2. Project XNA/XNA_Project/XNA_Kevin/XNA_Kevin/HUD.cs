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
        public Texture2D texture { get; internal set; }
        public SpriteFont spriteFont { get; internal set; }
        public string text { get; internal set; }
        public Color color { get; internal set; }
        public float positionEndX { get; internal set; }
        public float positionEndY { get; internal set; }
        public float positionX { get; internal set; }
        public float positionY { get; internal set; }
        public float width { get; internal set; }
        public float height { get; internal set; }
        public float time { get; internal set; }
       
        
        public HUD(Texture2D txtr, Rectangle rect)
        {
            texture = txtr;
            positionX = rect.X;
            positionY = rect.Y;
            width = rect.Width;
            height = rect.Height;            
            positionEndY = positionY + height;
            positionEndX = positionX + width;
        }

        public HUD(SpriteFont sprt, string txt, Color clr, Vector2 vec)
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

        public HUD(SpriteFont sprt, string txt, Color clr, Vector2 vec)
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

        public void Draw(SpriteBatch spritebatch)
        {
            if (texture != null)
                spritebatch.Draw(texture, new Rectangle((int)positionX, (int)positionY, (int)width, (int)height), Color.White); 
            else
            {
                spritebatch.DrawString(spriteFont, text, new Vector2(positionX, positionY), color);
            }
        }
        
        public bool GetTimeState()
        {            
            time = positionEndX / 950; 
            if (positionX >= positionEndX)                
                return true;            
            else
            {
                positionX += time;                
                return false;
            }
        }
    }
}
