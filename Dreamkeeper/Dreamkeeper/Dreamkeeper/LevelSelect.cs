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
            background = theContent.Load<Texture2D>("Mountains4");
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

            // (btnStory.Hover(Mouse.GetState())) ? Color.Gray : Color.Black

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
            textures[3] = content.Load<Texture2D>("level2wip"); // Level 2
            textures[4] = content.Load<Texture2D>("level3wip"); // Level 3
            textures[5] = content.Load<Texture2D>("level4wip"); // Level 4
            textures[6] = content.Load<Texture2D>("level5wip"); // Level 5
            textures[7] = content.Load<Texture2D>("level6wip"); // Level 6
            textures[8] = content.Load<Texture2D>("level7wip"); // Level 7
            textures[9] = content.Load<Texture2D>("level8wip"); // Level 8
            textures[10] = content.Load<Texture2D>("level9wip"); // Level 9
        }
        #endregion

        #region Update
        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();


            // Need to be Optimalised with 3 switch cases : Easy, Medium and Hard
            // Level 1
            if (btns[2].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.EASY)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL1));
            }
            else if (btns[2].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.MEDIUM)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL1));
            }
            else if (btns[2].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.HARD)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL1));
            }

            // Level 2
            if (btns[3].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.EASY)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL2));
            }
            else if (btns[3].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.MEDIUM)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL2));
            }
            else if (btns[3].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.HARD)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL2));
            }

            // Level 3
            if (btns[4].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.EASY)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL3));
            }
            else if (btns[4].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.MEDIUM)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL3));
            }
            else if (btns[4].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.HARD)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL3));
            }
            
            // Level 4
            if (btns[5].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.EASY)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL4));
            }
            else if (btns[5].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.MEDIUM)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL4));
            }
            else if (btns[5].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.HARD)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL4));
            }

            // Level 5
            if (btns[6].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.EASY)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL5));
            }
            else if (btns[6].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.MEDIUM)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL5));
            }
            else if (btns[6].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.HARD)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL5));
            }

            // Level 6
            if (btns[7].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.EASY)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL6));
            }
            else if (btns[7].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.MEDIUM)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL6));
            }
            else if (btns[7].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.HARD)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL6));
            }

            // Level 7
            if (btns[8].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.EASY)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL7));
            }
            else if (btns[8].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.MEDIUM)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL7));
            }
            else if (btns[8].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.HARD)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL7));
            }

            // Level 8
            if (btns[9].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.EASY)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL8));
            }
            else if (btns[9].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.MEDIUM)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL8));
            }
            else if (btns[9].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.HARD)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL8));
            }

            // Level 9
            if (btns[10].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.EASY)
            {
                Program.game.difficulty = Difficulty.EASY;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL9));
            }
            else if (btns[10].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.MEDIUM)
            {
                Program.game.difficulty = Difficulty.MEDIUM;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL9));
            }
            else if (btns[10].IsClicked(newState) && oldState.LeftButton == ButtonState.Released && Program.game.difficulty == Difficulty.HARD)
            {
                Program.game.difficulty = Difficulty.HARD;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.LEVEL9));
            }



            oldState = newState;
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

            foreach (Button button in btns)
            {
                button.Draw(theBatch);
            }

            base.Draw(theBatch);

        }
        #endregion
    }
}
