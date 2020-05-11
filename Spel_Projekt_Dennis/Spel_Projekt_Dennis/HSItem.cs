using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel_Projekt_Dennis
{
    class HSItem
    {
        string name;
        int points;

        public string Name { get { return name; } set { name = value; } }

        public int Points { get { return points; } set { points = value; } }
        public HSItem(string name, int points)
        {
            this.name = name;
            this.points = points;
        }
    }
}
