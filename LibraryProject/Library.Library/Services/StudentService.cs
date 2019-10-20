
using Library.Core;
using Library.Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Service
{
    public class StudentService : IStudentService
    {
        private UnitOfWork _unitOfWork;
        public StudentService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        StudentInfo _studentInfo = new StudentInfo();
        public void SetStudentInfo(StudentInfo student)
        {
            _studentInfo = student;
            _unitOfWork.studentRepository.AddStudentInfo(_studentInfo);
        }
    }
}
