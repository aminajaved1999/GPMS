
namespace ItemsCombinationFinder
{
    partial class MainForm
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
            this.btnFindCombinations = new System.Windows.Forms.Button();
            this.txtNumItems = new System.Windows.Forms.TextBox();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFindCombinations
            // 
            this.btnFindCombinations.Location = new System.Drawing.Point(52, 96);
            this.btnFindCombinations.Name = "btnFindCombinations";
            this.btnFindCombinations.Size = new System.Drawing.Size(282, 23);
            this.btnFindCombinations.TabIndex = 11;
            this.btnFindCombinations.Text = "Find Combinations";
            this.btnFindCombinations.UseVisualStyleBackColor = true;
            this.btnFindCombinations.Click += new System.EventHandler(this.btnFindCombinations_Click);
            // 
            // txtNumItems
            // 
            this.txtNumItems.Location = new System.Drawing.Point(213, 61);
            this.txtNumItems.Name = "txtNumItems";
            this.txtNumItems.Size = new System.Drawing.Size(121, 20);
            this.txtNumItems.TabIndex = 10;
            this.txtNumItems.Text = "Enter No. of Items";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(213, 38);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(121, 20);
            this.txtCapacity.TabIndex = 9;
            this.txtCapacity.Text = "Enter Carton Capacity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Number of Items:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Capacity:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 156);
            this.Controls.Add(this.btnFindCombinations);
            this.Controls.Add(this.txtNumItems);
            this.Controls.Add(this.txtCapacity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "ItemsCombinationFinder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFindCombinations;
        private System.Windows.Forms.TextBox txtNumItems;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}