using System;
using System.Collections.Generic;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            IfElse();
            Conditional();
            ConditionalNullCheck();
            NullCoalescing();
            ConditionalNullCheckUseMember();
            NullConditional();
            NullConditionalIndexAccess();
            ChangeNotifierOld();
            ChangeNotifierNew();
            BitwiseAnd();
            BitwiseOr();
            BitwiseXor();
            BitwiseComplement();
            BitwiseShiftLeft();
            BitwiseShiftRight();
            BitwiseMultiShift();
            BitwiseSingleShift();
            LogicalAnd();
            LogicalOr();
            LogicalXor();
            EagerOr();
            LazyOr();
            BasicAssignment();
            ShorthandAssignment();
            IncrementsAndDecrements();
        }

        private static void IfElse()
        {
            var compactMode = true;
            int itemsPerRow;

            if (compactMode)
            {
                itemsPerRow = 5;
            }
            else
            {
                itemsPerRow = 3;
            }
        }

        private static void Conditional()
        {
            var compactMode = true;
            int itemsPerRow;

            itemsPerRow = compactMode ? 5 : 3;
        }

        private static void ConditionalNullCheck()
        {
            string middleName = null;

            middleName = middleName != null ? middleName : "";
        }

        private static void NullCoalescing()
        {
            string middleName = null;

            middleName = middleName ?? "";
        }

        private static void ConditionalNullCheckUseMember()
        {
            var list = new List<int>();
            int count;

            count = list != null ? list.Count : 0;
        }

        private static void NullConditional()
        {
            var list = new List<int>();
            int count;

            count = list?.Count ?? 0;
        }

        private static void NullConditionalIndexAccess()
        {
            var list = new List<int> { 0 };

            int? firstValue = list?[0];
        }

        private static void ChangeNotifierOld()
        {
            var notifier = new ChangeNotifierOld();
            notifier.PropertyChanged += (s, e) => { };
        }

        private static void ChangeNotifierNew()
        {
            var notifier = new ChangeNotifierNew();
            notifier.PropertyChanged += (s, e) => { };
        }

        private static void BitwiseAnd()
        {
            int a = 0b00000000_00000000_00000000_00001111;
            int b = 0b00000000_00000000_00000000_01010101;

            var and = a & b; // = 0b00000000_00000000_00000000_00000101        

            Console.WriteLine(Convert.ToString(and, 2));
        }

        private static void BitwiseOr()
        {
            int a = 0b00000000_00000000_00000000_00001111;
            int b = 0b00000000_00000000_00000000_01010101;

            var or = a | b; // = 0b00000000_00000000_00000000_01011111

            Console.WriteLine(Convert.ToString(or, 2));
        }

        private static void BitwiseXor()
        {
            int a = 0b00000000_00000000_00000000_00001111;
            int b = 0b00000000_00000000_00000000_01010101;

            var xor = a ^ b; // = 0b00000000_00000000_00000000_01011010

            Console.WriteLine(Convert.ToString(xor, 2));
        }

        private static void BitwiseComplement()
        {
            int a = 0b00000000_00000000_00000000_00001111;
            int b = 0b00000000_00000000_00000000_01010101;

            var complement = ~a; // = 0b11111111_11111111_11111111_11110000

            Console.WriteLine(Convert.ToString(complement, 2));
        }

        private static void BitwiseShiftLeft()
        {
            int a = 0b00000000_00000000_00000000_00001111;

            var shiftLeft = a << 1; // = 0b00000000_00000000_00000000_00011110

            Console.WriteLine(Convert.ToString(shiftLeft, 2));
        }

        private static void BitwiseShiftRight()
        {
            int a = 0b00000000_00000000_00000000_00001111;

            var shiftRight = a >> 1; // = 0b00000000_00000000_00000000_00000111

            Console.WriteLine(Convert.ToString(shiftRight, 2));
        }

        private static void BitwiseMultiShift()
        {
            var multiShift = 0b00000000_00000000_00000000_00000001;
            for (int i = 0; i < 32; i++)
            {
                multiShift = multiShift << 1;
            }

            Console.WriteLine(Convert.ToString(multiShift, 2));
        }

        private static void BitwiseSingleShift()
        {
            var singleShift = 0b1 << 32; // = 0b1

            Console.WriteLine(Convert.ToString(singleShift, 2));
        }

        private static void LogicalAnd()
        {
            var a = true;
            var b = false;
            var and = a & b; // = false
        }

        private static void LogicalOr()
        {
            var a = true;
            var b = false;
            var or = a | b; // = true
        }

        private static void LogicalXor()
        {
            var a = true;
            var b = false;
            var xor = a | b; // = true
        }

        private static void EagerOr()
        {
            bool invoked = false;

            bool IsOdd(int n)
            {
                invoked = true;
                return n % 2 == 1;
            }

            var eager = true | IsOdd(1); // IsOdd will be invoked
        }

        private static void LazyOr()
        {
            bool invoked = false;

            bool IsOdd(int n)
            {
                invoked = true;
                return n % 2 == 1;
            }

            var lazy = true || IsOdd(1); // IsOdd won't be invoked
        }

        private static void BasicAssignment()
        {
            var a = 1;
            var b = 2;

            a = a + b; // basic syntax
        }

        private static void ShorthandAssignment()
        {
            var a = 1;
            var b = 2;

            a += b; // shorthand syntax
        }

        private static void IncrementsAndDecrements()
        {
            var n = 1;
            var prefixIncrement = ++n; // = 2, n = 2
            var prefixDecrement = --n; // = 1, n = 1
            var postfixIncrement = n++; // = 1, n = 2
            var postfixDecrement = n--; // = 2, n = 1
        }
    }
}
