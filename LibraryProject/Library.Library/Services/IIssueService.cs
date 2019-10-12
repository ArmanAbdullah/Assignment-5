using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Service
{
    public interface IIssueService
    {
        void BookIssue(string[] informations);
        void BookReturn(string[] imformations);
    }
}
