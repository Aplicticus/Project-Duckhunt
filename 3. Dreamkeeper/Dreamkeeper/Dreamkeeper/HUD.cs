using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Dreamkeeper
{
    public class HUD
    {
        #region Variables
        private Texture2D texture { get; set; }
        private GraphicsDeviceManager graphics;
        private ContentManager content;
        private Vector2 position;
        private float width;
        private float height;

        // Arrays & Lists
        private Texture2D[] textures = new Texture2D[15];
        private List<HUD> huds = new List<HUD>();
        private List<Vector2> vectors = new List<Vector2>();
        private List<float> floatsW = new List<float>();
        private List<float> floatsH = new List<float>();              

        // Timeline Variables
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

        #region Initialize
        private void Initialize()
        {
            // Call Methods
            LoadContent();
            Calculate();

            // Fill in lists
            // Vectors
            vectors.Add(new Vector2(position.X / 28f, position.Y / 1.265f)); // Cloud PosX/PosY
            vectors.Add(new Vector2(position.X / 3f, position.Y / 1.265f)); // TimeLine PosX/PosY
            vectors.Add(new Vector2(position.X / 3f, position.Y / 1.085f)); // TimePointer PosX/PosY
            vectors.Add(new Vector2(0, 0)); // Background PosX/PosY

            // FloatsWidth
            floatsW.Add(width / 5f); // Cloud Width
            floatsW.Add(width / 2.5f); // TimeLine Width
            floatsW.Add(width / 95f); // TimePointer Width
            floatsW.Add(width); // Background Width
            
            // FloatsHeight
            floatsH.Add(height / 6f); // Cloud Height
            floatsH.Add(height / 6f); // Timeline Height
            floatsH.Add(height / 25f); // TimePointer Height 
            floatsH.Add(height); // Background Height

            // Huds
            huds.Add(new HUD(textures[3], new Vector2(vectors[3].X, vectors[3].Y), floatsW[3], floatsH[3])); // Background
            huds.Add(new HUD(textures[0], new Vector2(vectors[0].X, vectors[0].Y), floatsW[0], floatsH[0])); // Cloud
            huds.Add(new HUD(textures[1], new Vector2(vectors[1].X, vectors[1].Y), floatsW[1], floatsH[1])); // TimeLine
            huds.Add(new HUD(textures[2], new Vector2(vectors[2].X, vectors[2].Y), floatsW[2], floatsH[2])); // TimePointer  

            // Endpoint of TimePointer
            posEndXTimePointer = huds[2].position.X + huds[2].width / 1.015f; 
        }
        #endregion

        #region Calculate
        private void Calculate()
        {
            position.X = graphics.PreferredBackBufferWidth; // PositionX = Full ScreenWidth
            position.Y = graphics.PreferredBackBufferHeight; // PositionY = Full ScreenHeight
            width = graphics.PreferredBackBufferWidth; // Width = Full ScreenWidth
            height = graphics.PreferredBackBufferHeight; // Height = Full ScreenHeight
        }
        #endregion

        #region LoadContent
        private void LoadContent()
        {
            textures[0] = content.Load<Texture2D>("cloud"); // Cloud Texture
            textures[1] = content.Load<Texture2D>("HUD_Timeline"); // Timeline Texture
            textures[2] = content.Load<Texture2D>("HUD_TimePointer"); // TimePointer Texture
            textures[3] = content.Load<Texture2D>("DreamHud"); // DreamHud Texture
        }
        #endregion

        #region Draw Methods
        public void Draw(SpriteBatch theBatch)
        {
            foreach (HUD hud in huds)
            {
                hud.DrawHUD(theBatch);
            }
        }
        private void DrawHUD(SpriteBatch theBatch)
        {
            if (texture != null)
                theBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height), Color.White); // Cast to (int).. Rectangle allows only (Int)          
        }
        #endregion

        #region Timeline Method
        public bool GetTimeState(int levelTime)
        {
            timelaps = levelTime; // 1 minute = ~5700
            time = posEndXTimePointer / timelaps;

            if (huds[3].position.X >= posEndXTimePointer)
                return true;
            else
            {
                huds[3].position.X += time;
                return false;
            }
        }
        #endregion
    }
}