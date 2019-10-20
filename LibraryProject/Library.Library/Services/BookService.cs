
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
        private UnitOfWork _unitOfWork;
        public BookService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        BookInfo _bookInfo = new BookInfo();
        public void SetBookInfo(BookInfo bookInfo)
        {
            _bookInfo = bookInfo;
            _unitOfWork.bookRepository.AddBookInfo(_bookInfo);
        }
    }
}
