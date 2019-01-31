namespace EqualsMethod.CustomEquals
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
    }

}
