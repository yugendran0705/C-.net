using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Student
    {
        public string Name { get; set; }
        private int _age;
        private string _grade;

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative.");
                }
                _age = value;
            }
        }
        public string Grade
        {
            get { return _grade; }
            set
            {
                HashSet<string> validGrades = new HashSet<string> { "A", "B", "C", "D", "E", "F" };
                if (!validGrades.Contains(value))
                {
                    throw new ArgumentException("Invalid grade.");
                }
                _grade = value;
            }
        }

        public Student(string name, int age, string grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            try
            {
                students.Add(new Student("Alice", 20, "A"));
                students.Add(new Student("Bob", 19, "B"));
                students.Add(new Student("Charlie", 22, "C"));
                students.Add(new Student("David", 21, "D"));
                students.Add(new Student("Eve", 23, "E"));
                students.Add(new Student("Frank", 24, "F"));

                Console.Write("Enter Grade threshold:");
                string threshold = Console.ReadLine();
                if (!new HashSet<string> { "A", "B", "C", "D", "E", "F" }.Contains(threshold))
                {
                    throw new ArgumentException("Invalid grade threshold.");
                }

                Console.Write("Enter Sort Choice 1.By name, 2.By Grade (1/2):");
                string sortChoice = Console.ReadLine();

                IEnumerable<Student> filteredStudents;

                if (sortChoice == "1")
                {
                    filteredStudents = students
                        .Where(s => string.Compare(s.Grade, threshold) <= 0)
                        .OrderBy(s => s.Name);
                }
                else if (sortChoice == "2")
                {
                    filteredStudents = students
                        .Where(s => string.Compare(s.Grade, threshold) <= 0)
                        .OrderBy(s => s.Grade);
                }
                else
                {
                    throw new ArgumentException("Invalid choice.");
                }

                Console.WriteLine("Filtered Students:");
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine($"{student.Name}, {student.Age}, {student.Grade}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}