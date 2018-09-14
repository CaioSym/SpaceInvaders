using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Program
    {
        private static List<GameObject> gameObjects = new List<GameObject>();

        static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                Update();
                Draw();
                Console.ReadKey(true);
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
                if (graphics == null) { continue; }

                Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
                Console.ForegroundColor = graphics.Color;
                Console.Write(graphics.Character);
            }
        }
    }
}
