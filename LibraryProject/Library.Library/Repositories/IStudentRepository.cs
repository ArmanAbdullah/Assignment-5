using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Repository
{
    public interface IStudentRepository
    {
        void AddStudentInfo(StudentInfo studentInfo);
        StudentInfo GetStudentById(int stnId);
        void UpdateFineAmount(int stnId, float fineAmount);
    }
}
