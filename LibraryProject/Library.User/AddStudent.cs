using Library.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Library.User
{
    class AddStudent
    {
        public static void AddStudentInfo()
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

                request.GetResponse();
                
            }


        }
    }
}
