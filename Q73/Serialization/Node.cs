using System.Runtime.Serialization;

namespace Serialization
{
    [DataContract]
    public class Node<T>
    {
        [DataMember]
        public T Value { get; set; }
        [DataMember]
        public Node<T> Next { get; set; }
        [DataMember]
        public Node<T> Previous { get; set; }
    }

}
