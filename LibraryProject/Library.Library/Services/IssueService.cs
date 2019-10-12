using Library.Core;
using Library.Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Service
{
    public class IssueService : IIssueService
    {
        private IIssueRepository _issueRepository;
        private IStudentRepository _studentRepository;
        private IBookRepository _bookRepository;
        public IssueService(IIssueRepository issueRepository, IStudentRepository studentRepository, IBookRepository bookRepository)
        {
            _issueRepository = issueRepository;
            _studentRepository = studentRepository;
            _bookRepository = bookRepository;
        }

        public void BookIssue(string[] informations)
        {
            var stnId = Convert.ToInt32(informations[0]);
            var barCode = informations[1];
            var book = _bookRepository.GetBookInfoUsingBarcode(barCode);
            if (book.copyCount > 0)
            {
                DateTime? date = null;
                var issue = new Issue()
                {
                    StudentID = stnId,
                    bookId = book.Id,
                    bookBarcode = barCode,
                    issueDate = new DateTime(2019, 9, 20),
                    returnDate = date
                };


                _issueRepository.IssueABook(issue);
            }
        }
        public void BookReturn(string[] imformations)
        {

            int Id = Convert.ToInt32(imformations[0]);
            var barCode = imformations[1];

            var stu = _studentRepository.GetStudentById(Id);
            var issue = _issueRepository.GetIssueDataByStnIdNBarcode(Id, barCode);
            //var book = context.BookInfos.Where(x => x.barcode == bookbarcode).Single();

            issue.returnDate = DateTime.UtcNow;

            DateTime issDate = Convert.ToDateTime(issue.returnDate);

            TimeSpan diff = issDate - issue.issueDate;

            int days = Math.Abs(diff.Days);
            if (days > 7)
            {
                stu.fineAmount =stu.fineAmount+( (days - 7) * 10);
            }
            _studentRepository.UpdateFineAmount(stu.Id, stu.fineAmount);
        }


    }
}
