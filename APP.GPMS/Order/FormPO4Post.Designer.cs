
namespace APP.GPMS
{
    partial class FormPO4Post
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPOGo = new System.Windows.Forms.Button();
            this.textBoxPONo = new System.Windows.Forms.TextBox();
            this.panelActionControl = new System.Windows.Forms.Panel();
            this.buttonPostNClose = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
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
            this.label26.Text = "Posting Purchase Order";
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
            this.label24.Text = "STEP 4 OF 4 :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxPOInfo
            // 
            this.groupBoxPOInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBoxPOInfo.Controls.Add(this.label2);
            this.groupBoxPOInfo.Controls.Add(this.panelPOPreview);
            this.groupBoxPOInfo.Controls.Add(this.pictureBoxPONoSelect);
            this.groupBoxPOInfo.Controls.Add(this.textBoxPOMID);
            this.groupBoxPOInfo.Controls.Add(this.label1);
            this.groupBoxPOInfo.Controls.Add(this.label3);
            this.groupBoxPOInfo.Controls.Add(this.buttonPOGo);
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
            this.label2.Location = new System.Drawing.Point(402, 80);
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
            this.panelPOPreview.Location = new System.Drawing.Point(12, 101);
            this.panelPOPreview.Name = "panelPOPreview";
            this.panelPOPreview.Size = new System.Drawing.Size(937, 387);
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
            this.panelActionControl.Controls.Add(this.buttonPostNClose);
            this.panelActionControl.Controls.Add(this.buttonPost);
            this.panelActionControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActionControl.Location = new System.Drawing.Point(0, 535);
            this.panelActionControl.Name = "panelActionControl";
            this.panelActionControl.Size = new System.Drawing.Size(984, 57);
            this.panelActionControl.TabIndex = 200;
            // 
            // buttonPostNClose
            // 
            this.buttonPostNClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPostNClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPostNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPostNClose.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPostNClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonPostNClose.Location = new System.Drawing.Point(500, 17);
            this.buttonPostNClose.Name = "buttonPostNClose";
            this.buttonPostNClose.Size = new System.Drawing.Size(132, 25);
            this.buttonPostNClose.TabIndex = 3;
            this.buttonPostNClose.Text = "POST && CLOSE";
            this.buttonPostNClose.UseVisualStyleBackColor = true;
            this.buttonPostNClose.Click += new System.EventHandler(this.buttonPostNClose_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPost.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonPost.Location = new System.Drawing.Point(352, 17);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(132, 25);
            this.buttonPost.TabIndex = 2;
            this.buttonPost.Text = "POST";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
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
            // FormPO4Post
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
            this.Name = "FormPO4Post";
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
        public System.Windows.Forms.Button buttonPostNClose;
        public System.Windows.Forms.Button buttonPost;
    }
}