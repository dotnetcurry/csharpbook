using System.Collections.Generic;
using System.Linq;

namespace CSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            After();
            Before();
        }

        private static void After()
        {
            IWeapon weapon = new Sword();
            IEnemy enemy = new Enemy();

            switch (weapon)
            {
                case Sword sword when sword.Durability > 0:
                    enemy.Health -= sword.Damage;
                    sword.Durability--;
                    break;
                case Bow bow when bow.Arrows > 0:
                    enemy.Health -= bow.Damage;
                    bow.Arrows--;
                    break;
            }

            {
                if (weapon is Sword sword)
                {
                    // from here on, the sword variable is in scope
                }
            }

            var dictionary = new Dictionary<string, string>();
            var key = "key";
            var value = SafeGetAfter(dictionary, key);

            var inventory = StocktakeAfter(new List<IWeapon>());
        }

        private static string SafeGetAfter(IDictionary<string, string> dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }
        private static (int weight, int count) StocktakeAfter(IEnumerable<IWeapon> weapons)
        {
            return (weapons.Sum(weapon => weapon.Weight), weapons.Count());
        }


        private static void Before()
        {
            IWeapon weapon = new Sword();
            IEnemy enemy = new Enemy();

            if (weapon is Sword)
            {
                var sword = weapon as Sword;
                if (sword.Durability > 0)
                {
                    enemy.Health -= sword.Damage;
                    sword.Durability--;
                }
            }
            else if (weapon is Bow)
            {
                var bow = weapon as Bow;
                if (bow.Arrows > 0)
                {
                    enemy.Health -= bow.Damage;
                    bow.Arrows--;
                }
            }

            var dictionary = new Dictionary<string, string>();
            var key = "key";
            var value = SafeGetBefore(dictionary, key);

            var inventory = StocktakeBefore(new List<IWeapon>());
        }

        private static string SafeGetBefore(IDictionary<string, string> dictionary, string key)
        {
            string value;
            if (dictionary.TryGetValue(key, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }
        private static Inventory StocktakeBefore(IEnumerable<IWeapon> weapons)
        {
            return new Inventory
            {
                Weight = weapons.Sum(weapon => weapon.Weight),
                Count = weapons.Count()
            };
        }
    }
}
