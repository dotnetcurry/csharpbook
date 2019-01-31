using System;

namespace EqualsMethod.Equatable
{
    public class PointClass : IEquatable<PointClass>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public bool Equals(PointClass other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return X.Equals(other.X) && Y.Equals(other.Y);
            }
        }

        public override bool Equals(object obj)
        {
            PointClass point = obj as PointClass;
            return Equals(point);
        }

        //public override int GetHashCode()
        //{
        //    return X.GetHashCode() ^ Y.GetHashCode();
        //}

        public override int GetHashCode()
        {
            unchecked
            {
                return 17 + X.GetHashCode() * 23;
            }
        }
    }

}
