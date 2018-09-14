using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Animation
    {
        private GraphicElement[] elements;
        private int currentIndex;

        public Animation(GraphicElement[] elements)
        {
            this.elements = elements;
            currentIndex = 0;
        }

        public GraphicElement NextGraphicElement()
        {
            GraphicElement element = elements[currentIndex++];
            if (currentIndex >= elements.Length) { currentIndex = 0; }
            return element;
        }
    }
}
