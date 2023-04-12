using System;
using System.Collections.Generic;
using System.Text;

namespace Checo.Service.Interface
{
    public interface ITESTService
    {
        void RunProcess();
        void StopProcess();
        bool AddProcess(Action action, int sequence = 0);
    }
}
