using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dreamkeeper
{

    public class HUD
    {
        #region Variables
        private GraphicsDeviceManager graphics;
        private ContentManager content;
        private Vector2 position;
        private Texture2D texture { get; set; }
        private float width;
        private float height;

        private Texture2D[] textures = new Texture2D[15];
        private List<HUD> huds = new List<HUD>();
        private List<Vector2> vectors = new List<Vector2>();
        private List<float> floatsW = new List<float>();
        private List<float> floatsH = new List<float>();              

        // Timeline Variable
        private float posEndXTimePointer;
        private float time { get; set; }
        private float timelaps { get; set; }
        #endregion

        #region Constructor
        public HUD(ContentManager theContent, GraphicsDeviceManager graphics)
        {
            this.content = theContent;
            this.graphics = graphics;
            Initialize();
        }
        private HUD(Texture2D texture, Vector2 position, float width, float height)
        {
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.height = height;
        }
        #endregion

        #region
        private void Initialize()
        {
            LoadContent();
            Calculate();

            vectors.Add(new Vector2(position.X / 28f, position.Y / 1.265f)); // Cloud
            vectors.Add(new Vector2(position.X / 3f, position.Y / 1.265f)); // TimeLine
            vectors.Add(new Vector2(position.X / 3f, position.Y / 1.085f)); // TimePointer

            floatsW.Add(width / 5f); // Cloud Width
            floatsW.Add(width / 2.5f); // TimeLine Width
            floatsW.Add(width / 95f); // TimePointer Width

            floatsH.Add(height / 6f); // Cloud Height
            floatsH.Add(height / 6f); // Timeline Height
            floatsH.Add(height / 25f); // TimePointer Height         

            huds.Add(new HUD(textures[0], new Vector2(vectors[0].X, vectors[0].Y), floatsW[0], floatsH[0])); // Cloud
            huds.Add(new HUD(textures[1], new Vector2(vectors[1].X, vectors[1].Y), floatsW[1], floatsH[1])); // TimeLine
            huds.Add(new HUD(textures[2], new Vector2(vectors[2].X, vectors[2].Y), floatsW[2], floatsH[2])); // TimePointer   

            posEndXTimePointer = huds[1].position.X + huds[1].width / 1.015f;
        }
        #endregion

        #region Calculate
        private void Calculate()
        {
            position.X = graphics.PreferredBackBufferWidth;
            position.Y = graphics.PreferredBackBufferHeight;
            width = graphics.PreferredBackBufferWidth;
            height = graphics.PreferredBackBufferHeight;
        }
        #endregion

        #region LoadContent
        private void LoadContent()
        {
            textures[0] = content.Load<Texture2D>("cloud");
            textures[1] = content.Load<Texture2D>("HUD_Timeline");
            textures[2] = content.Load<Texture2D>("HUD_TimePointer");
            textures[3] = content.Load<Texture2D>("DreamHud");
        }
        #endregion

        #region Draw Methods
        private void Draw(SpriteBatch theBatch)
        {
            if (texture != null)
                theBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height), Color.White);           
        }
        public void DrawHUD(SpriteBatch theBatch)
        {
            theBatch.Draw(textures[3], new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            
            foreach (HUD hud in huds)
            {
                hud.Draw(theBatch);
            }
        }
        #endregion

        #region Timeline Method
        public bool GetTimeState(int levelTime)
        {
            timelaps = levelTime; // 1 minute = ~5700
            time = posEndXTimePointer / timelaps;

            if (huds[2].position.X >= posEndXTimePointer)
                return true;
            else
            {
                huds[2].position.X += time;
                return false;
            }
        }
        #endregion
    }
}