using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework;

namespace IntroTest
{
    public class TxtHandler
    {
        public String txt;
        public String partialtxt = " - ";
        public String entertxt = " - ";
        public String test = "0";
        public int nLine = 0;
        Char[] introChars;
        int counter = 0;

        public TxtHandler()
        {
            ReadTxt("LoremIpsumTest.txt");
        }

        public String ReadTxt(string txtFile)
        {
            try
            {
                string line = string.Empty;
                using (StreamReader sr = new StreamReader(txtFile))
                {

                    txt = sr.ReadToEnd();
                    txt = txt.Replace("\r\n", String.Empty);
                    introChars = new char[txt.Length];
                    introChars = txt.ToCharArray();
                    return txt;
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public String Partialtxt(int scrWidth, int strXCoor, SpriteFont font, float scale)
        {


            if (scrWidth >= ((font.MeasureString(entertxt).X * scale) + (strXCoor* 2)))
            {
                if (counter != txt.Length)
                {
                    partialtxt += introChars[counter];
                    entertxt += introChars[counter];
                    counter++;
                }

            }
            else
            {
                partialtxt += "\n";

                if (counter != txt.Length)
                {
                    partialtxt += introChars[counter];
                    entertxt += introChars[counter];
                    counter++;
                }
                entertxt = string.Empty;
                nLine++;
                return entertxt;
            }
            return partialtxt;

        }

        public Vector2 CalcTextPos(SpriteFont font, String txt, int scrHeight, int scrWidth, float scale)
        {
            float y = scrHeight - (font.MeasureString(partialtxt).Y * scale);
            float x = (scrWidth / 100) * 5;
            return new Vector2(x, y);
        }
    }
}
