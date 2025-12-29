using APP.GPMS.Reports;
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
    public partial class FormPO4Post : Form
    {
        public FormPO4Post()
        {
            InitializeComponent();
        }

        public FormPO4Post(string pPONo)
        {
            InitializeComponent();
            textBoxPONo.Text = pPONo.ToString();
            buttonPOGo_Click(null, null);
            //buttonPOGo.PerformClick();
        }

        private void textBoxPONo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPOGo.PerformClick();
            }
        }
        void ResetForm()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                pCurrentPOM = null;
                pictureBoxPONoSelect.Image = Properties.Resources.icons8_pending_24;
                textBoxPOMID.Text = "";
                //textBoxPONo.Text = "";
                panelPOPreview.Controls.Clear();


                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }
        private void textBoxPONo_TextChanged(object sender, EventArgs e)
        {
            ResetForm();
            //pictureBoxPONoSelect.Image = Properties.Resources.icons8_pending_24;
        }

        POMBo pCurrentPOM = null;
        private void buttonPOGo_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //pictureBoxPONoSelect.Image = Properties.Resources.icons8_pending_24;
            pCurrentPOM = null;
            try
            {
                ResetForm();
                this.Cursor = Cursors.WaitCursor;
                if (!string.IsNullOrEmpty(textBoxPONo.Text.Trim()))
                {
                    var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                    var resPOM = objService.GetPOByPONo((textBoxPONo.Text));

                    if (resPOM.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                    {
                        pictureBoxPONoSelect.Image = Properties.Resources.icons8_tick_24;
                        pCurrentPOM = resPOM.POMBo;
                        textBoxPOMID.Text = resPOM.POMBo.ID.ToString();


                        var load = new FormReportViewer();
                        load.ReportName = "POOverview";
                        load.FormBorderStyle = FormBorderStyle.None;
                        load.ReportParamertsValues = new ReportParamertsValues();
                        load.ReportParamertsValues.PONo = pCurrentPOM.PONo;
                        //load.ReportParamertsValues.ToDate = dateTimePickerStockTo.Value.ToString("dd-MMM-yyyy");
                        load.TopLevel = false;
                        load.Dock = DockStyle.Fill;
                        panelPOPreview.Controls.Add(load);
                        load.Show();

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
        }


        private void buttonPost_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (PostPO())
                {
                    buttonPOGo.PerformClick();
                }
                else
                {

                }
            }
        }

        private void buttonPostNClose_Click(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (PostPO())
                {
                    if (this.ParentForm != null)
                        this.ParentForm.Close();
                    else
                        this.Close();
                }
                else
                {

                }
            }
        }


        bool isValidate()
        {
            if (string.IsNullOrEmpty(textBoxPOMID.Text))
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a PONo");
                textBoxPONo.Focus();
                return false;
            }
            else if (pCurrentPOM == null)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a PONo");
                textBoxPONo.Focus();
                return false;
            }
            else if (pCurrentPOM.PODCollection == null || pCurrentPOM.PODCollection.Count <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "PO is not complete on step 2, please add one or more style/s");
                textBoxPONo.Focus();
                return false;
            }
            else if (pCurrentPOM.PODCollection.Where(x => x.POSizeDCollection == null || x.POSizeDCollection.Count <= 0).Any())
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "PO is not complete on step 3, please assign color and sizes to all styles");
                textBoxPONo.Focus();
                return false;
            }
            return true;
        }



        bool PostPO()
        {
            try
            {
                if (isValidate())
                {
                    if (string.IsNullOrEmpty(pCurrentPOM.ApprovedStatus) || (!string.IsNullOrEmpty(pCurrentPOM.ApprovedStatus) && pCurrentPOM.ApprovedStatus == POApprovalStatus.Rejected))
                    {
                        DialogResult resultUpdateQ = MessageBox.Show("Are you sure to post po?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (resultUpdateQ == DialogResult.Yes)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            POApprovalStatusBo pOApprovalStatusBo = new POApprovalStatusBo();
                            pOApprovalStatusBo.POMID = pCurrentPOM.ID;
                            pOApprovalStatusBo.Status = POApprovalStatus.Posted;
                            pOApprovalStatusBo.StatusByID = 0;
                            pOApprovalStatusBo.StatusBy = LoginUser._userName;


                            var objService = new GPMSService.GPMSServiceClient();
                            var res = objService.UpdatePOApprovedStatus(pOApprovalStatusBo);
                            if (res.DtoStatus == DtoStatus.Success) //if update response is successfull
                            {
                                // show success message to user
                                this.Cursor = Cursors.Default;

                                //MessageBox.Show("Data is saved successfully!");
                                string strMsg = "PO# : " + pCurrentPOM.PONo + " is posted successfully";
                                new MessagePopup().ShowMessagePopup(this.ParentForm, MessagePopupType.Success, strMsg);

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
                        new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "PO status should be unposted or rejected");
                        textBoxPONo.Focus();
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

    }
}
