using Library.Library.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Library
{
    public class IssueUnitOfWork
    {
        private LibraryContext _context;

        public IBookRepository bookRepository { get; private set; }
        public IIssueRepository issueRepository { get; private set; }
        

        public IssueUnitOfWork(string connectionString, string migrationAssemblyName)
        {
            _context = new LibraryContext(connectionString, migrationAssemblyName);

            bookRepository = new BookRepository(_context);
            issueRepository = new IssueRepository(_context);
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
