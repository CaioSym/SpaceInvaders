using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GameStateManager
    {
        // Singleton
        private static GameStateManager instance;
        public static GameStateManager Instance
        {
            get
            {

                if (instance == null) { instance = new GameStateManager(); }
                return instance;
            }
        }

        public GameState GameState = GameState.PLAYING;
    }
}
