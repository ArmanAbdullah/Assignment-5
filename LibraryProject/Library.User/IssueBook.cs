using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Library.User
{
    class IssueBook
    {
        public static void IssueABook()
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

                request.GetResponse();
            }
}
        public static void ReturnABook()
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
                request.GetResponse();
            }
        }
    }
}
