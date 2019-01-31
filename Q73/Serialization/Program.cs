using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        private static readonly string path = "serialized.out";

        static void Main(string[] args)
        {
            DataContractSerialize();
            DataContractDeserialize();
            DataContractSerializeCycles();
            DataContractSerializeKnownTypes();
            XmlSerialize();
            XmlDeserialize();
            XmlSerializeWithAttributes();
            BinarySerialize();
            BinaryDeserialize();
        }

        private static void DataContractSerialize()
        {
            var person = new Person("John", "Doe", new DateTime(1990, 1, 1));

            var serializer = new DataContractSerializer(typeof(Person));

            using (var stream = File.Create(path))
            {
                serializer.WriteObject(stream, person);
            }
        }
        
        private static void DataContractDeserialize()
        {
            var serializer = new DataContractSerializer(typeof(Person));

            using (var stream = File.OpenRead(path))
            {
                var deserialized = (Person)serializer.ReadObject(stream);
            }
        }
        
        private static void DataContractSerializeCycles()
        {
            var firstNode = new Node<int> { Value = 1 };
            var secondNode = new Node<int> { Value = 2 };
            firstNode.Next = secondNode;
            secondNode.Previous = firstNode;

            var settings = new DataContractSerializerSettings()
            {
                PreserveObjectReferences = true
            };


            using (var stream = File.Create(path))
            {
                var serializer = new DataContractSerializer(typeof(Node<int>), settings);
                serializer.WriteObject(stream, firstNode);
            }
        }
        
        private static void DataContractSerializeKnownTypes()
        {
            var hero = new Hero
            {
                Weapon = new Bow
                {
                    Damage = 20,
                    Arrows = 10
                }
            };

            using (var stream = File.Create(path))
            {
                var serializer = new DataContractSerializer(typeof(Hero));
                serializer.WriteObject(stream, hero);
            }
        }
        
        private static void XmlSerialize()
        {
            var person = new PersonNoAttributes()
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            using (var stream = File.Create(path))
            {
                var serializer = new XmlSerializer(typeof(PersonNoAttributes));
                serializer.Serialize(stream, person);
            }
        }
        
        private static void XmlDeserialize()
        {
            using (var stream = File.OpenRead(path))
            {
                var serializer = new XmlSerializer(typeof(PersonNoAttributes));
                var deserialized = (PersonNoAttributes)serializer.Deserialize(stream);
            }
        }

        private static void XmlSerializeWithAttributes()
        {
            var person = new PersonWithAttributes()
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1)
            };

            using (var stream = File.Create(path))
            {
                var serializer = new XmlSerializer(typeof(PersonWithAttributes));
                serializer.Serialize(stream, person);
            }
        }

        private static void BinarySerialize()
        {
            var person = new SerializablePerson("John", "Doe", new DateTime(1990, 1, 1));

            var formatter = new BinaryFormatter();

            using (var stream = File.Create(path))
            {
                formatter.Serialize(stream, person);
            }
        }

        private static void BinaryDeserialize()
        {
            var formatter = new BinaryFormatter();

            using (var stream = File.OpenRead(path))
            {
                var deserialized = (SerializablePerson)formatter.Deserialize(stream);
            }

        }
    }
}
