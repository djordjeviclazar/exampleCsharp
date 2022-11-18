using OfficeOpenXml;
using System.Reflection;

namespace CopyWorksheet_Azure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string sourcePath = $@"{rootPath}\TestFiles\TF1.xlsx", destinationPath = $@"{rootPath}\TestFiles\TF2_vba.xlsm";
            Stream sourceFile = File.Open(sourcePath, FileMode.Open), destinationFile = File.Open(destinationPath, FileMode.Open);

            ExcelPackage sourcePackage = new ExcelPackage(sourceFile), destinationPackage = new ExcelPackage(destinationFile);
            var intermediateStream = FillSheetWithRandomData(destinationPackage);
            var intermediatePackage = new ExcelPackage(intermediateStream);
            var resultStream = CopyValues(sourcePackage.Workbook.Worksheets["Sheet1"], intermediatePackage);

            byte[] resultBytes = new byte[resultStream.Length];
            int numBytesToRead = (int)resultStream.Length;
            int numBytesRead = 0;
            do
            {
                // Read may return anything from 0 to 10.
                int chunkSize = numBytesToRead > 10 ? 10 : numBytesToRead;
                int n = resultStream.Read(resultBytes, numBytesRead, chunkSize);
                numBytesRead += n;
                numBytesToRead -= n;
            } while (numBytesToRead > 0);
            File.WriteAllBytes($@"{rootPath}\TestFiles\Result_2.xlsm", resultBytes);
        }

        static Stream FillSheetWithRandomData(ExcelPackage package)
        {
            var worksheet = package.Workbook.Worksheets["Sheet1"];
            Random random = new Random();
            for (int row = 1; row < 11; row++)
            {
                for (int col = 1; col < 11; col++)
                {
                    worksheet.Cells[row, col].Value = random.NextDouble();
                }
            }

            var resultStream = new MemoryStream(package.GetAsByteArray());
            return resultStream;
        }

        static Stream CopyValues(ExcelWorksheet source, ExcelPackage destinationPackage)
        {
            var destination = destinationPackage.Workbook.Worksheets["Sheet2"];
            for (int row = 1; row < source.Dimension.End.Row; row++)
            {
                for(int col = 1; col < source.Dimension.End.Column; col++)
                {
                    destination.Cells[row, col].Value = source.Cells[row, col].Value;
                }
            }

            var resultStream = new MemoryStream(destinationPackage.GetAsByteArray());
            return resultStream;
        }
    }
}