using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Core
{
    public class StudentInfo
    {
        public int Id { get; set; }
        public string name { get; set; }
        public float fineAmount { get; set; }
        public IList<Issue> IssueBooks { get; set; }
        public StudentInfo()
        {
            fineAmount = 0;
        }
    }
}
