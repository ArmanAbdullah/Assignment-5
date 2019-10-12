using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Repository
{
    public interface IBookRepository
    {
        void AddBookInfo(BookInfo bookInfo);
        BookInfo GetBookInfoUsingBarcode(string bookBarcode);
    }
}
