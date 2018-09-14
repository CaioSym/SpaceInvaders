using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Invader : GameObject
    {
        private int moveCounter = 4;
        private Vector2 moveDirection = Vector2.RIGHT;

        public Invader(Vector2 position) : base(position, new GraphicElement(ConsoleColor.Green, 'W'))
        {
        }

        public override void OnUpdate()
        {
            if(--moveCounter == 0)
            {
                moveCounter = 4;
                moveDirection *= -1;
            }
            Position += moveDirection;
        }

        
    }
}
