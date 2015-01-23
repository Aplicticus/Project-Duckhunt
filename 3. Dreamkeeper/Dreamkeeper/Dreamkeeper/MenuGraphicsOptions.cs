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

namespace Dreamkeeper
{
    public class MenuGraphicsOptions : Screen
    {
        [Serializable]
        public struct GraphicsOptions
        {
            public int Height;
            public int Width;
            public bool Fullscreen;
            public bool AntiAliasing;
            public int ClickResCount;
        }

        private EventHandler<SwitchEventArgs> theScreenEvent;
        private ContentManager content;
        private Texture2D background;
        private MouseState oldState;
        private SpriteFont font;

        // Buttons
        private Button btnResultion;
        private Button btnFullscreen;
        private Button btnAntiAliasing;
        private Button btnApply;
        private Button btnBack;

        private int clickCountResolution;

        public GraphicsOptions graphicsOptions;
        private string SavegamePath;
        public FileStream dataStream;

        public MenuGraphicsOptions(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            this.content = theContent;
            background = theContent.Load<Texture2D>("Mountains4");

            font = theContent.Load<SpriteFont>("MenuFont");
            
            String dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Dreamkeeper");
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            if (!directory.Exists)
                directory.Create(); //so no exception rises when you try to access your game file

            this.SavegamePath = Path.Combine(dirPath, "GraphicsOptions.xml");
            if (!File.Exists(SavegamePath))
                CreateData();
            else
                LoadData();

            graphics.PreferredBackBufferHeight = graphicsOptions.Height;
            graphics.PreferredBackBufferWidth = graphicsOptions.Width;
            graphics.IsFullScreen = graphicsOptions.Fullscreen;
            graphics.PreferMultiSampling = graphicsOptions.AntiAliasing;
            clickCountResolution = graphicsOptions.ClickResCount;

            // Buttons
            btnResultion = new Button(font, "Resolutie " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight, Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 100));
            btnFullscreen = new Button(font, "Volledigscherm", (graphics.IsFullScreen) ? Color.Green : Color.Red, new Vector2(graphics.PreferredBackBufferWidth / 3, 140));
            btnAntiAliasing = new Button(font, "Anti-aliasing", (graphics.PreferMultiSampling) ? Color.Green : Color.Red, new Vector2(graphics.PreferredBackBufferWidth / 3, 180));
            btnApply = new Button(font, "Toepassen", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3, 220));
            btnBack = new Button(font, "Terug", Color.Black, new Vector2(graphics.PreferredBackBufferWidth / 3 + 200, 220));


        }

        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (btnResultion.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                clickCountResolution++;

                if (clickCountResolution == 1)
                {
                    graphics.PreferredBackBufferWidth = 800;
                    graphics.PreferredBackBufferHeight = 600;
                    btnResultion.text = "Resolution " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight;
                }

                if (clickCountResolution == 2)
                {
                    graphics.PreferredBackBufferWidth = 1280;
                    graphics.PreferredBackBufferHeight = 720;
                    btnResultion.text = "Resolution " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight;
                }

                if (clickCountResolution == 3)
                {
                    graphics.PreferredBackBufferWidth = 1920;
                    graphics.PreferredBackBufferHeight = 1080;
                    clickCountResolution = 0;
                    btnResultion.text = "Resolution " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight;
                }

                //graphics.ApplyChanges();
            }

            if (btnFullscreen.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (graphics.IsFullScreen)
                    graphics.IsFullScreen = false;
                else
                    graphics.IsFullScreen = true;
                //graphics.ApplyChanges();
            }

            if (btnAntiAliasing.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                if (graphics.PreferMultiSampling)
                    graphics.PreferMultiSampling = false;
                else
                    graphics.PreferMultiSampling = true;
                //graphics.ApplyChanges();
            }

            if (btnApply.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                ApplyChanges();
                graphics.ApplyChanges();
            }

            if (btnBack.IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.OPTIONS));
            }

            oldState = newState;

            // Change objects to resolution
            btnResultion = new Button(font, "Resolutie " + graphics.PreferredBackBufferWidth + "x" + graphics.PreferredBackBufferHeight, (btnResultion.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphicsOptions.Width / 3, 100));
            btnFullscreen = new Button(font, "Volledigscherm", (graphics.IsFullScreen) ? (btnFullscreen.Hover(Mouse.GetState())) ? Color.LightGreen : Color.Green : (btnFullscreen.Hover(Mouse.GetState())) ? Color.LightSalmon : Color.Red, new Vector2(graphicsOptions.Width / 3, 140));
            btnAntiAliasing = new Button(font, "Anti-aliasing", (graphics.PreferMultiSampling) ? (btnAntiAliasing.Hover(Mouse.GetState())) ? Color.LightGreen : Color.Green : (btnAntiAliasing.Hover(Mouse.GetState())) ? Color.LightSalmon : Color.Red, new Vector2(graphicsOptions.Width / 3, 180));
            btnApply = new Button(font, "Toepassen", (btnApply.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphicsOptions.Width / 3, 220));
            btnBack = new Button(font, "Terug", (btnBack.Hover(Mouse.GetState())) ? Color.Gray : Color.Black, new Vector2(graphicsOptions.Width / 3 + 200, 220));

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphicsOptions.Width, graphicsOptions.Height), Color.White);

            //Buttons
            btnResultion.Draw(theBatch);
            btnFullscreen.Draw(theBatch);
            btnAntiAliasing.Draw(theBatch);
            btnApply.Draw(theBatch);
            btnBack.Draw(theBatch);

            base.Draw(theBatch);
        }

        private void ApplyChanges()
        {
            graphicsOptions.Height = graphics.PreferredBackBufferHeight;
            graphicsOptions.Width = graphics.PreferredBackBufferWidth;
            graphicsOptions.Fullscreen = graphics.IsFullScreen;
            graphicsOptions.AntiAliasing = graphics.PreferMultiSampling;
            graphicsOptions.ClickResCount = clickCountResolution;
            dataStream = File.Open(SavegamePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(GraphicsOptions));
            serializer.Serialize(dataStream, graphicsOptions);
            dataStream.Close();
        }
        public void CreateData()
        {
            graphicsOptions.Height = graphics.PreferredBackBufferHeight;
            graphicsOptions.Width = graphics.PreferredBackBufferWidth;
            graphicsOptions.Fullscreen = graphics.IsFullScreen;
            graphicsOptions.AntiAliasing = graphics.PreferMultiSampling;
            graphicsOptions.ClickResCount = 1;
            dataStream = File.Create(SavegamePath);
            XmlSerializer serializer = new XmlSerializer(typeof(GraphicsOptions));
            serializer.Serialize(dataStream, graphicsOptions);
            dataStream.Close();
        }
        public void LoadData()
        {
            dataStream = File.Open(SavegamePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(GraphicsOptions));
            graphicsOptions = (GraphicsOptions)serializer.Deserialize(dataStream);
            dataStream.Close();
        }
    }
}
