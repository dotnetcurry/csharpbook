using System;
using System.Threading.Tasks;

namespace BestCs6Features
{
    public class AsyncResource
    {
        internal Task OpenAsync(bool throwException)
        {
            throw new NotImplementedException();
        }

        internal Task LogAsync(Exception exceptionToLog)
        {
            //throw new NotImplementedException();
            return Task.FromResult(0);
        }

        internal Task CloseAsync()
        {
            //throw new NotImplementedException();
            return Task.FromResult(0);
        }
    }
}
