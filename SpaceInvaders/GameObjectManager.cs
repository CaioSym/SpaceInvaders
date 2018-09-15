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
        private readonly List<GameObject> toAdd;
        private readonly List<GameObject> toRemove;

        public readonly Dictionary<GameObject, List<GameObject>> Collisions;

        public GameObjectManager()
        {
            GameObjects = new List<GameObject>();
            toAdd = new List<GameObject>();
            toRemove = new List<GameObject>();

            Collisions = new Dictionary<GameObject, List<GameObject>>();
        }

        public void Create(GameObject obj)
        {
            toAdd.Add(obj);
        }

        public void Destroy(GameObject obj)
        {
            toRemove.Add(obj);
        }

        public void ExecutePendingTransactions()
        {
            toRemove.ForEach(obj => GameObjects.Remove(obj));
            toRemove.RemoveAll(_ => true);
            GameObjects.AddRange(toAdd);
            toAdd.RemoveAll(_ => true);
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
