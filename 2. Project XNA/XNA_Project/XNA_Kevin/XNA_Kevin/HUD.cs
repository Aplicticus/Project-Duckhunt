using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNA_Kevin
{
    class HUD
    {
        private ContentManager content;
        private GraphicsDeviceManager graphics;
        private Texture2D texture { get; set; }
        private Vector2 position;

        private float width;
        private float height;

        List<HUD> HUDS = new List<HUD>();
        Texture2D[] Textures = new Texture2D[15];
        List<Vector2> Vectors = new List<Vector2>();


        public HUD(ContentManager content, GraphicsDeviceManager graphics)
        {
            this.content = content;
            this.graphics = graphics;
            Initialize();
        }

        public HUD(Texture2D txtr, Rectangle rect)
        {
            texture = txtr;            
            position.X = rect.X;
            position.Y = rect.Y;
            width = rect.Width;
            height = rect.Height;
        }

        // Initialize
        public void Initialize()
        {
            LoadContent();
            Calculate();
                        

            Vectors.Add(new Vector2(position.X / 5f, position.Y / 5f)); // Score
            Vectors.Add(new Vector2(position.X / 4f, position.Y / 4f));

            HUDS.Add(new HUD(Textures[0], new Rectangle((int)Vectors[0].X, (int)Vectors[0].Y, (int)width / 2, (int)height / 2)));
            HUDS.Add(new HUD(Textures[1], new Rectangle((int)Vectors[1].X, (int)Vectors[1].Y, (int)width / 2, (int)height / 2)));


        }

        private void Calculate()
        {
            position.X = graphics.PreferredBackBufferWidth;
            position.Y = graphics.PreferredBackBufferHeight;
            width = graphics.PreferredBackBufferWidth;
            height = graphics.PreferredBackBufferHeight;
            
        }

        // Load Content
        private void LoadContent()
        {
            Textures[0] = content.Load<Texture2D>("cloud"); // Score
            Textures[1] = content.Load<Texture2D>("HUD_Timeline"); // Timeline
            Textures[2] = content.Load<Texture2D>("HUD_TimePointer"); // Timepointer            
            Textures[3] = content.Load<Texture2D>("DreamHud"); // Dream ( Overlay )
        }

        // 

        #region Draw Methods
       
        private void Draw(SpriteBatch theBatch)
        {
            if (texture != null)
                theBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height), Color.White);  
        }
        public void DrawHUD(SpriteBatch theBatch)
        {            
            foreach (HUD hud in HUDS)
            {
                hud.Draw(theBatch);
            }
        }
        #endregion


    }
}
