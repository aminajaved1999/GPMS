
namespace APP.GPMS
{
    partial class FormPO2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBoxPOInfo = new System.Windows.Forms.GroupBox();
            this.pictureBoxPONoSelect = new System.Windows.Forms.PictureBox();
            this.textBoxPOMID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxStyleID = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.dataGridViewPOD = new System.Windows.Forms.DataGridView();
            this.SrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PODID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StyleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StyleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StyleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewImageColumn();
            this.isEdited = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPOGo = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonAddStyle = new System.Windows.Forms.Button();
            this.textBoxPONo = new System.Windows.Forms.TextBox();
            this.panelActionControl = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonSaveNPrevious = new System.Windows.Forms.Button();
            this.buttonSaveNNext = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3.SuspendLayout();
            this.groupBoxPOInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPONoSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPOD)).BeginInit();
            this.panelActionControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(984, 29);
            this.panel3.TabIndex = 150;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.label26.Location = new System.Drawing.Point(111, 2);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(355, 25);
            this.label26.TabIndex = 4;
            this.label26.Text = "Style Information";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Left;
            this.label24.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(2, 2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(109, 25);
            this.label24.TabIndex = 3;
            this.label24.Text = "STEP 2 OF 4 :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxPOInfo
            // 
            this.groupBoxPOInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBoxPOInfo.Controls.Add(this.pictureBoxPONoSelect);
            this.groupBoxPOInfo.Controls.Add(this.textBoxPOMID);
            this.groupBoxPOInfo.Controls.Add(this.label1);
            this.groupBoxPOInfo.Controls.Add(this.textBoxStyleID);
            this.groupBoxPOInfo.Controls.Add(this.label27);
            this.groupBoxPOInfo.Controls.Add(this.dataGridViewPOD);
            this.groupBoxPOInfo.Controls.Add(this.label3);
            this.groupBoxPOInfo.Controls.Add(this.buttonPOGo);
            this.groupBoxPOInfo.Controls.Add(this.buttonClearAll);
            this.groupBoxPOInfo.Controls.Add(this.buttonAddStyle);
            this.groupBoxPOInfo.Controls.Add(this.textBoxPONo);
            this.groupBoxPOInfo.Location = new System.Drawing.Point(83, 34);
            this.groupBoxPOInfo.Name = "groupBoxPOInfo";
            this.groupBoxPOInfo.Size = new System.Drawing.Size(818, 526);
            this.groupBoxPOInfo.TabIndex = 151;
            this.groupBoxPOInfo.TabStop = false;
            this.groupBoxPOInfo.Text = "STYLE  INFORMATION";
            // 
            // pictureBoxPONoSelect
            // 
            this.pictureBoxPONoSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPONoSelect.Image = global::APP.GPMS.Properties.Resources.icons8_pending_24;
            this.pictureBoxPONoSelect.Location = new System.Drawing.Point(300, 56);
            this.pictureBoxPONoSelect.Name = "pictureBoxPONoSelect";
            this.pictureBoxPONoSelect.Size = new System.Drawing.Size(21, 23);
            this.pictureBoxPONoSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPONoSelect.TabIndex = 196;
            this.pictureBoxPONoSelect.TabStop = false;
            // 
            // textBoxPOMID
            // 
            this.textBoxPOMID.Enabled = false;
            this.textBoxPOMID.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPOMID.Location = new System.Drawing.Point(204, 33);
            this.textBoxPOMID.Name = "textBoxPOMID";
            this.textBoxPOMID.Size = new System.Drawing.Size(40, 21);
            this.textBoxPOMID.TabIndex = 194;
            this.textBoxPOMID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "POMID";
            this.label1.Visible = false;
            // 
            // textBoxStyleID
            // 
            this.textBoxStyleID.Enabled = false;
            this.textBoxStyleID.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStyleID.Location = new System.Drawing.Point(299, 99);
            this.textBoxStyleID.Name = "textBoxStyleID";
            this.textBoxStyleID.ReadOnly = true;
            this.textBoxStyleID.Size = new System.Drawing.Size(40, 21);
            this.textBoxStyleID.TabIndex = 192;
            this.textBoxStyleID.Visible = false;
            this.textBoxStyleID.TextChanged += new System.EventHandler(this.textBoxStyleID_TextChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Enabled = false;
            this.label27.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(259, 102);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(40, 13);
            this.label27.TabIndex = 193;
            this.label27.Text = "StyleID";
            this.label27.Visible = false;
            // 
            // dataGridViewPOD
            // 
            this.dataGridViewPOD.AllowUserToAddRows = false;
            this.dataGridViewPOD.AllowUserToDeleteRows = false;
            this.dataGridViewPOD.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPOD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridViewPOD.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPOD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPOD.ColumnHeadersHeight = 25;
            this.dataGridViewPOD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPOD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNo,
            this.PODID,
            this.StyleID,
            this.StyleCode,
            this.StyleName,
            this.Description,
            this.Remove,
            this.isEdited});
            this.dataGridViewPOD.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPOD.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPOD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewPOD.EnableHeadersVisualStyles = false;
            this.dataGridViewPOD.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewPOD.Location = new System.Drawing.Point(44, 126);
            this.dataGridViewPOD.MultiSelect = false;
            this.dataGridViewPOD.Name = "dataGridViewPOD";
            this.dataGridViewPOD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewPOD.RowHeadersVisible = false;
            this.dataGridViewPOD.RowHeadersWidth = 20;
            this.dataGridViewPOD.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewPOD.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPOD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPOD.ShowCellErrors = false;
            this.dataGridViewPOD.ShowEditingIcon = false;
            this.dataGridViewPOD.ShowRowErrors = false;
            this.dataGridViewPOD.Size = new System.Drawing.Size(737, 385);
            this.dataGridViewPOD.TabIndex = 4;
            this.dataGridViewPOD.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewPOD_CellBeginEdit);
            this.dataGridViewPOD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPOD_CellClick);
            this.dataGridViewPOD.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPOD_CellEndEdit);
            this.dataGridViewPOD.Sorted += new System.EventHandler(this.dataGridViewPOD_Sorted);
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
            // PODID
            // 
            this.PODID.Frozen = true;
            this.PODID.HeaderText = "PODID";
            this.PODID.Name = "PODID";
            this.PODID.ReadOnly = true;
            this.PODID.Visible = false;
            // 
            // StyleID
            // 
            this.StyleID.FillWeight = 47.25943F;
            this.StyleID.Frozen = true;
            this.StyleID.HeaderText = "StyleID";
            this.StyleID.MinimumWidth = 6;
            this.StyleID.Name = "StyleID";
            this.StyleID.ReadOnly = true;
            this.StyleID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StyleID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StyleID.Visible = false;
            this.StyleID.Width = 6;
            // 
            // StyleCode
            // 
            this.StyleCode.Frozen = true;
            this.StyleCode.HeaderText = "Style Code";
            this.StyleCode.MinimumWidth = 100;
            this.StyleCode.Name = "StyleCode";
            this.StyleCode.ReadOnly = true;
            this.StyleCode.Width = 125;
            // 
            // StyleName
            // 
            this.StyleName.FillWeight = 106.1403F;
            this.StyleName.HeaderText = "Style Name";
            this.StyleName.MaxInputLength = 10;
            this.StyleName.MinimumWidth = 200;
            this.StyleName.Name = "StyleName";
            this.StyleName.ReadOnly = true;
            this.StyleName.Width = 200;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaShell;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Description.DefaultCellStyle = dataGridViewCellStyle2;
            this.Description.HeaderText = "Description";
            this.Description.MaxInputLength = 250;
            this.Description.MinimumWidth = 100;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.ToolTipText = "Description";
            // 
            // Remove
            // 
            this.Remove.HeaderText = "✖";
            this.Remove.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Remove.MinimumWidth = 30;
            this.Remove.Name = "Remove";
            this.Remove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Remove.Width = 30;
            // 
            // isEdited
            // 
            this.isEdited.HeaderText = "isEdited ";
            this.isEdited.Name = "isEdited";
            this.isEdited.ReadOnly = true;
            this.isEdited.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isEdited.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isEdited.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.label3.Location = new System.Drawing.Point(44, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 19);
            this.label3.TabIndex = 189;
            this.label3.Text = "P.O #";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPOGo
            // 
            this.buttonPOGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPOGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPOGo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPOGo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonPOGo.Location = new System.Drawing.Point(327, 56);
            this.buttonPOGo.Name = "buttonPOGo";
            this.buttonPOGo.Size = new System.Drawing.Size(35, 23);
            this.buttonPOGo.TabIndex = 1;
            this.buttonPOGo.Text = "GO";
            this.buttonPOGo.UseVisualStyleBackColor = true;
            this.buttonPOGo.Click += new System.EventHandler(this.buttonPOGo_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearAll.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonClearAll.Location = new System.Drawing.Point(146, 95);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(109, 25);
            this.buttonClearAll.TabIndex = 3;
            this.buttonClearAll.Text = "Clear New Styles";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonAddStyle
            // 
            this.buttonAddStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddStyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddStyle.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonAddStyle.Location = new System.Drawing.Point(44, 95);
            this.buttonAddStyle.Name = "buttonAddStyle";
            this.buttonAddStyle.Size = new System.Drawing.Size(98, 25);
            this.buttonAddStyle.TabIndex = 2;
            this.buttonAddStyle.Text = "Add Style";
            this.buttonAddStyle.UseVisualStyleBackColor = true;
            this.buttonAddStyle.Click += new System.EventHandler(this.buttonAddStyle_Click);
            // 
            // textBoxPONo
            // 
            this.textBoxPONo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPONo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPONo.Location = new System.Drawing.Point(44, 56);
            this.textBoxPONo.MaxLength = 50;
            this.textBoxPONo.Name = "textBoxPONo";
            this.textBoxPONo.Size = new System.Drawing.Size(257, 23);
            this.textBoxPONo.TabIndex = 0;
            this.textBoxPONo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPONo.TextChanged += new System.EventHandler(this.textBoxPONo_TextChanged);
            this.textBoxPONo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPONo_KeyDown);
            // 
            // panelActionControl
            // 
            this.panelActionControl.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelActionControl.Controls.Add(this.buttonSave);
            this.panelActionControl.Controls.Add(this.buttonPrevious);
            this.panelActionControl.Controls.Add(this.buttonSaveNPrevious);
            this.panelActionControl.Controls.Add(this.buttonSaveNNext);
            this.panelActionControl.Controls.Add(this.buttonNext);
            this.panelActionControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActionControl.Location = new System.Drawing.Point(0, 571);
            this.panelActionControl.Name = "panelActionControl";
            this.panelActionControl.Size = new System.Drawing.Size(984, 57);
            this.panelActionControl.TabIndex = 152;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Enabled = false;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonSave.Location = new System.Drawing.Point(425, 17);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(132, 25);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrevious.Enabled = false;
            this.buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevious.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonPrevious.Location = new System.Drawing.Point(275, 17);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(132, 25);
            this.buttonPrevious.TabIndex = 1;
            this.buttonPrevious.Text = "◀ PREVIOUS";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonSaveNPrevious
            // 
            this.buttonSaveNPrevious.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSaveNPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveNPrevious.Enabled = false;
            this.buttonSaveNPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveNPrevious.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveNPrevious.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonSaveNPrevious.Location = new System.Drawing.Point(125, 17);
            this.buttonSaveNPrevious.Name = "buttonSaveNPrevious";
            this.buttonSaveNPrevious.Size = new System.Drawing.Size(132, 25);
            this.buttonSaveNPrevious.TabIndex = 0;
            this.buttonSaveNPrevious.Text = "◀ SAVE && PREVIOUS";
            this.buttonSaveNPrevious.UseVisualStyleBackColor = true;
            this.buttonSaveNPrevious.Click += new System.EventHandler(this.buttonSaveNPrevious_Click);
            // 
            // buttonSaveNNext
            // 
            this.buttonSaveNNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSaveNNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveNNext.Enabled = false;
            this.buttonSaveNNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveNNext.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveNNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonSaveNNext.Location = new System.Drawing.Point(723, 17);
            this.buttonSaveNNext.Name = "buttonSaveNNext";
            this.buttonSaveNNext.Size = new System.Drawing.Size(132, 25);
            this.buttonSaveNNext.TabIndex = 4;
            this.buttonSaveNNext.Text = "SAVE && NEXT  ▶";
            this.buttonSaveNNext.UseVisualStyleBackColor = true;
            this.buttonSaveNNext.Click += new System.EventHandler(this.buttonSaveNNext_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonNext.Enabled = false;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonNext.Location = new System.Drawing.Point(574, 17);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(132, 25);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "NEXT ▶";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "✖";
            this.dataGridViewImageColumn1.Image = global::APP.GPMS.Properties.Resources.icons8_delete_64__1_;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // FormPO2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 628);
            this.Controls.Add(this.panelActionControl);
            this.Controls.Add(this.groupBoxPOInfo);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPO2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPO2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPO2_Load);
            this.panel3.ResumeLayout(false);
            this.groupBoxPOInfo.ResumeLayout(false);
            this.groupBoxPOInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPONoSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPOD)).EndInit();
            this.panelActionControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBoxPOInfo;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddStyle;
        public System.Windows.Forms.DataGridView dataGridViewPOD;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.TextBox textBoxStyleID;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonPOGo;
        public System.Windows.Forms.TextBox textBoxPONo;
        public System.Windows.Forms.TextBox textBoxPOMID;
        private System.Windows.Forms.PictureBox pictureBoxPONoSelect;
        public System.Windows.Forms.Panel panelActionControl;
        public System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.Button buttonPrevious;
        public System.Windows.Forms.Button buttonSaveNPrevious;
        public System.Windows.Forms.Button buttonSaveNNext;
        public System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PODID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StyleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StyleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StyleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewImageColumn Remove;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEdited;
    }
}