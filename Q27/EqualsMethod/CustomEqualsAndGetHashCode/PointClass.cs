namespace EqualsMethod.CustomEqualsAndGetHashCode
{
    public class PointClass
    {
        public double X { get; set; }
        public double Y { get; set; }

        public override bool Equals(object obj)
        {
            PointClass point = obj as PointClass;
            if (point == null)
            {
                return false;
            }
            else
            {
                return X.Equals(point.X) && Y.Equals(point.Y);
            }
        }

        //public override int GetHashCode()
        //{
        //    return X.GetHashCode() ^ Y.GetHashCode();
        //}

        //public override int GetHashCode()
        //{
        //    unchecked
        //    {
        //        return 17 + X.GetHashCode() * 23;
        //    }
        //}

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
    }

}
