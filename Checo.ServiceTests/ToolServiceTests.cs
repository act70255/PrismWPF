using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checo.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Checo.Service;
using Checo.Repository;

namespace Checo.Service.Tests
{
    [TestClass()]
    public class ToolServiceTests
    {
        [TestMethod()]
        public void ImportExcelTest()
        {
            ToolService server = new ToolService(new MsSQLRepository());
            var result = server.ImportExcel("");
            Assert.AreNotEqual(result,"");
        }
    }
}