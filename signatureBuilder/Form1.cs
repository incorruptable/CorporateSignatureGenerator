﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SignatureBuilder;

namespace SignatureBuilder
{
    public partial class Form1 : Form
    {
        Utilities utilities = new Utilities();
        private SaveFileDialog saveFileDialog;


        public Form1()
        {
            InitializeComponent();

            saveFileDialog = new SaveFileDialog()
            {
                Filter = "ZIP files (*.zip)|*.zip",
                Title = "Save output ZIP file"
            };
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string employeeName = richTextBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BatchProcessing batchProcessingForm = new BatchProcessing();
            batchProcessingForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SingleProcessInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            string employeeTitle = richTextBox2.Text;
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            string employeeLicense = richTextBox3.Text;
        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            string employeeEmail = richTextBox4.Text;
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {
            string employeeExtension = richTextBox6.Text;
        }

        private void richTextBox6_TextChanged(object sender, EventArgs e)
        {
            string employeePhone = richTextBox5.Text;
        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {
            string employeeURL = richTextBox7.Text;
        }

        internal void SingleProcessInfo()
        {
            string name = richTextBox1.Text;
            string title = richTextBox2.Text;
            string empLicense = richTextBox3.Text;
            string email = richTextBox4.Text;
            string extension = richTextBox6.Text;
            string phone = richTextBox5.Text;
            string url = richTextBox7.Text;

            // Validate user input
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(extension) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please ensure that all required fields are filled out.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate URL format
            if (!utilities.IsValidUrl(url) && (url != "" || url != null))
            {
                MessageBox.Show("Please enter a valid URL.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate phone number format
            var (isValid, formattedPhoneNumber) = Utilities.IsValidPhoneNumber(phone);
            if (!isValid)
            {
                MessageBox.Show("Please enter a valid phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create employee data
            BatchProcessing.EmployeeData employee = new BatchProcessing.EmployeeData
            {
                EmployeeName = name,
                EmployeeTitle = title,
                EmployeeLicense = empLicense,
                EmployeeEmail = email,
                EmployeeExt = extension,
                EmployeePhone = formattedPhoneNumber,
                EmployeeCaricature = url
            };

            // Create and save Signature files
            utilities.CreateSingleSignature(employee, checkBox1.Checked, saveFileDialog);
        }


        internal void ProcessInfo()
        {
            string name = richTextBox1.Text;
            string title = richTextBox2.Text;
            string empLicense = richTextBox3.Text;
            string email = richTextBox4.Text;
            string extension = richTextBox6.Text;
            string phone = richTextBox5.Text;
            string url = richTextBox7.Text;

            // Validate user input
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(extension) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please ensure that all required fields are filled out.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrWhiteSpace(url)) 
            {
                if (!utilities.IsValidUrl(url) && (url != "" || url != null))
                {
                    MessageBox.Show("Please enter a valid URL.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
            }
            var (isValid, formattedPhoneNumber) = Utilities.IsValidPhoneNumber(phone);
            if (!isValid)
            {
                MessageBox.Show("Please enter a valid phone number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog.FileName;

                BatchProcessing.EmployeeData employee = new BatchProcessing.EmployeeData
                {
                    EmployeeName = name,
                    EmployeeTitle = title,
                    EmployeeLicense = empLicense,
                    EmployeeEmail = email,
                    EmployeeExt = extension,
                    EmployeePhone = formattedPhoneNumber,
                    EmployeeCaricature = url
                };

                utilities.CreateAndSaveZipFile(savePath, new List<BatchProcessing.EmployeeData> { employee });
                MessageBox.Show("ZIP file created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBox1.Checked;

            if (isChecked)
            {

            }
            else
            {
                
            }
        }
    }
}
