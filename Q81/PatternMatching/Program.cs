using System;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            IWeapon weapon = new Sword { Durability = 100 };
            IEnemy enemy = new Enemy();

            {
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
            }

            {
                if (weapon is Sword sword)
                {
                    if (sword.Durability > 0)
                    {
                        enemy.Health -= sword.Damage;
                        sword.Durability--;
                    }
                }
                else if (weapon is Bow bow)
                {
                    if (bow.Arrows > 0)
                    {
                        enemy.Health -= bow.Damage;
                        bow.Arrows--;
                    }
                }
            }

            {
                if (!(weapon is Bow bow))
                {
                    // bow variable is not initialized
                }
            }

            {
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
            }

            {
                switch (weapon)
                {
                    default:
                        throw new ArgumentException($"Unsupported weapon type {weapon.GetType()}", nameof(weapon));
                    case Sword sword when sword.Durability > 0:
                        enemy.Health -= sword.Damage;
                        sword.Durability--;
                        break;
                    case Bow bow when bow.Arrows > 0:
                        enemy.Health -= bow.Damage;
                        bow.Arrows--;
                        break;
                }
            }

            {
                switch (weapon)
                {
                    default:
                        throw new ArgumentException($"Unsupported weapon type {weapon.GetType()}", nameof(weapon));
                    case Sword sword when sword.Durability > 0:
                        enemy.Health -= sword.Damage;
                        sword.Durability--;
                        break;
                    case Bow bow when bow.Arrows > 0:
                        enemy.Health -= bow.Damage;
                        bow.Arrows--;
                        break;
                    case null:
                        break;
                }
            }
        }
    }
}
