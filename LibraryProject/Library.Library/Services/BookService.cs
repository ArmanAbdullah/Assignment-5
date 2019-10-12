
using Library.Core;
using Library.Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Service
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        BookInfo _bookInfo = new BookInfo();
        public void SetBookInfo(BookInfo bookInfo)
        {
            
            _bookInfo = bookInfo;

            //var book = new BookInfo()
            //{
            //    Id = _bookInfo.Id,
            //    title = _bookInfo.title,
            //    author = informations[2],
            //    edition = informations[3],
            //    barcode = informations[4],
            //    copyCount = Convert.ToInt32(informations[5])

            //};
            
            _bookRepository.AddBookInfo(_bookInfo);
        }

    }
}
