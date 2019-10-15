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
        private IssueUnitOfWork _issueUnitOfWork;
        private ReturnUnitOfWork _returnUnitOfWork;
        public IssueService(IssueUnitOfWork issueUnitOfWork, ReturnUnitOfWork returnUnitOfWork)
        {
            _issueUnitOfWork = issueUnitOfWork;
            _returnUnitOfWork = returnUnitOfWork;
        }

        public void BookIssue(string[] informations)
        {
            var stnId = Convert.ToInt32(informations[0]);
            var barCode = informations[1];
            var book = _issueUnitOfWork.bookRepository.GetBookInfoUsingBarcode(barCode);
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
                _issueUnitOfWork.issueRepository.IssueABook(issue);
                book.copyCount--;
                _issueUnitOfWork.Save();
            }
        }
        public void BookReturn(string[] imformations)
        {

            int Id = Convert.ToInt32(imformations[0]);
            var barCode = imformations[1];

            var stu = _returnUnitOfWork.studentRepository.GetStudentById(Id);
            var issue = _returnUnitOfWork.issueRepository.GetIssueDataByStnIdNBarcode(Id, barCode);
            var book = _returnUnitOfWork.bookRepository.GetBookInfoUsingBarcode(barCode);

            issue.returnDate = DateTime.UtcNow;
            book.copyCount++;
            _returnUnitOfWork.bookRepository.GetBookInfoUsingBarcode(barCode); 
            DateTime issDate = Convert.ToDateTime(issue.returnDate);

            TimeSpan diff = issDate - issue.issueDate;

            int days = Math.Abs(diff.Days);
            if (days > 7)
            {
                stu.fineAmount =stu.fineAmount+( (days - 7) * 10);
            }
            _returnUnitOfWork.studentRepository.UpdateFineAmount(stu.Id, stu.fineAmount);
            _returnUnitOfWork.Save();
        }


    }
}
