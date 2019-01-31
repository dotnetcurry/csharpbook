using NUnit.Framework;
using System;

namespace ValuesByReference
{
    public class Tests
    {
        [Test]
        public void LocalVariableByReference()
        {
            var terrain = Terrain.Get();

            // assign a return value by reference to a local variable by reference
            ref TerrainType terrainType = ref terrain.GetAt(4, 2);
            // check the local variable
            Assert.AreEqual(TerrainType.Grass, terrainType);

            // modify enum value at the original location
            terrain.BurnAt(4, 2);
            // local value was also affected
            Assert.AreEqual(TerrainType.Dirt, terrainType);
        }

        [Test]
        public void TernaryOperator()
        {
            var a = 1;
            var b = 2;

            var max = a > b ? a : b;

            Assert.AreEqual(2, max);
        }

        [Test]
        public void ReassignReference()
        {
            var a = 1;
            var b = 2;

            ref var max = ref b; // requires initialization
            if (a > b)
            {
                max = ref a;     // not allowed in C# 7.2
            }
        }

        ref T BindConditionally<T>(bool condition, ref T trueExpression, ref T falseExpression)
        {
            if (condition)
            {
                return ref trueExpression;
            }
            else
            {
                return ref falseExpression;
            }
        }

        [Test]
        public void ReassignReferenceWithHelper()
        {
            var a = 1;
            var b = 2;

            // method call
            ref var max = ref BindConditionally(a > b, ref a, ref b);

            Assert.AreEqual(2, max);
        }

        [Test]
        public void FailedReassignReferenceWithHelper()
        {
            var emptyArray = new int[] { };
            var nonEmptyArray = new[] { 1 };

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ref var firstItem = ref BindConditionally(emptyArray.Length > 0, ref emptyArray[0], ref nonEmptyArray[0]);
            });
        }

        [Test]
        public void ConditionalRefExpression()
        {
            var emptyArray = new int[] { };
            var nonEmptyArray = new[] { 1 };

            ref var firstItem = ref (emptyArray.Length > 0 ? ref emptyArray[0] : ref nonEmptyArray[0]);

            Assert.AreEqual(1, firstItem);
        }

        Vector3 Normalize(in Vector3 value)
        {
            // returns a new unit vector from the specified vector
            // signature ensures that the input vector cannot be modified

            // value.X = 5; // will not compile
            value.Scale(2); // will be invoked on a copy to not modify value

            // calculate normalized vector
            return value;
        }

        [Test]
        public void ReadOnlyByReference()
        {
            Assert.DoesNotThrow(() =>
            {
                var result = Normalize(new Vector3(1, 1, 1));
            });
        }

        [Test]
        public void ReturnReadOnlyByReference()
        {
            ref readonly var zero = ref Vector3.Zero;
            // zero.X = 1; // will not compile
            var copy = zero;
            copy.X = 1;
        }

        [Test]
        public void ProcessSubArrayInPlace()
        {
            var array = new[] { 1, 2, 3, 4, 5 }; // initialize array
            Span<int> span = array; // implicit cast
            var subSpan = span.Slice(start: 1, length: 3); // reference part of the array
            (subSpan[0], subSpan[2]) = (subSpan[2], subSpan[0]); // swap items    

            CollectionAssert.AreEqual(new[] { 1, 4, 3, 2, 5 }, array);
        }
    }
}