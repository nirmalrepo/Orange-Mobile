namespace OrangeMobileWinForm
{
    partial class FrmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.btnAddPhone = new System.Windows.Forms.Button();
            this.comboBoxPhoneType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditPhone = new System.Windows.Forms.Button();
            this.btnDeletePhone = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.phoneList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phone Inventory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Items:";
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItems.Location = new System.Drawing.Point(123, 319);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(0, 13);
            this.lblTotalItems.TabIndex = 3;
            // 
            // btnAddPhone
            // 
            this.btnAddPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPhone.ForeColor = System.Drawing.Color.Green;
            this.btnAddPhone.Location = new System.Drawing.Point(374, 74);
            this.btnAddPhone.Name = "btnAddPhone";
            this.btnAddPhone.Size = new System.Drawing.Size(106, 23);
            this.btnAddPhone.TabIndex = 4;
            this.btnAddPhone.Text = "Add Phone";
            this.btnAddPhone.UseVisualStyleBackColor = true;
            // 
            // comboBoxPhoneType
            // 
            this.comboBoxPhoneType.FormattingEnabled = true;
            this.comboBoxPhoneType.Items.AddRange(new object[] {
            "OLD",
            "NEW"});
            this.comboBoxPhoneType.Location = new System.Drawing.Point(247, 76);
            this.comboBoxPhoneType.Name = "comboBoxPhoneType";
            this.comboBoxPhoneType.Size = new System.Drawing.Size(106, 21);
            this.comboBoxPhoneType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(244, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select Type:";
            // 
            // btnEditPhone
            // 
            this.btnEditPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPhone.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btnEditPhone.Location = new System.Drawing.Point(374, 159);
            this.btnEditPhone.Name = "btnEditPhone";
            this.btnEditPhone.Size = new System.Drawing.Size(106, 23);
            this.btnEditPhone.TabIndex = 7;
            this.btnEditPhone.Text = "Edit Details";
            this.btnEditPhone.UseVisualStyleBackColor = true;
            // 
            // btnDeletePhone
            // 
            this.btnDeletePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePhone.ForeColor = System.Drawing.Color.Red;
            this.btnDeletePhone.Location = new System.Drawing.Point(374, 116);
            this.btnDeletePhone.Name = "btnDeletePhone";
            this.btnDeletePhone.Size = new System.Drawing.Size(106, 23);
            this.btnDeletePhone.TabIndex = 8;
            this.btnDeletePhone.Text = "Delete";
            this.btnDeletePhone.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(247, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 66);
            this.button1.TabIndex = 9;
            this.button1.Text = "ORDERS";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(411, 319);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 10;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // phoneList
            // 
            this.phoneList.FormattingEnabled = true;
            this.phoneList.Location = new System.Drawing.Point(46, 74);
            this.phoneList.Name = "phoneList";
            this.phoneList.Size = new System.Drawing.Size(170, 225);
            this.phoneList.TabIndex = 11;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 361);
            this.Controls.Add(this.phoneList);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDeletePhone);
            this.Controls.Add(this.btnEditPhone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPhoneType);
            this.Controls.Add(this.btnAddPhone);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "Orange Mobile - Dashboard";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Button btnAddPhone;
        private System.Windows.Forms.ComboBox comboBoxPhoneType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditPhone;
        private System.Windows.Forms.Button btnDeletePhone;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.ListBox phoneList;
    }
}