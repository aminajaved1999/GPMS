
namespace APP.GPMS
{
    partial class FormGeneralLookup
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGeneralLookup));
            this.backgroundWorkerPOPUP = new System.ComponentModel.BackgroundWorker();
            this.labelPlaceHolderText = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelTotalCount = new System.Windows.Forms.Label();
            this.labelOf = new System.Windows.Forms.Label();
            this.labelSelect = new System.Windows.Forms.Label();
            this.panelBottomSelectIndex = new System.Windows.Forms.Panel();
            this.dataGridViewCollectionDisplay = new System.Windows.Forms.DataGridView();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowSelect = new System.Windows.Forms.DataGridViewImageColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelShowingPageStatus = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelBottomSelectIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollectionDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerPOPUP
            // 
            this.backgroundWorkerPOPUP.WorkerReportsProgress = true;
            this.backgroundWorkerPOPUP.WorkerSupportsCancellation = true;
            this.backgroundWorkerPOPUP.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPOPUP_DoWork);
            this.backgroundWorkerPOPUP.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPOPUP_RunWorkerCompleted);
            // 
            // labelPlaceHolderText
            // 
            this.labelPlaceHolderText.AutoSize = true;
            this.labelPlaceHolderText.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlaceHolderText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.labelPlaceHolderText.Location = new System.Drawing.Point(21, 46);
            this.labelPlaceHolderText.Name = "labelPlaceHolderText";
            this.labelPlaceHolderText.Size = new System.Drawing.Size(143, 13);
            this.labelPlaceHolderText.TabIndex = 210;
            this.labelPlaceHolderText.Text = "* Search Column 2 / Column 3";
            this.labelPlaceHolderText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.Image = global::APP.GPMS.Properties.Resources.icons8_search_48__1_;
            this.pictureBox4.Location = new System.Drawing.Point(441, 27);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(23, 18);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 16;
            this.pictureBox4.TabStop = false;
            // 
            // dataGridViewImageColumn1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewImageColumn1.HeaderText = "Select";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.BackColor = System.Drawing.Color.White;
            this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSearch.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxSearch.Location = new System.Drawing.Point(10, 23);
            this.textBoxSearch.MaxLength = 100;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(456, 26);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelPlaceHolderText);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(476, 63);
            this.panel1.TabIndex = 170;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Search";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(449, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 211;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelTotalCount
            // 
            this.labelTotalCount.AutoSize = true;
            this.labelTotalCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelTotalCount.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalCount.ForeColor = System.Drawing.Color.Black;
            this.labelTotalCount.Location = new System.Drawing.Point(64, 0);
            this.labelTotalCount.Name = "labelTotalCount";
            this.labelTotalCount.Size = new System.Drawing.Size(33, 15);
            this.labelTotalCount.TabIndex = 105;
            this.labelTotalCount.Text = "Total";
            // 
            // labelOf
            // 
            this.labelOf.AutoSize = true;
            this.labelOf.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelOf.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOf.Location = new System.Drawing.Point(40, 0);
            this.labelOf.Name = "labelOf";
            this.labelOf.Size = new System.Drawing.Size(24, 15);
            this.labelOf.TabIndex = 104;
            this.labelOf.Text = " of ";
            // 
            // labelSelect
            // 
            this.labelSelect.AutoSize = true;
            this.labelSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSelect.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelect.ForeColor = System.Drawing.Color.Black;
            this.labelSelect.Location = new System.Drawing.Point(0, 0);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(40, 15);
            this.labelSelect.TabIndex = 103;
            this.labelSelect.Text = "Select";
            // 
            // panelBottomSelectIndex
            // 
            this.panelBottomSelectIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelBottomSelectIndex.Controls.Add(this.labelTotalCount);
            this.panelBottomSelectIndex.Controls.Add(this.labelOf);
            this.panelBottomSelectIndex.Controls.Add(this.labelSelect);
            this.panelBottomSelectIndex.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomSelectIndex.Location = new System.Drawing.Point(0, 380);
            this.panelBottomSelectIndex.Name = "panelBottomSelectIndex";
            this.panelBottomSelectIndex.Size = new System.Drawing.Size(476, 17);
            this.panelBottomSelectIndex.TabIndex = 172;
            // 
            // dataGridViewCollectionDisplay
            // 
            this.dataGridViewCollectionDisplay.AllowUserToAddRows = false;
            this.dataGridViewCollectionDisplay.AllowUserToDeleteRows = false;
            this.dataGridViewCollectionDisplay.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewCollectionDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCollectionDisplay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridViewCollectionDisplay.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCollectionDisplay.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCollectionDisplay.ColumnHeadersHeight = 25;
            this.dataGridViewCollectionDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCollectionDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.RowID,
            this.RowCode,
            this.RowName,
            this.ExtraColumn,
            this.RowSelect});
            this.dataGridViewCollectionDisplay.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCollectionDisplay.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewCollectionDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCollectionDisplay.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewCollectionDisplay.EnableHeadersVisualStyles = false;
            this.dataGridViewCollectionDisplay.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewCollectionDisplay.Location = new System.Drawing.Point(0, 88);
            this.dataGridViewCollectionDisplay.MultiSelect = false;
            this.dataGridViewCollectionDisplay.Name = "dataGridViewCollectionDisplay";
            this.dataGridViewCollectionDisplay.ReadOnly = true;
            this.dataGridViewCollectionDisplay.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewCollectionDisplay.RowHeadersVisible = false;
            this.dataGridViewCollectionDisplay.RowHeadersWidth = 20;
            this.dataGridViewCollectionDisplay.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewCollectionDisplay.RowTemplate.ReadOnly = true;
            this.dataGridViewCollectionDisplay.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCollectionDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCollectionDisplay.ShowCellErrors = false;
            this.dataGridViewCollectionDisplay.ShowEditingIcon = false;
            this.dataGridViewCollectionDisplay.ShowRowErrors = false;
            this.dataGridViewCollectionDisplay.Size = new System.Drawing.Size(476, 292);
            this.dataGridViewCollectionDisplay.TabIndex = 171;
            this.dataGridViewCollectionDisplay.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCollectionDisplay_CellClick);
            this.dataGridViewCollectionDisplay.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCollectionDisplay_CellDoubleClick);
            this.dataGridViewCollectionDisplay.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCollectionDisplay_CellMouseEnter);
            this.dataGridViewCollectionDisplay.SelectionChanged += new System.EventHandler(this.dataGridViewCollectionDisplay_SelectionChanged);
            this.dataGridViewCollectionDisplay.Sorted += new System.EventHandler(this.dataGridViewCollectionDisplay_Sorted);
            this.dataGridViewCollectionDisplay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewCollectionDisplay_KeyDown);
            // 
            // SrNo
            // 
            this.SrNo.Frozen = true;
            this.SrNo.HeaderText = "Sr #";
            this.SrNo.MinimumWidth = 6;
            this.SrNo.Name = "SrNo";
            this.SrNo.ReadOnly = true;
            this.SrNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SrNo.Width = 50;
            // 
            // RowID
            // 
            this.RowID.FillWeight = 47.25943F;
            this.RowID.Frozen = true;
            this.RowID.HeaderText = "ID";
            this.RowID.MinimumWidth = 6;
            this.RowID.Name = "RowID";
            this.RowID.ReadOnly = true;
            this.RowID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RowID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RowID.Visible = false;
            this.RowID.Width = 6;
            // 
            // RowCode
            // 
            this.RowCode.Frozen = true;
            this.RowCode.HeaderText = "Code";
            this.RowCode.MinimumWidth = 100;
            this.RowCode.Name = "RowCode";
            this.RowCode.ReadOnly = true;
            this.RowCode.Width = 125;
            // 
            // RowName
            // 
            this.RowName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RowName.FillWeight = 106.1403F;
            this.RowName.HeaderText = "Name";
            this.RowName.MaxInputLength = 10;
            this.RowName.MinimumWidth = 200;
            this.RowName.Name = "RowName";
            this.RowName.ReadOnly = true;
            // 
            // ExtraColumn
            // 
            this.ExtraColumn.HeaderText = "ExtraColumn";
            this.ExtraColumn.MinimumWidth = 50;
            this.ExtraColumn.Name = "ExtraColumn";
            this.ExtraColumn.ReadOnly = true;
            this.ExtraColumn.Visible = false;
            this.ExtraColumn.Width = 125;
            // 
            // RowSelect
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Green;
            dataGridViewCellStyle3.NullValue = null;
            this.RowSelect.DefaultCellStyle = dataGridViewCellStyle3;
            this.RowSelect.HeaderText = "Select";
            this.RowSelect.Image = global::APP.GPMS.Properties.Resources.icons8_tick_50;
            this.RowSelect.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.RowSelect.MinimumWidth = 50;
            this.RowSelect.Name = "RowSelect";
            this.RowSelect.ReadOnly = true;
            this.RowSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RowSelect.Width = 50;
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripLabelShowingPageStatus});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 63);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(476, 25);
            this.bindingNavigator1.TabIndex = 173;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelShowingPageStatus
            // 
            this.toolStripLabelShowingPageStatus.Name = "toolStripLabelShowingPageStatus";
            this.toolStripLabelShowingPageStatus.Size = new System.Drawing.Size(105, 22);
            this.toolStripLabelShowingPageStatus.Text = "Showing {n} of {N}";
            // 
            // FormGeneralLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(476, 397);
            this.Controls.Add(this.dataGridViewCollectionDisplay);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottomSelectIndex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGeneralLookup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormGeneralLookup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBottomSelectIndex.ResumeLayout(false);
            this.panelBottomSelectIndex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCollectionDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPOPUP;
        private System.Windows.Forms.Label labelPlaceHolderText;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotalCount;
        private System.Windows.Forms.Label labelOf;
        private System.Windows.Forms.Label labelSelect;
        public System.Windows.Forms.Panel panelBottomSelectIndex;
        public System.Windows.Forms.DataGridView dataGridViewCollectionDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowID;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraColumn;
        private System.Windows.Forms.DataGridViewImageColumn RowSelect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabelShowingPageStatus;
    }
}