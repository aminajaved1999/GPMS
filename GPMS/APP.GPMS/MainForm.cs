using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.GPMS
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }


        Form formFimback = new Form();
        private void button1_Click(object sender, EventArgs e)
        {
            formFimback.BackColor = Color.Black;
            formFimback.Opacity = 0.50;
            formFimback.FormBorderStyle = FormBorderStyle.None;
            //form.TopLevel = false;
            formFimback.Size = new Size(this.Width, this.Height);
            formFimback.Location = new Point(0, 0);
            formFimback.Dock = DockStyle.Fill;
            //this.Controls.Add(form);
            formFimback.Show();

            FormGeneralLookup formGeneralLookup = new FormGeneralLookup();
            formGeneralLookup.PopupSelectionType = GeneralPopupSelectionType.Customer;
            formGeneralLookup.DataFilterIsActive = null;
            formGeneralLookup.Text = "Customer Lookup";
            formGeneralLookup.dataGridViewCollectionDisplay.Columns["RowCode"].HeaderText = "Customer Code";
            formGeneralLookup.dataGridViewCollectionDisplay.Columns["RowName"].HeaderText = "Customer Name";
            formGeneralLookup.ShowDialog();
            formFimback.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            formFimback.BackColor = Color.Black;
            formFimback.Opacity = 0.50;
            formFimback.FormBorderStyle = FormBorderStyle.None;
            //form.TopLevel = false;
            formFimback.Size = new Size(this.Width, this.Height);
            formFimback.Location = new Point(0, 0);
            formFimback.Dock = DockStyle.Fill;
            //this.Controls.Add(form);
            formFimback.Show();

            FormGeneralLookup formGeneralLookup = new FormGeneralLookup();
            formGeneralLookup.DataFilterIsActive = null;
            formGeneralLookup.pCustomerID = Convert.ToInt32(textBox1.Text);
            formGeneralLookup.PopupSelectionType = GeneralPopupSelectionType.Style;
            formGeneralLookup.Text = "Style Lookup";
            formGeneralLookup.dataGridViewCollectionDisplay.Columns["RowCode"].HeaderText = "Style Code";
            formGeneralLookup.dataGridViewCollectionDisplay.Columns["RowName"].HeaderText = "Style Name";
            formGeneralLookup.ShowDialog();
            formFimback.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            formFimback.BackColor = Color.Black;
            formFimback.Opacity = 0.50;
            formFimback.FormBorderStyle = FormBorderStyle.None;
            //form.TopLevel = false;
            formFimback.Size = new Size(this.Width, this.Height);
            formFimback.Location = new Point(0, 0);
            formFimback.Dock = DockStyle.Fill;
            //this.Controls.Add(form);
            formFimback.Show();

            FormGeneralLookup formGeneralLookup = new FormGeneralLookup();
            formGeneralLookup.DataFilterIsActive = null;
            formGeneralLookup.pCustomerID = Convert.ToInt32(textBox2.Text);
            formGeneralLookup.PopupSelectionType = GeneralPopupSelectionType.Size;
            formGeneralLookup.Text = "Size Lookup";
            formGeneralLookup.dataGridViewCollectionDisplay.Columns["RowCode"].HeaderText = "Size Code";
            formGeneralLookup.dataGridViewCollectionDisplay.Columns["RowName"].HeaderText = "Size Name";
            formGeneralLookup.ShowDialog();
            formFimback.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            formFimback.BackColor = Color.Black;
            formFimback.Opacity = 0.50;
            formFimback.FormBorderStyle = FormBorderStyle.None;
            //form.TopLevel = false;
            formFimback.Size = new Size(this.Width, this.Height);
            formFimback.Location = new Point(0, 0);
            formFimback.Dock = DockStyle.Fill;
            //this.Controls.Add(form);
            formFimback.Show();

            FormGeneralLookup formGeneralLookup = new FormGeneralLookup();
            formGeneralLookup.DataFilterIsActive = null;
            formGeneralLookup.pCustomerID = Convert.ToInt32(textBox3.Text);
            formGeneralLookup.PopupSelectionType = GeneralPopupSelectionType.Color;
            formGeneralLookup.Text = "Color Lookup";
            formGeneralLookup.dataGridViewCollectionDisplay.Columns["RowCode"].HeaderText = "Color Code";
            formGeneralLookup.dataGridViewCollectionDisplay.Columns["RowName"].HeaderText = "Color Name";
            formGeneralLookup.ShowDialog();
            formFimback.Hide();
        }
    }
}
