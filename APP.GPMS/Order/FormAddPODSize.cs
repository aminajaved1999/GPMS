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
using static APP.GPMS.FormPO3;

namespace APP.GPMS
{
    public partial class FormAddPODSize : Form
    {
        public FormAddPODSize()
        {
            InitializeComponent();
            textBoxSizeCode.Focus();
        }

        public int thisPOMID = 0;
        public int thisPODID = 0;
        public int thisPODStyleID = 0;
        public int thisColorID = 0;
        public int thisSizeID = 0;
        public int thisCustomerID = 0;
        public List<int> thisUsedSizes = new List<int>();


        private void textBoxSizeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                var txtBox = sender as TextBox;

                if (txtBox == textBoxSizeCode)
                    SizeLookup();
            }
        }
        private void SizeLookup()
        {
            FormGeneralLookup formSizeListPopSelection = new FormGeneralLookup();
            formSizeListPopSelection.Text = "Size Lookup";
            formSizeListPopSelection.PopupSelectionType = GeneralPopupSelectionType.Size;
            formSizeListPopSelection.pCustomerID = thisCustomerID;
            formSizeListPopSelection.FormClosing += FormSizeListPopSelection_FormClosing;
            formSizeListPopSelection.ShowDialog();
        }

        private void FormSizeListPopSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string recCode = ((FormGeneralLookup)sender).sentAtrributes.sentCode;

                if (!string.IsNullOrEmpty(recCode))
                    textBoxSizeCode.Text = recCode;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxSizeCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var txtBox = sender as TextBox;

                if (txtBox == textBoxSizeCode)
                {
                    if (!string.IsNullOrEmpty(textBoxSizeCode.Text.Trim()))
                    {
                        //if (textBoxSizeCode.Text.Length == 5)
                        {
                            var objService = new GPMSService.GPMSServiceClient();
                            var sizeDataResponse = objService.GetSizeByCode(textBoxSizeCode.Text.Trim());

                            if (sizeDataResponse.DtoStatus == DtoStatus.Success) // attention required
                            {
                                textBoxSizeID.Text = sizeDataResponse.SizeInfoBo.ID.ToString();
                                textBoxSizeName.Text = sizeDataResponse.SizeInfoBo.SizeName;

                            }
                            else if (sizeDataResponse.DtoStatus == DtoStatus.Error)
                            {
                                MessageBox.Show(sizeDataResponse.DtoStatusNotes.Exception);
                                textBoxSizeID.Text = "";
                                textBoxSizeName.Text = "";
                            }
                            else
                            {
                                textBoxSizeID.Text = "";
                                textBoxSizeName.Text = "";
                            }
                        }
                        //else
                        //{
                        //    textBoxSizeID.Text = "";
                        //    textBoxSizeName.Text = "";
                        //}


                    }
                    else
                    {
                        textBoxSizeID.Text = "";
                        textBoxSizeName.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSizeLookup_Click(object sender, EventArgs e)
        {
            SizeLookup();
        }

        public thisPOSizeDBO thisPOSizeDBo = null;
        bool isUsed(int sizeID)
        {
            if (thisUsedSizes.Contains(sizeID))
                return true;
            return false;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSizeID.Text))
            {
                if (this.ParentForm != null)
                    new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Please select a size");
                else
                    new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a size");

                textBoxSizeCode.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxItemNo.Text.Trim()))
            {
                if (this.ParentForm != null)
                    new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Please define an item #");
                else
                    new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please define an item #");

                textBoxItemNo.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxQty.Text) || Convert.ToInt32(textBoxQty.Text) <= 0)
            {
                if (this.ParentForm != null)
                    new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Qty is non empty field, cannot be less than or equal to zero");
                else
                    new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Qty is non empty field, cannot be less than or equal to zero");

                textBoxQty.Focus();
                return;
            }
            else if (string.IsNullOrEmpty(textBoxPrice.Text) || Convert.ToDecimal(textBoxPrice.Text) <= 0)
            {
                if (this.ParentForm != null)
                    new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Price is non empty field, cannot be less than or equal to zero");
                else
                    new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Price is non empty field, cannot be less than or equal to zero");

                textBoxPrice.Focus();
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(textBoxPODSizeID.Text.Trim()))
                {
                    //if (Convert.ToInt32(textBoxSizeID.Text) == thisSizeID)
                    //{
                    //    if (this.ParentForm != null)
                    //        new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Please select a new Size");
                    //    else
                    //        new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a new Size");

                    //    return;
                    //}
                    //else

                    if (isUsed(Convert.ToInt32(Convert.ToInt32(textBoxSizeID.Text))))
                    {
                        if (this.ParentForm != null)
                            new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Size already used, please select a different size");
                        else
                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Size already used, please select a different size");

                        return;
                    }
                    else
                    {
                        //update
                        POSizeDBo pOSizeDBo = new POSizeDBo();
                        pOSizeDBo.ID = Convert.ToInt32(textBoxPODSizeID.Text);
                        pOSizeDBo.PODID = thisPODID;
                        pOSizeDBo.ColorID = thisColorID;
                        pOSizeDBo.SizeID = Convert.ToInt32(textBoxSizeID.Text);
                        pOSizeDBo.ItemNo = textBoxItemNo.Text.Trim();
                        pOSizeDBo.Qty = Convert.ToInt32(textBoxQty.Text);
                        pOSizeDBo.IsPilotRun = checkBoxIsPilotRun.Checked;
                        pOSizeDBo.ComboCode = string.IsNullOrEmpty(textBoxComboCode.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(textBoxComboCode.Text.Trim());
                        pOSizeDBo.Price = Convert.ToDecimal(textBoxPrice.Text);
                        pOSizeDBo.Description = textBoxDescription.Text;

                        if (Convert.ToInt32(textBoxPODSizeID.Text) > 0)
                        {
                            pOSizeDBo.UpdatedBy = LoginUser._userName;
                            pOSizeDBo.UpdatedByID = LoginUser._userID;
                        }
                        else
                        {
                            pOSizeDBo.CreatedBy = LoginUser._userName;
                            pOSizeDBo.CreatedByID = LoginUser._userID;
                        }

                        pOSizeDBo.SizeInfoBo = new SizeInfoBo();
                        pOSizeDBo.SizeInfoBo.ID = Convert.ToInt32(textBoxSizeID.Text);
                        pOSizeDBo.SizeInfoBo.SizeName = textBoxSizeName.Text;
                        pOSizeDBo.SizeInfoBo.SizeCode = textBoxSizeCode.Text;

                        thisPOSizeDBo = new thisPOSizeDBO(pOSizeDBo);
                        thisPOSizeDBo.IsUpdated = true;
                        //this.Hide();
                        this.Close();

                    }
                }
                else
                {
                    if (isUsed(Convert.ToInt32(Convert.ToInt32(textBoxSizeID.Text))))
                    {
                        if (this.ParentForm != null)
                            new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Size already used, please select a different size");
                        else
                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Size already used, please select a different size");

                        return;
                    }
                    else
                    {
                        //add
                        POSizeDBo pOSizeDBo = new POSizeDBo();
                        pOSizeDBo.ID = 0;
                        pOSizeDBo.PODID = thisPODID;
                        pOSizeDBo.ColorID = thisColorID;
                        pOSizeDBo.SizeID = Convert.ToInt32(textBoxSizeID.Text);
                        pOSizeDBo.ItemNo = textBoxItemNo.Text.Trim();
                        pOSizeDBo.Qty = Convert.ToInt32(textBoxQty.Text);
                        pOSizeDBo.Price = Convert.ToDecimal(textBoxPrice.Text);
                        pOSizeDBo.IsPilotRun = checkBoxIsPilotRun.Checked;
                        pOSizeDBo.ComboCode = string.IsNullOrEmpty(textBoxComboCode.Text.Trim()) ? new Nullable<int>() : Convert.ToInt32(textBoxComboCode.Text.Trim());
                        pOSizeDBo.Description = textBoxDescription.Text;
                        pOSizeDBo.CreatedBy = LoginUser._userName;
                        pOSizeDBo.CreatedByID = LoginUser._userID;

                        pOSizeDBo.SizeInfoBo = new SizeInfoBo();
                        pOSizeDBo.SizeInfoBo.ID = Convert.ToInt32(textBoxSizeID.Text);
                        pOSizeDBo.SizeInfoBo.SizeName = textBoxSizeName.Text;
                        pOSizeDBo.SizeInfoBo.SizeCode = textBoxSizeCode.Text;

                        thisPOSizeDBo = new thisPOSizeDBO(pOSizeDBo);
                        thisPOSizeDBo.IsNew = true;
                        //this.Hide();
                        this.Close();
                    }
                }
            }
        }

        private void textBoxPODSizeID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxPODSizeID.Text.Trim()))
                {
                    labelFormMode.Text = "EDIT MODE";
                    buttonSave.Text = "MODIFY";

                }
                else
                {
                    labelFormMode.Text = "DEFINITION MODE";
                    buttonSave.Text = "ADD";
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBoxQty_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxQty.Text) || textBoxQty.Text.Trim() == "0")
            {
                textBoxQty.Text = "1";
            }
        }

        private void textBoxPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                textBoxPrice.Text = "1";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxComboCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxSizeID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSizeID.Text))
            {
                textBoxItemNo.Text = "";
                textBoxItemNo.ReadOnly = true;
            }
            else
            {
                var objService = new GPMSService.GPMSServiceClient();
                var itemNoRes = objService.GetItemNo(thisCustomerID, thisPODStyleID, thisColorID, Convert.ToInt32(textBoxSizeID.Text));

                if (itemNoRes.DtoStatus == DtoStatus.Success)
                {
                    if (!string.IsNullOrEmpty(itemNoRes.POSizeDBo.ItemNo))
                    {
                        textBoxItemNo.Text = itemNoRes.POSizeDBo.ItemNo;
                        textBoxItemNo.ReadOnly = true;
                    }
                    else
                    {
                        textBoxItemNo.Text = "";
                        textBoxItemNo.ReadOnly = false;
                    }

                }
                else if (itemNoRes.DtoStatus == DtoStatus.NoDataFound)
                {
                    textBoxItemNo.Text = "";
                    textBoxItemNo.ReadOnly = false;
                }
                else if (itemNoRes.DtoStatus == DtoStatus.Error)
                {
                    MessageBox.Show(itemNoRes.DtoStatusNotes.Exception);
                    textBoxItemNo.Text = "";
                    textBoxItemNo.ReadOnly = true;
                }
                else
                {
                    textBoxItemNo.Text = "";
                    textBoxItemNo.ReadOnly = true;
                }
            }
        }
    }
}
