using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Program
    {
        private static ConsoleKeyInfo keyPressed;

        static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                keyPressed = Console.ReadKey(true);
                Update();
                Draw();
            }
        }

        private static void Initialize()
        {
            // Add the player
            GameObjectManager.Instance.Create(new Player(new Vector2(22, 20)));

            // Add theinvaders
            GameObjectManager.Instance.Create(new Invader(new Vector2(10, 0)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(16, 0)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(22, 0)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(28, 0)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(34, 0)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(13, 3)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(19, 3)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(25, 3)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(31, 3)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(10, 6)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(16, 6)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(22, 6)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(28, 6)));
            GameObjectManager.Instance.Create(new Invader(new Vector2(34, 6)));

        }

        private static void Update()
        {
            // Hack to feed key presses into player
            ((Player)GameObjectManager.Instance.GameObjects[0]).HandleKeyPressed(keyPressed.Key);

            GameObjectManager.Instance.GameObjects.ForEach((obj) => {
                obj.OnUpdate();
            });
        }

        private static void Draw()
        {
            Console.Clear();

            GameObjectManager.Instance.GameObjects.ForEach((obj) => {
                GraphicElement graphics = obj.Graphics;

                // Skip drawing if object has no graphics
                if (graphics == null) { return; }

                // Skip drawing if object is positioned out of bounds
                if (obj.Position.X < 0 || obj.Position.X >= Console.BufferWidth) { return; }
                if (obj.Position.Y < 0 || obj.Position.Y >= Console.BufferHeight) { return; }

                Console.ForegroundColor = graphics.Color;
                // Draw each char in the GraphicObject´s char matrix
                for (int ii = 0, ww = graphics.Characters.GetLength(0); ii < ww; ii++)
                {
                    for (int jj = 0, hh = graphics.Characters.GetLength(1); jj < hh; jj++)
                    {
                        Vector2 pos = obj.Position + new Vector2(ii, jj);
                        Console.SetCursorPosition(pos.X, pos.Y);
                        Console.Write(graphics.Characters[ii, jj]);
                    }

                }
            });
        }
    }
}
