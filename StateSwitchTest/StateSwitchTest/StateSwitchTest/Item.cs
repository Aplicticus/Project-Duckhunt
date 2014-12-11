using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateSwitchTest
{
    class Item
    {
        protected ContentManager theContent;
        protected GraphicsDevice graphics;
        protected string name;

        public Item(ContentManager theContent, GraphicsDevice graphics, string name)
        {
            this.theContent = theContent;
            this.graphics = graphics;
            this.name = name;
        }

        public Item(ContentManager theContent, GraphicsDevice graphics, string name, Texture2D texture)
        {
            this.theContent = theContent;
            this.graphics = graphics;
            this.name = name;
        }

        public virtual void Update(MouseState mouseState)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
