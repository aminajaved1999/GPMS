using Entities.GPMS;
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
    public partial class FormGeneralLookup : Form
    {
        public const int pageSize = 2;

        public FormGeneralLookup()
        {
            InitializeComponent();
        }
        private void FormGeneralLookup_Load(object sender, EventArgs e)
        {
            if (PopupSelectionType == GeneralPopupSelectionType.Select)
            {
                MessageBox.Show("Selection is not valid");
                this.Hide();
                this.BeginInvoke(new MethodInvoker(this.Close));
            }
            labelPlaceHolderText.Text = "*Search " + dataGridViewCollectionDisplay.Columns[2].HeaderText + " / " + dataGridViewCollectionDisplay.Columns[3].HeaderText;
            forceToRunUpdatedDataBackWorker();
            this.Cursor = Cursors.Default;
            textBoxSearch.Focus();

        }
        public bool? DataFilterIsActive = null;
        FetchDto resFetchList = null;
        public int pCustomerID;
        public GeneralPopupSelectionType PopupSelectionType = GeneralPopupSelectionType.Select;


        public SentAtrributes sentAtrributes = new SentAtrributes();

        public class SentAtrributes
        {
            public int sentID { get; set; }
            public string sentCode { get; set; }
            public string sentName { get; set; }
            public string sentExtra { get; set; }

        }
        private void dataGridViewCollectionDisplay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    // Getting Serial No. from DataGridView and putting in Current Selected Value Index//
                    labelSelect.Text = dataGridViewCollectionDisplay.CurrentRow.Cells["SrNo"].Value.ToString();

                    if (dataGridViewCollectionDisplay.CurrentCell.ColumnIndex == dataGridViewCollectionDisplay.Rows[e.RowIndex].Cells["RowSelect"].ColumnIndex)
                    {
                        //checking if cell has value then performing following action//
                        if (dataGridViewCollectionDisplay.CurrentCell != null && dataGridViewCollectionDisplay.CurrentCell.Value != null)
                        {
                            sentAtrributes.sentID = Convert.ToInt32(dataGridViewCollectionDisplay.CurrentRow.Cells["RowID"].Value);
                            sentAtrributes.sentCode = dataGridViewCollectionDisplay.CurrentRow.Cells["RowCode"].Value != null ? (dataGridViewCollectionDisplay.CurrentRow.Cells["RowCode"].Value).ToString() : "";
                            sentAtrributes.sentName = (dataGridViewCollectionDisplay.CurrentRow.Cells["RowName"].Value).ToString();
                            //sentAtrributes.sentExtra = dataGridViewCollectionDisplay.CurrentRow.Cells["ExtraColumn"].Value != null ? (dataGridViewCollectionDisplay.CurrentRow.Cells["ExtraColumn"].Value).ToString() : "";
                            Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCollectionDisplay_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    //checking if cell has value then performing following action//
                    if (dataGridViewCollectionDisplay.CurrentCell != null && dataGridViewCollectionDisplay.CurrentCell.Value != null)
                    {
                        sentAtrributes.sentID = Convert.ToInt32(dataGridViewCollectionDisplay.CurrentRow.Cells["RowID"].Value);
                        sentAtrributes.sentCode = dataGridViewCollectionDisplay.CurrentRow.Cells["RowCode"].Value != null ? (dataGridViewCollectionDisplay.CurrentRow.Cells["RowCode"].Value).ToString() : "";
                        sentAtrributes.sentName = (dataGridViewCollectionDisplay.CurrentRow.Cells["RowName"].Value).ToString();
                        //sentAtrributes.sentExtra = (dataGridViewCollectionDisplay.CurrentRow.Cells["ExtraColumn"].Value).ToString();

                        Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCollectionDisplay_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridViewCollectionDisplay.Columns["RowSelect"].Index)
                    dataGridViewCollectionDisplay.Cursor = Cursors.Hand;
                else
                    dataGridViewCollectionDisplay.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCollectionDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dataGridViewCollectionDisplay.CurrentCell != null && dataGridViewCollectionDisplay.CurrentCell.Value != null)
                    {
                        sentAtrributes.sentID = Convert.ToInt32(dataGridViewCollectionDisplay.CurrentRow.Cells["RowID"].Value);
                        sentAtrributes.sentCode = dataGridViewCollectionDisplay.CurrentRow.Cells["RowCode"].Value != null ? (dataGridViewCollectionDisplay.CurrentRow.Cells["RowCode"].Value).ToString() : "";
                        sentAtrributes.sentName = (dataGridViewCollectionDisplay.CurrentRow.Cells["RowName"].Value).ToString();
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewCollectionDisplay_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCollectionDisplay.CurrentRow != null)
            {
                // Getting Serial No. from DataGridView and putting in Current Selected Value Index//
                labelSelect.Text = dataGridViewCollectionDisplay.CurrentRow.Cells["SrNo"].Value.ToString();
            }
        }

        private void dataGridViewCollectionDisplay_Sorted(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCollectionDisplay.Rows.Count > 0)
                {
                    int pgOff = 0;
                    PageList.ItemPage page = bindingSource1.Current as PageList.ItemPage;
                    if (page != null)
                        pgOff = page.Offset;
                    int count = pgOff;
                    foreach (DataGridViewRow row in dataGridViewCollectionDisplay.Rows)
                    {
                        row.Cells["SrNo"].Value = count;
                        count++;
                    }

                    dataGridViewCollectionDisplay.FirstDisplayedCell.Selected = true;

                    labelSelect.Text = "1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void forceToRunUpdatedDataBackWorker()
        {
            try
            {
                if (!backgroundWorkerPOPUP.IsBusy)
                {
                    bindingSource1.DataSource = null;
                    backgroundWorkerPOPUP.RunWorkerAsync();
                }
                else
                {
                    backgroundWorkerPOPUP.CancelAsync();
                    backgroundWorkerPOPUP = null;
                    backgroundWorkerPOPUP = new BackgroundWorker();
                    backgroundWorkerPOPUP.WorkerSupportsCancellation = true;
                    backgroundWorkerPOPUP.DoWork += backgroundWorkerPOPUP_DoWork;
                    backgroundWorkerPOPUP.RunWorkerCompleted += backgroundWorkerPOPUP_RunWorkerCompleted;
                    bindingSource1.DataSource = null;
                    backgroundWorkerPOPUP.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textChangeTimer != null)
                textChangeTimer.Stop();
            else
            {
                textChangeTimer = new System.Windows.Forms.Timer();
                textChangeTimer.Interval = 200;
                textChangeTimer.Tick += TextChangeTimer_Tick;
            }
            textChangeTimer.Start();
        }
        System.Windows.Forms.Timer textChangeTimer;

        private void TextChangeTimer_Tick(object sender, EventArgs e)
        {
            forceToRunUpdatedDataBackWorker();
            this.Cursor = Cursors.Default;

            if (textChangeTimer != null)
                textChangeTimer.Stop();
        }
        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridViewCollectionDisplay.RowCount > 0)
                {
                    try
                    {
                        dataGridViewCollectionDisplay.CurrentCell = dataGridViewCollectionDisplay.FirstDisplayedCell;
                        //checking if cell has value then performing following action//
                        if (dataGridViewCollectionDisplay.CurrentCell != null && dataGridViewCollectionDisplay.CurrentCell.Value != null)
                        {
                            sentAtrributes.sentID = Convert.ToInt32(dataGridViewCollectionDisplay.CurrentRow.Cells["RowID"].Value);
                            sentAtrributes.sentCode = dataGridViewCollectionDisplay.CurrentRow.Cells["RowCode"].Value != null ? (dataGridViewCollectionDisplay.CurrentRow.Cells["RowCode"].Value).ToString() : "";
                            sentAtrributes.sentName = (dataGridViewCollectionDisplay.CurrentRow.Cells["RowName"].Value).ToString();
                            //sentAtrributes.sentExtra = (dataGridViewCollectionDisplay.CurrentRow.Cells["ExtraColumn"].Value).ToString();

                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                dataGridViewCollectionDisplay.Focus();
            }

        }

        private void backgroundWorkerPOPUP_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


                if (this.IsHandleCreated)
                {
                    if (dataGridViewCollectionDisplay.InvokeRequired)
                    {
                        dataGridViewCollectionDisplay.BeginInvoke(new Action(() =>
                        {
                            dataGridViewCollectionDisplay.Enabled = false;
                        }));
                    }
                    else
                        dataGridViewCollectionDisplay.Enabled = false;
                }
                if (this.IsHandleCreated)
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new Action(() =>
                        {
                            this.Cursor = Cursors.WaitCursor;
                        }));
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                    }
                }

                int pgOff = 0;
                if (bindingSource1.DataSource != null)
                {
                    //select current pgOffset
                    PageList.ItemPage page = bindingSource1.Current as PageList.ItemPage;
                    if (page != null)
                        pgOff = page.Offset;
                    // var items = m_datastore.GetTableItems(m_conn, list.TableName, page.Limit, page.Offset);
                }
                string text = null;
                int compID = 0;
                if (this.IsHandleCreated)
                {
                    if (this.InvokeRequired)
                    {
                        this.Invoke(new Action(() =>
                        {
                            text = string.IsNullOrEmpty(textBoxSearch.Text) ? null : textBoxSearch.Text;

                        }));
                    }
                    else
                    {
                        text = string.IsNullOrEmpty(textBoxSearch.Text) ? null : textBoxSearch.Text;

                    }
                }


                compID = LoginUser.CompanyID;
                if (PopupSelectionType == GeneralPopupSelectionType.Customer)
                    resFetchList = new GPMSService.GPMSServiceClient().SkipNGetN_OfCustomerDataWithSearch(compID, DataFilterIsActive, text, (pgOff), pageSize);
                else if (PopupSelectionType == GeneralPopupSelectionType.Style)
                    resFetchList = new GPMSService.GPMSServiceClient().SkipNGetN_OfStyleDataWithSearch(pCustomerID, DataFilterIsActive, text, (pgOff), pageSize);
                else if (PopupSelectionType == GeneralPopupSelectionType.Size)
                    resFetchList = new GPMSService.GPMSServiceClient().SkipNGetN_OfSizeDataWithSearch(pCustomerID, DataFilterIsActive, text, (pgOff), pageSize);
                else if (PopupSelectionType == GeneralPopupSelectionType.Color)
                    resFetchList = new GPMSService.GPMSServiceClient().SkipNGetN_OfColorDataWithSearch(pCustomerID, DataFilterIsActive, text, (pgOff), pageSize);

                if (this.IsHandleCreated)
                {
                    dataGridViewCollectionDisplay.BeginInvoke(new Action(() =>
                    {
                        dataGridViewCollectionDisplay.Rows.Clear();
                    }));
                }

                if (resFetchList != null && resFetchList.DtoStatus == DtoStatus.Success && resFetchList.SelectedCount > 0) // Checking all of the things are Okay and response is positive
                {

                    this.Invoke(new Action(() =>
                    {
                        if (bindingSource1.DataSource == null)
                        {
                            bindingNavigator1.BindingSource = bindingSource1;
                            bindingSource1.DataSource = new PageList("PopupList", resFetchList.TotalCount);
                        }


                        // Thread.Sleep(1500);
                        if (PopupSelectionType == GeneralPopupSelectionType.Customer)
                        {
                            foreach (var row in resFetchList.CustomerInfoCollection)
                            {
                                {
                                    int rowIndex = dataGridViewCollectionDisplay.Rows.Add
                                                (
                                                    pgOff + dataGridViewCollectionDisplay.RowCount + 1
                                                    , row.ID
                                                    , row.CustomerCode
                                                    , row.CustomerName
                                                    , null
                                                    , null
                                                );
                                }
                            }
                        }
                        else if (PopupSelectionType == GeneralPopupSelectionType.Style)
                        {
                            foreach (var row in resFetchList.StyleInfoCollection)
                            {
                                {
                                    int rowIndex = dataGridViewCollectionDisplay.Rows.Add
                                                (
                                                    pgOff + dataGridViewCollectionDisplay.RowCount + 1
                                                    , row.ID
                                                    , row.StyleCode
                                                    , row.StyleName
                                                    , null
                                                    , null
                                                );
                                }
                            }
                        }
                        else if (PopupSelectionType == GeneralPopupSelectionType.Size)
                        {
                            foreach (var row in resFetchList.SizeInfoCollection)
                            {
                                {
                                    int rowIndex = dataGridViewCollectionDisplay.Rows.Add
                                                (
                                                    pgOff + dataGridViewCollectionDisplay.RowCount + 1
                                                    , row.ID
                                                    , row.SizeCode
                                                    , row.SizeName
                                                    , null
                                                    , null
                                                );
                                }
                            }
                        }
                        else if (PopupSelectionType == GeneralPopupSelectionType.Color)
                        {
                            foreach (var row in resFetchList.ColorInfoCollection)
                            {
                                {
                                    int rowIndex = dataGridViewCollectionDisplay.Rows.Add
                                                (
                                                    pgOff + dataGridViewCollectionDisplay.RowCount + 1
                                                    , row.ID
                                                    , row.ColorCode
                                                    , row.ColorName
                                                    , null
                                                    , null
                                                );
                                }
                            }
                        }


                    }));

                }
                else if (resFetchList != null && resFetchList.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {

                }
                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resFetchList.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorkerPOPUP_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (dataGridViewCollectionDisplay.SortedColumn != null)
            {
                DataGridViewColumn col = dataGridViewCollectionDisplay.SortedColumn;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            int pgOff = 0;
            if (bindingSource1.DataSource != null)
            {
                //select current pgOffset
                PageList.ItemPage page = bindingSource1.Current as PageList.ItemPage;
                if (page != null)
                    pgOff = page.Offset;
                // var items = m_datastore.GetTableItems(m_conn, list.TableName, page.Limit, page.Offset);
            }
            if (resFetchList != null && resFetchList.SelectedCount > 0)
            {
                if (resFetchList.SelectedCount == 0)
                    labelSelect.Text = "0";
                else
                    labelSelect.Text = dataGridViewCollectionDisplay.CurrentRow != null ? dataGridViewCollectionDisplay.CurrentRow.Cells["SrNo"].Value.ToString() : "0";

                labelTotalCount.Text = (pgOff + resFetchList.SelectedCount).ToString();
                int showingStrtInd = resFetchList.SelectedCount > 0 ? (pgOff + 1) : 0;
                toolStripLabelShowingPageStatus.Text = "Showing " + (showingStrtInd) + " to " + (pgOff + resFetchList.SelectedCount) + " of " + resFetchList.TotalCount;
            }
            else
            {
                labelTotalCount.Text = labelSelect.Text = "0";
                toolStripLabelShowingPageStatus.Text = "";
            }

            //if (dataGridViewCollectionDisplay.RowCount > 0)
            //{
            //    toolStripStatusLabelMain.ForeColor = Color.Green;
            //    toolStripStatusLabelMain.Text = "Data successfully loaded";
            //}
            //else
            //{
            //    toolStripStatusLabelMain.ForeColor = Color.Red;
            //    toolStripStatusLabelMain.Text = "No data found in Customers";
            //}
            dataGridViewCollectionDisplay.Enabled = true;
            textBoxSearch.Enabled = true;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorkerPOPUP.IsBusy)
                {
                    if (bindingSource1.DataSource != null)
                    {
                        backgroundWorkerPOPUP.RunWorkerAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            this.Cursor = Cursors.Default;
        }


        class PageList : System.ComponentModel.IListSource
        {
            private long totalitems;

            public PageList(string tablename, long totalrecords)
            {
                this.TableName = tablename;
                totalitems = totalrecords;
            }

            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                List<ItemPage> pages = new List<ItemPage>();
                int totalPages = (int)Math.Ceiling((double)totalitems / (double)pageSize);
                pages.AddRange(Enumerable.Range(0, totalPages).Select(
                    pageidx => new ItemPage(pageSize, pageidx * pageSize)));
                return pages;
            }

            public string TableName { get; protected set; }


            public class ItemPage
            {
                public ItemPage(int limit, int offset)
                {
                    this.Limit = limit;
                    this.Offset = offset;
                }

                public readonly int Limit;
                public readonly int Offset;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
