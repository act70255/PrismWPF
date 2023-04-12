using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Implement
{
    public class PythonInterface
    {
        static ScriptEngine pyEngine;
        static ScriptScope pyScope;
        public PythonInterface()
        {
            pyEngine = Python.CreateEngine();
            pyScope = pyEngine.CreateScope();
        }

        public dynamic Execute(string pyPath,string pyFunc)
        {
            //pyEngine.ExecuteFile(@"C:\test.py", pyScope);
            //dynamic testFunction = pyScope.GetVariable("test_func");
            pyEngine.ExecuteFile(pyPath, pyScope);
            dynamic pyFunction = pyScope.GetVariable(pyFunc);
            var result = pyFunction("value1", "value2");
            return result;
        }
    }
}
