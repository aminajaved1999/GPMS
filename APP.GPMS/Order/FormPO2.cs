
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
using static Entities.GPMS.AppKeyProperties;

namespace APP.GPMS
{
    public partial class FormPO2 : Form
    {
        public FormPO2()
        {
            InitializeComponent();
            ((DataGridViewImageColumn)this.dataGridViewPOD.Columns["Remove"]).DefaultCellStyle.NullValue = null;
        }
        //public FormPO2(int pPOMID)
        //{
        //    InitializeComponent();
        //    ((DataGridViewImageColumn)this.dataGridViewPOD.Columns["Remove"]).DefaultCellStyle.NullValue = null;
        //    textBoxPOMID.Text = pPOMID.ToString();
        //}
        public FormPO2(string pPONo)
        {
            InitializeComponent();
            ((DataGridViewImageColumn)this.dataGridViewPOD.Columns["Remove"]).DefaultCellStyle.NullValue = null;
            textBoxPONo.Text = pPONo.ToString();
            buttonPOGo_Click(null, null);
            //buttonPOGo.PerformClick();
        }
        private void FormPO2_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = buttonSaveNNext.Enabled = buttonSaveNPrevious.Enabled = true;
        }
        void ResetClearForm()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                pCurrentPOM = null;

                if (pCurrentPOM != null)
                    buttonPrevious.Enabled = true;
                else
                    buttonPrevious.Enabled = false;

                if (pCurrentPOM != null && pCurrentPOM.PODCollection != null && pCurrentPOM.PODCollection.Count > 0)
                    buttonNext.Enabled = true;
                else
                    buttonNext.Enabled = false;

                pictureBoxPONoSelect.Image = Properties.Resources.icons8_pending_24;
                textBoxPOMID.Text = "";
                //textBoxPONo.Text = "";
                textBoxStyleID.Text = "";
                dataGridViewPOD.Rows.Clear();

                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonAddStyle_Click(object sender, EventArgs e)
        {
            StyleLookup();
        }

