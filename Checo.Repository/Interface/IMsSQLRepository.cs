using System;
using System.Collections.Generic;
using System.Text;

namespace Checo.Repository.Interface
{
    public interface IMsSQLRepository
    {
        int InsertDapper(string queryInsert, object obj);
    }
}
