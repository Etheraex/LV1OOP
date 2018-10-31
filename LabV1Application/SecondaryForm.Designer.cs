namespace LabV1Application
{
    partial class SecondaryForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtBoxOrderDate = new System.Windows.Forms.TextBox();
            this.txtBoxOrderID = new System.Windows.Forms.TextBox();
            this.txtBoxDateRequired = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxShipVia = new System.Windows.Forms.TextBox();
            this.txtBoxDateShipped = new System.Windows.Forms.TextBox();
            this.txtBoxFreightCharges = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rchTxtBoxCustomer = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ACME Corporation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 52);
            this.label2.TabIndex = 1;
            this.label2.Text = "1223 First Street\r\nMountain View, CA 94040\r\n(650) 555-3445\r\nwww.acme.com";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(138, 96);
            this.panel1.TabIndex = 2;
            // 
            // lblOrderId
            // 
            this.lblOrderId.BackColor = System.Drawing.Color.DarkKhaki;
            this.lblOrderId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderId.ForeColor = System.Drawing.Color.DimGray;
            this.lblOrderId.Location = new System.Drawing.Point(229, 10);
            this.lblOrderId.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(80, 30);
            this.lblOrderId.TabIndex = 3;
            this.lblOrderId.Text = "Order ID";
            this.lblOrderId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkKhaki;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(309, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 10, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Order Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblOrderId);
            this.panel2.Controls.Add(this.txtBoxOrderDate);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.txtBoxOrderID);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 123);
            this.panel2.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pending",
            "Processing",
            "Complete"});
            this.comboBox1.Location = new System.Drawing.Point(328, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // txtBoxOrderDate
            // 
            this.txtBoxOrderDate.Location = new System.Drawing.Point(309, 39);
            this.txtBoxOrderDate.Name = "txtBoxOrderDate";
            this.txtBoxOrderDate.Size = new System.Drawing.Size(140, 20);
            this.txtBoxOrderDate.TabIndex = 11;
            this.txtBoxOrderDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxOrderID
            // 
            this.txtBoxOrderID.Location = new System.Drawing.Point(229, 39);
            this.txtBoxOrderID.MaxLength = 8;
            this.txtBoxOrderID.Name = "txtBoxOrderID";
            this.txtBoxOrderID.Size = new System.Drawing.Size(80, 20);
            this.txtBoxOrderID.TabIndex = 11;
            this.txtBoxOrderID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxDateRequired
            // 
            this.txtBoxDateRequired.Location = new System.Drawing.Point(9, 43);
            this.txtBoxDateRequired.Margin = new System.Windows.Forms.Padding(0);
            this.txtBoxDateRequired.Name = "txtBoxDateRequired";
            this.txtBoxDateRequired.Size = new System.Drawing.Size(110, 20);
            this.txtBoxDateRequired.TabIndex = 11;
            this.txtBoxDateRequired.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DarkKhaki;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(9, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(0, 10, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Date Required";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtBoxDateRequired);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtBoxShipVia);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtBoxDateShipped);
            this.panel3.Controls.Add(this.txtBoxFreightCharges);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(463, 83);
            this.panel3.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkKhaki;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(119, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 30);
            this.label5.TabIndex = 3;
            this.label5.Text = "Date Shipped";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkKhaki;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(340, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 10, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 30);
            this.label6.TabIndex = 3;
            this.label6.Text = "Freight Charges";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBoxShipVia
            // 
            this.txtBoxShipVia.Location = new System.Drawing.Point(229, 43);
            this.txtBoxShipVia.Margin = new System.Windows.Forms.Padding(0);
            this.txtBoxShipVia.Name = "txtBoxShipVia";
            this.txtBoxShipVia.Size = new System.Drawing.Size(111, 20);
            this.txtBoxShipVia.TabIndex = 11;
            this.txtBoxShipVia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxDateShipped
            // 
            this.txtBoxDateShipped.Location = new System.Drawing.Point(119, 43);
            this.txtBoxDateShipped.Margin = new System.Windows.Forms.Padding(0);
            this.txtBoxDateShipped.Name = "txtBoxDateShipped";
            this.txtBoxDateShipped.Size = new System.Drawing.Size(110, 20);
            this.txtBoxDateShipped.TabIndex = 11;
            this.txtBoxDateShipped.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBoxFreightCharges
            // 
            this.txtBoxFreightCharges.Location = new System.Drawing.Point(340, 43);
            this.txtBoxFreightCharges.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.txtBoxFreightCharges.Name = "txtBoxFreightCharges";
            this.txtBoxFreightCharges.Size = new System.Drawing.Size(111, 20);
            this.txtBoxFreightCharges.TabIndex = 11;
            this.txtBoxFreightCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkKhaki;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(229, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 30);
            this.label7.TabIndex = 3;
            this.label7.Text = "Ship Via";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkKhaki;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(9, 219);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(442, 30);
            this.label8.TabIndex = 3;
            this.label8.Text = "Customer";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rchTxtBoxCustomer
            // 
            this.rchTxtBoxCustomer.Location = new System.Drawing.Point(9, 248);
            this.rchTxtBoxCustomer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 3);
            this.rchTxtBoxCustomer.Name = "rchTxtBoxCustomer";
            this.rchTxtBoxCustomer.Size = new System.Drawing.Size(442, 84);
            this.rchTxtBoxCustomer.TabIndex = 13;
            this.rchTxtBoxCustomer.Text = "";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Order Items";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 368);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(442, 171);
            this.dataGridView1.TabIndex = 15;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(9, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(376, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOK);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 545);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(463, 45);
            this.panel4.TabIndex = 17;
            // 
            // SecondaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(463, 590);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.rchTxtBoxCustomer);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.MaximumSize = new System.Drawing.Size(479, 1080);
            this.MinimumSize = new System.Drawing.Size(479, 628);
            this.Name = "SecondaryForm";
            this.Text = "SecondaryForm";
            this.Load += new System.EventHandler(this.SecondaryForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOrderId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBoxOrderDate;
        private System.Windows.Forms.TextBox txtBoxOrderID;
        private System.Windows.Forms.TextBox txtBoxDateRequired;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxShipVia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxFreightCharges;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxDateShipped;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox rchTxtBoxCustomer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel4;
    }
}