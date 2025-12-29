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

namespace APP.GPMS.Packing
{
    public partial class FormPickAndPack : Form
    {
        public FormPickAndPack()
        {
            InitializeComponent();
        }

        private void FormPickAndPack_Load(object sender, EventArgs e)
        {

        }

        PackingInstructionMBo pPackingInstructionMBo = null;
        void ResetClearForm()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                pPackingInstructionMBo = null;


                pictureBoxPONoSelect.Image = Properties.Resources.icons8_pending_24;
                textBoxPackInstMID.Text = "";
                textBoxPackInstDID.Text = "";
                textBoxItemNo.Text = "";
                labelCustomer.Text = labelPONo.Text
                    = labelSequenceNo.Text = labelStatus.Text
                    = labelStoreNo.Text = labelDC.Text = labelDescription.Text = "";
                dataGridViewPickPack.Rows.Clear();
                labelTotalBoxQty.Text = "0";
                labelTotalScanQty.Text = "0";
                labelTotalRemainingQty.Text = "0";
                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        void setScanAndRemainingQtyValues()
        {
            try
            {
                int Total = Convert.ToInt32(labelTotalBoxQty.Text);
                int scan = dataGridViewPickPack.Rows
                                    .Cast<DataGridViewRow>()
                                    .Sum(x => Convert.ToInt32(x.Cells["ScanQty"].Value));
                labelTotalScanQty.Text = scan.ToString();
                labelTotalRemainingQty.Text = (Total - scan).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonPOGo_Click(object sender, EventArgs e)
        {
            pPackingInstructionMBo = null;
            try
            {
                ResetClearForm();
                this.Cursor = Cursors.WaitCursor;
                if (!string.IsNullOrEmpty(textBoxBoxBarcode.Text.Trim()))
                {
                    var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                    var resBox = objService.GetBoxDataByBarcode((textBoxBoxBarcode.Text));

                    if (resBox.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                    {
                        if (string.IsNullOrEmpty(resBox.PackingInstructionMBo.Status) || resBox.PackingInstructionMBo.Status == "G")//hardcode
                        {
                            pictureBoxPONoSelect.Image = Properties.Resources.icons8_tick_24;

                            pPackingInstructionMBo = resBox.PackingInstructionMBo;
                            //textBoxPONo.Text = resPOM.POMBo.PONo;
                            textBoxPackInstMID.Text = resBox.PackingInstructionMBo.ID.ToString();

                            labelCustomer.Text = resBox.PackingInstructionMBo.CustomerInfoBo.CustomerName;
                            labelPONo.Text = resBox.PackingInstructionMBo.PONo;
                            labelSequenceNo.Text = resBox.PackingInstructionMBo.CartonSequence.ToString();
                            labelStatus.Text = resBox.PackingInstructionMBo.Status;
                            labelStoreNo.Text = resBox.PackingInstructionMBo.StoreNo;
                            labelDC.Text = resBox.PackingInstructionMBo.DC;
                            labelDescription.Text = resBox.PackingInstructionMBo.Description;

                            if (resBox.PackingInstructionMBo.PackingInstructionDList != null && resBox.PackingInstructionMBo.PackingInstructionDList.Count > 0)
                            {
                                foreach (var PID in resBox.PackingInstructionMBo.PackingInstructionDList)
                                {
                                    var index = dataGridViewPickPack.Rows.Add(
                                                     PID.PackingInstructionMID
                                                   , PID.ID
                                                   , dataGridViewPickPack.RowCount + 1
                                                   , PID.StyleInfoBo.ID
                                                   , PID.StyleInfoBo.StyleName
                                                   , PID.ColorInfoBo.ID
                                                   , PID.ColorInfoBo.ColorName
                                                   , PID.SizeInfoBo.ID
                                                   , PID.SizeInfoBo.SizeName
                                                   , PID.ItemNo
                                                   , PID.ItemQtyPerCase
                                                   , 0
                                                   , PID.ItemQtyPerCase
                                               );
                                }
                                labelTotalBoxQty.Text = resBox.PackingInstructionMBo.PackingInstructionDList.Sum(x => x.ItemQtyPerCase).ToString();
                                dataGridViewPickPack.Columns["SystemQty"].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                                dataGridViewPickPack.Columns["SystemQty"].DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 255, 192);
                                dataGridViewPickPack.Columns["ScanQty"].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 255);
                                dataGridViewPickPack.Columns["ScanQty"].DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 255, 255);
                                dataGridViewPickPack.Columns["RemainingQty"].DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 192);
                                dataGridViewPickPack.Columns["RemainingQty"].DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 224, 192);

                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Info, "Box is already packed");
                            ResetClearForm();
                        }
                        this.Cursor = Cursors.Default;
                    }
                    else if (resBox.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                    {
                        this.Cursor = Cursors.Default;
                        new MessagePopup().ShowMessagePopup((this), MessagePopupType.Info, "Box not found");
                    }
                    else        //Checking all of the things( Client Side) are Okay but response is negative
                    {
                        this.Cursor = Cursors.Default;
                        //Showing Error Message to User
                        string errorRes = resBox.DtoStatusNotes.Exception;
                        MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please enter box barcode");
                    textBoxBoxBarcode.Focus();
                    //MessageBox.Show("Error while loading this action");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void buttonItemGo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPickPack.RowCount > 0)
                {
                    var foundRow = dataGridViewPickPack.Rows
                                    .Cast<DataGridViewRow>()
                                    .Where(x => x.Cells["ItemNo"].Value.ToString().ToUpper() == textBoxItemNo.Text.ToString().ToUpper())
                                    .FirstOrDefault();
                    if (foundRow != null)
                    {
                        dataGridViewPickPack.ClearSelection();
                        dataGridViewPickPack.CurrentCell = foundRow.Cells.Cast<DataGridViewCell>().Where(x => x.Visible).FirstOrDefault();
                        foundRow.Selected = true;

                        int sysQty = Convert.ToInt32(foundRow.Cells["SystemQty"].Value);
                        int scanQty = Convert.ToInt32(foundRow.Cells["ScanQty"].Value);
                        if (scanQty < sysQty)
                        {
                            scanQty = scanQty + 1;
                            foundRow.Cells["ScanQty"].Value = scanQty;
                            foundRow.Cells["RemainingQty"].Value = sysQty - (scanQty);
                            textBoxItemNo.Text = "";
                            setScanAndRemainingQtyValues();
                        }
                        else if (scanQty == sysQty)
                        {
                            this.Cursor = Cursors.Default;
                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Item quantity reached to its end, cannot include more quantity in packing");

                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Quantity Error");
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Item not found in list, cannot include this item in packing");

                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            textBoxItemNo.SelectAll();
            textBoxItemNo.Focus();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (ProcessPacking())
                {
                    ResetClearForm();
                }
                else
                {

                }
            }
        }


        bool isValidate()
        {
            if (string.IsNullOrEmpty(textBoxPackInstMID.Text))
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a box");
                textBoxBoxBarcode.Focus();
                return false;
            }
            else if (pPackingInstructionMBo == null)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a box");
                textBoxBoxBarcode.Focus();
                return false;
            }
            //if any not properly filled row found
            else if (dataGridViewPickPack.Rows
                                .Cast<DataGridViewRow>()
                                .Where(x => Convert.ToInt32(x.Cells["ScanQty"].Value) == 0
                                        || Convert.ToInt32(x.Cells["ScanQty"].Value) != Convert.ToInt32(x.Cells["SystemQty"].Value))
                                .Any()
                                )
            {
                var row = dataGridViewPickPack.Rows
                                .Cast<DataGridViewRow>()
                                .Where(x => Convert.ToInt32(x.Cells["ScanQty"].Value) == 0
                                        || Convert.ToInt32(x.Cells["ScanQty"].Value) != Convert.ToInt32(x.Cells["SystemQty"].Value)).First();

                dataGridViewPickPack.ClearSelection();
                dataGridViewPickPack.CurrentCell = row.Cells.Cast<DataGridViewCell>().Where(x => x.Visible).FirstOrDefault();
                row.Selected = true;

                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "One or more item(s) has/have less quantity in box , please complete the box accordingly");
                textBoxBoxBarcode.Focus();
                return false;
            }
            return true;
        }



        bool ProcessPacking()
        {
            try
            {
                if (isValidate())
                {
                    if (string.IsNullOrEmpty(pPackingInstructionMBo.Status) || (!string.IsNullOrEmpty(pPackingInstructionMBo.Status) && pPackingInstructionMBo.Status == "G"))
                    {
                        //DialogResult resultUpdateQ = MessageBox.Show("Are you sure to packing?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        //if (resultUpdateQ == DialogResult.Yes)
                        {
                            this.Cursor = Cursors.WaitCursor;

                            var objService = new GPMSService.GPMSServiceClient();
                            var res = objService.SaveBoxPacking(pPackingInstructionMBo.ID, LoginUser._userID, LoginUser._userName);
                            if (res.DtoStatus == DtoStatus.Success) //if update response is successfull
                            {
                                // show success message to user
                                this.Cursor = Cursors.Default;

                                //MessageBox.Show("Data is saved successfully!");
                                string strMsg = "Box : " + pPackingInstructionMBo.BoxBarcode + " is packed successfully";
                                new MessagePopup().ShowMessagePopup(this, MessagePopupType.Success, strMsg);
                                return true;

                            }
                            else if (res.DtoStatus == DtoStatus.RecordNotUpdatedWithoutChanges)
                            {
                                this.Cursor = Cursors.Default;
                            }
                            else if (res.DtoStatus == DtoStatus.NoDataFound)
                            {
                                this.Cursor = Cursors.Default;
                            }
                            else if (res.DtoStatus == DtoStatus.RecordNotUpdated)
                            {
                                this.Cursor = Cursors.Default;
                            }
                            else   //if Update status is error then showing exception messages
                            {
                                this.Cursor = Cursors.Default;
                                string errorRes = res.DtoStatusNotes.Exception;
                                MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Box is already packed, no need to process");
                        textBoxBoxBarcode.Focus();
                        return false;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
                return false;

            }
#pragma warning disable CS0162 // Unreachable code detected
            return false;
#pragma warning restore CS0162 // Unreachable code detected
        }

        private void textBoxBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonBoxGo.PerformClick();
            }
        }

        private void textBoxItemNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonItemGo.PerformClick();
            }
        }

        private void buttonUnpackAll_Click(object sender, EventArgs e)
        {
            DialogResult resultUpdateQ = MessageBox.Show("Are you sure to unpack all?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultUpdateQ == DialogResult.Yes)
            {
                dataGridViewPickPack.Rows
                .Cast<DataGridViewRow>().ToList()
                .ForEach(x =>
                {
                    x.Cells["ScanQty"].Value = "0";
                    x.Cells["RemainingQty"].Value = x.Cells["SystemQty"].Value;
                });

                setScanAndRemainingQtyValues();
            }
        }
    }
}
