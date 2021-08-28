using System;
using System.Windows.Forms;

namespace CopyDirectoryUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.COPY_BTN = new System.Windows.Forms.Button();
            this.lblCopyBtn = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // COPY_BTN
            // 
            this.COPY_BTN.Location = new System.Drawing.Point(325, 138);
            this.COPY_BTN.Name = "COPY_BTN";
            this.COPY_BTN.Size = new System.Drawing.Size(157, 63);
            this.COPY_BTN.TabIndex = 0;
            this.COPY_BTN.Text = "Copy Files";
            this.COPY_BTN.UseVisualStyleBackColor = true;
            this.COPY_BTN.Click += new System.EventHandler(this.COPY_BTN_Click);
            // 
            // lblCopyBtn
            // 
            this.lblCopyBtn.AutoSize = true;
            this.lblCopyBtn.Location = new System.Drawing.Point(353, 204);
            this.lblCopyBtn.Name = "lblCopyBtn";
            this.lblCopyBtn.Size = new System.Drawing.Size(82, 20);
            this.lblCopyBtn.TabIndex = 1;
            this.lblCopyBtn.Text = "lblCopyBtn";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(1, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(800, 46);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Click the button below to copy files and folders";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCopyBtn);
            this.Controls.Add(this.COPY_BTN);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button COPY_BTN;
        private System.Windows.Forms.Label lblCopyBtn;
        private TextBox textBox1;
    }
}

