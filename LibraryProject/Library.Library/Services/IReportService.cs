using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Library.Service
{
    public interface IReportService
    {
        float checkFine(int stnId);
        void payFine(string[] info);
    }
}
