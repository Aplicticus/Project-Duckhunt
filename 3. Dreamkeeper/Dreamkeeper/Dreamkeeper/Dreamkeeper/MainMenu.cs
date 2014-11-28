using System;
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

namespace Dreamkeeper
{
    class MainMenu : Screen
    {
        //Load content here
        public MainMenu(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent)
        {
        }
        public override void Update(GameTime theTime)
        {
            //Update logic

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            //Draw logic

            base.Draw(theBatch);
        }
    }
}
