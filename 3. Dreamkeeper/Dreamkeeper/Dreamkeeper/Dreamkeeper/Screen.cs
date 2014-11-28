﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dreamkeeper
{
    class Screen
    {
        //The event associated with the Screen. This event is used to raise events
        //back in the main game class to notify the game that something has changed
        //or needs to be changed
        protected EventHandler ScreenEvent;
        GraphicsDeviceManager graphics;

        public Screen(EventHandler theScreenEvent)
        {
            ScreenEvent = theScreenEvent;
        }

        public Screen(EventHandler theScreenEvent, GraphicsDeviceManager graphics)
        {
            ScreenEvent = theScreenEvent;
            this.graphics = graphics;
        }

        //Update any information specific to the screen
        public virtual void Update(GameTime theTime)
        {
        }

        //Draw any objects specific to the screen
        public virtual void Draw(SpriteBatch theBatch)
        {
        }
    }
}
