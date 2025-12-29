
namespace APP.GPMS
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderStylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderColorSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveRejectOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packingPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePackingPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bgwFormOpen = new System.ComponentModel.BackgroundWorker();
            this.pickPackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.catalogToolStripMenuItem,
            this.orderToolStripMenuItem,
            this.packingPlanToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // catalogToolStripMenuItem
            // 
            this.catalogToolStripMenuItem.Name = "catalogToolStripMenuItem";
            this.catalogToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.catalogToolStripMenuItem.Text = "Catalog";
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerOrderToolStripMenuItem,
            this.orderStylesToolStripMenuItem,
            this.orderColorSizeToolStripMenuItem,
            this.postToolStripMenuItem,
            this.approveRejectOrderToolStripMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // customerOrderToolStripMenuItem
            // 
            this.customerOrderToolStripMenuItem.Name = "customerOrderToolStripMenuItem";
            this.customerOrderToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.customerOrderToolStripMenuItem.Text = "Customer Order";
            this.customerOrderToolStripMenuItem.Click += new System.EventHandler(this.customerOrderToolStripMenuItem_Click);
            // 
            // orderStylesToolStripMenuItem
            // 
            this.orderStylesToolStripMenuItem.Name = "orderStylesToolStripMenuItem";
            this.orderStylesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.orderStylesToolStripMenuItem.Text = "Order Style";
            this.orderStylesToolStripMenuItem.Click += new System.EventHandler(this.orderStylesToolStripMenuItem_Click);
            // 
            // orderColorSizeToolStripMenuItem
            // 
            this.orderColorSizeToolStripMenuItem.Name = "orderColorSizeToolStripMenuItem";
            this.orderColorSizeToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.orderColorSizeToolStripMenuItem.Text = "Order Color && Size";
            this.orderColorSizeToolStripMenuItem.Click += new System.EventHandler(this.orderColorSizeToolStripMenuItem_Click);
            // 
            // postToolStripMenuItem
            // 
            this.postToolStripMenuItem.Name = "postToolStripMenuItem";
            this.postToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.postToolStripMenuItem.Text = "Post Order";
            this.postToolStripMenuItem.Click += new System.EventHandler(this.postToolStripMenuItem_Click);
            // 
            // approveRejectOrderToolStripMenuItem
            // 
            this.approveRejectOrderToolStripMenuItem.Name = "approveRejectOrderToolStripMenuItem";
            this.approveRejectOrderToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.approveRejectOrderToolStripMenuItem.Text = "Approve/Reject Order";
            this.approveRejectOrderToolStripMenuItem.Click += new System.EventHandler(this.approveRejectOrderToolStripMenuItem_Click);
            // 
            // packingPlanToolStripMenuItem
            // 
            this.packingPlanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatePackingPlanToolStripMenuItem,
            this.pickPackToolStripMenuItem});
            this.packingPlanToolStripMenuItem.Name = "packingPlanToolStripMenuItem";
            this.packingPlanToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.packingPlanToolStripMenuItem.Text = "Packing Plan";
            // 
            // generatePackingPlanToolStripMenuItem
            // 
            this.generatePackingPlanToolStripMenuItem.Name = "generatePackingPlanToolStripMenuItem";
            this.generatePackingPlanToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.generatePackingPlanToolStripMenuItem.Text = "Generate Packing Plan";
            this.generatePackingPlanToolStripMenuItem.Click += new System.EventHandler(this.generatePackingPlanToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(936, 453);
            this.panel1.TabIndex = 3;
            // 
            // bgwFormOpen
            // 
            this.bgwFormOpen.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFormOpen_DoWork);
            this.bgwFormOpen.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwFormOpen_RunWorkerCompleted);
            // 
            // pickPackToolStripMenuItem
            // 
            this.pickPackToolStripMenuItem.Name = "pickPackToolStripMenuItem";
            this.pickPackToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.pickPackToolStripMenuItem.Text = "Pick && Pack";
            this.pickPackToolStripMenuItem.Click += new System.EventHandler(this.pickPackToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(936, 453);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GPMS (Beta)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerOrderToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker bgwFormOpen;
        private System.Windows.Forms.ToolStripMenuItem orderStylesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderColorSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packingPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePackingPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveRejectOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pickPackToolStripMenuItem;
    }
}



