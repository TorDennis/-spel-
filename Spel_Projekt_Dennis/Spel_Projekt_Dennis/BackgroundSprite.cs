using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel_Projekt_Dennis
{
    class BackgroundSprite : GameObjects
    {
        public BackgroundSprite(Texture2D texture, float X, float Y) : base(texture, X, Y)
        {
        }
        public void Update(GameWindow window, int nrBackgroundsY)
        {
            vector.Y += 2f;
            if (vector.Y > window.ClientBounds.Height) vector.Y = vector.Y - nrBackgroundsY * texture.Height;
        }
    }
}
