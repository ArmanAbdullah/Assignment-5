using Library.Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Service
{
    public class ReportService : IReportService
    {
        private UnitOfWork _unitOfWork;
        public ReportService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        int _stnId = 0;

        public float checkFine(int stnId)
        {
            _stnId = stnId;
            var stu = _unitOfWork.studentRepository.GetStudentById(stnId);
            return stu.fineAmount;
        }

        public void payFine(string[] info)
        {
            int stnId = Convert.ToInt32(info[0]);
            int paidAmount = Convert.ToInt32(info[1]);
            var stu = _unitOfWork.studentRepository.GetStudentById(stnId);
            stu.fineAmount -= paidAmount;
            if (stu.fineAmount > 0)
            {
                _unitOfWork.studentRepository.UpdateFineAmount(stnId, stu.fineAmount);
            }
            else
                throw new InvalidOperationException("Paid amount is greater than payable amount");
        }
    }
}
