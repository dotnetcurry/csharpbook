using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Cs8Features
{
    public class Tests
    {
        [Test]
        public void RangeFromBeginning()
        {
            Range range = 1..5;

            var array = new[] { 0, 1, 2, 3, 4, 5 };
            var subArray = array[range];

            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, subArray);
        }

        [Test]
        public void RangeFromEnd()
        {
            Range range = 1..^1;

            var array = new[] { 0, 1, 2, 3, 4, 5 };
            var subArray = array[range];

            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, subArray);
        }

        private void NullableReferenceTypesDereferencing(IWeapon? canBeNull, IWeapon cantBeNull)
        {
            canBeNull.Repair();       // warning
            cantBeNull.Repair();      // no warning
            if (canBeNull != null)
            {
                canBeNull.Repair();  // no warning
            }
        }

        [Test]
        public void NullableReferenceTypes()
        {
            IWeapon? canBeNull;
            IWeapon cantBeNull;

            canBeNull = null;       // no warning
            cantBeNull = null;      // warning
            cantBeNull = canBeNull; // warning

            Assert.Throws<NullReferenceException>(() =>
            {
                NullableReferenceTypesDereferencing(canBeNull, cantBeNull);
            });
        }

        private async IAsyncEnumerable<int> GetValuesAsync()
        {
            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }

        [Test]
        public async Task AsynchronousStreamsEnumerator()
        {
            var asyncEnumerator = GetValuesAsync().GetAsyncEnumerator();
            try
            {
                while (await asyncEnumerator.MoveNextAsync())
                {
                    var value = asyncEnumerator.Current;

                    // process value
                }
            }
            finally
            {
                await asyncEnumerator.DisposeAsync();
            }
        }

        [Test]
        public async Task AsynchronousStreamsForeach()
        {
            await foreach (var value in GetValuesAsync())
            {
                // process value
            }
        }
    }
}