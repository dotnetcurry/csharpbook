using System;
using System.Collections.Generic;
using System.Text;

namespace CriticalSection
{
    class BankAccount
    {
        private readonly object lockObject = new object();
        
        public decimal Balance { get; private set; }

        public BankAccount(decimal balance)
        {
            Balance = balance;
        }

        public bool WithdrawNoLock(decimal amount)
        {
            if (amount > Balance)
            {
                return false;
            }

            Balance -= amount;
            return true;
        }

        public bool WithdrawPrivateLock(decimal amount)
        {
            lock (lockObject)
            {
                if (amount > Balance)
                {
                    return false;
                }

                Balance -= amount;
                return true;
            }
        }

        public bool WithdrawPublicLock(decimal amount)
        {
            lock (this)
            {
                if (amount > Balance)
                {
                    return false;
                }

                Balance -= amount;
                return true;
            }
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}
