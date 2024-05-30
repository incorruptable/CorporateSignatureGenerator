namespace SignatureBuilder
{
    partial class About
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

        #region Component Section

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// Fuck you, I do what I want - Scott
        /// Mostly because I'm using VS Code and refuse to use your auto-generated code for my stuff! Fear me!
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxAbout = new System.Windows.Forms.RichTextBox();
            this.buttonExit = new System.Windows.Forms.Button();

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "About";


            //Read only Text Box for the About page, detailing the usage of the program.
            this.richTextBoxAbout.Location = new System.Drawing.Point(10, 10);
            this.richTextBoxAbout.Name = "About";
            this.richTextBoxAbout.Size = new System.Drawing.Size(780, 380);
            this.richTextBoxAbout.TabIndex = 0;
            this.richTextBoxAbout.Text = $@"This program will generate signatures from input information as well as Excel Files, CSV files, and Json files. Please make sure that the format for employees follows the format utilized from the top down in the single entry page.";
            this.richTextBoxAbout.ReadOnly = true;


            //Exit button to close the About dialog.
            this.buttonExit.Location = new System.Drawing.Point(710, 400);
            this.buttonExit.Name = "Exit";
            this.buttonExit.Size = new System.Drawing.Size(75, 40);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);


            //Autoscaling Code
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F,16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.richTextBoxAbout);
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxAbout;
        private System.Windows.Forms.Button buttonExit;
    }
}