using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace SignatureBuilder
{
    public partial class BatchProcessing : Form
    {

        Utilities utilities = new Utilities();
        SaveFileDialog saveFileDialog;

        #region Nested Classes
        public class EmployeeData
        {
            public string EmployeeName { get; set; }
            public string EmployeeTitle { get; set; }
            public string EmployeePhone { get; set; }
            public string EmployeeCaricature { get; set; }
            public string EmployeeLicense { get; set; }
            public string EmployeeExt { get; set; }
            public string EmployeeEmail { get; set; }

            public EmployeeData()
            {
                
            }

            public EmployeeData(string employeeName, string employeeTitle, string employeePhone, string employeeCaricature, string employeeLicense, string employeeExt, string employeeEmail)
            {
                EmployeeName = employeeName;
                EmployeeTitle = employeeTitle;
                EmployeePhone = employeePhone;
                EmployeeCaricature = employeeCaricature;
                EmployeeLicense = employeeLicense;
                EmployeeExt = employeeExt;
                EmployeeEmail = employeeEmail;
            }
        }

        #endregion

        #region Constructors

        public BatchProcessing()
        {
            InitializeComponent();
            saveFileDialog = new SaveFileDialog
            {
                Filter = "ZIP files (*.zip)|*.zip",
                Title = "Save Signature ZIP File"
            };
        }

        #endregion

        #region Event Handlers

        private async void ButtonBatch_Click(object sender, EventArgs e)
        {
            string fileName = RichTextBoxFilePath.Text;
            if (File.Exists(fileName))
            {
                string zipFileName = $"{Path.GetFileNameWithoutExtension(fileName)}.zip";
                string fileExt = Path.GetExtension(fileName);
                List<Task> fileTasks = new List<Task>();
                switch (fileExt)
                {
                    case ".json":
                        await ProcessFileAndCreateZip(fileName, zipFileName, JsonFileOperations);
                        break;
                    case ".csv":
                        await ProcessFileAndCreateZip(fileName, zipFileName, CsvFileOperations);
                        break;
                    case ".xls":
                    case ".xlsx":
                    case ".xlsm":
                        await ProcessFileAndCreateZip(fileName, zipFileName, ExcelFileOperations);
                        break;
                    default:
                        MessageBox.Show($"Unsupported file type: {fileExt}");
                        break;
                }
            }
            else
            {
                MessageBox.Show($"File not found: {fileName}");
            }
        }

        private void RichTextBoxFilePath_TextChanged(object sender, EventArgs e)
        {
            string filePath = RichTextBoxFilePath.Text;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|Excel Files |*.xls;*.xlsx;*.xlsm| JSON Files (.json)|*.json"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxFilePath.Text = openFileDialog.FileName;
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region File Operations

        // Modify to take in the switch casing.
        private async Task<List<EmployeeData>> JsonFileOperations(string filePath)
        {
            try
            {
                string jsonString = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<List<EmployeeData>>(jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading JSON file: {ex.Message}");
                return new List<EmployeeData>();
            }
        }

        private async Task<List<EmployeeData>> CsvFileOperations(string filePath)
        {
                var employees = new List<EmployeeData>();
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string csvLine;
                        while ((csvLine = await reader.ReadLineAsync()) != null)
                        {
                            string[] fields = csvLine.Split('.');

                            if (fields.Length < 7)
                            {
                                MessageBox.Show("Issue parsing Employee from CSV. File format is incorrect.");
                                return new List<EmployeeData>();
                            }

                            EmployeeData employeeData = new EmployeeData()
                            {
                                EmployeeName = fields[0],
                                EmployeeTitle = fields[1],
                                EmployeeLicense = fields[2],
                                EmployeeCaricature = fields[3],
                                EmployeePhone = fields[4],
                                EmployeeExt = fields[5],
                                EmployeeEmail = fields[6],
                            };

                            employees.Add(employeeData);
                        }
                    }
                    MessageBox.Show($"File '{filePath}' finished processing.");
                    return employees;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error has occurred: {ex.Message}");
                    return new List<EmployeeData>();
                }
        }

        private async Task<List<EmployeeData>> ExcelFileOperations(string filePath)
        {
            var employees = new List<EmployeeData>();
            await Task.Run(() =>
                {
                    Excel.Application excelApp = null;
                    Excel.Workbook workbook = null;
                    Excel.Worksheet worksheet = null;
                    Excel.Range usedRange = null;
                    try
                    {
                        excelApp = new Excel.Application();
                        workbook = excelApp.Workbooks.Open(filePath);
                        worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                        usedRange = worksheet.UsedRange;

                        for (int row = 2; row <= usedRange.Rows.Count; row++)
                        {
                            EmployeeData employeeData = new EmployeeData();
                            for (int col = 1; col <= usedRange.Columns.Count; col++)
                            {
                                string cellValue = Convert.ToString((usedRange.Cells[row, col] as Excel.Range).Value2);

                                switch (col)
                                {
                                    case 1:
                                        employeeData.EmployeeName = cellValue;
                                        break;
                                    case 2:
                                        employeeData.EmployeeTitle = cellValue;
                                        break;
                                    case 3:
                                        employeeData.EmployeeLicense = cellValue;
                                        break;
                                    case 7:
                                        if(utilities.IsValidImg(cellValue))
                                            employeeData.EmployeeCaricature = cellValue;
                                        else employeeData.EmployeeCaricature = "";
                                        break;
                                    case 5:
                                        if (utilities.IsValidPhoneNumber(cellValue))
                                            employeeData.EmployeePhone = cellValue;
                                        else{
                                            employeeData.EmployeePhone = Utilities.NumbersOnly(cellValue);
                                        }
                                        break;
                                    case 6:
                                        employeeData.EmployeeExt = cellValue;
                                        break;
                                    case 4:
                                        if (!utilities.IsValidUrl(cellValue))
                                            employeeData.EmployeeEmail = cellValue;
                                        break;
                                }

                            }
                            if(!string.IsNullOrEmpty(employeeData.EmployeeName))
                            {
                                employees.Add(employeeData);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error reading Excel File: {ex.Message}");
                    }
                    finally
                    {
                        if (workbook != null)
                        {
                            workbook.Close(false);
                            Marshal.ReleaseComObject(workbook);
                        }
                        if (excelApp != null)
                        {
                            excelApp.Quit();
                            Marshal.ReleaseComObject(excelApp);
                        }
                        if (usedRange != null) Marshal.ReleaseComObject(usedRange);
                        if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                    }
                });
            return employees;
        }

        private async Task ProcessFileAndCreateZip(string filePath, string zipFilePath, Func<string, Task<List<EmployeeData>>> fileProcessor)
        {
            List<EmployeeData> employees = await fileProcessor(filePath);
            if(employees != null && employees.Count > 0)
            {
                utilities.CreateAndSaveZipFile(zipFilePath, employees);
                MessageBox.Show("ZIP created.");
            }
            else
            {
                MessageBox.Show("No employee data found to be processed.");
            }
        }

        #endregion
    }
}