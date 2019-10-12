using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Core
{
    public class Issue
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public StudentInfo Student { get; set; }
        public int bookId { get; set; }
        public BookInfo Book { get; set; }
        public string bookBarcode { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime? returnDate { get; set; }
    }
}
