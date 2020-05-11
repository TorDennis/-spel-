using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel_Projekt_Dennis
{
    class GameElements
    {
        static Player player;
        static List<Enemies> enemies;
        //static PrintText printText;!!!!!!!!!!!!!
        static Menu menu;
        //static Background background;!!!!!!!!!!!!
        
        public enum State { Menu, Level, EnterHighscore, Highscore, Quit };
        
        public static State currentstate;

        public static void Initialize()
        {

        }
        public static void LoadContent(ContentManager content, GameWindow window)
        {

        }
        //public static State MenuUpdate()
        //{

        //}
        //public static State RunUpdate(ContentManager content, GameWindow window, GameTime gameTime)
        //{

        //}

    }
}
