using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Invader : GameObject
    {
        private const int MOVE_COUNT = 10;

        private int moveCounter = MOVE_COUNT;
        private Vector2 moveDirection = Vector2.RIGHT;
        private int speed = 1;

        private Animation animation = new Animation(new [] {
            new GraphicElement(ConsoleColor.Green, 'V'),
            new GraphicElement(ConsoleColor.Green, 'W')
        });

        public Invader(Vector2 position) : base(position, null)
        {
            Graphics = animation.NextGraphicElement();
        }

        public override void OnUpdate()
        {
            Move();
            Graphics = animation.NextGraphicElement();
        }

        private void Move()
        {
            if (--moveCounter == 0)
            {
                moveCounter = MOVE_COUNT;
                moveDirection *= -1;
                Position += Vector2.Down;
            }
            Position += speed * moveDirection;
        }


    }
}
