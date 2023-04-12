using Checo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checo.Service
{
    public class TESTService : ITESTService
    {
        static object locker = new object();
        List<ProcessQueueObject> ProcessQueue { get; set; } = new List<ProcessQueueObject>();
        bool IsRunnung = false;
        public void RunProcess()
        {
            if (!IsRunnung)
                ExecuteQueue();
        }
        public void StopProcess()
        {
            IsRunnung = false;
        }

        async Task ExecuteQueue()
        {
            IsRunnung = true;
            try
            {
                while (IsRunnung)
                {
                    while (IsRunnung && ProcessQueue.Any(a => !a.IsFinished))
                    {
                        var currentProcess = ProcessQueue.OrderBy(o => o.Sequence).FirstOrDefault(f => f.IsFinished == false);
                        if (currentProcess != null)
                        {
                            Debug.WriteLine($"[Start Process] {currentProcess.ProcessID}");
                            lock (locker)
                            {
                                currentProcess.Action();
                                currentProcess.IsFinished = true;
                                Debug.WriteLine($"[Finished] {currentProcess.ProcessID}");
                            }
                        }
                    }
                    await Task.Delay(5000);
                }
            }
            catch (Exception ex)
            {
                IsRunnung = false;
                throw;
            }
        }

        public bool AddProcess(Action action, int sequence = 0)
        {
            try
            {
                var newProcess = new ProcessQueueObject(action, sequence);
                ProcessQueue.Add(newProcess);
                Debug.WriteLine($"[Add] {newProcess.ProcessID}");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public class ProcessQueueObject
        {
            public ProcessQueueObject(Action action, int sequence)
            {
                Action = action;
                Sequence = sequence;
                IsFinished = false;
                ProcessID = Guid.NewGuid().ToString();
            }
            public Action Action;
            public string ProcessID { get; set; }
            public int Sequence { get; set; } = 0;
            public bool IsFinished { get; set; } = false;
        }
    }
}
