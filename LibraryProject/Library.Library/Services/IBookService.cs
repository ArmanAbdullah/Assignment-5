using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Service
{
    public interface IBookService
    {
        //string[] HaveBookInfo(string[] arr);
        void SetBookInfo(BookInfo bookInfo);
    }
}
