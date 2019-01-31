using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple();
            ValueTuple();
            ValueTupleReturnValue();
            Deconstruct();
        }

        private static void Tuple()
        {
            var weapons = new List<IWeapon>();

            var inventory = StocktakeTuple(weapons);
            Console.WriteLine($"Inventory weight: {inventory.Item1}, item count: {inventory.Item2}");
        }

        private static Tuple<int, int> StocktakeTuple(IEnumerable<IWeapon> weapons)
        {
            var weight = 0;
            var count = 0;
            foreach (var weapon in weapons)
            {
                weight += weapon.Weight;
                count++;
            }
            return new Tuple<int, int>(weight, count);
        }

        private static void ValueTuple()
        {
            var weapons = new List<IWeapon>();

            {
                var inventory = StocktakeValueTuple(weapons);
                Console.WriteLine($"Inventory weight: {inventory.weight}, item count: {inventory.count}");

                Console.WriteLine($"Inventory weight: {inventory.Item1}, item count: {inventory.Item2}");
            }

            {
                var weight = 0;
                var count = 0;
                var inventory = (weight, count);
                foreach (var weapon in weapons)
                {
                    inventory.weight += weapon.Weight;
                    inventory.count++;
                }
            }

            {
                var inventory = (weight: 0, count: 0);
            }

            {
                var (weight, count) = StocktakeValueTuple(weapons);
                Console.WriteLine($"Inventory weight: {weight}, item count: {count}");
            }

        }

        private static (int weight, int count) StocktakeValueTuple(IEnumerable<IWeapon> weapons)
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

        private static void ValueTupleReturnValue()
        {
            var persons = new List<Person>();
            var names = GetNames(persons);
        }

        private static IEnumerable<(string name, string surname)> GetNames(IEnumerable<Person> persons)
        {
            return from p in persons
                   select (p.FirstName, p.LastName);
        }


        private static void Deconstruct()
        {
            var person = new Person() { FirstName = "John", LastName = "Doe" };
            var (name, surname) = person;
        }
    }
}
