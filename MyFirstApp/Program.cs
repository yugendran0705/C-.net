using System;

class Person
{
    string Name { get; set; }
    int _age;
    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Age cannot be negative.");
            }
            else
            {
                _age = value;
            }
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public void Introduce()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
    }

}
class Program
{
    static void Main(string[] args){
        Person person1 = new Person("Person 1", 21);
        person1.Introduce();
        Person person2 = new Person("Person 2", 21);
        person2.Introduce();
        Person person3 = new Person("Person 3", 20);
        person3.Introduce();
    }
}
