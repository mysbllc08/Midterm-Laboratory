using System;
using System.Collections.Generic;

struct Student
{
    public string studentNumber;
    public string studentName;
    public string program;
    public int yearLevel;
}
struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Program
{
    static Student[] students = new Student[10];
    static int studentCount = 0;
    static Stack<Operation> operationHistory =
        new Stack<Operation>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== STUDENT RECORD MANAGEMENT =====");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Operation History");
            Console.WriteLine("7. Exit");
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
                OperationMenu();
            }
            else if (choice == 7)
            {
                Console.WriteLine("Exiting...");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

        } while (choice != 7);
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
        Operation operation = new Operation();

        operation.Action = "Added";
        operation.StudentNumber =
            students[studentCount].studentNumber;
        operation.StudentName =
            students[studentCount].studentName;

        operationHistory.Push(operation);

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
                Console.WriteLine("\n===== STUDENT RECORD =====");

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
    }    static void UpdateStudent()
    {
        Console.Write("Enter Student Number: ");
        string number = Console.ReadLine();

        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].studentNumber == number)
            {
                Console.Write("New Name: ");
                students[i].studentName =
                    Console.ReadLine();

                Console.Write("New Program: ");
                students[i].program =
                    Console.ReadLine();

                Console.Write("New Year Level: ");
                students[i].yearLevel =
                    Convert.ToInt32(Console.ReadLine());
                Operation operation = new Operation();

                operation.Action = "Updated";
                operation.StudentNumber =
                    students[i].studentNumber;
                operation.StudentName =
                    students[i].studentName;

                operationHistory.Push(operation);

                Console.WriteLine(
                    "Student updated successfully!");

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
                string studentName =
                    students[i].studentName;
                Operation operation = new Operation();

                operation.Action = "Deleted";
                operation.StudentNumber =
                    students[i].studentNumber;
                operation.StudentName =
                    students[i].studentName;

                operationHistory.Push(operation);
                for (int j = i; j < studentCount - 1; j++)
                {
                    students[j] = students[j + 1];
                }

                studentCount--;

                Console.WriteLine(
                    "Student deleted successfully!");

                return;
            }
        }

        Console.WriteLine("Student not found.");
    }
    static void OperationMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== OPERATION HISTORY =====");
            Console.WriteLine("1. View Operation History");
            Console.WriteLine("2. View Last Operation");
            Console.WriteLine("3. Remove Last Operation");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                ViewOperationHistory();
            }
            else if (choice == 2)
            {
                ViewLastOperation();
            }
            else if (choice == 3)
            {
                RemoveLastOperation();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Returning to main menu...");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

        } while (choice != 4);
    }
    static void ViewOperationHistory()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No recorded operations.");
            return;
        }

        Console.WriteLine("\n===== OPERATION HISTORY =====");

        int number = 1;

        foreach (Operation operation in operationHistory)
        {
            Console.WriteLine(
                number + ". " +
                operation.Action + " " +
                operation.StudentName
            );

            number++;
        }
    }
    static void ViewLastOperation()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No recorded operations.");
            return;
        }
        Operation operation =
            operationHistory.Peek();

        Console.WriteLine(
            "\nLast Operation: " +
            operation.Action + " " +
            operation.StudentName
        );
    }
    static void RemoveLastOperation()
    {
        if (operationHistory.Count == 0)
        {
            Console.WriteLine("No recorded operations.");
            return;
        }
        operationHistory.Pop();

        Console.WriteLine(
            "Last operation removed successfully!"
        );
    }
}
