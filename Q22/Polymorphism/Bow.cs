namespace Polymorphism
{
    class Bow : IWeapon
    {
        public int Damage { get; set; }
        public int Arrows { get; set; }

        public void Attack(IEnemy enemy)
        {
            if (Arrows > 0)
            {
                enemy.Health -= Damage;
                Arrows--;
            }
        }

        public void Repair()
        { }
    }

}
