using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Kevin
{
    class FloatRectangle
    {        
        public float Xvalue;
        public float Yvalue;
        public float width;
        public float height;

        public FloatRectangle()
        {
            Xvalue = 3f;
            Yvalue = 5f;
            width = 1f;
            height = 1f;
        }
        public FloatRectangle(float Xvalue, float Yvalue, float width, float height)
        {
            this.Xvalue = Xvalue;
            this.Yvalue = Yvalue;
            this.width = width;
            this.height = height;
        }  
    }
}
