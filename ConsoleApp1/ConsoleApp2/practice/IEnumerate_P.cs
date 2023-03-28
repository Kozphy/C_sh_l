using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.practice
{
    //<summary> 
    // IEnumerable <T> contains a single method that you must implement when implementing this interface;
    // GetEnumerator(), which returns IEnumerator<T> object.
    // The returns IEnumerator<T> provides the ability  to iterate through the collection
    // by exposing a Current property that points at the object we are currently at in the collection.
    //</summary>

    /*
        When it is recommend to use the IEnumerable interface:
        Your collection represents a massive database table,
        you don't want to copy the entire thing into memory and cause performance issues in your application.
        When it is not recommend to use the IEnumerable interface:
        You need to result right away and are possibly mutating / editing the objects later on.
        In this case, it is better to use an Array or a List.
     */
    public class IEnumerate_P
    {
        DogShelter shelter = new DogShelter();
        public void Dog_iter() { 
            foreach(Dog dog in shelter)
            {
                if (dog.IsNaughtyDog == false)
                {
                    dog.GetTreat(2);
                }
                else
                {
                    dog.GetTreat(1);
                }
            }
        }
    }
    class Dog
    { 
        public string Name { get; set; }
        public bool IsNaughtyDog { get; set; }

        public Dog(string name, bool IsNaughtyDog) 
        {
            this.Name = name;
            this.IsNaughtyDog = IsNaughtyDog;
        }

        public void GetTreat(int numberofTreats)
        {
            Console.WriteLine("Dog: {0} said wuoff {1} times!.", Name, numberofTreats);
        }
    }

    class DogShelter : IEnumerable<Dog>
    {
        public List<Dog> dogs;
        public DogShelter()
        {
            dogs = new List<Dog>
            {
                new Dog("Casper", false),
                new Dog("Sif", true),
                new Dog("Oreo", false),
                new Dog("Pixel", false),
            };
        }

        IEnumerator<Dog> IEnumerable<Dog>.GetEnumerator()
        {
            return dogs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
