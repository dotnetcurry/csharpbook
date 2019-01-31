namespace Polymorphism
{
    interface IWeapon
    {
        int Damage { get; set; }
        void Attack(IEnemy enemy);
        void Repair();
    }

}
