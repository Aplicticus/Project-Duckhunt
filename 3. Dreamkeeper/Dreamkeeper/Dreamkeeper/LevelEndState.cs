using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dreamkeeper
{
    public class LevelEndState : Screen
    {
        #region Variables
        private EventHandler<SwitchEventArgs> theScreenEvent;
        private Texture2D background;
        private Vector2 position;
        private ContentManager theContent;
        private MouseState oldState;
        private SpriteFont font;

        private Texture2D[] textures = new Texture2D[15];
        private List<Button> buttons = new List<Button>();
        private List<Vector2> vectors = new List<Vector2>();
        private List<float> floatsW = new List<float>();
        private List<float> floatsH = new List<float>();

        private float width;
        private float height;
        private static bool resultState; // != static == Invalid memory
        private string resultText;
        #endregion

        #region Constructor
        public LevelEndState(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            this.theContent = theContent;
            background = theContent.Load<Texture2D>("Mountains4");
            Initialize();
        }
        #endregion

        #region Initialize
        private void Initialize()
        {
            Calculate();
            LoadContent();

            // Strings
            resultText = "Je eindscore is:";

            // FloatsW
            floatsW.Add(width / 2f); // Win Image
            floatsW.Add(width / 2f); // Lose Image
            floatsW.Add(width / 8f); // Back Button
            floatsW.Add(width / 8f); // Save Highscore Button

            // FloatsH
            floatsH.Add(height / 3f); // Win Image
            floatsH.Add(height / 3f); // Lose Image
            floatsH.Add(height / 8f); // Back Button
            floatsH.Add(height / 8f); // Save Highscore Button

            // Vectors
            vectors.Add(new Vector2(position.X / 4f, position.Y / 30f)); // Win Image
            vectors.Add(new Vector2(position.X / 4f, position.Y / 30f)); // Lose Image
            vectors.Add(new Vector2(position.X / 1.7f, position.Y / 1.9f)); // Back Button
            vectors.Add(new Vector2(position.X / 3.5f, position.Y / 1.9f)); // Save Highscore Button
            vectors.Add(new Vector2(position.X / 1.5f, position.Y / 2.5f)); // Score Result
            vectors.Add(new Vector2(position.X / 3.5f, position.Y / 2.5f)); // Score Text

            // Buttons
            buttons.Add(new Button(textures[0], new Rectangle((int)vectors[0].X, (int)vectors[0].Y, (int)floatsW[0], (int)floatsH[0]), Color.White)); // Win Image
            buttons.Add(new Button(textures[1], new Rectangle((int)vectors[1].X, (int)vectors[1].Y, (int)floatsW[1], (int)floatsH[1]), Color.White)); // Lose Image
            buttons.Add(new Button(textures[2], new Rectangle((int)vectors[2].X, (int)vectors[2].Y, (int)floatsW[2], (int)floatsH[2]), Color.White)); // Back Button
            buttons.Add(new Button(textures[3], new Rectangle((int)vectors[3].X, (int)vectors[3].Y, (int)floatsW[3], (int)floatsH[3]), Color.White)); // Save Highscore Button               
        }
        #endregion

        #region LoadContent
        private void LoadContent()
        {
            textures[0] = theContent.Load<Texture2D>("Gewonnen");
            textures[1] = theContent.Load<Texture2D>("Verloren");
            textures[2] = theContent.Load<Texture2D>("Gewonnen"); // Missing Texture
            textures[3] = theContent.Load<Texture2D>("Gewonnen"); // Missing Texture

            font = theContent.Load<SpriteFont>("MenuFont");
        }
        #endregion

        #region Update
        public override void Update(GameTime theTime)
        {
            //Update logic
            MouseState newState = Mouse.GetState();

            if (buttons[2].IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                Program.game.score = 0;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.MAIN));
            }

            // Highscore is not programmed yet ( missing highscore save )
            if (buttons[3].IsClicked(newState) && oldState.LeftButton == ButtonState.Released)
            {
                // Add code saving highscore
                Program.game.score = 0;
                ReloadContent();
                var method = theScreenEvent;
                method(this, new SwitchEventArgs((int)Stateswitch.HIGHSCORE));
            }

            oldState = newState;

            base.Update(theTime);
        }
        #endregion

        #region Draw Methods
        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            if (background != null)
            {
                theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            }

            switch (resultState)
            {
                case true:
                    buttons[0].Draw(theBatch);                    
                    buttons[2].Draw(theBatch);
                    buttons[3].Draw(theBatch);
                    theBatch.DrawString(font, Program.game.score.ToString(), new Vector2(vectors[4].X, vectors[4].Y), Color.Black);
                    theBatch.DrawString(font, resultText, new Vector2(vectors[5].X, vectors[5].Y), Color.Black);
                    break;
                case false:
                    buttons[1].Draw(theBatch);
                    buttons[2].Draw(theBatch);
                    buttons[3].Draw(theBatch);
                    theBatch.DrawString(font, Program.game.score.ToString(), new Vector2(vectors[4].X, vectors[4].Y), Color.Black);
                    theBatch.DrawString(font, resultText, new Vector2(vectors[5].X, vectors[5].Y), Color.Black);
                    break;
                default:
                    break;
            }
            base.Draw(theBatch);
        }
        #endregion

        #region Setters
        public void SetResultState(bool result)
        {
            resultState = result;
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
    }
}
