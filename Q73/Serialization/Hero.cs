using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Serialization
{
    [DataContract]
    [KnownType(typeof(Bow))]
    public class Hero
    {
        [DataMember]
        public IWeapon Weapon { get; set; }
    }
}
