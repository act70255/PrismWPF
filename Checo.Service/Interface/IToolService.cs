using System;
using System.Collections.Generic;
using System.Text;

namespace Checo.Service.Interface
{
    public interface IToolService
    {
        string ImportExcelBAL(string path);
        string ImportExcelPrice(string path);
        void AnalysicQueryFile(string path);
    }
}
