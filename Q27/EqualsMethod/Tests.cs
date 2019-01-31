using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void StructWithDefaultEquals()
        {
            var point1 = new EqualsMethod.NoCustomEquals.PointStruct { X = 1, Y = 2 };
            var point2 = new EqualsMethod.NoCustomEquals.PointStruct { X = 1, Y = 2 };
            Assert.IsTrue(point1.Equals(point2));
        }

        [Test]
        public void ClassWithDefaultEquals()
        {
            var point1 = new EqualsMethod.NoCustomEquals.PointClass { X = 1, Y = 2 };
            var point2 = point1;
            Assert.IsTrue(point1.Equals(point2));
        }

        [Test]
        public void ClassWithDefaultEqualsSameValue()
        {
            var point1 = new EqualsMethod.NoCustomEquals.PointClass { X = 1, Y = 2 };
            var point2 = new EqualsMethod.NoCustomEquals.PointClass { X = 1, Y = 2 };
            Assert.IsFalse(point1.Equals(point2));
        }

        [Test]
        public void ClassWithCustomEquals()
        {
            var point1 = new EqualsMethod.CustomEquals.PointClass { X = 1, Y = 2 };
            var point2 = new EqualsMethod.CustomEquals.PointClass { X = 1, Y = 2 };
            Assert.IsTrue(point1.Equals(point2));
        }

        [Test]
        public void ClassWithCustomEqualsReferenceEquals()
        {
            var point1 = new EqualsMethod.CustomEquals.PointClass { X = 1, Y = 2 };
            var point2 = new EqualsMethod.CustomEquals.PointClass { X = 1, Y = 2 };
            Assert.IsFalse(ReferenceEquals(point1, point2));

            var point3 = point1;
            Assert.IsTrue(ReferenceEquals(point1, point3));
        }

        [Test]
        public void ClassWithCustomEqualsHashSet()
        {
            var point1 = new EqualsMethod.CustomEquals.PointClass { X = 1, Y = 2 };
            var point2 = new EqualsMethod.CustomEquals.PointClass { X = 1, Y = 2 };

            // overridden Equals method returns true
            Assert.IsTrue(point1.Equals(point2));
            // default GetHashCode method returns different values
            Assert.IsFalse(point1.GetHashCode() == point2.GetHashCode());

            var set = new HashSet<EqualsMethod.CustomEquals.PointClass>();
            set.Add(point1);
            set.Add(point2);
            // HashSet adds both points because of different GetHashCode value
            Assert.IsFalse(set.Count == 1);
        }

        [Test]
        public void ClassWithCustomEqualsAndGetHashCode()
        {
            var point1 = new EqualsMethod.CustomEqualsAndGetHashCode.PointClass { X = 1, Y = 2 };
            var point2 = new EqualsMethod.CustomEqualsAndGetHashCode.PointClass { X = 1, Y = 2 };

            Assert.IsTrue(point1.Equals(point2));
            Assert.IsTrue(point1.GetHashCode() == point2.GetHashCode());

            var set = new HashSet<EqualsMethod.CustomEqualsAndGetHashCode.PointClass>();
            set.Add(point1);
            set.Add(point2);
            Assert.IsTrue(set.Count == 1);
        }

        [Test]
        public void StringBuilderDifferentEquals()
        {
            var builder1 = new StringBuilder("string");
            var builder2 = new StringBuilder("string");
            Assert.IsTrue(builder1.Equals(builder2));

            var asObject1 = (object)builder1;
            Assert.IsFalse(asObject1.Equals(builder2));
        }
    }
}