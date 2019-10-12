using Library.Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Service
{
    public class ReportService : IReportService
    {
        private IStudentRepository _studentRepository;
        public ReportService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        int _stnId = 0;
        string[] _info;

        public float checkFine(int stnId)
        {
            _stnId = stnId;
            var stu = _studentRepository.GetStudentById(stnId);
            return stu.fineAmount;
        }


        public void payFine(string[] info)
        {
            _info = info;
            int stnId = Convert.ToInt32(_info[0]);
            int FineAmount = Convert.ToInt32(_info[1]);
            var stu = _studentRepository.GetStudentById(stnId);
            stu.fineAmount -= FineAmount;
            _studentRepository.UpdateFineAmount(stnId, stu.fineAmount);
        }
    }
}
