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
        private EventHandler<SwitchEventArgs> theScreenEvent;        
        private Texture2D background;

        Texture2D[] textures = new Texture2D[15];
        List<Button> buttons = new List<Button>();

        public LevelEndState(ContentManager theContent, EventHandler<SwitchEventArgs> theScreenEvent, GraphicsDeviceManager graphics)
            : base(theScreenEvent, graphics)
        {
            this.graphics = graphics;
            this.theScreenEvent = theScreenEvent;
            background = theContent.Load<Texture2D>("Mountains4");
            Initialize(theContent);
        }

        private void Initialize(ContentManager theContent)
        {
            textures[0] = theContent.Load<Texture2D>("Gewonnen");
            textures[1] = theContent.Load<Texture2D>("Verloren");
            buttons.Add(new Button(textures[0], new Rectangle(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 3, 300, 200), Color.White));
            buttons.Add(new Button(textures[1], new Rectangle(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 3, 300, 200), Color.White));
        }   

        public override void Update(GameTime theTime)
        {
            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
                       
            

            base.Draw(theBatch);
        }

            
    }
}
