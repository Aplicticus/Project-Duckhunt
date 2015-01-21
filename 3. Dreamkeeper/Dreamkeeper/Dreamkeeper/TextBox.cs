using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    class TextBox
    {
        private GraphicsDevice GraphicsDevice { get; set; }
        private SpriteBatch SpriteBatch { get; set; }
        public SpriteFont SpriteFont { get; private set; }
        public string File { get; private set; }
        public string Text { get; private set; }
        public string PartialText { get; private set; }
        public Rectangle DestinationRectangle { get; set; }
        public Color Color { get; set; }
        public Vector2 TextSize { get { return SpriteFont.MeasureString(Text); } }
        public int TimeInFrames { get; private set; }
        public int TimeinSecondes { get; private set; }
        public string LastWord { get; set; }
        public float Scale { get; private set; }

        public TextBox(GraphicsDevice GraphicsDevice, SpriteBatch SpriteBatch, SpriteFont SpriteFont, string File, Rectangle DestinationRectangle, Color Color)
        {
            this.GraphicsDevice = GraphicsDevice;
            this.SpriteBatch = SpriteBatch;
            this.SpriteFont = SpriteFont;
            this.File = File;
            this.DestinationRectangle = DestinationRectangle;
            this.Color = Color;

            Text = ReadText(File);
            PartialText = "";
            LastWord = "";
            Scale = (float)Math.Sqrt((double)(DestinationRectangle.Width * (DestinationRectangle.Height * 0.8))) / (float)Math.Sqrt((double)(TextSize.X * TextSize.Y));
        }

        public void Update()
        {
            TimeInFrames++;
            if (PartialText.Contains(" "))
                LastWord = PartialText.Substring(PartialText.LastIndexOf(" "));

            if (TimeInFrames % 3 == 0 && TimeinSecondes < Text.Length)
            {
                if (PartialText.Contains("\n\r") && SpriteFont.MeasureString(PartialText.Substring(PartialText.LastIndexOf("\n\r"))).Length() * Scale >= DestinationRectangle.Width)
                    PartialText = PartialText.Substring(0, PartialText.LastIndexOf(" ")) + "\n\r" + LastWord;
                else if (!PartialText.Contains("\n\r") && SpriteFont.MeasureString(PartialText).Length() * Scale >= DestinationRectangle.Width)
                    PartialText = PartialText.Substring(0, PartialText.LastIndexOf(" ")) + "\n\r" + LastWord;

                PartialText += Text[TimeinSecondes];
                TimeinSecondes++;
            }
        }

        public void Draw()
        {
            SpriteBatch.DrawString(SpriteFont, PartialText, new Vector2(DestinationRectangle.X, DestinationRectangle.Y), Color, 0f, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }

        private string ReadText(string File)
        {
            try
            {
                using (StreamReader sr = new StreamReader(File))
                {
                    string txt = sr.ReadToEnd();
                    //txt = txt.Replace("\r\n", String.Empty);
                    return txt;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
