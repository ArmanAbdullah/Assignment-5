using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Library.User
{
    class Report
    {
        public static void CheckFine()
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
                            Console.WriteLine("Fine:" + item);

                        }
                    }
                }
            }
        }

        public static void ReceiveFine()
        {
            var arr = new string[2];
            Console.Write("Enter student id:");
            arr[0] = Console.ReadLine();
            Console.Write("Enter fine amount:");
            arr[1] = Console.ReadLine();

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

                request.GetResponse();
            }
        }
    }
}
