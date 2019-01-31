using System;
using System.Collections.Generic;
using System.Linq;

namespace Discards
{
    class Program
    {
        private static readonly List<IWeapon> weapons = new List<IWeapon>()
        {
            new Sword { Weight = 5 },
            new Bow { Weight = 3 }
        };

        private static readonly IWeapon weapon = new Sword();
        private static readonly string input = string.Empty;
        private static readonly int[] numbers = new[] { 5, 4, 3, 2, 1 };

        static void Main(string[] args)
        {
            TupleDeconstructionThrowAway();
            TupleDeconstructionDiscard();
            ObjectDeconstructionDiscard();
            PatternMatchingDiscard();
            OutVariableDiscard();
            UnderscoreAsLocalVariable();
            LocalVariableConflict();
        }

        private static (int weight, int count) Stocktake(IEnumerable<IWeapon> weapons)
        {
            var weight = 0;
            var count = 0;
            foreach (var weapon in weapons)
            {
                weight += weapon.Weight;
                count++;
            }
            return (weight, count);
        }

        private static void TupleDeconstructionThrowAway()
        {
            var (weight, count) = Stocktake(weapons);
            Console.WriteLine($"Inventory weight: {weight}");
        }

        private static void TupleDeconstructionDiscard()
        {
            var (weight, _) = Stocktake(weapons);
            Console.WriteLine($"Inventory weight: {weight}");

            // doesn't compile
            // Console.WriteLine(_);
        }

        private static void ObjectDeconstructionDiscard()
        {
            var person = new Person() { FirstName = "John", LastName = "Doe", Age = 42 };
            var (name, _, _) = person;
            Console.WriteLine($"{name}");
        }

        private static void PatternMatchingDiscard()
        {
            switch (weapon)
            {
                case Bow bow:
                    Console.WriteLine($"It's a bow with {bow.Arrows} arrows left.");
                    break;
                case Sword _:
                    Console.WriteLine("It's a sword.");
                    break;
                default:
                    Console.WriteLine("It's an unrecognized weapon.");
                    break;
            }
        }

        private static void OutVariableDiscard()
        {
            var isNumber = Int32.TryParse(input, out _);
        }

        private static void UnderscoreAsLocalVariable()
        {
            var validNumbers = numbers.Where(_ => _ > 3).ToArray();
        }

        private static void LocalVariableConflict()
        {
            var numbers = new[] { "4", "3", "Two", "1", "0" };

            var validNumbers = numbers.Where((number, _) =>
            {
                if (Int32.TryParse(number, out _))
                {
                    Console.Write(_);
                    return true;
                }
                return false;
            }).ToArray();
        }
    }
}
