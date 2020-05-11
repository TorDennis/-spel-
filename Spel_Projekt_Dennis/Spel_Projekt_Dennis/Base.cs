using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel_Projekt_Dennis
{
    class Base : PhysicalObject
    {
        public Base(Texture2D texture, float X, float Y) : base(texture, X, Y, 0f, 0f)
        {
        }

        public void Update()
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.White);
        }
    }
}
