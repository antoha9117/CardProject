using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame.GameMod
{
    //агрегация с классом GameModBase
    class GameContext
    {
        public GameModBase Context { get; set; }

        public GameContext(GameModBase _context)
        {
            Context = _context;
        }

        public void Example()
        {
            //Context.DoSomething();
        }
    }
}
