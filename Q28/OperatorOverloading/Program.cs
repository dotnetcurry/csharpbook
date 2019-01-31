using System;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Add();
            AddReal();
            Unary();
            Comparison();
            Assignment();
            Cast();
        }

        private static void Add()
        {
            var complex1 = new ComplexNumber(2, 1);
            var complex2 = new ComplexNumber(1, 2);

            var result1 = ComplexNumber.Add(complex1, complex2); // 3+3i
            var result2 = complex1 + complex2; // 3+3i
        }

        private static void AddReal()
        {
            var complex1 = new ComplexNumber(2, 1);
            var complex = complex1 + 5; // 7+i
        }

        private static void Unary()
        {
            var complex1 = new ComplexNumber(2, 1);
            var complex = -complex1; // -2-i
        }

        private static void Comparison()
        {
            var complex1 = new ComplexNumber(2, 1);
            var complex2 = new ComplexNumber(2, 1);
            var equal = complex1 == complex2; // true

            var complex3 = new ComplexNumber(1, 2);
            var notEqual = complex1 != complex3; // true
        }

        private static void Assignment()
        {
            var complex = new ComplexNumber(2, 1);
            var complex1 = new ComplexNumber(1, 2);
            complex += complex1; // 3+3i
        }

        private static void Cast()
        {
            var complex = new ComplexNumber(2, 1);
            var real = (double)complex; // 2
            //double real = complex; // 2
        }
    }
}
