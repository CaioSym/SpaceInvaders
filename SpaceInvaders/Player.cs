using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Player : GameObject
    {
        public Player(Vector2 position) : base(position, new GraphicElement(ConsoleColor.Blue, 'A'))
        {
        }

        public void HandleKeyPressed(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    Move(Vector2.LEFT);
                    break;
                case ConsoleKey.D:
                    Move(Vector2.RIGHT);
                    break;
                case ConsoleKey.Enter:
                    Fire();
                    break;
                default:
                    break;
            }
        }

        private void Move(Vector2 direction)
        {
            Position += direction;
        }

        private void Fire()
        {
            GameObjectManager.Instance.Create(new Bullet(Position + Vector2.UP, Vector2.UP, 1));
        }
    }
}
