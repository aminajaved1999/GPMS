
namespace APP.GPMS
{
    partial class FormPO5Approve
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBoxPOInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelPOPreview = new System.Windows.Forms.Panel();
            this.textBoxPOMID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPOGo = new System.Windows.Forms.Button();
            this.textBoxRemarks = new System.Windows.Forms.TextBox();
            this.textBoxPONo = new System.Windows.Forms.TextBox();
            this.panelActionControl = new System.Windows.Forms.Panel();
            this.buttonApproveNClose = new System.Windows.Forms.Button();
            this.buttonApprove = new System.Windows.Forms.Button();
            this.buttonRejectNClose = new System.Windows.Forms.Button();
            this.buttonReject = new System.Windows.Forms.Button();
            this.pictureBoxPONoSelect = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.groupBoxPOInfo.SuspendLayout();
            this.panelActionControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPONoSelect)).BeginInit();
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
            this.panel3.TabIndex = 151;
            // 
            // label26
            // 
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.label26.Location = new System.Drawing.Point(111, 2);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(305, 25);
            this.label26.TabIndex = 4;
            this.label26.Text = "Approve Purchase Order";
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
            this.label24.Text = "STEP FINAL :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxPOInfo
            // 
            this.groupBoxPOInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBoxPOInfo.Controls.Add(this.label2);
            this.groupBoxPOInfo.Controls.Add(this.panelPOPreview);
            this.groupBoxPOInfo.Controls.Add(this.pictureBoxPONoSelect);
            this.groupBoxPOInfo.Controls.Add(this.textBoxPOMID);
            this.groupBoxPOInfo.Controls.Add(this.label4);
            this.groupBoxPOInfo.Controls.Add(this.label1);
            this.groupBoxPOInfo.Controls.Add(this.label3);
            this.groupBoxPOInfo.Controls.Add(this.buttonPOGo);
            this.groupBoxPOInfo.Controls.Add(this.textBoxRemarks);
            this.groupBoxPOInfo.Controls.Add(this.textBoxPONo);
            this.groupBoxPOInfo.Location = new System.Drawing.Point(12, 35);
            this.groupBoxPOInfo.Name = "groupBoxPOInfo";
            this.groupBoxPOInfo.Size = new System.Drawing.Size(960, 494);
            this.groupBoxPOInfo.TabIndex = 152;
            this.groupBoxPOInfo.TabStop = false;
            this.groupBoxPOInfo.Text = "PO POSTING";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(85)))), ((int)(((byte)(11)))));
            this.label2.Location = new System.Drawing.Point(402, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 18);
            this.label2.TabIndex = 198;
            this.label2.Text = "Purchase Order Preview";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPOPreview
            // 
            this.panelPOPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPOPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPOPreview.Location = new System.Drawing.Point(12, 173);
            this.panelPOPreview.Name = "panelPOPreview";
            this.panelPOPreview.Size = new System.Drawing.Size(937, 315);
            this.panelPOPreview.TabIndex = 3;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 14);
            this.label4.TabIndex = 195;
            this.label4.Text = "Remarks";
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
            // textBoxRemarks
            // 
            this.textBoxRemarks.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRemarks.Location = new System.Drawing.Point(44, 107);
            this.textBoxRemarks.MaxLength = 1000;
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.Size = new System.Drawing.Size(318, 43);
            this.textBoxRemarks.TabIndex = 2;
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
            this.panelActionControl.Controls.Add(this.buttonApproveNClose);
            this.panelActionControl.Controls.Add(this.buttonApprove);
            this.panelActionControl.Controls.Add(this.buttonRejectNClose);
            this.panelActionControl.Controls.Add(this.buttonReject);
            this.panelActionControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActionControl.Location = new System.Drawing.Point(0, 535);
            this.panelActionControl.Name = "panelActionControl";
            this.panelActionControl.Size = new System.Drawing.Size(984, 57);
            this.panelActionControl.TabIndex = 200;
            // 
            // buttonApproveNClose
            // 
            this.buttonApproveNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApproveNClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonApproveNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApproveNClose.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApproveNClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonApproveNClose.Location = new System.Drawing.Point(829, 17);
            this.buttonApproveNClose.Name = "buttonApproveNClose";
            this.buttonApproveNClose.Size = new System.Drawing.Size(132, 25);
            this.buttonApproveNClose.TabIndex = 5;
            this.buttonApproveNClose.Text = "APPROVE && CLOSE";
            this.buttonApproveNClose.UseVisualStyleBackColor = true;
            this.buttonApproveNClose.Click += new System.EventHandler(this.buttonApproveNClose_Click);
            // 
            // buttonApprove
            // 
            this.buttonApprove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApprove.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonApprove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonApprove.Location = new System.Drawing.Point(681, 17);
            this.buttonApprove.Name = "buttonApprove";
            this.buttonApprove.Size = new System.Drawing.Size(132, 25);
            this.buttonApprove.TabIndex = 4;
            this.buttonApprove.Text = "APPROVE";
            this.buttonApprove.UseVisualStyleBackColor = true;
            this.buttonApprove.Click += new System.EventHandler(this.buttonApprove_Click);
            // 
            // buttonRejectNClose
            // 
            this.buttonRejectNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRejectNClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRejectNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRejectNClose.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRejectNClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRejectNClose.Location = new System.Drawing.Point(172, 17);
            this.buttonRejectNClose.Name = "buttonRejectNClose";
            this.buttonRejectNClose.Size = new System.Drawing.Size(132, 25);
            this.buttonRejectNClose.TabIndex = 1;
            this.buttonRejectNClose.Text = "REJECT && CLOSE";
            this.buttonRejectNClose.UseVisualStyleBackColor = true;
            this.buttonRejectNClose.Click += new System.EventHandler(this.buttonRejectNClose_Click);
            // 
            // buttonReject
            // 
            this.buttonReject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReject.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonReject.Location = new System.Drawing.Point(24, 17);
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.Size = new System.Drawing.Size(132, 25);
            this.buttonReject.TabIndex = 0;
            this.buttonReject.Text = "REJECT";
            this.buttonReject.UseVisualStyleBackColor = true;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
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
            // FormPO5Approve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 592);
            this.Controls.Add(this.panelActionControl);
            this.Controls.Add(this.groupBoxPOInfo);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPO5Approve";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel3.ResumeLayout(false);
            this.groupBoxPOInfo.ResumeLayout(false);
            this.groupBoxPOInfo.PerformLayout();
            this.panelActionControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPONoSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBoxPOInfo;
        private System.Windows.Forms.PictureBox pictureBoxPONoSelect;
        public System.Windows.Forms.TextBox textBoxPOMID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button buttonPOGo;
        public System.Windows.Forms.TextBox textBoxPONo;
        private System.Windows.Forms.Panel panelPOPreview;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Panel panelActionControl;
        public System.Windows.Forms.Button buttonApproveNClose;
        public System.Windows.Forms.Button buttonApprove;
        public System.Windows.Forms.Button buttonRejectNClose;
        public System.Windows.Forms.Button buttonReject;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxRemarks;
    }
}