using System;
using System.Collections.Generic;
using System.Text;

namespace Checo.Service.Interface
{
    public interface IToolService
    {
        string ImportExcel(string path);
        string ImportExcelPrice(string filepath);
        void AnalysicQueryFile(string path);
    }
}
