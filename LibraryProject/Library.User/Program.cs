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
                    AddStudentInfo();
                    break;
                case 2:
                    AddBookInfo();
                    break;
                case 3:
                    IssueABook();
                    break;
                case 4:
                    ReturnABook();
                    break;
                case 5:
                    CheckFine();
                    break;
                case 6:
                    ReceiveFine();
                    break;
            }


            static void AddBookInfo()
            {
                Console.Write("Please enter book id:");
                string bookId = Console.ReadLine();
                Console.Write("Please enter book title:");
                string bookTitle = Console.ReadLine();

                Console.Write("Please enter author name:");
                string bookAuthor = Console.ReadLine();
                Console.Write("Please enter edition:");
                string bookEdition = Console.ReadLine();
                Console.Write("Please enter barcode:");
                string bookBarcode = Console.ReadLine();
                Console.Write("Please enter copy count:");
                string bookCopyCount = Console.ReadLine();
                var book = new BookInfo()
                {
                    Id = Convert.ToInt32(bookId),
                    title = bookTitle,
                    author = bookAuthor,
                    edition = bookEdition,
                    barcode = bookBarcode,
                    copyCount = Convert.ToInt32(bookCopyCount)

                };
                const string url = "https://localhost:44332/api/Book";
                var request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";

                var requestContent = JsonConvert.SerializeObject(book);
                var data = Encoding.UTF8.GetBytes(requestContent);
                request.ContentLength = data.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Flush();

                    using (var response = request.GetResponse())
                    {
                        using (var streamItem = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(streamItem))
                            {
                                var result = reader.ReadToEnd();
                                Console.WriteLine(result);
                            }
                        }
                    }
                }
            }


            static void AddStudentInfo()
            {
                Console.Write("Please enter student id:");
                string studentId = Console.ReadLine();
                Console.Write("Please enter student name:");
                string studentName = Console.ReadLine();
                var studentInfo = new StudentInfo()
                {
                    Id = Convert.ToInt32(studentId),
                    name = studentName
                };
                const string url = "https://localhost:44332/api/Student";
                var request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                var requestContent = JsonConvert.SerializeObject(studentInfo);
                var data = Encoding.UTF8.GetBytes(requestContent);
                request.ContentLength = data.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Flush();

                    using (var response = request.GetResponse())
                    {
                        using (var streamItem = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(streamItem))
                            {
                                var result = reader.ReadToEnd();
                                Console.WriteLine(result);
                            }
                        }
                    }
                }


            }

            static void IssueABook()
            {
                var arr = new string[2];
                Console.Write("Enter student id:");
                arr[0] = Console.ReadLine();
                Console.Write("Enter book barcode:");
                arr[1] = Console.ReadLine();



                const string url = "https://localhost:44332/api/Issue";
                var request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                var requestContent = JsonConvert.SerializeObject(arr);
                var data = Encoding.UTF8.GetBytes(requestContent);
                request.ContentLength = data.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Flush();

                    using (var response = request.GetResponse())
                    {
                        using (var streamItem = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(streamItem))
                            {
                                var result = reader.ReadToEnd();
                                Console.WriteLine(result);
                            }
                        }
                    }
                }



                //var b = context.IssueBooks.Where(x => x.bookBarcode == bookInfo.barcode && x.StudentID == studentInfo.Id).FirstOrDefault();
            }

            static void ReturnABook()
            {
                var arr = new string[2];
                Console.Write("Enter student id:");
                arr[0] = Console.ReadLine();
                Console.Write("Enter book barcode:");
                arr[1] = Console.ReadLine();

                const string url = "https://localhost:44332/api/Issue/5";
                var request = WebRequest.Create(url);
                request.Method = "PUT";
                request.ContentType = "application/json";
                var requestContent = JsonConvert.SerializeObject(arr);
                var data = Encoding.UTF8.GetBytes(requestContent);
                request.ContentLength = data.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Flush();

                    using (var response = request.GetResponse())
                    {
                        using (var streamItem = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(streamItem))
                            {
                                var result = reader.ReadToEnd();
                                Console.WriteLine(result);
                            }
                        }
                    }
                }




            }
            static void CheckFine()
            {
                Console.Write("Enter student id:");
                int stnId = Convert.ToInt32(Console.ReadLine());
                const string url = "https://localhost:44332/api/Report/checkFine";
                var request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                var requestContent = JsonConvert.SerializeObject(stnId);
                var data = Encoding.UTF8.GetBytes(requestContent);
                request.ContentLength = data.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Flush();

                    using (var response = request.GetResponse())
                    {
                        using (var streamItem = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(streamItem))
                            {
                                var result = reader.ReadToEnd();
                                //Console.WriteLine(result);
                                dynamic item = JsonConvert.DeserializeObject(result);
                                Console.WriteLine("Fine:"+item);
                                
                            }
                        }
                    }
                }
            }

            static void ReceiveFine()
            {
                var arr = new string[2];
                Console.Write("Enter student id:");
                arr[0] =Console.ReadLine();
                Console.Write("Enter fine amount:");
                arr[1] =Console.ReadLine();

                const string url = "https://localhost:44332/api/Report/payFine";
                var request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                var requestContent = JsonConvert.SerializeObject(arr);
                var data = Encoding.UTF8.GetBytes(requestContent);
                request.ContentLength = data.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Flush();

                    using (var response = request.GetResponse())
                    {
                        using (var streamItem = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(streamItem))
                            {
                                var result = reader.ReadToEnd();
                                Console.WriteLine(result);
                            }
                        }
                    }
                }

            }

        }
    }
}
