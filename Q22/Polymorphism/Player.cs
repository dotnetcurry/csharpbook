namespace Polymorphism
{
    class Player
    {
        public IWeapon Weapon { get; set; }

        public void Attack(IEnemy enemy)
        {
            Weapon?.Attack(enemy);
        }
    }

}
