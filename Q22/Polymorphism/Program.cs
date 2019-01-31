namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var enemy = new Enemy();

            PoisonedSword poisonedSword = new PoisonedSword();
            poisonedSword.Attack(enemy); // will execute PoisonedSword.Attack

            Sword sword = poisonedSword;
            sword.Attack(enemy); // will still execute PoisonedSword.Attack

            IWeapon weapon = poisonedSword;
            weapon.Attack(enemy); // will still execute PoisonedSword.Attack
        }
    }
}
