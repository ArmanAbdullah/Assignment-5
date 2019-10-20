using Library.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Library.User
{
    class AddBook
    {
        public static void AddBookInfo()
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
                request.GetResponse();
            }
        }
    }
}
