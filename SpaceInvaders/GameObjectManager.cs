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
        public readonly Dictionary<GameObject, List<GameObject>> Collisions;

        public GameObjectManager()
        {
            GameObjects = new List<GameObject>();
            Collisions = new Dictionary<GameObject, List<GameObject>>();
        }

        public void Create(GameObject obj)
        {
            GameObjects.Add(obj);
        }

        public void ComputeCollisions()
        {
            GameObjects.ForEach(obj => {
                List<GameObject> objCollisions = new List<GameObject>();
                objCollisions.AddRange(GameObjects
                    .Where(other => !obj.Equals(other))
                    .Where(other => RectangleCollider.IsColliding(obj.Collider, obj.Position,
                        other.Collider, other.Position)));
                Collisions[obj] = objCollisions;
            });

        }
    }
}
