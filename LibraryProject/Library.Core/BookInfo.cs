using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Core
{
    public class BookInfo
    {
        //public BookInfo()
        //{

        //}
        public int Id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string edition { get; set; }
        public string barcode { get; set; }
        public int copyCount { get; set; }
        public IList<Issue> IssueBooks { get; set; }

    }
}
