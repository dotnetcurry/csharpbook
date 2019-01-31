using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadSynchronization
{
    class BankAccount
    {
        private readonly int timeout = 100;
        private readonly object lockObject = new object();

        public decimal Balance { get; private set; }

        public bool WithdrawLock(decimal amount)
        {
            lock (lockObject)
            {
                if (amount > Balance) // check available amounts
                {
                    return false;
                }

                Balance -= amount; // withdraw money
                return true;
            }
        }

        public bool WithdrawMonitor(decimal amount)
        {
            var lockAcquired = false;
            try
            {
                Monitor.Enter(lockObject, ref lockAcquired);

                if (amount > Balance)
                {
                    return false;
                }

                Balance -= amount;
                return true;
            }
            finally
            {
                if (lockAcquired)
                {
                    Monitor.Exit(lockObject);
                }
            }
        }

        public bool WithdrawMonitorWithTimeout(decimal amount)
        {
            if (Monitor.TryEnter(lockObject, timeout))
            {
                try
                {
                    if (amount > Balance)
                    {
                        return false;
                    }

                    Balance -= amount;
                    return true;
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                // lock wasn't acquired
                return false;
            }
        }
    }
}
