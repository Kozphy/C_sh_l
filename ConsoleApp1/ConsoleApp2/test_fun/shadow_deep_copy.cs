using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.test_fun
{
    public class shadow_deep_copy
    {

    }
    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int IdNumber)
        {
            this.IdNumber = IdNumber;
        }
    }

    public class Person
    {
        public int Age;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.IdInfo = new IdInfo(IdInfo.IdNumber);
            other.Name = String.Copy(Name);
            return other;
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}", p.Name, p.Age);
            Console.WriteLine("      Value: {0:d}", p.IdInfo.IdNumber);
        }

    }
}
