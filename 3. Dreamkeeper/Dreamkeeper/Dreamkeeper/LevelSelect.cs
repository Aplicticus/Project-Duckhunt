using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Dreamkeeper
{
    public class LevelSelect : Screen
    {           
         // btns[0] and btns[1] are Borders, use btns[2] to start with level 1         
        #region Variables
        // Global Variables
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private MouseState oldState;
        private ContentManager content;
        private Texture2D background { get; set; }

        // position, width, height
        private Vector2 position;
        private float width;
        private float height;

        // Array & Lists
        private Texture2D[] textures = new Texture2D[15];        
        List<Button> btns = new List<Button>();
        private List<Vector2> vectors = new List<Vector2>();
       
        // Width & Height   
        private float globalBorderWidth;
        private float globalBorderHeight;
        private float globalWidth;
        private float globalHeight;
        private float levelWidth;
        private float levelHeight;
        #endregion

        #region Constructors
        public LevelSelect(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base (theScreenEvent, graphics)
        {
            this.content = theContent;
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("LvlSelectBG");
            Initialize();

        }                     
        #endregion

        #region Initialize
        private void Initialize()
        {
            LoadContent();
            Calculate();

            vectors.Add(new Vector2(position.X / 9f, position.Y / 9f)); // Vector 0, Global Border
            vectors.Add(new Vector2(vectors[0].X / 0.84f, vectors[0].Y / 0.85f)); // Vector1, Global
            vectors.Add(new Vector2(vectors[1].X / 0.900f, vectors[1].Y / 0.900f)); // Vector 2, level 1
            vectors.Add(new Vector2(vectors[1].X / 0.337f, vectors[1].Y / 0.900f)); // Vector 3, level 2
            vectors.Add(new Vector2(vectors[1].X / 0.208f, vectors[1].Y / 0.900f)); // Vector 4, level 3
            vectors.Add(new Vector2(vectors[1].X / 0.900f, vectors[1].Y / 0.336f)); // Vector 5, level 4
            vectors.Add(new Vector2(vectors[1].X / 0.337f, vectors[1].Y / 0.336f)); // Vector 6, level 5
            vectors.Add(new Vector2(vectors[1].X / 0.208f, vectors[1].Y / 0.336f)); // Vector 7, level 6
            vectors.Add(new Vector2(vectors[1].X / 0.900f, vectors[1].Y / 0.206f)); // Vector 8, level 7
            vectors.Add(new Vector2(vectors[1].X / 0.337f, vectors[1].Y / 0.206f)); // Vector 9, level 8
            vectors.Add(new Vector2(vectors[1].X / 0.208f, vectors[1].Y / 0.206f)); // Vector 10, level 9

            btns.Add(new Button(textures[0], new Rectangle((int)vectors[0].X, (int)vectors[0].Y, (int)globalBorderWidth, (int)globalBorderHeight), Color.White)); // Global Border
            btns.Add(new Button(textures[1], new Rectangle((int)vectors[1].X, (int)vectors[1].Y, (int)globalWidth, (int)globalHeight), Color.White)); // Global
            btns.Add(new Button(textures[2], new Rectangle((int)vectors[2].X, (int)vectors[2].Y, (int)levelWidth, (int)levelHeight), Color.White)); // Level 1
            btns.Add(new Button(textures[3], new Rectangle((int)vectors[3].X, (int)vectors[3].Y, (int)levelWidth, (int)levelHeight), Color.White)); // Level 2
            btns.Add(new Button(textures[4], new Rectangle((int)vectors[4].X, (int)vectors[4].Y, (int)levelWidth, (int)levelHeight), Color.White)); // Level 3
            btns.Add(new Button(textures[5], new Rectangle((int)vectors[5].X, (int)vectors[5].Y, (int)levelWidth, (int)levelHeight), Color.White)); // Level 4
            btns.Add(new Button(textures[6], new Rectangle((int)vectors[6].X, (int)vectors[6].Y, (int)levelWidth, (int)levelHeight), Color.White)); // Level 5
            btns.Add(new Button(textures[7], new Rectangle((int)vectors[7].X, (int)vectors[7].Y, (int)levelWidth, (int)levelHeight), Color.White)); // Level 6
            btns.Add(new Button(textures[8], new Rectangle((int)vectors[8].X, (int)vectors[8].Y, (int)levelWidth, (int)levelHeight), Color.White)); // Level 7
            btns.Add(new Button(textures[9], new Rectangle((int)vectors[9].X, (int)vectors[9].Y, (int)levelWidth, (int)levelHeight), Color.White)); // Level 8
            btns.Add(new Button(textures[10], new Rectangle((int)vectors[10].X, (int)vectors[10].Y, (int)levelWidth, (int)levelHeight), Color.White)); // Level 9
        }
        #endregion

        #region Load Content
        private void LoadContent()
        {
            textures[0] = content.Load<Texture2D>("missingTextureWhite"); // Global Border
            textures[1] = content.Load<Texture2D>("missingTextureBlack"); // Global
            textures[2] = content.Load<Texture2D>("level1"); // Level 1
            textures[3] = content.Load<Texture2D>("level2"); // Level 2
            textures[4] = content.Load<Texture2D>("level3wip"); // Level 3
            textures[5] = content.Load<Texture2D>("level4"); // Level 4
            textures[6] = content.Load<Texture2D>("level5"); // Level 5
            textures[7] = content.Load<Texture2D>("level6"); // Level 6
            textures[8] = content.Load<Texture2D>("level7"); // Level 7
            textures[9] = content.Load<Texture2D>("level8"); // Level 8
            textures[10] = content.Load<Texture2D>("level9"); // Level 9
        }
        #endregion

        #region Update
        public override void Update(GameTime theTime)
        {
            //Update logic          
            switch(Program.game.difficulty)
            {                
                case Difficulty.EASY:
                    ClickOnLevel(Mouse.GetState());
                    break;
                case Difficulty.MEDIUM:
                    ClickOnLevel(Mouse.GetState());
                    break;
                case Difficulty.HARD:
                    ClickOnLevel(Mouse.GetState());
                    break;
                default:
                    break;
            }         
        }
        private void GetClickedLevel(int level)
        {
            var method = theScreenEvent;
            switch (level)
            {
                case 2:
                    ReloadContent();
                    method(this, new SwitchEventArgs((int)Stateswitch.INTRO1_1));
                    break;
                case 3:
                    ReloadContent();
                    method(this, new SwitchEventArgs((int)Stateswitch.INTRO2_1));
                    break;
                case 4:
                    ReloadContent();
                    method(this, new SwitchEventArgs((int)Stateswitch.INTRO3_1));
                    break;
                case 5:
                    ReloadContent();
                    method(this, new SwitchEventArgs((int)Stateswitch.INTRO4_1));
                    break;
                case 6:
                    ReloadContent();
                    method(this, new SwitchEventArgs((int)Stateswitch.INTRO5_1));
                    break;
                case 7:
                    ReloadContent();
                    method(this, new SwitchEventArgs((int)Stateswitch.INTRO6_1));
                    break;
                case 8:
                    ReloadContent();
                    method(this, new SwitchEventArgs((int)Stateswitch.INTRO7_1));
                    break;
                case 9:
                    ReloadContent();
                    method(this, new SwitchEventArgs((int)Stateswitch.INTRO8_1));
                    break;
                case 10:
                    ReloadContent();
                    method(this, new SwitchEventArgs((int)Stateswitch.INTRO9_1));
                    break;
                default:
                    break;
            }
        }
        private void ClickOnLevel(MouseState newState)
        {
            for (int i = 2; i < btns.Count; i++)
            {
                if (btns[i].IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
                {
                    GetClickedLevel(i);
                }
            }
        }       
        #endregion

        #region Calculate
        private void Calculate()
        {
            // Variable Initialize
            position.X = graphics.PreferredBackBufferWidth;
            position.Y = graphics.PreferredBackBufferHeight;
            width = graphics.PreferredBackBufferWidth;
            height = graphics.PreferredBackBufferHeight;

            // Widths
            globalBorderWidth = width / 1.3f;
            globalWidth = globalBorderWidth / 1.06f;
            levelWidth = globalWidth / 3.5f;

            // Heights
            globalBorderHeight = height / 1.3f;
            globalHeight = globalBorderHeight / 1.06f;
            levelHeight = globalHeight / 3.5f;
        }
        #endregion  

        #region Draw Methods
        private void DrawLevels(SpriteBatch theBatch)
        {
            theBatch.Draw(background, new Rectangle((int)position.X, (int)position.Y, (int)width, (int)height), Color.White);         
        }
       
        public override void Draw(SpriteBatch theBatch)
        {
            

            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            for (int i = 2; i < btns.Count; i++)
            {
                btns[i].Draw(theBatch);
            }

            base.Draw(theBatch);

        }
        #endregion
    }
}
