using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class RectangleCollider
    {
        private Vector2 topLeft;
        private Vector2 bottomRight;

        public RectangleCollider(Vector2 topLeft, Vector2 bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public Vector2[] Vertices()
        {
            return new[] {
                topLeft,
                new Vector2(bottomRight.X, topLeft.Y), //topRight
                bottomRight,
                new Vector2(topLeft.X, bottomRight.Y) //bottomLeft
        };
        }

        // Detects if colliders lhs and rhs are collinding.
        //Adjusts each collider´s position by the passed parameter when performing calculations
        public static bool IsColliding(RectangleCollider lhs, Vector2 lhsPos,
            RectangleCollider rhs, Vector2 rhsPos)
        {
            // If any of the vertices of rhs is inside lhs then we are colliding
            Vector2 actualLHSTopLeft = lhs.topLeft + lhsPos;
            Vector2 actualLHSBottomRight = lhs.bottomRight + lhsPos;
            foreach (Vector2 v in rhs.Vertices()) {
                Vector2 actualV = v + rhsPos;
                if (actualV.X >= actualLHSTopLeft.X &&
                    actualV.X <= actualLHSBottomRight.X &&
                    actualV.Y >= actualLHSTopLeft.Y &&
                    actualV.Y <= actualLHSBottomRight.Y)
                {
                    return true;
                }
            }

            // If any of the vertices of lhs is inside rhs then we are colliding
            Vector2 actualRHSTopLeft = rhs.topLeft + rhsPos;
            Vector2 actualRHSBottomRight = rhs.bottomRight + rhsPos;
            foreach (Vector2 v in lhs.Vertices())
            {
                Vector2 actualV = v + lhsPos;
                if (actualV.X >= actualRHSTopLeft.X &&
                    actualV.X <= actualRHSBottomRight.X &&
                    actualV.Y >= actualRHSTopLeft.Y &&
                    actualV.Y <= actualRHSBottomRight.Y)
                {
                    return true;
                }
            }

            // Else the two rectangles are not colliding as that would violate
            //the basic laws of geometry (assumes no rotations!)
            return false;
        }
    }
}
