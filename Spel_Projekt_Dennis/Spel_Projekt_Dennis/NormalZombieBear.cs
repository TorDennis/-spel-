using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel_Projekt_Dennis
{
    class NormalZombieBear : Enemies
    {
        
        public NormalZombieBear(Texture2D texture, float X, float Y, float scale, float originX, float originY) : base(texture, X, Y, 0f, 0.3f, scale, originX, originY)
        {
        }
        public override void Update(GameWindow window)
        {
            vector.Y += speed.Y;
            vector.X += speed.X;
            if (vector.Y > window.ClientBounds.Height - texture.Height - 200)
            {
                speed.Y = 0;
                speed.X = 0;
            }
            else
            {
                _scale += 0.015f;
                speed.X = -0.5f;
            }


        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, new Rectangle(0,0, Convert.ToInt32(Width), Convert.ToInt32(Height)), Color.White, 0f, _origin, _scale, SpriteEffects.None, 0f);
        }
        
        
    }
}
