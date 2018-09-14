using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Vector2
    {
        public readonly int X;
        public readonly int Y;
    
        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator+(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }
    }
}
