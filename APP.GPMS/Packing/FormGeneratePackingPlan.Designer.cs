
namespace APP.GPMS.Packing
{
    partial class FormGeneratePackingPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panelActionControl = new System.Windows.Forms.Panel();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.checkBoxQtyValidate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.dataGridViewPackingPlan = new System.Windows.Forms.DataGridView();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.PackPlanStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarcodeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackQtyStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabelStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Path = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSuccess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowseProcessedPath = new System.Windows.Forms.Button();
            this.txtProcessedPath = new System.Windows.Forms.TextBox();
            this.btnBowseSourcePath = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelHeading = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelContainer.SuspendLayout();
            this.panelActionControl.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackingPlan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.Controls.Add(this.buttonClear);
            this.panelContainer.Controls.Add(this.panelActionControl);
            this.panelContainer.Controls.Add(this.checkBoxQtyValidate);
            this.panelContainer.Controls.Add(this.groupBox2);
            this.panelContainer.Controls.Add(this.label2);
            this.panelContainer.Controls.Add(this.groupBox1);
            this.panelContainer.Controls.Add(this.comboBoxCustomer);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 38);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1012, 475);
            this.panelContainer.TabIndex = 126;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonClear.Location = new System.Drawing.Point(858, 10);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(132, 25);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "CLEAR";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panelActionControl
            // 
            this.panelActionControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelActionControl.Controls.Add(this.buttonProcess);
            this.panelActionControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActionControl.Location = new System.Drawing.Point(0, 418);
            this.panelActionControl.Name = "panelActionControl";
            this.panelActionControl.Size = new System.Drawing.Size(1012, 57);
            this.panelActionControl.TabIndex = 151;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProcess.Enabled = false;
            this.buttonProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProcess.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonProcess.Location = new System.Drawing.Point(439, 17);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(132, 25);
            this.buttonProcess.TabIndex = 2;
            this.buttonProcess.Text = "PROCESS";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // checkBoxQtyValidate
            // 
            this.checkBoxQtyValidate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxQtyValidate.AutoSize = true;
            this.checkBoxQtyValidate.Checked = true;
            this.checkBoxQtyValidate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxQtyValidate.Location = new System.Drawing.Point(360, 15);
            this.checkBoxQtyValidate.Name = "checkBoxQtyValidate";
            this.checkBoxQtyValidate.Size = new System.Drawing.Size(163, 17);
            this.checkBoxQtyValidate.TabIndex = 33;
            this.checkBoxQtyValidate.Text = "Validate PackQty and POQty";
            this.checkBoxQtyValidate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox2.Controls.Add(this.chbSelectAll);
            this.groupBox2.Controls.Add(this.dataGridViewPackingPlan);
            this.groupBox2.Location = new System.Drawing.Point(19, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(974, 265);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available File(s)";
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(6, 27);
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chbSelectAll.TabIndex = 36;
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // dataGridViewPackingPlan
            // 
            this.dataGridViewPackingPlan.AllowUserToAddRows = false;
            this.dataGridViewPackingPlan.AllowUserToDeleteRows = false;
            this.dataGridViewPackingPlan.AllowUserToResizeColumns = false;
            this.dataGridViewPackingPlan.AllowUserToResizeRows = false;
            this.dataGridViewPackingPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPackingPlan.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPackingPlan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPackingPlan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewPackingPlan.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridViewPackingPlan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPackingPlan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPackingPlan.ColumnHeadersHeight = 40;
            this.dataGridViewPackingPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPackingPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox,
            this.FileName,
            this.Verified,
            this.Status,
            this.PackPlanStatus,
            this.BarcodeStatus,
            this.PackQtyStatus,
            this.LabelStatus,
            this.Description,
            this.Path,
            this.PONo,
            this.IsSuccess});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPackingPlan.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewPackingPlan.EnableHeadersVisualStyles = false;
            this.dataGridViewPackingPlan.GridColor = System.Drawing.Color.DimGray;
            this.dataGridViewPackingPlan.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewPackingPlan.Name = "dataGridViewPackingPlan";
            this.dataGridViewPackingPlan.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPackingPlan.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewPackingPlan.RowHeadersVisible = false;
            this.dataGridViewPackingPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPackingPlan.Size = new System.Drawing.Size(968, 238);
            this.dataGridViewPackingPlan.TabIndex = 37;
            // 
            // checkbox
            // 
            this.checkbox.Frozen = true;
            this.checkbox.HeaderText = "";
            this.checkbox.Name = "checkbox";
            this.checkbox.Width = 20;
            // 
            // FileName
            // 
            this.FileName.Frozen = true;
            this.FileName.HeaderText = "File Name";
            this.FileName.MinimumWidth = 300;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 300;
            // 
            // Verified
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Verified.DefaultCellStyle = dataGridViewCellStyle2;
            this.Verified.HeaderText = "Verified";
            this.Verified.MinimumWidth = 60;
            this.Verified.Name = "Verified";
            this.Verified.ReadOnly = true;
            this.Verified.Width = 60;
            // 
            // Status
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Status.DefaultCellStyle = dataGridViewCellStyle3;
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 50;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Status.Width = 50;
            // 
            // PackPlanStatus
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PackPlanStatus.DefaultCellStyle = dataGridViewCellStyle4;
            this.PackPlanStatus.HeaderText = "Pack Plan Added";
            this.PackPlanStatus.MinimumWidth = 75;
            this.PackPlanStatus.Name = "PackPlanStatus";
            this.PackPlanStatus.ReadOnly = true;
            this.PackPlanStatus.Width = 75;
            // 
            // BarcodeStatus
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.BarcodeStatus.DefaultCellStyle = dataGridViewCellStyle5;
            this.BarcodeStatus.HeaderText = "Barcode Gen.";
            this.BarcodeStatus.MinimumWidth = 65;
            this.BarcodeStatus.Name = "BarcodeStatus";
            this.BarcodeStatus.ReadOnly = true;
            this.BarcodeStatus.Width = 65;
            // 
            // PackQtyStatus
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PackQtyStatus.DefaultCellStyle = dataGridViewCellStyle6;
            this.PackQtyStatus.HeaderText = "Pack Qty";
            this.PackQtyStatus.MinimumWidth = 55;
            this.PackQtyStatus.Name = "PackQtyStatus";
            this.PackQtyStatus.ReadOnly = true;
            this.PackQtyStatus.Width = 55;
            // 
            // LabelStatus
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.LabelStatus.DefaultCellStyle = dataGridViewCellStyle7;
            this.LabelStatus.HeaderText = "Label Gen.";
            this.LabelStatus.MinimumWidth = 60;
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.ReadOnly = true;
            this.LabelStatus.Width = 60;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.DefaultCellStyle = dataGridViewCellStyle8;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Path
            // 
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            this.Path.ReadOnly = true;
            this.Path.Visible = false;
            // 
            // PONo
            // 
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.PONo.DefaultCellStyle = dataGridViewCellStyle9;
            this.PONo.HeaderText = "PO #";
            this.PONo.Name = "PONo";
            this.PONo.ReadOnly = true;
            // 
            // IsSuccess
            // 
            this.IsSuccess.HeaderText = "IsSuccess";
            this.IsSuccess.Name = "IsSuccess";
            this.IsSuccess.ReadOnly = true;
            this.IsSuccess.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Select Customer";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.btnBrowseProcessedPath);
            this.groupBox1.Controls.Add(this.txtProcessedPath);
            this.groupBox1.Controls.Add(this.btnBowseSourcePath);
            this.groupBox1.Controls.Add(this.txtSourcePath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(19, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(971, 84);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select File(s)";
            // 
            // btnBrowseProcessedPath
            // 
            this.btnBrowseProcessedPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseProcessedPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseProcessedPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnBrowseProcessedPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.btnBrowseProcessedPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseProcessedPath.Location = new System.Drawing.Point(911, 53);
            this.btnBrowseProcessedPath.Name = "btnBrowseProcessedPath";
            this.btnBrowseProcessedPath.Size = new System.Drawing.Size(37, 22);
            this.btnBrowseProcessedPath.TabIndex = 28;
            this.btnBrowseProcessedPath.Text = "//..";
            this.btnBrowseProcessedPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowseProcessedPath.UseVisualStyleBackColor = true;
            this.btnBrowseProcessedPath.Click += new System.EventHandler(this.btnBrowseProcessedPath_Click);
            // 
            // txtProcessedPath
            // 
            this.txtProcessedPath.BackColor = System.Drawing.Color.White;
            this.txtProcessedPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcessedPath.Location = new System.Drawing.Point(145, 53);
            this.txtProcessedPath.Name = "txtProcessedPath";
            this.txtProcessedPath.ReadOnly = true;
            this.txtProcessedPath.Size = new System.Drawing.Size(765, 22);
            this.txtProcessedPath.TabIndex = 24;
            // 
            // btnBowseSourcePath
            // 
            this.btnBowseSourcePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBowseSourcePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBowseSourcePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBowseSourcePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.btnBowseSourcePath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBowseSourcePath.Location = new System.Drawing.Point(911, 25);
            this.btnBowseSourcePath.Name = "btnBowseSourcePath";
            this.btnBowseSourcePath.Size = new System.Drawing.Size(37, 22);
            this.btnBowseSourcePath.TabIndex = 27;
            this.btnBowseSourcePath.Text = "//..";
            this.btnBowseSourcePath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBowseSourcePath.UseVisualStyleBackColor = true;
            this.btnBowseSourcePath.Click += new System.EventHandler(this.btnBowseSourcePath_Click);
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.BackColor = System.Drawing.Color.White;
            this.txtSourcePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourcePath.Location = new System.Drawing.Point(145, 25);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.ReadOnly = true;
            this.txtSourcePath.Size = new System.Drawing.Size(765, 22);
            this.txtSourcePath.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Destination File Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Source File Path";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBoxCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.comboBoxCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(113, 13);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(205, 21);
            this.comboBoxCustomer.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.labelHeading);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 38);
            this.panel1.TabIndex = 125;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Maroon;
            this.buttonClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonClose.Location = new System.Drawing.Point(985, 1);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(25, 25);
            this.buttonClose.TabIndex = 32;
            this.buttonClose.TabStop = false;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelHeading
            // 
            this.labelHeading.BackColor = System.Drawing.Color.Transparent;
            this.labelHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeading.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.labelHeading.Location = new System.Drawing.Point(0, 0);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new System.Drawing.Size(1012, 37);
            this.labelHeading.TabIndex = 26;
            this.labelHeading.Text = "PACKING PLAN";
            this.labelHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1012, 1);
            this.label1.TabIndex = 33;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormGeneratePackingPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1012, 513);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGeneratePackingPlan";
            this.Load += new System.EventHandler(this.FormGeneratePackingPlan_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.panelActionControl.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPackingPlan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelContainer;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelHeading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxQtyValidate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chbSelectAll;
        private System.Windows.Forms.DataGridView dataGridViewPackingPlan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowseProcessedPath;
        private System.Windows.Forms.TextBox txtProcessedPath;
        private System.Windows.Forms.Button btnBowseSourcePath;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        public System.Windows.Forms.Panel panelActionControl;
        public System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Verified;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackPlanStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn BarcodeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackQtyStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn LabelStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Path;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSuccess;
        public System.Windows.Forms.Button buttonClear;
    }
}