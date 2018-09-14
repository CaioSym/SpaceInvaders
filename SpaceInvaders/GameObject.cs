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

        public GameObject(Vector2 position, GraphicElement graphics)
        {
            Position = position;
            Graphics = graphics;
        }


    }
}
