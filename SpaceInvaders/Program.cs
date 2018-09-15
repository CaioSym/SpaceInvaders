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
        private static List<GameObject> gameObjects = new List<GameObject>();
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
            gameObjects.Add(new Player(new Vector2(15, 10)));

            // Add theinvaders
            gameObjects.Add(new Invader(new Vector2(10, 0)));
            gameObjects.Add(new Invader(new Vector2(12, 0)));
            gameObjects.Add(new Invader(new Vector2(14, 0)));
            gameObjects.Add(new Invader(new Vector2(16, 0)));
            gameObjects.Add(new Invader(new Vector2(18, 0)));
            gameObjects.Add(new Invader(new Vector2(11, 1)));
            gameObjects.Add(new Invader(new Vector2(13, 1)));
            gameObjects.Add(new Invader(new Vector2(15, 1)));
            gameObjects.Add(new Invader(new Vector2(17, 1)));
            gameObjects.Add(new Invader(new Vector2(10, 2)));
            gameObjects.Add(new Invader(new Vector2(12, 2)));
            gameObjects.Add(new Invader(new Vector2(14, 2)));
            gameObjects.Add(new Invader(new Vector2(16, 2)));
            gameObjects.Add(new Invader(new Vector2(18, 2)));

        }

        private static void Update()
        {
            // Hack to feed key presses into player
            ((Player)gameObjects[0]).HandleKeyPressed(keyPressed.Key);

            gameObjects.ForEach((obj) => {
                obj.OnUpdate();
            });
        }

        private static void Draw()
        {
            Console.Clear();

            gameObjects.ForEach((obj) => {
                GraphicElement graphics = obj.Graphics;

                // Skip drawing if object has no graphics
                if (graphics == null) { return; }

                // Skip drawing if object is positioned out of bounds
                if (obj.Position.X < 0 || obj.Position.X >= Console.BufferWidth) { return; }
                if (obj.Position.Y < 0 || obj.Position.Y >= Console.BufferHeight) { return; }

                Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                Console.ForegroundColor = graphics.Color;
                Console.Write(graphics.Character);
            });
        }
    }
}
