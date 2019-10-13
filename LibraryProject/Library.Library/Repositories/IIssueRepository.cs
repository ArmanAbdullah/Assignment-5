using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Repository
{
    public interface IIssueRepository
    {
        void IssueABook(Issue issue);
        void Save();
        Issue GetIssueDataByStnIdNBarcode(int StnId, string bookBarcode);
    }
}
