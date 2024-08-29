using System;

namespace SignatureBuilder
{
    partial class Form1
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            buttonAbout = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox3 = new RichTextBox();
            richTextBox4 = new RichTextBox();
            richTextBox5 = new RichTextBox();
            richTextBox6 = new RichTextBox();
            richTextBox7 = new RichTextBox();
            label1 = new Label();
            colorDialog1 = new ColorDialog();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(136, 228);
            button1.Name = "button1";
            button1.Size = new Size(66, 38);
            button1.TabIndex = 0;
            button1.Text = "Batch";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(66, 228);
            button2.Name = "button2";
            button2.Size = new Size(66, 38);
            button2.TabIndex = 1;
            button2.Text = "Submit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(278, 228);
            button3.Name = "button3";
            button3.Size = new Size(66, 38);
            button3.TabIndex = 2;
            button3.Text = "Exit";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // buttonAbout
            // 
            buttonAbout.Location = new Point(207, 228);
            buttonAbout.Name = "buttonAbout";
            buttonAbout.Size = new Size(70, 38);
            buttonAbout.TabIndex = 3;
            buttonAbout.Text = "About";
            buttonAbout.UseVisualStyleBackColor = true;
            buttonAbout.Click += buttonAbout_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(96, 29);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(221, 25);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(96, 57);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(221, 25);
            richTextBox2.TabIndex = 9;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(96, 85);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(221, 25);
            richTextBox3.TabIndex = 10;
            richTextBox3.Text = "";
            richTextBox3.TextChanged += richTextBox3_TextChanged;
            // 
            // richTextBox4
            // 
            richTextBox4.Location = new Point(96, 113);
            richTextBox4.Name = "richTextBox4";
            richTextBox4.Size = new Size(221, 25);
            richTextBox4.TabIndex = 11;
            richTextBox4.Text = "";
            richTextBox4.TextChanged += richTextBox4_TextChanged;
            // 
            // richTextBox5
            // 
            richTextBox5.Location = new Point(96, 141);
            richTextBox5.Name = "richTextBox5";
            richTextBox5.Size = new Size(106, 25);
            richTextBox5.TabIndex = 13;
            richTextBox5.Text = "";
            richTextBox5.TextChanged += richTextBox6_TextChanged;
            // 
            // richTextBox6
            // 
            richTextBox6.Location = new Point(241, 141);
            richTextBox6.Name = "richTextBox6";
            richTextBox6.Size = new Size(76, 25);
            richTextBox6.TabIndex = 12;
            richTextBox6.Text = "";
            richTextBox6.TextChanged += richTextBox5_TextChanged;
            // 
            // richTextBox7
            // 
            richTextBox7.Location = new Point(96, 169);
            richTextBox7.Name = "richTextBox7";
            richTextBox7.Size = new Size(221, 25);
            richTextBox7.TabIndex = 14;
            richTextBox7.Text = "";
            richTextBox7.TextChanged += richTextBox7_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 32);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 5;
            label1.Text = "Name: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 60);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 6;
            label2.Text = "Title: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 88);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 7;
            label3.Text = "License: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 116);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 8;
            label4.Text = "Email: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 144);
            label5.Name = "label5";
            label5.Size = new Size(47, 15);
            label5.TabIndex = 16;
            label5.Text = "Phone: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(207, 144);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 15;
            label6.Text = "Ext: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(33, 172);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 17;
            label7.Text = "URL: ";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(96, 200);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(113, 19);
            checkBox1.TabIndex = 18;
            checkBox1.Text = "Developer Mode";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 287);
            Controls.Add(checkBox1);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(richTextBox7);
            Controls.Add(richTextBox5);
            Controls.Add(richTextBox6);
            Controls.Add(richTextBox4);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(buttonAbout);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Signature Generator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.RichTextBox richTextBox5;
        private System.Windows.Forms.RichTextBox richTextBox6;
        private System.Windows.Forms.RichTextBox richTextBox7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CheckBox checkBox1;
    }
}

