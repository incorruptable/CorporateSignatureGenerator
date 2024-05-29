namespace SignatureBuilder
{
    partial class BatchProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelFilePath = new System.Windows.Forms.Label();
            this.ButtonBatch = new System.Windows.Forms.Button();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.RichTextBoxFilePath = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // LabelFilePath
            // 
            this.LabelFilePath.AutoSize = true;
            this.LabelFilePath.Location = new System.Drawing.Point(43, 61);
            this.LabelFilePath.Name = "LabelFilePath";
            this.LabelFilePath.Size = new System.Drawing.Size(62, 16);
            this.LabelFilePath.TabIndex = 0;
            this.LabelFilePath.Text = "File Path:";
            // 
            // ButtonBatch
            // 
            this.ButtonBatch.Location = new System.Drawing.Point(164, 95);
            this.ButtonBatch.Name = "ButtonBatch";
            this.ButtonBatch.Size = new System.Drawing.Size(75, 26);
            this.ButtonBatch.TabIndex = 1;
            this.ButtonBatch.Text = "Batch";
            this.ButtonBatch.UseVisualStyleBackColor = true;
            this.ButtonBatch.Click += new System.EventHandler(this.ButtonBatch_Click);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(245, 95);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(75, 26);
            this.ButtonExit.TabIndex = 2;
            this.ButtonExit.Text = "Exit";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(378, 55);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(75, 26);
            this.ButtonBrowse.TabIndex = 3;
            this.ButtonBrowse.Text = "Browse";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // RichTextBoxFilePath
            // 
            this.RichTextBoxFilePath.Location = new System.Drawing.Point(111, 58);
            this.RichTextBoxFilePath.Name = "RichTextBoxFilePath";
            this.RichTextBoxFilePath.Size = new System.Drawing.Size(252, 26);
            this.RichTextBoxFilePath.TabIndex = 4;
            this.RichTextBoxFilePath.Text = "";
            this.RichTextBoxFilePath.TextChanged += new System.EventHandler(this.RichTextBoxFilePath_TextChanged);
            // 
            // BatchProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 193);
            this.Controls.Add(this.RichTextBoxFilePath);
            this.Controls.Add(this.ButtonBrowse);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ButtonBatch);
            this.Controls.Add(this.LabelFilePath);
            this.Name = "BatchProcessing";
            this.Text = "BatchProcessing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelFilePath;
        private System.Windows.Forms.Button ButtonBatch;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.RichTextBox RichTextBoxFilePath;
    }
}
