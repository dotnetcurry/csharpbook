using System.Runtime.Serialization;

namespace Serialization
{
    [DataContract]
    public class Bow : IWeapon
    {
        [DataMember]
        public int Damage { get; set; }
        [DataMember]
        public int Arrows { get; set; }
    }
}
