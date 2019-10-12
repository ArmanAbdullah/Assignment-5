
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
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        StudentInfo _studentInfo = new StudentInfo();

        public void SetStudentInfo(StudentInfo student)
        {


            
            _studentInfo = student;
            _studentRepository.AddStudentInfo(_studentInfo);
        }


    }
}
