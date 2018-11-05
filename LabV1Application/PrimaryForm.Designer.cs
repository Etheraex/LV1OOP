namespace LabV1Application
{
    partial class PrimaryForm
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
            this.dgvOrderList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxOrderID = new System.Windows.Forms.TextBox();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExportItem = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnProcessing = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExportList = new System.Windows.Forms.Button();
            this.btnImportList = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrderList
            // 
            this.dgvOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvOrderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderList.Location = new System.Drawing.Point(12, 56);
            this.dgvOrderList.Name = "dgvOrderList";
            this.dgvOrderList.ReadOnly = true;
            this.dgvOrderList.Size = new System.Drawing.Size(787, 290);
            this.dgvOrderList.TabIndex = 0;
            this.dgvOrderList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOrderList_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpDateFrom);
            this.panel1.Controls.Add(this.dtpDateTo);
            this.panel1.Controls.Add(this.cmbState);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBoxOrderID);
            this.panel1.Controls.Add(this.btnResetFilters);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 50);
            this.panel1.TabIndex = 1;
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "Pending",
            "Processing",
            "Complete"});
            this.cmbState.Location = new System.Drawing.Point(392, 16);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(121, 21);
            this.cmbState.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filters:";
            // 
            // txtBoxOrderID
            // 
            this.txtBoxOrderID.Location = new System.Drawing.Point(74, 16);
            this.txtBoxOrderID.MaxLength = 8;
            this.txtBoxOrderID.Name = "txtBoxOrderID";
            this.txtBoxOrderID.Size = new System.Drawing.Size(100, 20);
            this.txtBoxOrderID.TabIndex = 1;
            this.txtBoxOrderID.Text = "OrderID";
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Location = new System.Drawing.Point(721, 14);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(75, 23);
            this.btnResetFilters.TabIndex = 6;
            this.btnResetFilters.Text = "Reset Filters";
            this.btnResetFilters.UseVisualStyleBackColor = true;
            this.btnResetFilters.Click += new System.EventHandler(this.btnResetFilters_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(640, 14);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnExportItem);
            this.panel2.Controls.Add(this.btnComplete);
            this.panel2.Controls.Add(this.btnProcessing);
            this.panel2.Controls.Add(this.btnPending);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Location = new System.Drawing.Point(12, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 23);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "On item:";
            // 
            // btnExportItem
            // 
            this.btnExportItem.Location = new System.Drawing.Point(709, -1);
            this.btnExportItem.Name = "btnExportItem";
            this.btnExportItem.Size = new System.Drawing.Size(75, 23);
            this.btnExportItem.TabIndex = 6;
            this.btnExportItem.Text = "Export to file";
            this.btnExportItem.UseVisualStyleBackColor = true;
            this.btnExportItem.Click += new System.EventHandler(this.btnExportItem_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(562, -1);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(75, 23);
            this.btnComplete.TabIndex = 5;
            this.btnComplete.Text = "->Complete";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnProcessing
            // 
            this.btnProcessing.Location = new System.Drawing.Point(475, -1);
            this.btnProcessing.Name = "btnProcessing";
            this.btnProcessing.Size = new System.Drawing.Size(81, 23);
            this.btnProcessing.TabIndex = 4;
            this.btnProcessing.Text = "->Processing";
            this.btnProcessing.UseVisualStyleBackColor = true;
            this.btnProcessing.Click += new System.EventHandler(this.btnProcessing_Click);
            // 
            // btnPending
            // 
            this.btnPending.Location = new System.Drawing.Point(394, -1);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(75, 23);
            this.btnPending.TabIndex = 3;
            this.btnPending.Text = "->Pending";
            this.btnPending.UseVisualStyleBackColor = true;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(235, -1);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(154, -1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(73, -1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnExportList);
            this.panel3.Controls.Add(this.btnImportList);
            this.panel3.Location = new System.Drawing.Point(12, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(787, 23);
            this.panel3.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "On list:";
            // 
            // btnExportList
            // 
            this.btnExportList.Location = new System.Drawing.Point(154, -1);
            this.btnExportList.Name = "btnExportList";
            this.btnExportList.Size = new System.Drawing.Size(75, 23);
            this.btnExportList.TabIndex = 1;
            this.btnExportList.Text = "Export";
            this.btnExportList.UseVisualStyleBackColor = true;
            this.btnExportList.Click += new System.EventHandler(this.btnExportList_Click);
            // 
            // btnImportList
            // 
            this.btnImportList.Location = new System.Drawing.Point(73, -1);
            this.btnImportList.Name = "btnImportList";
            this.btnImportList.Size = new System.Drawing.Size(75, 23);
            this.btnImportList.TabIndex = 0;
            this.btnImportList.Text = "Import";
            this.btnImportList.UseVisualStyleBackColor = true;
            this.btnImportList.Click += new System.EventHandler(this.btnImportList_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 352);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(811, 60);
            this.panel4.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(12, 29);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(787, 2);
            this.label4.TabIndex = 4;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(180, 16);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.ShowCheckBox = true;
            this.dtpDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpDateFrom.TabIndex = 5;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(286, 16);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.ShowCheckBox = true;
            this.dtpDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpDateTo.TabIndex = 5;
            // 
            // PrimaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(811, 412);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvOrderList);
            this.MaximumSize = new System.Drawing.Size(827, 1080);
            this.MinimumSize = new System.Drawing.Size(827, 450);
            this.Name = "PrimaryForm";
            this.Text = "PrimaryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBoxOrderID;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExportItem;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnProcessing;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExportList;
        private System.Windows.Forms.Button btnImportList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
    }
}

