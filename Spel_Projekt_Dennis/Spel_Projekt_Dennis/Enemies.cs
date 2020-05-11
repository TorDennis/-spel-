using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel_Projekt_Dennis
{
    abstract class Enemies : PhysicalObject
    {
        protected float _scale;
        protected Vector2 _origin;


        public Enemies(Texture2D texture, float X, float Y, float speedX, float speedY, float scale, float originX, float originY) : base(texture, X, Y, speedX, speedY)
        {
            _scale = scale;
            _origin.X = originX;
            _origin.Y = originY;
        }
        public abstract void Update(GameWindow window);

        public float originX { get { return _origin.X; } }
        public float originY { get { return _origin.Y; } }
    }
}
