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
        public readonly char[,] Characters;

        // Single char objects get a simple 1 element matrix
        public GraphicElement(ConsoleColor color, char character) : this(color, new[,] { { character } })
        {
        }

        public GraphicElement(ConsoleColor color, char[,] characters)
        {
            Color = color;
            Characters = characters;
        }    
    }
}
