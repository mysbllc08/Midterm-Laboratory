using System;

struct Student
{
    public string studentNumber;
    public string studentName;
    public string program;
    public int yearLevel;
}
class Program
{
    static Student[] students = new Student[10];
    static int studentCount = 0;
    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\n===== STUDENT RECORD MANAGEMENT=====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                AddStudent();
            }
            else if (choice == 2)
            {
                DisplayStudents();
            }
            else if (choice == 3)
            {
                SearchStudent();
            }
            else if (choice == 4)
            {
                UpdateStudent();
            }
            else if (choice == 5)
            {
                DeleteStudent();
            }
            else if (choice == 6)
            {
                Console.WriteLine("Exiting...");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

        } while (choice != 6);
    }
    static void AddStudent()
    {
        if (studentCount == 10)
        {
            Console.WriteLine("Maximum of 10 students only.");
            return;
        }

        Console.Write("Enter Student Number: ");
        students[studentCount].studentNumber =
            Console.ReadLine();

        Console.Write("Enter Name: ");
        students[studentCount].studentName =
            Console.ReadLine();

        Console.Write("Enter Program: ");
        students[studentCount].program =
            Console.ReadLine();

        Console.Write("Enter Year Level: ");
        students[studentCount].yearLevel =
            Convert.ToInt32(Console.ReadLine());

        studentCount++;

        Console.WriteLine("Student added successfully!");
    }
    static void SearchStudent()
    {
        Console.Write("Enter Student Number: ");
        string number = Console.ReadLine();

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].studentNumber == number)
            {
                Console.WriteLine("\n===== STUDENT RECORDS =====");
                Console.WriteLine("Student Number: " +
                    students[i].studentNumber);
                Console.WriteLine("Name: " +
                    students[i].studentName);
                Console.WriteLine("Program: " +
                    students[i].program);
                Console.WriteLine("Year Level: " +
                    students[i].yearLevel);

                return;
            }
        }

        Console.WriteLine("Student not found.");
    }
    static void DisplayStudents()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No student records.");
            return;
        }

        Console.WriteLine("\n===== STUDENT RECORDS =====");

        for (int i = 0; i < studentCount; i++)
        {
            Console.WriteLine("\nStudent Number: " +
                students[i].studentNumber);

            Console.WriteLine("Name: " +
                students[i].studentName);

            Console.WriteLine("Program: " +
                students[i].program);

            Console.WriteLine("Year Level: " +
                students[i].yearLevel);
        }
    }
    static void UpdateStudent()
    {
        Console.Write("Enter Student Number: ");
        string number = Console.ReadLine();

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].studentNumber == number)
            {
                Console.Write("New Name: ");
                students[i].studentName = Console.ReadLine();

                Console.Write("New Program: ");
                students[i].program = Console.ReadLine();

                Console.Write("New Year Level: ");
                students[i].yearLevel =
                    Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Student updated successfully!");

                return;
            }
        }

        Console.WriteLine("Student not found.");
    }
    static void DeleteStudent()
    {
        Console.Write("Enter Student Number: ");

        string number = Console.ReadLine();

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].studentNumber == number)
            {
                for (int j = i; j < studentCount - 1; j++)
                {
                    students[j] = students[j + 1];
                }

                studentCount--;

                Console.WriteLine("Student deleted successfully!");

                return;
            }
        }
        
        Console.WriteLine("Student not found.");
    }
}
