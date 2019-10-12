
using Library.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Repository
{
    public class BookRepository : IBookRepository
    {
        LibraryContext context;


        public BookRepository(LibraryContext _context)
        {
            context = _context;
        }

        public void AddBookInfo(BookInfo bookInfo)
        {

            //BookService bookService = new BookService();
            //BookInfo _bookInfo = bookService.GetBook();


            context.BookInfos.Add(bookInfo);
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.BookInfos ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.BookInfos OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
        public BookInfo GetBookInfoUsingBarcode(string bookBarcode)
        {
            return context.BookInfos.Where(x => x.barcode == bookBarcode).Single();
        }
    }
}
