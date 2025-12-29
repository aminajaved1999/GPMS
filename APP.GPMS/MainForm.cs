
using APP.GPMS.Packing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.GPMS
{
    public partial class MainForm : Form
    {
        //Form formFimback = new Form();

        const int WS_MINIMIZEBOX = 0x20000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                cp.Style |= WS_MINIMIZEBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;
            const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form

            switch (m.Msg)
            {
                case WM_SYSCOMMAND:             //preventing the form from being moved by the mouse.
                    int command = m.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            if (m.Msg == WM_NCLBUTTONDBLCLK)       //preventing the form being resized by the mouse double click on the title bar.
            {
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "GPMS (" + APP.GPMS.App.appVersion + ")";

            //new MessagePopup().ShowMessagePopup( (this),MessagePopupType.Success, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");
            //new MessagePopup().ShowMessagePopup( (this),MessagePopupType.Info, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");
            //new MessagePopup().ShowMessagePopup( (this),MessagePopupType.Error, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");
            //new MessagePopup().ShowMessagePopup( (this),MessagePopupType.Warning, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");


            //var resMsg1 = new MessagePopup().ShowMessagePopup(MessagePopupType.Error, "Error Message");
            //resMsg1.Location = new Point(100, 100);
            //this.Controls.Add(resMsg1);
            //resMsg1.BringToFront();

            //var resMsg2 = new MessagePopup().ShowMessagePopup(MessagePopupType.Info, "Error Message");
            //resMsg2.Location = new Point(100, 150);
            //this.Controls.Add(resMsg2);
            //resMsg2.BringToFront();

            //var resMsg3 = new MessagePopup().ShowMessagePopup(MessagePopupType.Warning, "Error Message");
            //resMsg3.Location = new Point(100, 200);
            //this.Controls.Add(resMsg3);
            //resMsg3.BringToFront();



        }

        FormTransparentLoader loader = new FormTransparentLoader();
        void showLoader()
        {
            this.Cursor = Cursors.WaitCursor;
            loader.Cursor = Cursors.WaitCursor;
            //loader.Size = this.Size;
            //Telling the operating system that we want to set the start position manually
            loader.StartPosition = FormStartPosition.Manual;
            //Actually setting our Width, Height, and Location
            loader.Height = Screen.PrimaryScreen.WorkingArea.Height;
            loader.Width = Screen.PrimaryScreen.WorkingArea.Width;
            loader.Location = Screen.PrimaryScreen.WorkingArea.Location;
            loader.labelLoaderText.BackColor = Color.Transparent;
            loader.labelLoaderText.ForeColor = Color.White;
            loader.pictureBoxSpinner.BackColor = Color.Transparent;
            loader.BringToFront();
            //loader.WindowState = FormWindowState.Maximized;
            loader.Show();
            loader.BringToFront();

        }
        void hideLoader()
        {
            this.Cursor = Cursors.Default;
            loader.Hide();
        }


        public Form currentForm = null;
        public Form childForm = null;
        void OpenForm(Form pForm, Form pchildForm)
        {
            currentForm = pForm;
            childForm = pchildForm;
            if (!bgwFormOpen.IsBusy)
            {
                showLoader();
                bgwFormOpen.RunWorkerAsync();
            }
            else
            {
                bgwFormOpen.CancelAsync();
                bgwFormOpen = null;
                bgwFormOpen = new BackgroundWorker();
                bgwFormOpen.WorkerSupportsCancellation = true;
                bgwFormOpen.DoWork += bgwFormOpen_DoWork;
                bgwFormOpen.RunWorkerCompleted += bgwFormOpen_RunWorkerCompleted;
                showLoader();
                bgwFormOpen.RunWorkerAsync();
            }
        }


        private void bgwFormOpen_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);

            if (this.IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((Action)(() =>
                    {

                        this.Controls.OfType<Panel>().ToList().ForEach(f => f.Dispose());
                        if (!MdiChildren.Any())
                        {
                            if (currentForm != null)
                            {
                                currentForm.FormBorderStyle = FormBorderStyle.None;
                                currentForm.MdiParent = this;
                                currentForm.TopLevel = false;
                                currentForm.Dock = DockStyle.Fill;
                                currentForm.Show();
                                loader.BringToFront();

                                if (childForm != null)
                                {
                                    childForm.TopLevel = false;
                                    (currentForm as FormCustomerPurchaseOrder).panelContainer.Controls.Add(childForm);
                                    childForm.FormBorderStyle = FormBorderStyle.None;
                                    childForm.Show();
                                    currentForm.WindowState = FormWindowState.Maximized;
                                    loader.BringToFront();
                                }

                            }
                        }

                    }));
                }
                else
                {
                    this.Controls.OfType<Panel>().ToList().ForEach(f => f.Dispose());
                    if (!MdiChildren.Any())
                    {
                        if (currentForm != null)
                        {
                            currentForm.FormBorderStyle = FormBorderStyle.None;
                            currentForm.MdiParent = this;
                            currentForm.TopLevel = false;
                            currentForm.Dock = DockStyle.Fill;
                            currentForm.Show();
                            loader.BringToFront();

                            if (childForm != null)
                            {
                                childForm.TopLevel = false;
                                (currentForm as FormCustomerPurchaseOrder).panelContainer.Controls.Add(childForm);
                                childForm.FormBorderStyle = FormBorderStyle.None;
                                childForm.Show();
                                currentForm.WindowState = FormWindowState.Maximized;
                                loader.BringToFront();
                            }

                        }

                    }

                }
            }
        }

        private void bgwFormOpen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            hideLoader();
        }
        private void customerOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MdiChildren.Any())
            {
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO1());
            }
            else if (childForm == null || childForm.Name != nameof(FormPO1))
            {
                MdiChildren.First().Close();
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO1());
            }
        }

        private void orderStylesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MdiChildren.Any())
            {
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO2());
            }
            else if (childForm == null || childForm.Name != nameof(FormPO2))
            {
                MdiChildren.First().Close();
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO2());
            }
        }

        private void orderColorSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MdiChildren.Any())
            {
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO3());
            }
            else if (childForm == null || childForm.Name != nameof(FormPO3))
            {
                MdiChildren.First().Close();
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO3());
            }
        }

        private void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MdiChildren.Any())
            {
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO4Post());
            }
            else if (childForm == null || childForm.Name != nameof(FormPO4Post))
            {
                MdiChildren.First().Close();
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO4Post());
            }
        }

        private void generatePackingPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MdiChildren.Any())
            {
                this.SuspendLayout();
                OpenForm(new FormGeneratePackingPlan(), null);
                this.ResumeLayout();

            }
            else if (currentForm == null || currentForm.Name != nameof(FormGeneratePackingPlan))
            {
                MdiChildren.First().Close();
                OpenForm(new FormGeneratePackingPlan(), null);
            }
        }

        private void approveRejectOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MdiChildren.Any())
            {
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO5Approve());
            }
            else if (childForm == null || childForm.Name != nameof(FormPO5Approve))
            {
                MdiChildren.First().Close();
                OpenForm(new FormCustomerPurchaseOrder(), new FormPO5Approve());
            }
        }

        private void pickPackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!MdiChildren.Any())
            {
                OpenForm(new FormPickAndPack(), null);
            }
            else if (currentForm == null || currentForm.Name != nameof(FormPickAndPack))
            {
                MdiChildren.First().Close();
                OpenForm(new FormPickAndPack(), null);
            }
        }
    }
}
