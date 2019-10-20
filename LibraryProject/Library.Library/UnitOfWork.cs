using Library.Library.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Library
{
    public class UnitOfWork
    {
        private LibraryContext _context;
        public IBookRepository bookRepository { get; private set; }
        public IIssueRepository issueRepository { get; private set; }
        public IStudentRepository studentRepository { get; private set; }
        public UnitOfWork(string connectionString, string migrationAssemblyName)
        {
            _context = new LibraryContext(connectionString, migrationAssemblyName);

            bookRepository = new BookRepository(_context);
            issueRepository = new IssueRepository(_context);
            studentRepository=new StudentRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
