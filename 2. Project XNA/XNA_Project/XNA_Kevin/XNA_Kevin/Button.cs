using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace XNA_Kevin
{
    class Button
    {
        Rectangle btn;        
        private int positionEndX;
        private int positionEndY;
        
        public Button()
        {
            
        }       

        public Rectangle GetButton(int positionX, int positionY, int width, int height)
        {
            return btn = new Rectangle(positionX, positionY, width, height);            
        }


        // Methods
        public int GetPositionBeginX()
        {
            return btn.X;
        }
        public int GetPositionBeginY()
        {
            return btn.Y;
        }

        public int GetPositionEndX()
        {
            positionEndX = btn.X;
            return positionEndX + btn.Width;
        }
        public int getPositionEndY()
        {
            positionEndY = btn.Y;
            return positionEndY + btn.Height;
        }

                

        
        
            

    }

    
   
}
