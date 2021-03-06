﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNA_Mathijs
{
    class Gamemode : Screen
    {
        KeyboardState oldState = new KeyboardState(Keys.Space);

        Texture2D Background;

        // Load Content here
        public Gamemode(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            Background = theContent.Load<Texture2D>("Isaac_form1");
        }
        public override void Update(GameTime theTime)
        {
            //Update logic
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
                ScreenEvent.Invoke(this, new EventArgs());
            oldState = Keyboard.GetState();

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic
            theBatch.Draw(Background, Vector2.Zero, Color.White);

            base.Draw(theBatch);
        }

    }
}
