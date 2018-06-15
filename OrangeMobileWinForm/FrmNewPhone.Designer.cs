namespace OrangeMobileWinForm
{
    partial class FrmNewPhone
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
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxWarrenty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Warrenty:";
            // 
            // textBoxWarrenty
            // 
            this.textBoxWarrenty.Location = new System.Drawing.Point(108, 299);
            this.textBoxWarrenty.Name = "textBoxWarrenty";
            this.textBoxWarrenty.Size = new System.Drawing.Size(185, 20);
            this.textBoxWarrenty.TabIndex = 15;
            // 
            // FrmNewPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(345, 364);
            this.Controls.Add(this.textBoxWarrenty);
            this.Controls.Add(this.label8);
            this.Name = "FrmNewPhone";
            this.Text = "Orange Mobile - New Product";
            this.Load += new System.EventHandler(this.FrmNewPhone_Load);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.textBoxWarrenty, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxWarrenty;
    }
}
