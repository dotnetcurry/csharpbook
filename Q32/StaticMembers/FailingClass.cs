using System;

namespace StaticMembers
{
    public class FailingClass
    {
        static FailingClass()
        {
            if (Config.ThrowException)
            {
                throw new InvalidOperationException();
            }
        }
    }

}
