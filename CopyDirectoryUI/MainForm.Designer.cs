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
            this.BTN_COPY = new System.Windows.Forms.Button();
            this.BTN_STOP = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.PROG_COPY = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // BTN_COPY
            // 
            this.BTN_COPY.AutoSize = true;
            this.BTN_COPY.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTN_COPY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BTN_COPY.Font = new System.Drawing.Font("Segoe UI", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.BTN_COPY.Location = new System.Drawing.Point(0, 391);
            this.BTN_COPY.MinimumSize = new System.Drawing.Size(20, 20);
            this.BTN_COPY.Name = "BTN_COPY";
            this.BTN_COPY.Size = new System.Drawing.Size(800, 59);
            this.BTN_COPY.TabIndex = 0;
            this.BTN_COPY.Text = "Copy Files";
            this.BTN_COPY.UseVisualStyleBackColor = false;
            this.BTN_COPY.Click += new System.EventHandler(this.COPY_BTN_Click);
            // 
            // BTN_STOP
            // 
            this.BTN_STOP.AutoSize = true;
            this.BTN_STOP.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTN_STOP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BTN_STOP.Location = new System.Drawing.Point(0, 355);
            this.BTN_STOP.Name = "BTN_STOP";
            this.BTN_STOP.Size = new System.Drawing.Size(800, 36);
            this.BTN_STOP.TabIndex = 5;
            this.BTN_STOP.Text = "Stop Copying";
            this.BTN_STOP.UseVisualStyleBackColor = false;
            this.BTN_STOP.Click += new System.EventHandler(this.BTN_STOP_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(800, 46);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Click the button below to copy files and folders";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox2.Location = new System.Drawing.Point(0, 215);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(800, 111);
            this.textBox2.TabIndex = 4;
            // 
            // PROG_COPY
            // 
            this.PROG_COPY.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PROG_COPY.Location = new System.Drawing.Point(0, 326);
            this.PROG_COPY.Name = "PROG_COPY";
            this.PROG_COPY.Size = new System.Drawing.Size(800, 29);
            this.PROG_COPY.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PROG_COPY);
            this.Controls.Add(this.BTN_STOP);
            this.Controls.Add(this.BTN_COPY);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_COPY;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button BTN_STOP;
        private ProgressBar PROG_COPY;
    }
}

