
namespace APP.GPMS
{
    partial class FormTransparentLoader
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
            this.labelLoaderText = new System.Windows.Forms.Label();
            this.pictureBoxSpinner = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinner)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLoaderText
            // 
            this.labelLoaderText.BackColor = System.Drawing.Color.Transparent;
            this.labelLoaderText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoaderText.ForeColor = System.Drawing.Color.White;
            this.labelLoaderText.Location = new System.Drawing.Point(20, 1);
            this.labelLoaderText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLoaderText.Name = "labelLoaderText";
            this.labelLoaderText.Size = new System.Drawing.Size(110, 21);
            this.labelLoaderText.TabIndex = 17;
            this.labelLoaderText.Text = "Loading ...";
            this.labelLoaderText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLoaderText.UseWaitCursor = true;
            // 
            // pictureBoxSpinner
            // 
            this.pictureBoxSpinner.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSpinner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxSpinner.Image = global::APP.GPMS.Properties.Resources.ZKZg;
            this.pictureBoxSpinner.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxSpinner.Name = "pictureBoxSpinner";
            this.pictureBoxSpinner.Size = new System.Drawing.Size(22, 21);
            this.pictureBoxSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinner.TabIndex = 16;
            this.pictureBoxSpinner.TabStop = false;
            this.pictureBoxSpinner.UseWaitCursor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelLoaderText);
            this.panel1.Controls.Add(this.pictureBoxSpinner);
            this.panel1.Location = new System.Drawing.Point(292, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 24);
            this.panel1.TabIndex = 18;
            // 
            // FormTransparentLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(719, 451);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTransparentLoader";
            this.Opacity = 0.5D;
            this.Text = "FormTransparentLoader";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinner)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBoxSpinner;
        public System.Windows.Forms.Label labelLoaderText;
        public System.Windows.Forms.Panel panel1;
    }
}