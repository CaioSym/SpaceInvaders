using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GameObject
    {
        public Vector2 Position;
        public GraphicElement Graphics;
        public RectangleCollider Collider;

        public GameObject(Vector2 position, GraphicElement graphics, RectangleCollider collider)
        {
            Position = position;
            Graphics = graphics;
            Collider = collider;
        }

        public virtual void OnUpdate() {

        }
    }
}
