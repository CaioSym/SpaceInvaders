using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Player : GameObject
    {
        private static readonly GraphicElement PLAYER_GRAPHICS = new GraphicElement(ConsoleColor.Blue,
            new char[,] {
                { '<' , '/'  },
                { 'A' , 'W'  },
                { '>' , '\\' }
            });

        public Player(Vector2 position)
            : base(position, PLAYER_GRAPHICS, new RectangleCollider(Vector2.ZERO, new Vector2(2, 1)))
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

        public override void OnUpdate()
        {
            int invadersCollidedWithCount = GameObjectManager.Instance.Collisions[this]
                .Where(obj => obj is Invader)
                .Count();

            if (invadersCollidedWithCount > 0)
            {
                GameStateManager.Instance.GameState = GameState.GAME_OVER;
            }
        }

        private void Move(Vector2 direction)
        {
            Position += direction;
        }

        private void Fire()
        {
            GameObjectManager.Instance.Create(new Bullet(Position + Vector2.RIGHT, Vector2.UP, 1));
        }
    }
}
