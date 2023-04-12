using Dapper;
using Checo.Repository.Entity;
using Checo.Service.Interface;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml.Style;
using Checo.Repository.Interface;

namespace Checo.Service
{
    public class ToolService : IToolService
    {
        IMsSQLRepository _sqlRepository;
        public ToolService(IMsSQLRepository sqlRepository)
        {

            _sqlRepository = sqlRepository;
        }
        public string ImportExcel(string path)
        {
            if (string.IsNullOrEmpty(path))
                return "";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage(path);
            var workSheet = excel.Workbook.Worksheets[0];
            var rowCount = workSheet.Rows.EndRow;
            var columnCount = workSheet.Columns.EndColumn;
            workSheet.Select(new ExcelAddress(0, 0, rowCount, columnCount));
            var obj = workSheet.SelectedRange.ToCollection<TMP_IMPORT_dm_bad_bal>();
            //var obj = workSheet.Cells["A1:K786"].ToCollection<TMP_IMPORT_dm_bad_bal>();
            var queryInsert = @"INSERT INTO [dbo].[TMP_IMPORT_dm_bad_bal]
           ([date]
           ,[code]
           ,[trade_sn]
           ,[par_value]
           ,[cost]
           ,[amortize]
           ,[eom_amortize])
     VALUES
           (@終結日
           ,@債券名稱
           ,@交易序號
           ,@持有面額
           ,@買入成本
           ,@折溢價
           ,@累計攤銷)";
            var result = _sqlRepository.InsertDapper(queryInsert, obj);
            return result < 0 ? "fail" : result.ToString();
        }
        public string ImportExcelPrice(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
                return "";
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage(filepath);
            var workSheet = excel.Workbook.Worksheets[0];
            var rowCount = workSheet.Rows.EndRow;
            var columnCount = workSheet.Columns.EndColumn;
            workSheet.Select(new ExcelAddress(1, 0, rowCount, columnCount));
            //var obj = workSheet.SelectedRange.ToCollection<T>();
            var obj = workSheet.Cells["A1:Q51321"].ToCollection<TMP_cmn_bond_price>();
            var queryInsert =@"
INSERT INTO [dbo].[TMP_cmn_bond_price]
           ([log_id]
           ,[log_user]
           ,[log_time]
           ,[log_type]
           ,[data_type]
           ,[data_dt]
           ,[source]
           ,[code]
           ,[price_dt]
           ,[price]
           ,[duration]
           ,[rate]
           ,[lockuser]
           ,[locktime]
           ,[loguser]
           ,[logtime])
     VALUES
            (@log_id
            ,@log_user
            ,@log_time
            ,@log_type
            ,@data_type
            ,@data_dt
            ,@source
            ,@code
            ,@price_dt
            ,@price
            ,@duration
            ,@rate
            ,@lockuser
            ,@locktime
            ,@loguser
            ,@logtime)";

            var result = _sqlRepository.InsertDapper(queryInsert, obj);
            return result < 0 ? "fail" : result.ToString();
        }

        public void AnalysicQueryFile(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();

            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

            workSheet.TabColor = System.Drawing.Color.Black;
            workSheet.DefaultRowHeight = 12;
            workSheet.Row(1).Height = 20;
            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Cells[1, 1].Value = "File Name";
            workSheet.Cells[1, 2].Value = "Insert";
            workSheet.Cells[1, 3].Value = "Update";

            int recordIndex = 2;

            foreach (var file in Directory.GetFiles(path))
            {
                var fileContent = File.ReadAllText(file).ToLower();
                workSheet.Cells[recordIndex, 1].Value = Path.GetFileName(file);
                workSheet.Cells[recordIndex, 2].Value = fileContent.Contains("insert") ? "O" : "X";
                workSheet.Cells[recordIndex, 3].Value = fileContent.Contains("update") ? "O" : "X";
                recordIndex++;
            }

            workSheet.Column(1).AutoFit();
            workSheet.Column(2).AutoFit();
            workSheet.Column(3).AutoFit();

            string p_strPath = Directory.GetCurrentDirectory() + "QueryInfo.xlsx";

            if (File.Exists(p_strPath))
                File.Delete(p_strPath);

            FileStream objFileStrm = File.Create(p_strPath);
            objFileStrm.Close();

            File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
            excel.Dispose();
        }
    }
}
