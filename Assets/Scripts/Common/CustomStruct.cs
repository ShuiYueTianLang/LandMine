using System;

namespace Jacky
{
    public class CustomStruct
    {

    }
    
    public struct IntVector2 : IEquatable<IntVector2>
    {
        public int x;
        public int y;


        public bool Equals(IntVector2 other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            return obj is IntVector2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x * 397) ^ y;
            }
        }
    }
}