using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;

namespace Core.Libs.Utils.Helpers
{
    public static class FileExtensions
    {
        public static void ExportExcel<T>(this List<T> data, string fileName) where T : class
        {
            var maxRow = 50000;
            var count = 0;

            var batchs = data.SplitToBatchs(maxRow).ToList();

            if (batchs.Count > 1)
                foreach (var batch in batchs)
                {
                    count++;

                    batch.ToList().exportExcel($"{fileName}_{count}.xls");
                }
            else
                data.exportExcel($"{fileName}.xls");
        }

        private static void exportExcel<T>(this List<T> data, string path) where T : class
        {
            if (data == null)
                throw new ArgumentNullException("data");

            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Sheet1");

            var props = typeof(T).GetProperties();

            #region build row0

            var row0 = sheet.CreateRow(0);
            
            for (var i = 0; i < props.Length; i++)
            {
                var prop = props[i];

                var attr = prop.GetCustomAttribute<DisplayAttribute>();
                var name = attr != null ? attr.Name : prop.Name;

                if (name.Equals("#Ignore#"))
                    continue;

                row0.CreateCell(i).SetCellValue(name);
            }

            #endregion

            var dataFormat = workbook.CreateDataFormat();
            var cellStyle = workbook.CreateCellStyle();

            #region build rows

            for (int i = 0; i < data.Count; i++)
            {
                var row = sheet.CreateRow(i + 1);

                for (var o = 0; o < props.Length; o++)
                {
                    var prop = props[o];

                    var attr = prop.GetCustomAttribute<DisplayAttribute>();
                    var name = attr != null ? attr.Name : prop.Name;

                    if (name.Equals("#Ignore#"))
                        continue;

                    var value = prop.GetValue(data[i]);
                    var dataType = prop.PropertyType;
                    
                    if (value == null)
                    {
                        row.CreateCell(o);
                        continue;
                    }

                    if (dataType == typeof(bool) || dataType == typeof(bool?))
                    {
                        switch ((bool)value)
                        {
                            case true:
                                row.CreateCell(o).SetCellValue("Yes");
                                break;
                            default:
                                row.CreateCell(o).SetCellValue("No");
                                break;
                        }
                    }
                    else if (dataType == typeof(int) || dataType == typeof(int?))
                    {
                        if (name == "Gender" || name == "Giới tính")
                        {
                            switch (value)
                            {
                                case 1:
                                    row.CreateCell(o).SetCellValue("Male");
                                    break;
                                case 0:
                                    row.CreateCell(o).SetCellValue("Female");
                                    break;
                                default:
                                    row.CreateCell(o).SetCellValue(string.Empty);
                                    break;
                            }
                        }
                        else
                        {
                            var intValue = 0;
                            if (int.TryParse(value.ToString(), out intValue))
                                row.CreateCell(o).SetCellValue(intValue);
                        }
                    }
                    else if (dataType == typeof(long) || dataType == typeof(long?))
                    {
                        long longValue = 0;
                        if (long.TryParse(value.ToString(), out longValue))
                            row.CreateCell(o).SetCellValue(longValue);
                    }
                    else if (dataType == typeof(double) || dataType == typeof(double?))
                    {
                        double doubleValue = 0;
                        if (double.TryParse(value.ToString(), out doubleValue))
                            row.CreateCell(o).SetCellValue(doubleValue);
                    }
                    else if (dataType == typeof(decimal) || dataType == typeof(decimal?))
                    {
                        double doubleValue = 0;
                        if (double.TryParse(value.ToString(), out doubleValue))
                            row.CreateCell(o).SetCellValue(doubleValue);
                    }
                    else if (dataType == typeof(DateTime) || dataType == typeof(DateTime?))
                    {
                        DateTime dateTimeValue;

                        if (DateTime.TryParse(value.ToString(), out dateTimeValue))
                        {

                            row.CreateCell(o).SetCellValue(dateTimeValue);

                            if (name == "Birthday" || name == "Ngày sinh")
                            {
                                var birthdaystyle = workbook.CreateCellStyle();
                                row.Cells[o - 1].CellStyle = birthdaystyle;
                                row.Cells[o - 1].CellStyle.DataFormat = dataFormat.GetFormat("dd-MM-yyyy");
                            }
                            else
                            {
                                row.Cells[o - 1].CellStyle = cellStyle;
                                row.Cells[o - 1].CellStyle.DataFormat = dataFormat.GetFormat("dd-MM-yyyy HH:mm:ss");
                            }
                        }
                    }
                    else
                    {
                        if (dataType == typeof(String))
                        {
                            if (value.ToString().Length > 32767)
                                value = value.ToString().Substring(0, 32767);
                        }

                        row.CreateCell(o).SetCellValue(value.ToString());
                    }
                }
            }

            #endregion

            using (var stream = new MemoryStream())
            {
                workbook.Write(stream);

                using (var fileStream = File.Create(path))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.CopyTo(fileStream);
                }
            }
        }
    
        public static Task WriteJsonFile<T>(this T data, string fileName)
        {
            return WriteFile(JsonConvert.SerializeObject(data), fileName);
        }
        public static async Task WriteFile(this string content, string fileName)
        {
            using (var stream = new FileStream(
                fileName, FileMode.Create, FileAccess.Write, FileShare.Write, 4096))
            {
                var bytes = Encoding.UTF8.GetBytes(content);
                await stream.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        public static async Task<T> ReadJsonFile<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(await ReadFile(fileName));
        }
        public static async Task<string> ReadFile(string fileName)
        {
            using (var stream = new System.IO.StreamReader(fileName))
                return await stream.ReadToEndAsync();
        }
    }
}