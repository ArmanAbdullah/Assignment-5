using Library.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Repository
{
    public class IssueRepository : IIssueRepository
    {
        LibraryContext context;

        public IssueRepository(LibraryContext _context)
        {
            context = _context;
        }
        public void IssueABook(Issue issue)
        {

            context.IssueBooks.Add(issue);
            context.SaveChanges();
        }

        public Issue GetIssueDataByStnIdNBarcode(int StnId, string bookBarcode)
        {
            var issue = context.IssueBooks.Where(x => x.bookBarcode == bookBarcode && x.StudentID == StnId).FirstOrDefault();
            return issue;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
