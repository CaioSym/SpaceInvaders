using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GameObjectManager
    {
        // Singleton
        private static GameObjectManager instance;
        public static GameObjectManager Instance
        {
            get
            {
                if(instance == null) { instance = new GameObjectManager(); }
                return instance;
            }
        }   

        public readonly List<GameObject> GameObjects;

        public GameObjectManager()
        {
            GameObjects = new List<GameObject>();
        }

        public void Create(GameObject obj)
        {
            GameObjects.Add(obj);
        }
    }
}
