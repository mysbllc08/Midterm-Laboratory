using System;
using System.Collections.Generic;

struct Student
{
    public string studentNumber;
    public string studentName;
    public string program;
    public int yearLevel;
}
class Program
{
    static Dictionary<string, Student> studentDictionary =
    new Dictionary<string, Student>();

    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\n===== STUDENT LOOKUP USING DICTIONARY =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                AddStudent();
            }
            else if (choice == 2)
            {
                SearchStudent();
            }
            else if (choice == 3)
            {
                DisplayStudents();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Exiting...");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

        } while (choice != 4);
    }
    static void AddStudent()
    {
        Console.Write("Enter Student Number: ");
        string number = Console.ReadLine();

        if (studentDictionary.ContainsKey(number))
        {
            Console.WriteLine("Student number already exists.");
            return;
        }

        Student student = new Student();

        student.studentNumber = number;

        Console.Write("Enter Name: ");
        student.studentName = Console.ReadLine();

        Console.Write("Enter Program: ");
        student.program = Console.ReadLine();

        Console.Write("Enter Year Level: ");
        student.yearLevel =
            Convert.ToInt32(Console.ReadLine());

        studentDictionary.Add(number, student);

        Console.WriteLine("Student added successfully!");
    }
    static void SearchStudent()
    {
        Console.Write("Enter Student Number to search: ");
        string number = Console.ReadLine();

        if (studentDictionary.ContainsKey(number))
        {
            Student student = studentDictionary[number];

            Console.WriteLine("\n===== STUDENT LOOKUP USING DICTIONARY =====");
            
            Console.WriteLine("Student Found!");
            
            Console.WriteLine("Student Number: " +
                student.studentNumber);

            Console.WriteLine("Name: " +
                student.studentName);

            Console.WriteLine("Program: " +
                student.program);

            Console.WriteLine("Year Level: " +
                student.yearLevel);
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void DisplayStudents()
    {
        if (studentDictionary.Count == 0)
        {
            Console.WriteLine("No student records.");
            return;
        }

        Console.WriteLine("\n===== STUDENT LOOKUP USING DICTIONARY =====");

        foreach (Student student in studentDictionary.Values)
        {
            Console.WriteLine("Student Number: " +
                student.studentNumber);

            Console.WriteLine("Name: " +
                student.studentName);

            Console.WriteLine("Program: " +
                student.program);

            Console.WriteLine("Year Level: " +
                student.yearLevel);
        }
    }
}
