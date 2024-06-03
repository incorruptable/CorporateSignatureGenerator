using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignatureBuilder;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace SignatureBuilder
{
    internal class Utilities
    {
        internal bool IsValidImg(string imagePath)
        {
            try
            {
                using (Image img = Image.FromFile(imagePath))
                {
                    return true;
                }
            }
            catch (OutOfMemoryException)
            {
                return false;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal bool IsValidUrl(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        internal bool IsValidPhoneNumber(string phoneNumber)
        {
            
                Regex pattern1 = new Regex(@"^\(\d{3}\) \d{3}-\d{4}$");
                Regex pattern2 = new Regex(@"^\d{3}-\d{3}-\d{4}$");
                Regex pattern3 = new Regex(@"^\d{3}.\d{3}.\d{4}$");
                Regex pattern4 = new Regex(@"^{9}$");
            if(phoneNumber.Length == 9 && (pattern1.IsMatch(phoneNumber) || pattern2.IsMatch(phoneNumber) || pattern3.IsMatch(phoneNumber) || pattern4.IsMatch(phoneNumber))){
                return pattern1.IsMatch(phoneNumber) || pattern2.IsMatch(phoneNumber) || pattern3.IsMatch(phoneNumber) || pattern4.IsMatch(phoneNumber);
            }
            else
            {
                return false;
            }
        }

        internal static string GenerateHtml(BatchProcessing.EmployeeData employee)
        {
            string htmlContent = $@"
                <!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Employee Signature</title>
                </head>
                <body>
                    <h1>Employee Signature</h1>
                    <p>Name: {employee.EmployeeName}</p>
                    <p>Title: {employee.EmployeeTitle}</p>
                    <p>License: {employee.EmployeeLicense}</p>
                    <p>Phone: {employee.EmployeePhone}</p>
                    <p>Extension: {employee.EmployeeExt}</p>
                    <p>Email: {employee.EmployeeEmail}</p>
                    <p>Caricature: <img src ="" {employee.EmployeeCaricature}"" alt=""Caricature""></p>
                </body>
                </html>";
            return htmlContent;
        }

        internal static string GeneratePlainText(BatchProcessing.EmployeeData employee)
        {
            string plainTextContent = $@"
                Employee Signature
                Name: {employee.EmployeeName}
                Title: {employee.EmployeeTitle}
                License: {employee.EmployeeLicense}
                Phone: {employee.EmployeePhone}
                Extension: {employee.EmployeeExt}
                Email: {employee.EmployeeEmail}";

            return plainTextContent;
        }

        internal static string GenerateRtf(BatchProcessing.EmployeeData employee)
        {
            // Encode special characters in employee data
            string encodedEmployeeName = EncodeRtfSpecialChars(employee.EmployeeName);
            string encodedEmployeeTitle = EncodeRtfSpecialChars(employee.EmployeeTitle);
            string encodedEmployeeLicense = EncodeRtfSpecialChars(employee.EmployeeLicense);
            string encodedEmployeePhone = EncodeRtfSpecialChars(employee.EmployeePhone);
            string encodedEmployeeExt = EncodeRtfSpecialChars(employee.EmployeeExt);
            string encodedEmployeeEmail = EncodeRtfSpecialChars(employee.EmployeeEmail);
            string encodedEmployeeCaricature = EncodeRtfSpecialChars(employee.EmployeeCaricature);

            // Construct RTF content
            string rtfContent = $@"
            {{\rtf1\ansi\deff0
                {{\fonttbl
                    {{\f0\fnil\fcharset0 Arial;}}
                }}
                \pard\plain\fs20
                \b Employee Signature\par
                \b0 Name: {encodedEmployeeName}\par
                Title: {encodedEmployeeTitle}\par
                License: {encodedEmployeeLicense}\par
                Phone: {encodedEmployeePhone}\par
                Extension: {encodedEmployeeExt}\par
                Email: {encodedEmployeeEmail}\par
                Caricature: \par\pict\jpegblip{encodedEmployeeCaricature}\par
            }}";

            return rtfContent;
        }

        internal static string EncodeRtfSpecialChars(string input)
        {
            // Encode special characters for RTF
            return input.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}");
        }

        public void CreateAndSaveZipFile(string zipPath, List<BatchProcessing.EmployeeData> employees)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);

            try
            {
                foreach(var employee in employees)
                {
                    string employeeDir = Path.Combine(tempDir, employee.EmployeeName);
                    Directory.CreateDirectory(employeeDir);

                    string htmlContent = GenerateHtml(employee);
                    string plainTextContent = GeneratePlainText(employee);
                    string rtfContent = GenerateRtf(employee);

                    File.WriteAllText(Path.Combine(employeeDir, "signature.html"), htmlContent);
                    File.WriteAllText(Path.Combine(employeeDir, "signature.txt"), plainTextContent);
                    File.WriteAllText(Path.Combine(employeeDir, "signature.rtf"), rtfContent);
                }
                ZipFile.CreateFromDirectory(tempDir, zipPath);
            }
            finally
            {
                Directory.Delete(tempDir,true);
            }
        }

        public void CreateSingleSignature(BatchProcessing.EmployeeData employee)
        {
            string sigDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Signatures");
            Directory.CreateDirectory(sigDir);
            string employeeDir = Path.Combine(sigDir, employee.EmployeeName);
            Directory.CreateDirectory(employeeDir);

            string htmlContent = GenerateHtml(employee);
            string plainTextContent = GeneratePlainText(employee);
            string rtfContent = GenerateRtf(employee);

            File.WriteAllText(Path.Combine(employeeDir, "signature.html"), htmlContent);
            File.WriteAllText(Path.Combine(employeeDir, "signature.txt"), plainTextContent);
            File.WriteAllText(Path.Combine(employeeDir, "signature.rtf"), rtfContent);
        }

        static string employeeName (string name = null)
        {
            string sigName = "";
            if (name == null)
            {
                sigName = "";
            }

            return sigName;
        }


        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }

        public static string NumbersOnly(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in input)
            {
                if(char.IsDigit(c))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
    }
}
