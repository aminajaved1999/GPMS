
namespace APP.GPMS
{
    partial class FormPO3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPO3));
            this.groupBoxPOInfo = new System.Windows.Forms.GroupBox();
            this.panelColorSizeContainer = new System.Windows.Forms.Panel();
            this.buttonResetSelection = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.treeViewColorSize = new System.Windows.Forms.TreeView();
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.pictureBoxPONoSelect = new System.Windows.Forms.PictureBox();
            this.textBoxPOMID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPOGo = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdateSize = new System.Windows.Forms.Button();
            this.buttonAddSize = new System.Windows.Forms.Button();
            this.buttonUpdateColor = new System.Windows.Forms.Button();
            this.buttonAddColor = new System.Windows.Forms.Button();
            this.buttonCollapseAll = new System.Windows.Forms.Button();
            this.buttonExpandAll = new System.Windows.Forms.Button();
            this.textBoxPONo = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panelActionControl = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonSaveNPrevious = new System.Windows.Forms.Button();
            this.buttonSaveNNext = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.groupBoxPOInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPONoSelect)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelActionControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPOInfo
            // 
            this.groupBoxPOInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBoxPOInfo.Controls.Add(this.panelColorSizeContainer);
            this.groupBoxPOInfo.Controls.Add(this.buttonResetSelection);
            this.groupBoxPOInfo.Controls.Add(this.buttonReset);
            this.groupBoxPOInfo.Controls.Add(this.treeViewColorSize);
            this.groupBoxPOInfo.Controls.Add(this.pictureBoxPONoSelect);
            this.groupBoxPOInfo.Controls.Add(this.textBoxPOMID);
            this.groupBoxPOInfo.Controls.Add(this.label1);
            this.groupBoxPOInfo.Controls.Add(this.label3);
            this.groupBoxPOInfo.Controls.Add(this.buttonPOGo);
            this.groupBoxPOInfo.Controls.Add(this.buttonDelete);
            this.groupBoxPOInfo.Controls.Add(this.buttonUpdateSize);
            this.groupBoxPOInfo.Controls.Add(this.buttonAddSize);
            this.groupBoxPOInfo.Controls.Add(this.buttonUpdateColor);
            this.groupBoxPOInfo.Controls.Add(this.buttonAddColor);
            this.groupBoxPOInfo.Controls.Add(this.buttonCollapseAll);
            this.groupBoxPOInfo.Controls.Add(this.buttonExpandAll);
            this.groupBoxPOInfo.Controls.Add(this.textBoxPONo);
            this.groupBoxPOInfo.Location = new System.Drawing.Point(25, 34);
            this.groupBoxPOInfo.Name = "groupBoxPOInfo";
            this.groupBoxPOInfo.Size = new System.Drawing.Size(1139, 599);
            this.groupBoxPOInfo.TabIndex = 152;
            this.groupBoxPOInfo.TabStop = false;
            this.groupBoxPOInfo.Text = "COLOR  &&  SIZES  INFORMATION";
            // 
            // panelColorSizeContainer
            // 
            this.panelColorSizeContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelColorSizeContainer.AutoScroll = true;
            this.panelColorSizeContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColorSizeContainer.Location = new System.Drawing.Point(716, 113);
            this.panelColorSizeContainer.Name = "panelColorSizeContainer";
            this.panelColorSizeContainer.Size = new System.Drawing.Size(400, 478);
            this.panelColorSizeContainer.TabIndex = 200;
            // 
            // buttonResetSelection
            // 
            this.buttonResetSelection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonResetSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetSelection.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetSelection.ForeColor = System.Drawing.Color.Orange;
            this.buttonResetSelection.Location = new System.Drawing.Point(896, 15);
            this.buttonResetSelection.Name = "buttonResetSelection";
            this.buttonResetSelection.Size = new System.Drawing.Size(150, 25);
            this.buttonResetSelection.TabIndex = 199;
            this.buttonResetSelection.TabStop = false;
            this.buttonResetSelection.Text = "RESET SELECTION";
            this.buttonResetSelection.UseVisualStyleBackColor = true;
            this.buttonResetSelection.Click += new System.EventHandler(this.buttonResetSelection_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReset.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonReset.Location = new System.Drawing.Point(1052, 15);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(64, 25);
            this.buttonReset.TabIndex = 199;
            this.buttonReset.TabStop = false;
            this.buttonReset.Text = "RESET";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // treeViewColorSize
            // 
            this.treeViewColorSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewColorSize.BackColor = System.Drawing.Color.White;
            this.treeViewColorSize.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewColorSize.ImageIndex = 2;
            this.treeViewColorSize.ImageList = this.imageListTreeView;
            this.treeViewColorSize.LineColor = System.Drawing.Color.Green;
            this.treeViewColorSize.Location = new System.Drawing.Point(18, 113);
            this.treeViewColorSize.Name = "treeViewColorSize";
            this.treeViewColorSize.SelectedImageIndex = 2;
            this.treeViewColorSize.Size = new System.Drawing.Size(693, 478);
            this.treeViewColorSize.TabIndex = 197;
            this.treeViewColorSize.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewColorSize_AfterSelect);
            this.treeViewColorSize.Leave += new System.EventHandler(this.treeViewColorSize_Leave);
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeView.Images.SetKeyName(0, "icons8-new-48.png");
            this.imageListTreeView.Images.SetKeyName(1, "icons8-sync-50.png");
            this.imageListTreeView.Images.SetKeyName(2, "icons8-line-50.png");
            this.imageListTreeView.Images.SetKeyName(3, "icons8-select-24.png");
            // 
            // pictureBoxPONoSelect
            // 
            this.pictureBoxPONoSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPONoSelect.Image = global::APP.GPMS.Properties.Resources.icons8_pending_24;
            this.pictureBoxPONoSelect.Location = new System.Drawing.Point(276, 45);
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
            this.textBoxPOMID.Location = new System.Drawing.Point(179, 22);
            this.textBoxPOMID.Name = "textBoxPOMID";
            this.textBoxPOMID.Size = new System.Drawing.Size(40, 21);
            this.textBoxPOMID.TabIndex = 194;
            this.textBoxPOMID.Visible = false;
            this.textBoxPOMID.TextChanged += new System.EventHandler(this.textBoxPOMID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 195;
            this.label1.Text = "POMID";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.label3.Location = new System.Drawing.Point(19, 22);
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
            this.buttonPOGo.Location = new System.Drawing.Point(302, 45);
            this.buttonPOGo.Name = "buttonPOGo";
            this.buttonPOGo.Size = new System.Drawing.Size(35, 23);
            this.buttonPOGo.TabIndex = 174;
            this.buttonPOGo.Text = "GO";
            this.buttonPOGo.UseVisualStyleBackColor = true;
            this.buttonPOGo.Click += new System.EventHandler(this.buttonPOGo_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonDelete.Location = new System.Drawing.Point(613, 84);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(98, 25);
            this.buttonDelete.TabIndex = 174;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdateSize
            // 
            this.buttonUpdateSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdateSize.Enabled = false;
            this.buttonUpdateSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateSize.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonUpdateSize.Location = new System.Drawing.Point(514, 84);
            this.buttonUpdateSize.Name = "buttonUpdateSize";
            this.buttonUpdateSize.Size = new System.Drawing.Size(98, 25);
            this.buttonUpdateSize.TabIndex = 174;
            this.buttonUpdateSize.Text = "Update Size";
            this.buttonUpdateSize.UseVisualStyleBackColor = true;
            this.buttonUpdateSize.Click += new System.EventHandler(this.buttonUpdateSize_Click);
            // 
            // buttonAddSize
            // 
            this.buttonAddSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddSize.Enabled = false;
            this.buttonAddSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddSize.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonAddSize.Location = new System.Drawing.Point(415, 84);
            this.buttonAddSize.Name = "buttonAddSize";
            this.buttonAddSize.Size = new System.Drawing.Size(98, 25);
            this.buttonAddSize.TabIndex = 174;
            this.buttonAddSize.Text = "Add Size";
            this.buttonAddSize.UseVisualStyleBackColor = true;
            this.buttonAddSize.Click += new System.EventHandler(this.buttonAddSize_Click);
            // 
            // buttonUpdateColor
            // 
            this.buttonUpdateColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdateColor.Enabled = false;
            this.buttonUpdateColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdateColor.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonUpdateColor.Location = new System.Drawing.Point(316, 84);
            this.buttonUpdateColor.Name = "buttonUpdateColor";
            this.buttonUpdateColor.Size = new System.Drawing.Size(98, 25);
            this.buttonUpdateColor.TabIndex = 174;
            this.buttonUpdateColor.Text = "Update Color";
            this.buttonUpdateColor.UseVisualStyleBackColor = true;
            this.buttonUpdateColor.Click += new System.EventHandler(this.buttonUpdateColor_Click);
            // 
            // buttonAddColor
            // 
            this.buttonAddColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddColor.Enabled = false;
            this.buttonAddColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddColor.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonAddColor.Location = new System.Drawing.Point(217, 84);
            this.buttonAddColor.Name = "buttonAddColor";
            this.buttonAddColor.Size = new System.Drawing.Size(98, 25);
            this.buttonAddColor.TabIndex = 174;
            this.buttonAddColor.Text = "Add Color";
            this.buttonAddColor.UseVisualStyleBackColor = true;
            this.buttonAddColor.Click += new System.EventHandler(this.buttonAddColor_Click);
            // 
            // buttonCollapseAll
            // 
            this.buttonCollapseAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCollapseAll.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCollapseAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonCollapseAll.Location = new System.Drawing.Point(118, 84);
            this.buttonCollapseAll.Name = "buttonCollapseAll";
            this.buttonCollapseAll.Size = new System.Drawing.Size(98, 25);
            this.buttonCollapseAll.TabIndex = 174;
            this.buttonCollapseAll.Text = "Collapse All";
            this.buttonCollapseAll.UseVisualStyleBackColor = true;
            this.buttonCollapseAll.Click += new System.EventHandler(this.buttonCollapseAll_Click);
            // 
            // buttonExpandAll
            // 
            this.buttonExpandAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpandAll.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpandAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonExpandAll.Location = new System.Drawing.Point(19, 84);
            this.buttonExpandAll.Name = "buttonExpandAll";
            this.buttonExpandAll.Size = new System.Drawing.Size(98, 25);
            this.buttonExpandAll.TabIndex = 174;
            this.buttonExpandAll.Text = "Expand All";
            this.buttonExpandAll.UseVisualStyleBackColor = true;
            this.buttonExpandAll.Click += new System.EventHandler(this.buttonExpandAll_Click);
            // 
            // textBoxPONo
            // 
            this.textBoxPONo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxPONo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPONo.Location = new System.Drawing.Point(19, 45);
            this.textBoxPONo.MaxLength = 50;
            this.textBoxPONo.Name = "textBoxPONo";
            this.textBoxPONo.Size = new System.Drawing.Size(258, 23);
            this.textBoxPONo.TabIndex = 179;
            this.textBoxPONo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPONo.TextChanged += new System.EventHandler(this.textBoxPONo_TextChanged);
            this.textBoxPONo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPONo_KeyDown);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(1162, 29);
            this.panel3.TabIndex = 153;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.label26.Location = new System.Drawing.Point(111, 2);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(384, 25);
            this.label26.TabIndex = 4;
            this.label26.Text = "Color && Sizes Information";
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
            this.label24.Text = "STEP 3 OF 4 :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.panelActionControl.Location = new System.Drawing.Point(0, 639);
            this.panelActionControl.Name = "panelActionControl";
            this.panelActionControl.Size = new System.Drawing.Size(1162, 57);
            this.panelActionControl.TabIndex = 154;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSave.Enabled = false;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.buttonSave.Location = new System.Drawing.Point(514, 17);
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
            this.buttonPrevious.Location = new System.Drawing.Point(364, 17);
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
            this.buttonSaveNPrevious.Location = new System.Drawing.Point(214, 17);
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
            this.buttonSaveNNext.Location = new System.Drawing.Point(812, 17);
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
            this.buttonNext.Location = new System.Drawing.Point(663, 17);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(132, 25);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "NEXT ▶";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // FormPO3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 696);
            this.Controls.Add(this.panelActionControl);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBoxPOInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPO3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPO3_Load);
            this.groupBoxPOInfo.ResumeLayout(false);
            this.groupBoxPOInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPONoSelect)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panelActionControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxPOInfo;
        private System.Windows.Forms.PictureBox pictureBoxPONoSelect;
        public System.Windows.Forms.TextBox textBoxPOMID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button buttonPOGo;
        private System.Windows.Forms.Button buttonExpandAll;
        public System.Windows.Forms.TextBox textBoxPONo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button buttonUpdateSize;
        private System.Windows.Forms.Button buttonAddSize;
        private System.Windows.Forms.Button buttonUpdateColor;
        private System.Windows.Forms.Button buttonAddColor;
        private System.Windows.Forms.Button buttonCollapseAll;
        private System.Windows.Forms.TreeView treeViewColorSize;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ImageList imageListTreeView;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelColorSizeContainer;
        private System.Windows.Forms.Button buttonResetSelection;
        public System.Windows.Forms.Panel panelActionControl;
        public System.Windows.Forms.Button buttonSave;
        public System.Windows.Forms.Button buttonPrevious;
        public System.Windows.Forms.Button buttonSaveNPrevious;
        public System.Windows.Forms.Button buttonSaveNNext;
        public System.Windows.Forms.Button buttonNext;
    }
}