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
            gameObjects.Add(new GameObject(new Vector2(0, 0),
                            new GraphicElement(ConsoleColor.Blue, 'x')));
        }

        private static void Update()
        {
            gameObjects[0].Position += new Vector2(1, 0);
        }

        private static void Draw()
        {
            Console.Clear();
            foreach (var obj in gameObjects)
            {
                GraphicElement graphics = obj.Graphics;
                
                // Skip drawing if object has no graphics
                if (graphics == null) { continue; }

                // Skip drawing if object is positioned out of bounds
                if (obj.Position.X < 0 || obj.Position.X >= Console.BufferWidth) { continue; }
                if (obj.Position.Y < 0 || obj.Position.Y >= Console.BufferHeight) { continue; }

                Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                Console.ForegroundColor = graphics.Color;
                Console.Write(graphics.Character);
            }
        }
    }
}
