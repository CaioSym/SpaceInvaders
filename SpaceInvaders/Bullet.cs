using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Bullet : GameObject
    {

        private Vector2 direction;
        private int speed;

        public Bullet(Vector2 position, Vector2 direction, int speed) 
            : base(position, new GraphicElement(ConsoleColor.Red, 'o'), new RectangleCollider(Vector2.ZERO, Vector2.ZERO))
        {
            this.direction = direction;
            this.speed = speed;
        }

        public override void OnUpdate()
        {
            Position += speed * direction;
        }
    }
}
