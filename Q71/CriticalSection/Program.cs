using System;

namespace CriticalSection
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountA = new BankAccount(100);
            var accountB = new BankAccount(100);

            Transfer(50, accountA, accountB);
        }

        private static void Transfer(decimal amount, BankAccount from, BankAccount to)
        {
            lock (to)
            {
                from.WithdrawPublicLock(amount);
                to.Deposit(amount);
            }
        }

    }
}
