using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace XNA_Tommy
{
    class Highscore : Screen
    {
        public EventHandler<SwitchEventArgs> theScreenEvent;
        public GraphicsDeviceManager graphics;

        public SpriteFont font;

        public Texture2D background;

        public Highscore(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Mountains4");
            
            font = theContent.Load<SpriteFont>("MenuFont");
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public struct HighScoreData
        {
            public string[] Name;
            public int[] Level;
            public int[] Score;

            public int Count;

            public HighScoreData(int count)
            {
                Name = new string[count];
                Level = new int[count];
                Score = new int[count];

                Count = count;
            }
        }

        public static void SaveHighScores(HighScoreData data, string Highscores)
        {
            // Get the path of the save game
            string fullpath = "Highscore.xml";

            // Open the file, creating it if necessary
            FileStream stream = File.Open(fullpath, FileMode.OpenOrCreate);
            try
            {
                // Convert the object to XML data and put it in the stream
                XmlSerializer serializer = new XmlSerializer(typeof(HighScoreData));
                serializer.Serialize(stream, data);
            }
            finally
            {
                // Close the file
                stream.Close();
            }
        }

        public static HighScoreData LoadHighScores(string Highscores)
        {
            HighScoreData data = new HighScoreData();

            // Get the path of the save game
            string fullpath = "Highscore.xml";

            // Open the file
            FileStream stream = File.Open(fullpath, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {

                // Read the data from the file
                Module_XML xmlreader = new Module_XML();
                xmlreader.ReadXml("Highscore.xml", "Highscore.xml");
            }
            finally
            {
                // Close the file
                stream.Close();
            }

            return (data);
        }

        public string makeHighScoreString()
        {
            // Create the data to save
            HighScoreData data2 = LoadHighScores("Highscore.xml");

            // Create scoreBoardString
            string scoreBoardString = "Highscores:\n\n";

            for (int i = 0; i<5;i++)
            {
                scoreBoardString = scoreBoardString + data2.Name[i] + "-" + data2.Score[i] + "\n";
            }
            return scoreBoardString;
        }

        //private void SaveHighScore()
        //{
        //    // Create the data to save
        //    HighScoreData data = LoadHighScores("Highscore.xml");

        //    int scoreIndex = -1;
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        if (score > data.Score[i])
        //        {
        //            scoreIndex = i;
        //            break;
        //        }
        //    }

        //    if (scoreIndex > -1)
        //    {
        //        //New high score found ... do swaps
        //        for (int i = data.Count - 1; i > scoreIndex; i--)
        //        {
        //            data.Name[i] = data.Name[i - 1];
        //            data.Score[i] = data.Score[i - 1];
        //            data.Level[i] = data.Level[i - 1];
        //        }

        //        data.Name[scoreIndex] = "Player1"; //Retrieve User Name Here
        //        data.Score[scoreIndex] = score;
        //        data.Level[scoreIndex] = currentLevel + 1;

        //        SaveHighScores(data, "Highscore.xml");
        //    }
        //}

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            theBatch.DrawString(font,"" + makeHighScoreString(),new Vector2(200,200),Color.White);
            base.Draw(theBatch);
        }
    }
}
