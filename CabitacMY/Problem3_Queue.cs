using System;
using System.Collections.Generic;

struct Student
{
    public string studentNumber;
    public string studentName;
    public string program;
    public int yearLevel;
}
struct StudentRequest
{
    public string StudentNumber;
    public string StudentName;
    public string RequestType;
}
class Program
{
    static Student[] students = new Student[10];
    static int studentCount = 0;

    static Queue<StudentRequest> requestQueue =
        new Queue<StudentRequest>();
    static void Main()
    {
        int choice;
        do
        {
            Console.WriteLine("\n===== STUDENT REQUEST QUEUE =====");
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Pending Requests");
            Console.WriteLine("3. Process Request");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                AddRequest();
            }
            else if (choice == 2)
            {
                ViewRequests();
            }
            else if (choice == 3)
            {
                ProcessRequest();
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
    static void AddRequest()
    {
        StudentRequest request = new StudentRequest();

        Console.Write("Enter Student Number: ");
        request.StudentNumber = Console.ReadLine();

        Console.Write("Enter Student Name: ");
        request.StudentName = Console.ReadLine();

        Console.WriteLine("\nRequest Types:");
        Console.WriteLine("1. Certificate of Enrollment");
        Console.WriteLine("2. Student ID");
        Console.WriteLine("3. Transcript Request");
        Console.Write("Choose Request Type: ");

        int requestChoice =
            Convert.ToInt32(Console.ReadLine());

        if (requestChoice == 1)
        {
            request.RequestType = "Certificate of Enrollment";
        }
        else if (requestChoice == 2)
        {
            request.RequestType = "Student ID";
        }
        else if (requestChoice == 3)
        {
            request.RequestType = "Transcript Request";
        }
        else
        {
            Console.WriteLine("Invalid request type.");
            return;
        }

        requestQueue.Enqueue(request);

        Console.WriteLine("Request added successfully!");
    }
    static void ViewRequests()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("There are no pending requests.");
            return;
        }

        Console.WriteLine("\n===== REQUEST QUEUE =====");

        int number = 1;

        foreach (StudentRequest request in requestQueue)
        {
            Console.WriteLine(
                number + ". " +
                request.StudentName + " - " +
                request.RequestType
            );

            number++;
        }
    }
    static void ProcessRequest()
    {
        if (requestQueue.Count == 0)
        {
            Console.WriteLine("There are no pending requests.");
            return;
        }
        StudentRequest request =
            requestQueue.Dequeue();

        Console.WriteLine(
            "\nProcessing Request: " +
            request.StudentName + " - " +
            request.RequestType
        );

        Console.WriteLine("Request processed successfully!");
    }
}
