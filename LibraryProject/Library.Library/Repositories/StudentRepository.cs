using Library.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Repository
{
    public class StudentRepository : IStudentRepository
    {
        LibraryContext context;

        public StudentRepository(LibraryContext _context)
        {
            context = _context;
        }
        public void AddStudentInfo(StudentInfo studentInfo)
        {

            context.StudentInfos.Add(studentInfo);
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.StudentInfos ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.StudentInfos OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
        public StudentInfo GetStudentById(int stnId)
        {
            var stu = context.StudentInfos.Where(x => x.Id == stnId).Single();
            return stu;
        }
        public void UpdateFineAmount(int stnId, float fineAmount)
        {
            var stu = GetStudentById(stnId);
            stu.fineAmount = fineAmount;
            context.SaveChanges();
        }
        

    }
}
