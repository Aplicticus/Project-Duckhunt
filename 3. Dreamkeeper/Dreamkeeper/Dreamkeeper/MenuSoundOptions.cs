using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Dreamkeeper
{
    public class MenuSoundOptions : Screen
    {
        [Serializable]
        public struct SoundOptions
        {
            public int Volume;
        }

        private EventHandler<SwitchEventArgs> theScreenEvent;
        private Texture2D background;
        private MouseState oldState;
        private SpriteFont font;

        // Buttons
        private Button btnMasterVolumeDescrease;
        private Button btnMasterVolumeIncrease;
        private Button btnBack;

        public SoundOptions soundOptions;
        private string SavegamePath;
        public FileStream dataStream;

         public MenuSoundOptions(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("MenuBG");

            font = theContent.Load<SpriteFont>("MenuFont");

            // Buttons
            btnMasterVolumeDescrease = new Button(font, "<", Color.Black, new Vector2(300, 100));
            btnMasterVolumeIncrease = new Button(font, ">", Color.Black, new Vector2(360, 100));
            btnBack = new Button(font, "Terug", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));

            String dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dreamkeeper");
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            if (!directory.Exists)
                directory.Create(); //so no exception rises when you try to access your game file

            this.SavegamePath = Path.Combine(dirPath, "SoundOptions.xml");
            if (!File.Exists(SavegamePath))
                CreateData();
            LoadData();

            MediaPlayer.Volume = (float)soundOptions.Volume;
        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnMasterVolumeDescrease.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                MediaPlayer.Volume -= 0.1f;

            if (btnMasterVolumeIncrease.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                MediaPlayer.Volume += 0.1f;

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                ReloadContent();
                ApplyChanges();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.OPTIONS));
            }

            oldState = newState;

            // Change objects to resolution
            btnMasterVolumeDescrease = new Button(font, "<", (btnMasterVolumeDescrease.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3 + 300, 100));
            btnMasterVolumeIncrease = new Button(font, ">", (btnMasterVolumeIncrease.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3 + 360, 100));
            btnBack = new Button(font, "Terug", (btnBack.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3 , 140));

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            // Text
            theBatch.DrawString(font, "Volume", new Vector2(graphics.PreferredBackBufferWidth / 3, 100), Color.Black);
            theBatch.DrawString(font, Math.Round(MediaPlayer.Volume * 10).ToString(), new Vector2(graphics.PreferredBackBufferWidth / 3 + 320, 100), Color.Black);

            //Buttons
            btnMasterVolumeDescrease.Draw(theBatch);
            btnMasterVolumeIncrease.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }
        private void ApplyChanges()
        {
            soundOptions.Volume = (int)MediaPlayer.Volume;
            dataStream = File.Open(SavegamePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(SoundOptions));
            serializer.Serialize(dataStream, soundOptions);
            dataStream.Close();
        }
        public void CreateData()
        {
            soundOptions.Volume = 10;
            dataStream = File.Create(SavegamePath);
            XmlSerializer serializer = new XmlSerializer(typeof(SoundOptions));
            serializer.Serialize(dataStream, soundOptions);
            dataStream.Close();
        }
        public void LoadData()
        {
            dataStream = File.Open(SavegamePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(SoundOptions));
            soundOptions = (SoundOptions)serializer.Deserialize(dataStream);
            dataStream.Close();
        }
    }
}
