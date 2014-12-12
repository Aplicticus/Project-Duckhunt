using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework;

namespace Intro_test
{
    public class TxtHandler
    {
        public String txt;
        public String partialtxt = " - ";
        public String entertxt = " - ";
        public String test = "0";
        public int nLine = 0;
        StreamReader sr;

        public enum SWITCHER { INTRO, LEVEL1, LEVEL2, LEVEL3, LEVEL4, LEVEL5, LEVEL6, LEVEL7, LEVEL8, LEVEL9, LEVEL10 }

        Char[] introChars;
        int counter = 0;

        public TxtHandler()
        {
            SWITCHER switcher = new SWITCHER();
            switcher = SWITCHER.LEVEL1;
            switch (switcher)
            {
                case SWITCHER.INTRO:
                    ReadTxt("Intro.txt");
                    break;
                case SWITCHER.LEVEL1:
                    ReadTxt("Level1.txt");
                    break;
                case SWITCHER.LEVEL2:
                    ReadTxt("Level2.txt");
                    break;
                case SWITCHER.LEVEL3:
                    ReadTxt("Level3.txt");
                    break;
                case SWITCHER.LEVEL4:
                    ReadTxt("Level4.txt");
                    break;
                case SWITCHER.LEVEL5:
                    ReadTxt("Level5.txt");
                    break;
                case SWITCHER.LEVEL6:
                    ReadTxt("Level6.txt");
                    break;
                case SWITCHER.LEVEL7:
                    ReadTxt("Level7.txt");
                    break;
                case SWITCHER.LEVEL8:
                    ReadTxt("Level8.txt");
                    break;
                case SWITCHER.LEVEL9:
                    ReadTxt("Level9.txt");
                    break;
                case SWITCHER.LEVEL10:
                    ReadTxt("Level10.txt");
                    break;
                default:
                    ReadTxt("Something went wrong.");
                    break;
            }
        }

        public String ReadTxt(string txtFile)
        {
            try
            {
                string line = string.Empty;
                using (sr = new StreamReader(txtFile))
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
            if (scrWidth >= ((font.MeasureString(entertxt).X * scale) + (strXCoor * 2)))
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