namespace Polymorphism
{
    class PoisonedSword : Sword
    {
        public override void Attack(IEnemy enemy)
        {
            if (Durability > 0)
            {
                enemy.Poisoned = true;
            }
            base.Attack(enemy);
        }
    }

}
