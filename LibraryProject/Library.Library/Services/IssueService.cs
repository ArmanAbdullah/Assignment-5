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
        private UnitOfWork _unitOfWork;
        public IssueService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void BookIssue(string[] informations)
        {
            var stnId = Convert.ToInt32(informations[0]);
            var barCode = informations[1];
            var book = _unitOfWork.bookRepository.GetBookInfoUsingBarcode(barCode);
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
                _unitOfWork.issueRepository.IssueABook(issue);
                book.copyCount--;
                _unitOfWork.Save();
            }
            else
                throw new InvalidOperationException("This book is not available");
        }

        public void BookReturn(string[] imformations)
        {
            int Id = Convert.ToInt32(imformations[0]);
            var barCode = imformations[1];
            var stu = _unitOfWork.studentRepository.GetStudentById(Id);
            var issue = _unitOfWork.issueRepository.GetIssueDataByStnIdNBarcode(Id, barCode);
            var book = _unitOfWork.bookRepository.GetBookInfoUsingBarcode(barCode);
            issue.returnDate = DateTime.UtcNow;
            book.copyCount++;
            _unitOfWork.bookRepository.GetBookInfoUsingBarcode(barCode);
            DateTime issDate = Convert.ToDateTime(issue.returnDate);
            TimeSpan diff = issDate - issue.issueDate;
            int days = Math.Abs(diff.Days);
            if (days > 7)
            {
                stu.fineAmount = stu.fineAmount + ((days - 7) * 10);
            }
            _unitOfWork.studentRepository.UpdateFineAmount(stu.Id, stu.fineAmount);
            _unitOfWork.Save();
        }


    }
}