        void StyleLookup()
        {
            if (pCurrentPOM != null && pCurrentPOM.ID > 0)
            {
                FormGeneralLookup formStyleListPopSelection = new FormGeneralLookup();
                formStyleListPopSelection.Text = "Style Lookup";
                formStyleListPopSelection.PopupSelectionType = GeneralPopupSelectionType.Style;
                formStyleListPopSelection.pCustomerID = pCurrentPOM.CustomerID;
                formStyleListPopSelection.FormClosing += FormStyleListPopSelection_FormClosing;
                formStyleListPopSelection.ShowDialog();
            }
            else
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "PO is not selected");
            }
        }

        private void FormStyleListPopSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string recID = ((FormGeneralLookup)sender).sentAtrributes.sentID.ToString();

                if (!string.IsNullOrEmpty(recID) && Convert.ToInt32(recID) > 0)
                {
                    textBoxStyleID.Text = recID;
                    textBoxStyleID.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxStyleID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxStyleID.Text) && !string.IsNullOrWhiteSpace(textBoxStyleID.Text))
                {
                    if (!dataGridViewPOD.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToInt32(x.Cells["StyleID"].Value) == Convert.ToInt32(textBoxStyleID.Text)).Any())
                    {
                        var resStyle = new GPMSService.GPMSServiceClient().GetStyleById(Convert.ToInt32(textBoxStyleID.Text.Trim()));

                        if (resStyle.DtoStatus == DtoStatus.Success)
                        {
                            var index = dataGridViewPOD.Rows.Add(
                                            dataGridViewPOD.RowCount + 1
                                            , null
                                            , resStyle.StyleInfoBo.ID
                                            , resStyle.StyleInfoBo.StyleCode
                                            , resStyle.StyleInfoBo.StyleName
                                            , null
                                            , APP.GPMS.Properties.Resources.icons8_delete_64__1_
                                            , false
                                        );

                            dataGridViewPOD.Rows[index].ReadOnly = false;
                            dataGridViewPOD.Rows[index].Cells["Description"].ReadOnly = false;
                            dataGridViewPOD.BeginEdit(true);

                        }
                        else if (resStyle.DtoStatus == DtoStatus.NoDataFound)
                        {
                            MessageBox.Show("Having issue while finding this Style");
                        }
                        else if (resStyle.DtoStatus == DtoStatus.Error)
                        {
                            MessageBox.Show(resStyle.DtoStatusNotes.Exception);
                        }

                    }
                    else
                    {
                        //MessageBox.Show("Style already exist in list");
                        new MessagePopup().ShowMessagePopup(this, MessagePopupType.Info, "Style already exist in list");
                        var row = dataGridViewPOD.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToInt32(x.Cells["StyleID"].Value) == Convert.ToInt32(textBoxStyleID.Text)).FirstOrDefault();
                        if (row != null)
                        {
                            dataGridViewPOD.ClearSelection();
                            row.Selected = true;

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewPOD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dataGridViewPOD.Columns["Remove"].Index)
            {
                if (dataGridViewPOD.CurrentRow.Cells["PODID"].Value == null)
                {
                    //local del
                    dataGridViewPOD.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    //del from db

                    try
                    {
                        var id = Convert.ToInt32(dataGridViewPOD.CurrentRow.Cells["PODID"].Value);
                        var pod = pCurrentPOM.PODCollection.Where(x => x.ID == id).FirstOrDefault();
                        if (pod != null)
                        {
                            if (pod.POSizeDCollection == null || pod.POSizeDCollection.Count <= 0)
                            {
                                DialogResult resultUpdateQ = MessageBox.Show("Are you sure to delete style?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (resultUpdateQ == DialogResult.Yes)
                                {
                                    this.Cursor = Cursors.WaitCursor;
                                    var objService = new GPMSService.GPMSServiceClient();
                                    var res = objService.DeletePOD(id , LoginUser._userID);
                                    if (res.DtoStatus == DtoStatus.Success) //if update response is successfull
                                    {
                                        // show success message to user
                                        this.Cursor = Cursors.Default;
                                        dataGridViewPOD.Rows.RemoveAt(e.RowIndex);
                                        pCurrentPOM.PODCollection.Remove(pod);
                                        //MessageBox.Show("Data is saved successfully!");
                                        string strMsg = "Style is deleted";
                                        new MessagePopup().ShowMessagePopup(this.ParentForm, MessagePopupType.Info, strMsg);
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
                                new MessagePopup().ShowMessagePopup(this.ParentForm, MessagePopupType.Info, "You cannot remove this style now b/c this has color and sizes");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        POMBo pCurrentPOM = null;
        private void buttonPOGo_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //pictureBoxPONoSelect.Image = Properties.Resources.icons8_pending_24;
            pCurrentPOM = null;
            try
            {
                ResetClearForm();
                this.Cursor = Cursors.WaitCursor;
                if (!string.IsNullOrEmpty(textBoxPONo.Text.Trim()))
                {
                    var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                    var resPOM = objService.GetPOByPONo((textBoxPONo.Text));

                    if (resPOM.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                    {
                        if (string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) || resPOM.POMBo.ApprovedStatus == POApprovalStatus.Rejected)
                        {
                            pictureBoxPONoSelect.Image = Properties.Resources.icons8_tick_24;

                            pCurrentPOM = resPOM.POMBo;
                            //textBoxPONo.Text = resPOM.POMBo.PONo;
                            textBoxPOMID.Text = resPOM.POMBo.ID.ToString();
                            if (resPOM.POMBo.PODCollection != null && resPOM.POMBo.PODCollection.Count > 0)
                            {
                                foreach (var PODBo in resPOM.POMBo.PODCollection)
                                {
                                    var index = dataGridViewPOD.Rows.Add(
                                                   dataGridViewPOD.RowCount + 1
                                                   , PODBo.ID
                                                   , PODBo.StyleInfoBo.ID
                                                   , PODBo.StyleInfoBo.StyleCode
                                                   , PODBo.StyleInfoBo.StyleName
                                                   , PODBo.Description
                                                   , APP.GPMS.Properties.Resources.icons8_remove_64__1_
                                                   , false //isEdit
                                               );
                                    dataGridViewPOD.Rows[index].Cells["Description"].ReadOnly = false;

                                }
                            }
                        }
                        else
                        {
                            string poStatus = "";
                            if (!string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) && resPOM.POMBo.ApprovedStatus == POApprovalStatus.Approved)
                                poStatus = "Approved";
                            else if (!string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) && resPOM.POMBo.ApprovedStatus == POApprovalStatus.Posted)
                                poStatus = "Posted";

                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Info, "PO Status is " + poStatus);
                            ResetClearForm();
                        }
                    }
                    else if (resPOM.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                    {
                        this.Cursor = Cursors.Default;
                        new MessagePopup().ShowMessagePopup((this), MessagePopupType.Info, "PO# not found");
                    }
                    else        //Checking all of the things( Client Side) are Okay but response is negative
                    {
                        this.Cursor = Cursors.Default;
                        //Showing Error Message to User
                        string errorRes = resPOM.DtoStatusNotes.Exception;
                        MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please enter PO#");
                    textBoxPONo.Focus();
                    //MessageBox.Show("Error while loading this action");
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;

            if (pCurrentPOM != null)
                buttonPrevious.Enabled = true;
            else
                buttonPrevious.Enabled = false;

            if (pCurrentPOM != null && pCurrentPOM.PODCollection != null && pCurrentPOM.PODCollection.Count > 0)
                buttonNext.Enabled = true;
            else
                buttonNext.Enabled = false;
        }
        private void dataGridViewPOD_Sorted(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPOD.Rows.Count > 0)
                {
                    int count = 1;

                    foreach (DataGridViewRow row in dataGridViewPOD.Rows)
                    {
                        row.Cells["SrNo"].Value = count;
                        count++;
                    }

                    dataGridViewPOD.FirstDisplayedCell.Selected = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            dataGridViewPOD.Rows.Cast<DataGridViewRow>()
                .Where(x => x.Cells["PODID"].Value == null || Convert.ToInt32(x.Cells["PODID"].Value) <= 0)
                .ToList().ForEach(f => dataGridViewPOD.Rows.Remove(f));
        }

        bool SaveStyles()
        {
            try
            {

                if (isValidate())
                {
                    //Create New
                    DialogResult resultAddQ = MessageBox.Show("Are you sure to save data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultAddQ == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        List<PODBo> PODList = new List<PODBo>();
                        foreach (var row in dataGridViewPOD.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["PODID"].Value == null || Convert.ToInt32(x.Cells["PODID"].Value) <= 0).ToList())
                        {
                            PODBo pODBo = new PODBo();
                            pODBo.POMID = pCurrentPOM.ID;
                            pODBo.StyleID = Convert.ToInt32(row.Cells["StyleID"].Value);
                            pODBo.Description = row.Cells["Description"].Value != null ? row.Cells["Description"].Value.ToString() : null;
                            pODBo.CreatedBy = LoginUser._userName;
                            pODBo.CreatedByID = LoginUser._userID;

                            PODList.Add(pODBo);
                        }
                        foreach (var updRow in dataGridViewPOD.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["isEdited"].Value)).ToList())
                        {
                            PODBo pODBo = new PODBo();
                            pODBo.ID = Convert.ToInt32(updRow.Cells["PODID"].Value);
                            pODBo.POMID = pCurrentPOM.ID;
                            pODBo.StyleID = Convert.ToInt32(updRow.Cells["StyleID"].Value);
                            pODBo.Description = updRow.Cells["Description"].Value != null ? updRow.Cells["Description"].Value.ToString() : null;
                            pODBo.UpdatedBy = LoginUser._userName;
                            pODBo.UpdatedByID = LoginUser._userID;

                            PODList.Add(pODBo);
                        }
                        //Adding Catalog's object with properties via service object
                        //Calling Manager's Function to Add new data with Catalog's Object on Web Service Object
                        var objService = new GPMSService.GPMSServiceClient();
                        var res = objService.AddUpdatePOD(PODList.ToArray()); //getting Response from Action
                        if (res.DtoStatus == DtoStatus.Success) // if Add New Data status is successfull then positive actions
                        {
                            this.Cursor = Cursors.Default;
                            //MessageBox.Show("Data is saved successfully!");
                            string strMsg = "Styles are saved successfully";
                            new MessagePopup().ShowMessagePopup(this.ParentForm, MessagePopupType.Success, strMsg);
                            return true;

                        }
                        else if (res.DtoStatus == DtoStatus.RecordNotAdded)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Record is not added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (res.DtoStatus == DtoStatus.RecordNotUpdated)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Record is not updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (res.DtoStatus == DtoStatus.Failed)
                        {
                            this.Cursor = Cursors.Default;
                            MessageBox.Show("Failed to add data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else // if Add New Data status is not successfull then showing exception messages
                        {
                            ////// error/alter message
                            this.Cursor = Cursors.Default;
                            string errorRes = res.DtoStatusNotes.Exception;
                            MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        this.Cursor = Cursors.Default;
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
        bool isValidate()
        {
            if (string.IsNullOrEmpty(textBoxPOMID.Text))
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a PONo");
                textBoxPONo.Focus();
                return false;
            }
            else if (dataGridViewPOD.RowCount <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please add one or more new style/s");
                textBoxPONo.Focus();
                return false;
            }
            else if (dataGridViewPOD.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["PODID"].Value == null || Convert.ToInt32(x.Cells["PODID"].Value) <= 0).Count() <= 0
                    && dataGridViewPOD.Rows.Cast<DataGridViewRow>().Where(x => Convert.ToBoolean(x.Cells["isEdited"].Value)).Count() <= 0
                )
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "No changes found, please add one or more new style/s");
                buttonAddStyle.Focus();
                return false;
            }
            //else if (dataGridViewPOD.Rows.Count <= 0)
            //{
            //    new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please add one or more styles");
            //    buttonAddStyle.Focus();
            //    return false;
            //}

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (SaveStyles())
                {
                    ResetClearForm();
                    buttonPOGo.PerformClick();
                }
                else
                {

                }
            }
        }
        private void buttonSaveNPrevious_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (SaveStyles())
                {

                    var childForm = new FormPO1(pCurrentPOM.ID) { TopLevel = false };
                    childForm.Dock = DockStyle.Fill;
                    (this.ParentForm as FormCustomerPurchaseOrder).panelContainer.Controls.Add(childForm);
                    (this.ParentForm.MdiParent as MainForm).childForm = childForm;
                    childForm.Show();
                    this.Close();
                }
                else
                {

                }
            }

        }

        private void textBoxPONo_TextChanged(object sender, EventArgs e)
        {
            ResetClearForm();
            //pictureBoxPONoSelect.Image = Properties.Resources.icons8_pending_24;
        }

        private void textBoxPONo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPOGo.PerformClick();
            }
        }

        private void buttonSaveNNext_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (SaveStyles())
                {

                    var childForm = new FormPO3(pCurrentPOM.PONo) { TopLevel = false };
                    childForm.Dock = DockStyle.Fill;
                    (this.ParentForm as FormCustomerPurchaseOrder).panelContainer.Controls.Add(childForm);
                    (this.ParentForm.MdiParent as MainForm).childForm = childForm;
                    childForm.Show();
                    this.Close();
                }
                else
                {

                }
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pCurrentPOM != null && pCurrentPOM.PODCollection != null && pCurrentPOM.PODCollection.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                var childForm = new FormPO3(pCurrentPOM.PONo) { TopLevel = false };
                childForm.Dock = DockStyle.Fill;
                (this.ParentForm as FormCustomerPurchaseOrder).panelContainer.Controls.Add(childForm);
                (this.ParentForm.MdiParent as MainForm).childForm = childForm;
                //childForm.textBoxPOMID.Text = currentPOMID.ToString();
                childForm.Show();
                this.Close();
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Invalid Selection");
            }
            this.Cursor = Cursors.Default;

        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (pCurrentPOM != null && pCurrentPOM.ID > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                var childForm = new FormPO1(pCurrentPOM.ID) { TopLevel = false };
                childForm.Dock = DockStyle.Fill;
                (this.ParentForm as FormCustomerPurchaseOrder).panelContainer.Controls.Add(childForm);
                (this.ParentForm.MdiParent as MainForm).childForm = childForm;
                //childForm.textBoxPOMID.Text = currentPOMID.ToString();
                childForm.Show();
                this.Close();
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Invalid Selection");
            }
            this.Cursor = Cursors.Default;
        }


        private void dataGridViewPOD_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridViewPOD_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPOD.CurrentRow.Cells["PODID"].Value != null)
            {
                string desc = dataGridViewPOD.CurrentRow.Cells["Description"].Value == null ? null : dataGridViewPOD.CurrentRow.Cells["Description"].Value.ToString();
                var id = Convert.ToInt32(dataGridViewPOD.CurrentRow.Cells["PODID"].Value);
                var pod = pCurrentPOM.PODCollection.Where(x => x.ID == id).FirstOrDefault();
                if (pod != null)
                {
                    if (pod.Description != desc)
                    {
                        dataGridViewPOD.CurrentRow.Cells["isEdited"].Value = true;
                    }
                    else
                    {
                        dataGridViewPOD.CurrentRow.Cells["isEdited"].Value = false;
                    }
                }
                else
                {
                    MessageBox.Show("Description not saved");
                }
            }

        }
    }
}
