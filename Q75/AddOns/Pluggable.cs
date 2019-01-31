using Contracts;
using System;

namespace AddOns
{
    public class Pluggable : IPluggable
    {
        public string GetString()
        {
            return "Dynamically loaded";
        }
    }

}
