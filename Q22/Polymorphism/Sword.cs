namespace Polymorphism
{
    class Sword : IWeapon
    {
        public int Damage { get; set; }
        public int Durability { get; set; }

        public virtual void Attack(IEnemy enemy)
        {
            if (Durability > 0)
            {
                enemy.Health -= Damage;
                Durability--;
            }
        }

        public void Repair()
        {
            Durability += 100;
        }
    }

}
