using Library.Core;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Library.User
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to library system.");
            Console.Write("Please enter your choice:\nTo entry student information enter: 1\n" +
                "To entry book information enter: 2\nTo issue a book, enter: 3\nTo return a book enter: 4\n" +
                "To check fine, enter: 5\nTo receive fine, enter: 6\n");
            Console.Write("Enter:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    AddStudent.AddStudentInfo();
                    break;
                case 2:
                    AddBook.AddBookInfo();
                    break;
                case 3:
                    IssueBook.IssueABook();
                    break;
                case 4:
                    IssueBook.ReturnABook();
                    break;
                case 5:
                    Report.CheckFine();
                    break;
                case 6:
                    Report.ReceiveFine();
                    break;
            }

        }
    }
}
