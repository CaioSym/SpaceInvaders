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

        public static readonly Vector2 ZERO = new Vector2(0, 0);
        public static readonly Vector2 UP = new Vector2(0, -1);
        public static readonly Vector2 Down = new Vector2(0, 1);
        public static readonly Vector2 LEFT = new Vector2(-1, 0);
        public static readonly Vector2 RIGHT = new Vector2(1, 0);

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Sum operator

        public static Vector2 operator+(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        // Scalar product operator

        public static Vector2 operator *(int lhs, Vector2 rhs)
        {
            return new Vector2(lhs*rhs.X, lhs*rhs.Y);
        }

        public static Vector2 operator *(Vector2 lhs, int rhs)
        {
            return rhs * lhs;
        }
    }
}
