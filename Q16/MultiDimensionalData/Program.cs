using System;

namespace MultiDimensionalData
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleDimension();
            TwoDimensions();
            Jagged();
        }

        private static void SingleDimension()
        {
            var uninitializedArray = new int[10];
            var initializedArray = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var valueFromArray = initializedArray[0];

            Array.Resize(ref initializedArray, initializedArray.Length + 1);
        }

        private static void TwoDimensions()
        {
            var uninitialized2dArray = new int[5, 5];
            var initialized2dArray = new[,]
            {
                { 0, 1, 2, 3, 4 },
                { 1, 2, 3, 4, 5 },
                { 2, 3, 4, 5, 6 },
                { 3, 4, 5, 6, 7 },
                { 4, 5, 6, 7, 8 }
            };
            var valueFrom2dArray = initialized2dArray[0, 0];

            var totalLength = initialized2dArray.Length; //  = 25
            var dimensionsCount = initialized2dArray.Rank; // = 2
            var firstDimensionLength = initialized2dArray.GetLength(0); // = 5
            var secondDimensionLength = initialized2dArray.GetLength(1); // = 5
        }

        private static void Jagged()
        {
            var uninitializedJaggedArray = new[]
            {
                new int[5],
                new int[5],
                new int[5],
                new int[5],
                new int[5]
            };
            var initializedJaggedArray = new int[][]
            {
                new[] { 0, 1, 2, 3, 4 },
                new[] { 1, 2, 3, 4, 5 },
                new[] { 2, 3, 4, 5, 6 },
                new[] { 3, 4, 5, 6, 7 },
                new[] { 4, 5, 6, 7, 8 }
            };
            var valueFromJaggedArray = initializedJaggedArray[0][0];

            var jaggedArray = new int[][]
            {
                new[] { 0 },
                new[] { 1, 2 },
                new[] { 1, 2, 3},
                new[] { 1, 2, 3, 4 },
                new[] { 1, 2, 3, 4, 5 }
            };

            try
            {
                var nonExistentValue = jaggedArray[0][2]; // throws IndexOutOfRangeException
            }
            catch (IndexOutOfRangeException)
            { }

            var rootRank = jaggedArray.Rank; // = 1
            var rootLength = jaggedArray.Length; // = 5
            var inner0Rank = jaggedArray[0].Rank; // = 1
            var inner0Length = jaggedArray[0].Length; // = 1
            var inner1Rank = jaggedArray[1].Rank; // = 1
            var inner1Length = jaggedArray[1].Length; // = 2
        }
    }
}
