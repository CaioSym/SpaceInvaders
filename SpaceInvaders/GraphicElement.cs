using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class GraphicElement
    {
        public readonly ConsoleColor Color;
        public readonly char Character;

        public GraphicElement(ConsoleColor color, char character)
        {
            Color = color;
            Character = character;
        }
    }
}
