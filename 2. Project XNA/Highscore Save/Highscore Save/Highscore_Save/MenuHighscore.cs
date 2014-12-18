using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Highscore_Save
{
    public class MenuHighscore : Screen
    {
        public EventHandler<SwitchEventArgs> theScreenEvent;
        public GraphicsDeviceManager graphics;

        public SpriteFont font;

        public Texture2D background;

        private MouseState oldState;

        private Button btnBack;

        private string SavegamePath;

        private Vector2 enter;

        private int count;

        public FileStream dataStream;

        public HighScore bestScore;

        public MenuHighscore(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Mountains4");

            enter = new Vector2(0, 40);
            count = 0;
            
            font = theContent.Load<SpriteFont>("MenuFont");

            btnBack = new Button(font, "Back", Color.White, new Vector2(graphics.PreferredBackBufferWidth - 100, graphics.PreferredBackBufferHeight - 80));

            String dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dreamkeeper");
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            if (!directory.Exists)
            {
                directory.Create(); //so no exception rises when you try to access your game file
            }

            this.SavegamePath = Path.Combine(dirPath, "Savegame.xml");
            if (!File.Exists(SavegamePath))
            {
                _highScores.Add(new HighScore() { Name = "Rudy", Score = 2000, Level = 1 });
                _highScores.Add(new HighScore() { Name = "Mathijs", Score = 9001, Level = 1 });
                _highScores.Add(new HighScore() { Name = "Tommy", Score = 1337, Level = 1 });
                CreateData();
            }

        }

        public override void Update(GameTime gameTime)
        {
            MouseState newState = Mouse.GetState();

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                var method = theScreenEvent;
                method(this, new SwitchEventArgs(0));
            }

            oldState = newState;

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            btnBack.Draw(theBatch);
            LoadData();
            foreach (HighScore highscore in _highScores)
            {
                Vector2 pos = new Vector2(100, 100);
                pos += enter * count;
                theBatch.DrawString(font, highscore.Name + "  " + highscore.Score + "  " + highscore.Level, pos, Color.Black);
                count++;
            }
            count = 0;
            base.Draw(theBatch);
        }
        [Serializable]
        public struct HighScore
        {
            public string Name;
            public int Score;
            public int Level;
        }

        public List<HighScore> _highScores = new List<HighScore>();

        public void LoadData()
        {
            dataStream = File.Open(SavegamePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
            _highScores = serializer.Deserialize(dataStream) as List<HighScore>;
            dataStream.Close();
        }
        public void AddData(string name, int score, int level)
        {
            _highScores.Add(new HighScore() { Name = name, Score = score, Level = level });
            var orderedScores = _highScores.OrderByDescending(s => s.Score);
            bestScore = orderedScores.FirstOrDefault();
            dataStream = File.Open(SavegamePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
            serializer.Serialize(dataStream, _highScores);
            dataStream.Close();
        }
        public void CreateData()
        {
            var orderedScores = _highScores.OrderByDescending(s => s.Score);
            bestScore = orderedScores.FirstOrDefault();
            dataStream = File.Create(SavegamePath);
            XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
            serializer.Serialize(dataStream, _highScores);
            dataStream.Close();
        }
        public void ClearData()
        {
            _highScores.Clear();
            dataStream = File.Open(SavegamePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
            _highScores = serializer.Deserialize(dataStream) as List<HighScore>;
            dataStream.Close();
        }
    }
}
