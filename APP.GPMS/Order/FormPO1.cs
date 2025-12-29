
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
    public partial class FormPO1 : Form
    {
        public FormPO1()
        {
            InitializeComponent();
            MyInitillize();
            labelFormMode.Text = "DEFINITION MODE";
            buttonNext.Enabled = false;
            buttonSave.Enabled = buttonSaveNNext.Enabled = true;
        }


        public FormPO1(int pPOMID)
        {
            InitializeComponent();
            MyInitillize();
            textBoxPOMID.Text = pPOMID.ToString();
        }

        string[] EnableCtrlList = new string[]
                    {
                        "dateTimePickerGatePassDate"
                    };

        //List<AppActionSelect> thisAppActiveActions = null;

        bool dateValidation()
        {
            if (dateTimePickerOrderDate.Value >= dateTimePickerStartDate.Value)
            {
                MessageBox.Show("Start date cannot be less or equal to PO Rec. Date");
                dateTimePickerStartDate.Focus();
                return false;
            }
            else if (dateTimePickerOrderDate.Value >= dateTimePickerShipDate.Value)
            {
                MessageBox.Show("Ship date cannot be less or equal to PO Rec. Date");
                dateTimePickerShipDate.Focus();
                return false;
            }
            else if (dateTimePickerOrderDate.Value >= dateTimePickerShipRequestDate.Value)
            {
                MessageBox.Show("Ship Req. Date cannot be less or equal to PO Rec. Date");
                dateTimePickerShipRequestDate.Focus();
                return false;
            }
            else if (dateTimePickerOrderDate.Value >= dateTimePickerRevisionDate.Value)
            {
                MessageBox.Show("Revision date cannot be less or equal to PO Rec. Date");
                dateTimePickerRevisionDate.Focus();
                return false;
            }

            return true;
        }
        void MyInitillize()
        {
            dateTimePickerStartDate.Checked = false;
            dateTimePickerShipDate.Checked = false;
            dateTimePickerShipRequestDate.Checked = false;
            dateTimePickerRevisionDate.Checked = false;


            isShowDateChangeMsg = false;
            dateTimePickerOrderDate.MinDate = DateTime.Now.AddMonths(-6).Date;
            isShowDateChangeMsg = false;
            dateTimePickerOrderDate.MaxDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            dateTimePickerOrderDate.Value = DateTime.Now;
            dateTimePickerStartDate.MinDate = dateTimePickerOrderDate.Value.Date.AddDays(+1);
            dateTimePickerShipDate.MinDate = dateTimePickerOrderDate.Value.Date.AddDays(+1);
            dateTimePickerShipRequestDate.MinDate = dateTimePickerOrderDate.Value.Date.AddDays(+1);
            dateTimePickerRevisionDate.MinDate = dateTimePickerOrderDate.Value.Date.AddDays(+1);

            FillPOTypeComboBox();
            FillPaymentModeComboBox();
            FillTermCodeComboBox();
            FillOrderFromComboBox();
            FillShippingMethodComboBox();
            FillPackingTypeComboBox();
            FillShipmentTermComboBox();
            FillPOLevelComboBox();
        }
        private void FormPO1_Load(object sender, EventArgs e)
        {

            //this.Cursor = Cursors.WaitCursor;

            //var resAction = null;// new GPMSService.GPMSServiceClient().GetUserFormAction(LoginUser.AppActionGroupID, this.Name, null);
            //if (resAction != null && resAction.DtoStatus == DtoStatus.Success)
            //{
            //    thisAppActiveActions = resAction.AppActionSelectCollection.Where(x => x.Status == true).ToList();
            //    var formAcc = thisAppActiveActions.Where(x => x.ParentID == 0).FirstOrDefault();
            //    if (formAcc != null)
            //    {

            //        var enableList = thisAppActiveActions.Where(x => EnableCtrlList.Contains(x.ControlName)).ToList();
            //        if (enableList != null && enableList.Count > 0)
            //        {
            //            foreach (var name in enableList)
            //            {
            //                var c = this.Controls.Find(name.ControlName, true).FirstOrDefault();
            //                if (c != null)
            //                    c.Enabled = true;
            //            }
            //        }
            //        //ready to load


            //    }
            //    else
            //    {
            //        this.Cursor = Cursors.Default;
            //        MessageBox.Show("You don't have access to Purchase Order Information", "Alter Message");
            //        this.BeginInvoke(new MethodInvoker(Close));
            //    }
            //}
            //else if (resAction != null && resAction.DtoStatus == DtoStatus.Error)
            //{
            //    MessageBox.Show("An error occured while getting access of this form, please contact I.T team", "Error Message");
            //    this.BeginInvoke(new MethodInvoker(Close));
            //}
            //else
            //{
            //    this.Cursor = Cursors.Default;
            //    MessageBox.Show("You don't have access to  Purchase Order Information", "Alter Message");
            //    this.BeginInvoke(new MethodInvoker(Close));
            //}
            //this.Cursor = Cursors.Default;

        }

        void ResetSelectionForm()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //currentPOMID = 0;
                //currentPONo = "";

                if (!labelCustomerChangeDesc.Visible)
                {
                    textBoxCustomerID.Text = "";
                    textBoxCustomerName.Text = "";
                    textBoxCustomerCode.Text = "";
                }

                textBoxPONo.Text = "";
                textBoxOriginalPO.Text = "";

                textBoxGarmentDescription.Text = "";
                textBoxRevisionNo.Text = "";
                textBoxPOTypeDays.Text = "";

                isShowDateChangeMsg = false;
                dateTimePickerOrderDate.Value = dateTimePickerOrderDate.MaxDate;
                //dateTimePickerOrderDate.Value = DateTime.Now;
                //dateTimePickerStartDate.Value = DateTime.Now;
                //dateTimePickerStartDate.Checked = false;
                //dateTimePickerShipDate.Value = DateTime.Now;
                //dateTimePickerShipDate.Checked = false;
                //dateTimePickerShipRequestDate.Value = DateTime.Now;
                //dateTimePickerShipRequestDate.Checked = false;
                //dateTimePickerRevisionDate.Value = DateTime.Now;
                //dateTimePickerRevisionDate.Checked = false;


                comboBoxPOType.SelectedIndex = comboBoxPOType.Items.Count > 0 ? 0 : -1;
                comboBoxPaymentMode.SelectedIndex = comboBoxPaymentMode.Items.Count > 0 ? 0 : -1;
                comboBoxTermCode.SelectedIndex = comboBoxTermCode.Items.Count > 0 ? 0 : -1;
                comboBoxShippingMethod.SelectedIndex = comboBoxShippingMethod.Items.Count > 0 ? 0 : -1;
                comboBoxPackingType.SelectedIndex = comboBoxPackingType.Items.Count > 0 ? 0 : -1;
                comboBoxOrderFrom.SelectedIndex = comboBoxOrderFrom.Items.Count > 0 ? 0 : -1;
                comboBoxShipmentTerm.SelectedIndex = comboBoxShipmentTerm.Items.Count > 0 ? 0 : -1;
                comboBoxPOLevel.SelectedIndex = comboBoxPOLevel.Items.Count > 0 ? 0 : -1;
                textBoxApproveStatus.Text = "";

                this.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }


        bool isValidate()
        {

            if (string.IsNullOrEmpty(textBoxCustomerID.Text))
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a customer");
                textBoxCustomerCode.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(textBoxPONo.Text))
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please define a PO#");
                textBoxPONo.Focus();
                return false;
            }
            else if (comboBoxPOType.SelectedItem == null || Convert.ToInt32(comboBoxPOType.SelectedValue) <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a PO type");
                comboBoxPOType.Focus();
                return false;
            }
            else if (comboBoxPaymentMode.SelectedItem == null || Convert.ToInt32(comboBoxPaymentMode.SelectedValue) <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a payment mode");
                comboBoxPaymentMode.Focus();
                return false;
            }
            else if (comboBoxTermCode.SelectedItem == null || Convert.ToInt32(comboBoxTermCode.SelectedValue) <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a term code");
                comboBoxTermCode.Focus();
                return false;
            }
            else if (comboBoxOrderFrom.SelectedItem == null || Convert.ToInt32(comboBoxOrderFrom.SelectedValue) <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select an order levelfrom");
                comboBoxOrderFrom.Focus();
                return false;
            }
            else if (comboBoxShippingMethod.SelectedItem == null || Convert.ToInt32(comboBoxShippingMethod.SelectedValue) <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a shipment method");
                comboBoxShippingMethod.Focus();
                return false;
            }
            else if (comboBoxPackingType.SelectedItem == null || Convert.ToInt32(comboBoxPackingType.SelectedValue) <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a packing type");
                comboBoxPackingType.Focus();
                return false;
            }
            else if ((string.IsNullOrEmpty(textBoxRevisionNo.Text.Trim()) && dateTimePickerRevisionDate.Checked))
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Revision # and revision date are dependant, please type a revision # or unselect a revision date");
                dateTimePickerRevisionDate.Focus();
                return false;
            }
            else if ((!string.IsNullOrEmpty(textBoxRevisionNo.Text.Trim()) && !dateTimePickerRevisionDate.Checked))
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Revision # and revision date are dependant, please select a revision date or set revision # to empty");
                textBoxRevisionNo.Focus();
                return false;
            }
            else if (comboBoxShipmentTerm.SelectedItem == null || Convert.ToInt32(comboBoxShipmentTerm.SelectedValue) <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select an shipment term");
                comboBoxShipmentTerm.Focus();
                return false;
            }
            else if (comboBoxPOLevel.SelectedItem == null || Convert.ToInt32(comboBoxPOLevel.SelectedValue) <= 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select an PO level");
                comboBoxPOLevel.Focus();
                return false;
            }
            else if (!dateValidation())
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Date conflicts, please resolve before saving");
                return false;
            }


            return true;
        }
        int currentPOMID = 0;
        string currentPONo = "";
        bool AddPOM()
        {
            try
            {
                if (isValidate())
                {
                    //Create New
                    DialogResult resultAddQ = MessageBox.Show("Are you sure to add data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultAddQ == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        POMBo pOMBo = new POMBo();

                        pOMBo.CustomerID = Convert.ToInt32(textBoxCustomerID.Text);
                        pOMBo.PONo = textBoxPONo.Text.Trim();
                        pOMBo.OriginalPONo = textBoxOriginalPO.Text.Trim();
                        isShowDateChangeMsg = false;
                        pOMBo.POReceivedDate = dateTimePickerOrderDate.Value.Date;
                        pOMBo.PaymentModeID = Convert.ToInt32(comboBoxPaymentMode.SelectedValue);
                        pOMBo.TermID = Convert.ToInt32(comboBoxTermCode.SelectedValue);
                        pOMBo.ShippingMethodID = Convert.ToInt32(comboBoxShippingMethod.SelectedValue);
                        pOMBo.ShipmentTermID = Convert.ToInt32(comboBoxShipmentTerm.SelectedValue);
                        pOMBo.POFromID = Convert.ToInt32(comboBoxOrderFrom.SelectedValue);
                        pOMBo.POTypeID = Convert.ToInt32(comboBoxPOType.SelectedValue);
                        pOMBo.POLevelID = Convert.ToInt32(comboBoxPOLevel.SelectedValue);
                        pOMBo.PackingTypeID = Convert.ToInt32(comboBoxPackingType.SelectedValue);
                        pOMBo.POStartDate = (dateTimePickerStartDate.Checked ? dateTimePickerStartDate.Value.Date : new Nullable<DateTime>());
                        pOMBo.POStatus = "N"; //hardcode
                        pOMBo.GarmentDescription = string.IsNullOrEmpty(textBoxGarmentDescription.Text) ? null : textBoxGarmentDescription.Text.Trim();
                        // pOMBo.BillTo 
                        //pOMBo.Season
                        pOMBo.RivisionNo = string.IsNullOrEmpty(textBoxRevisionNo.Text) ? new Nullable<int>() : Convert.ToInt32(textBoxRevisionNo.Text.Trim());
                        pOMBo.LastRevisionDate = (dateTimePickerRevisionDate.Checked ? dateTimePickerRevisionDate.Value.Date : new Nullable<DateTime>());
                        //pOMBo.ClosingDate = 
                        //pOMBo.ClosedBy
                        pOMBo.ShipDate = (dateTimePickerShipDate.Checked ? dateTimePickerShipDate.Value.Date : new Nullable<DateTime>());
                        pOMBo.ShipRequestDate = (dateTimePickerShipRequestDate.Checked ? dateTimePickerShipRequestDate.Value.Date : new Nullable<DateTime>());
                        //pOMBo.Description
                        pOMBo.CreatedBy = LoginUser._userName;
                        pOMBo.CreatedByID = LoginUser._userID;

                        //Adding Catalog's object with properties via service object
                        //Calling Manager's Function to Add new data with Catalog's Object on Web Service Object
                        var objService = new GPMSService.GPMSServiceClient();
                        var res = objService.AddPOM(pOMBo); //getting Response from Action
                        if (res.DtoStatus == DtoStatus.Success) // if Add New Data status is successfull then positive actions
                        {
                            this.Cursor = Cursors.Default;
                            //MessageBox.Show("Data is saved successfully!");
                            string strMsg = "PO# :" + pOMBo.PONo + " is added successfully";
                            new MessagePopup().ShowMessagePopup(this.ParentForm, MessagePopupType.Success, strMsg);
                            currentPOMID = res.POMBo.ID;
                            currentPONo = pOMBo.PONo;
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
        bool UpdatePOM()
        {
            try
            {
                if (isValidate())
                {
                    DialogResult resultUpdateQ = MessageBox.Show("Are you sure to update data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultUpdateQ == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        POMBo pOMBo = new POMBo();

                        pOMBo.ID = Convert.ToInt32(textBoxPOMID.Text);
                        pOMBo.CustomerID = Convert.ToInt32(textBoxCustomerID.Text);
                        pOMBo.PONo = textBoxPONo.Text.Trim();
                        pOMBo.OriginalPONo = textBoxOriginalPO.Text.Trim();
                        pOMBo.POReceivedDate = dateTimePickerOrderDate.Value.Date;
                        pOMBo.PaymentModeID = Convert.ToInt32(comboBoxPaymentMode.SelectedValue);
                        pOMBo.TermID = Convert.ToInt32(comboBoxTermCode.SelectedValue);
                        pOMBo.ShippingMethodID = Convert.ToInt32(comboBoxShippingMethod.SelectedValue);
                        pOMBo.ShipmentTermID = Convert.ToInt32(comboBoxShipmentTerm.SelectedValue);
                        pOMBo.POFromID = Convert.ToInt32(comboBoxOrderFrom.SelectedValue);
                        pOMBo.POTypeID = Convert.ToInt32(comboBoxPOType.SelectedValue);
                        pOMBo.POLevelID = Convert.ToInt32(comboBoxPOLevel.SelectedValue);
                        pOMBo.PackingTypeID = Convert.ToInt32(comboBoxPackingType.SelectedValue);
                        pOMBo.POStartDate = (dateTimePickerStartDate.Checked ? dateTimePickerStartDate.Value.Date : new Nullable<DateTime>());
                        pOMBo.POStatus = "N"; //hardcode
                        pOMBo.GarmentDescription = string.IsNullOrEmpty(textBoxGarmentDescription.Text) ? null : textBoxGarmentDescription.Text.Trim();
                        // pOMBo.BillTo 
                        //pOMBo.Season
                        pOMBo.RivisionNo = string.IsNullOrEmpty(textBoxRevisionNo.Text) ? new Nullable<int>() : Convert.ToInt32(textBoxRevisionNo.Text.Trim());
                        pOMBo.LastRevisionDate = (dateTimePickerRevisionDate.Checked ? dateTimePickerRevisionDate.Value.Date : new Nullable<DateTime>());
                        //pOMBo.ClosingDate = 
                        //pOMBo.ClosedBy
                        pOMBo.ShipDate = (dateTimePickerShipDate.Checked ? dateTimePickerShipDate.Value.Date : new Nullable<DateTime>());
                        pOMBo.ShipRequestDate = (dateTimePickerShipRequestDate.Checked ? dateTimePickerShipRequestDate.Value.Date : new Nullable<DateTime>());
                        //pOMBo.Description
                        pOMBo.UpdatedBy = LoginUser._userName;
                        pOMBo.UpdatedByID = LoginUser._userID;

                        var objService = new GPMSService.GPMSServiceClient();
                        var res = objService.UpdatePOM(pOMBo);
                        if (res.DtoStatus == DtoStatus.Success) //if update response is successfull
                        {
                            // show success message to user
                            this.Cursor = Cursors.Default;

                            //MessageBox.Show("Data is saved successfully!");
                            string strMsg = "PO# : " + pOMBo.PONo + " is updated successfully";
                            new MessagePopup().ShowMessagePopup(this.ParentForm, MessagePopupType.Success, strMsg);
                            currentPOMID = pOMBo.ID;
                            currentPONo = pOMBo.PONo;
                            //resCustomers = new GPMSService.GPMSServiceClient().getAllCustomers();// new customer updations load

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
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (AddPOM())
                {
                    //ResetForm();
                    textBoxPOMID.Text = currentPOMID.ToString();
                }
                else
                {

                }
            }
            else
            {
                if (UpdatePOM())
                {
                    int id = currentPOMID;
                    textBoxPOMID.Text = "";
                    textBoxPOMID.Text = currentPOMID.ToString();
                    //ResetSelectionForm();
                }
                else
                {

                }
            }
        }
        private void buttonSaveNNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (AddPOM())
                {
                    this.Cursor = Cursors.WaitCursor;
                    var childForm = new FormPO2(currentPONo) { TopLevel = false };
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
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                if (UpdatePOM())
                {
                    this.Cursor = Cursors.WaitCursor;
                    var childForm = new FormPO2(currentPONo) { TopLevel = false };
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
                }
                this.Cursor = Cursors.Default;
            }
            this.Cursor = Cursors.Default;
        }

        private void textBoxPOMID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
                {
                    labelFormMode.Text = "EDIT MODE";
                    var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                    var resPOM = objService.GetPOMById(Convert.ToInt32(textBoxPOMID.Text));

                    if (resPOM.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                    {
                        if (string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) || resPOM.POMBo.ApprovedStatus == POApprovalStatus.Rejected)
                        {
                            buttonNext.Enabled = true;
                            buttonSave.Enabled = buttonSaveNNext.Enabled = true;

                            if (resPOM.POMBo != null && resPOM.POMBo.PODCollection != null && resPOM.POMBo.PODCollection.Count > 0)
                            {
                                textBoxCustomerCode.Enabled = false;
                                buttonCustomerLookup.Enabled = false;
                                labelCustomerChangeDesc.Visible = true;
                            }
                            else
                            {
                                textBoxCustomerCode.Enabled = true;
                                buttonCustomerLookup.Enabled = true;
                                labelCustomerChangeDesc.Visible = false;
                            }

                            currentPOMID = resPOM.POMBo.ID;
                            currentPONo = resPOM.POMBo.PONo;
                            textBoxCustomerCode.Text = resPOM.POMBo.CustomerInfoBo.CustomerCode;
                            textBoxPONo.Text = resPOM.POMBo.PONo;
                            textBoxOriginalPO.Text = resPOM.POMBo.OriginalPONo;


                            if (resPOM.POMBo.POReceivedDate.Date <= dateTimePickerOrderDate.MinDate)
                            {
                                isShowDateChangeMsg = false;
                                dateTimePickerOrderDate.MinDate = resPOM.POMBo.POReceivedDate.Date;
                                isShowDateChangeMsg = false;
                                dateTimePickerOrderDate.MaxDate = resPOM.POMBo.POReceivedDate.Date.AddDays(+1).AddTicks(-1);
                                isShowDateChangeMsg = false;
                                dateTimePickerOrderDate.Value = resPOM.POMBo.POReceivedDate;

                            }
                            else
                            {
                                isShowDateChangeMsg = false;
                                dateTimePickerOrderDate.MaxDate = resPOM.POMBo.POReceivedDate.Date.AddDays(+1).AddTicks(-1);
                                isShowDateChangeMsg = false;
                                dateTimePickerOrderDate.MinDate = resPOM.POMBo.POReceivedDate.Date;
                                isShowDateChangeMsg = false;
                                dateTimePickerOrderDate.Value = resPOM.POMBo.POReceivedDate;
                            }

                            comboBoxPaymentMode.SelectedValue = resPOM.POMBo.PaymentModeID;
                            comboBoxTermCode.SelectedValue = resPOM.POMBo.TermID;
                            comboBoxShippingMethod.SelectedValue = resPOM.POMBo.ShippingMethodID;
                            comboBoxShipmentTerm.SelectedValue = resPOM.POMBo.ShipmentTermID;
                            comboBoxOrderFrom.SelectedValue = resPOM.POMBo.POFromID;
                            comboBoxPOType.SelectedValue = resPOM.POMBo.POTypeID;
                            comboBoxPOLevel.SelectedValue = resPOM.POMBo.POLevelID;
                            comboBoxPackingType.SelectedValue = resPOM.POMBo.PackingTypeID;

                            if (resPOM.POMBo.POStartDate.HasValue)
                                dateTimePickerStartDate.Value = resPOM.POMBo.POStartDate.Value;
                            dateTimePickerStartDate.Checked = resPOM.POMBo.POStartDate.HasValue ? true : false;

                            textBoxGarmentDescription.Text = resPOM.POMBo.GarmentDescription;
                            textBoxRevisionNo.Text = resPOM.POMBo.RivisionNo.HasValue ? resPOM.POMBo.RivisionNo.ToString() : "";

                            if (resPOM.POMBo.LastRevisionDate.HasValue)
                                dateTimePickerRevisionDate.Value = resPOM.POMBo.LastRevisionDate.Value;
                            dateTimePickerRevisionDate.Checked = resPOM.POMBo.LastRevisionDate.HasValue ? true : false;

                            if (resPOM.POMBo.ShipDate.HasValue)
                                dateTimePickerShipDate.Value = resPOM.POMBo.ShipDate.Value;
                            dateTimePickerShipDate.Checked = resPOM.POMBo.ShipDate.HasValue ? true : false;

                            if (resPOM.POMBo.ShipRequestDate.HasValue)
                                dateTimePickerShipRequestDate.Value = resPOM.POMBo.ShipRequestDate.Value;
                            dateTimePickerShipRequestDate.Checked = resPOM.POMBo.ShipRequestDate.HasValue ? true : false;


                            textBoxApproveStatus.Text = "";
                            if (!string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) && resPOM.POMBo.ApprovedStatus == POApprovalStatus.Rejected)
                                textBoxApproveStatus.Text = "Rejected";

                        }
                        else
                        {
                            string poApproveStatus = "";
                            if (!string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) && resPOM.POMBo.ApprovedStatus == POApprovalStatus.Approved)
                                poApproveStatus = "Approved";
                            else if (!string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) && resPOM.POMBo.ApprovedStatus == POApprovalStatus.Posted)
                                poApproveStatus = "Posted";

                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Info, "PO Status is " + poApproveStatus);
                            textBoxPOMID.Text = "";
                        }
                    }
                    else if (resPOM.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                    {
                        MessageBox.Show("PO not found");
                    }
                    else        //Checking all of the things( Client Side) are Okay but response is negative
                    {
                        //Showing Error Message to User
                        string errorRes = resPOM.DtoStatusNotes.Exception;
                        MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    isShowDateChangeMsg = false;
                    dateTimePickerOrderDate.MaxDate = DateTime.Now.Date.AddDays(1).AddTicks(-1);
                    isShowDateChangeMsg = false;
                    dateTimePickerOrderDate.MinDate = DateTime.Now.AddMonths(-6).Date;

                    ResetSelectionForm();
                    labelFormMode.Text = "DEFINITION MODE";
                    textBoxCustomerCode.Enabled = true;
                    buttonCustomerLookup.Enabled = true;
                    labelCustomerChangeDesc.Visible = false;
                    buttonNext.Enabled = false;
                    buttonSave.Enabled = buttonSaveNNext.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxCustomerCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                var txtBox = sender as TextBox;

                if (txtBox == textBoxCustomerCode)
                    CustomerLookup();
            }
        }
        private void CustomerLookup()
        {
            FormGeneralLookup formCustomerListPopSelection = new FormGeneralLookup();
            formCustomerListPopSelection.Text = "Customer Lookup";
            formCustomerListPopSelection.PopupSelectionType = GeneralPopupSelectionType.Customer;
            formCustomerListPopSelection.FormClosing += FormCustomerListPopSelection_FormClosing;
            formCustomerListPopSelection.ShowDialog();
        }

        private void FormCustomerListPopSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string recCode = ((FormGeneralLookup)sender).sentAtrributes.sentCode;

                if (!string.IsNullOrEmpty(recCode))
                    textBoxCustomerCode.Text = recCode;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxCustomerCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var txtBox = sender as TextBox;

                if (txtBox == textBoxCustomerCode)
                {
                    if (!string.IsNullOrEmpty(textBoxCustomerCode.Text.Trim()))
                    {
                        //if (textBoxCustomerCode.Text.Length == 5)
                        {
                            var objService = new GPMSService.GPMSServiceClient();
                            var custDataResponse = objService.GetCustomerByCode(textBoxCustomerCode.Text.Trim());

                            if (custDataResponse.DtoStatus == DtoStatus.Success) // attention required
                            {
                                if (custDataResponse.CustomerInfoBo.CompanyID == LoginUser.CompanyID)
                                {
                                    textBoxCustomerID.Text = custDataResponse.CustomerInfoBo.ID.ToString();
                                    textBoxCustomerName.Text = custDataResponse.CustomerInfoBo.CustomerName;
                                }
                                else
                                {
                                    textBoxCustomerID.Text = "";
                                    textBoxCustomerName.Text = "";
                                }

                            }
                            else if (custDataResponse.DtoStatus == DtoStatus.Error)
                            {
                                MessageBox.Show(custDataResponse.DtoStatusNotes.Exception);
                                textBoxCustomerID.Text = "";
                                textBoxCustomerName.Text = "";
                            }
                            else
                            {
                                textBoxCustomerID.Text = "";
                                textBoxCustomerName.Text = "";
                            }
                        }
                        //else
                        //{
                        //    textBoxCustomerID.Text = "";
                        //    textBoxCustomerName.Text = "";
                        //}


                    }
                    else
                    {
                        textBoxCustomerID.Text = "";
                        textBoxCustomerName.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCustomerLookup_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button == buttonCustomerLookup)
                CustomerLookup();
        }


        public void FillPOTypeComboBox()
        {
            try
            {
                comboBoxPOType.DataSource = null;
                var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                var resPOType = objService.GetAllPOTypes(true);

                if (resPOType.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                {
                    var POTypeList = resPOType.POTypeCollection;
                    if (POTypeList != null && POTypeList.Count > 0)
                    {
                        POTypeList.Add(new POTypeBo { ID = -1, POTypeName = "------ Select ------" });

                        comboBoxPOType.DataSource = POTypeList.OrderBy(x => x.ID).ToList();
                        comboBoxPOType.DisplayMember = "POTypeName";
                        comboBoxPOType.ValueMember = "ID";
                        //comboBoxPOType.SelectedValue = -1;

                    }
                    else
                    {
                        //toolStripStatusLabelMain.ForeColor = Color.Red;
                        //toolStripStatusLabelMain.Text = "No payment mode found, please add one or more payment mode/s";
                    }
                }
                else if (resPOType.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {
                    //toolStripStatusLabelMain.ForeColor = Color.Red;
                    //toolStripStatusLabelMain.Text = "No data found in payment mode";
                }

                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resPOType.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        public void FillPaymentModeComboBox()
        {
            try
            {
                comboBoxPaymentMode.DataSource = null;
                var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                var resPaymentMode = objService.GetAllPaymentModes(true);

                if (resPaymentMode.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                {
                    var PaymentModeList = resPaymentMode.PaymentModeInfoCollection;
                    if (PaymentModeList != null && PaymentModeList.Count > 0)
                    {
                        PaymentModeList.Add(new PaymentModeInfoBo { ID = -1, PaymentModeName = "------ Select ------" });

                        comboBoxPaymentMode.DataSource = PaymentModeList.OrderBy(x => x.ID).ToList();
                        comboBoxPaymentMode.DisplayMember = "PaymentModeName";
                        comboBoxPaymentMode.ValueMember = "ID";
                        //comboBoxPaymentMode.SelectedValue = -1;

                    }
                    else
                    {
                        //toolStripStatusLabelMain.ForeColor = Color.Red;
                        //toolStripStatusLabelMain.Text = "No payment mode found, please add one or more payment mode/s";
                    }
                }
                else if (resPaymentMode.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {
                    //toolStripStatusLabelMain.ForeColor = Color.Red;
                    //toolStripStatusLabelMain.Text = "No data found in payment mode";
                }

                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resPaymentMode.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }
        public void FillTermCodeComboBox()
        {
            try
            {
                comboBoxTermCode.DataSource = null;
                var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                var resTermCode = objService.GetAllTerms(true);

                if (resTermCode.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                {
                    var TermCodeList = resTermCode.TermInfoCollection;
                    if (TermCodeList != null && TermCodeList.Count > 0)
                    {
                        TermCodeList.Add(new TermInfoBo { ID = -1, TermName = "------ Select ------" });

                        comboBoxTermCode.DataSource = TermCodeList.OrderBy(x => x.ID).ToList();
                        comboBoxTermCode.DisplayMember = "TermName";
                        comboBoxTermCode.ValueMember = "ID";
                        //comboBoxTermCode.SelectedValue = -1;

                    }
                    else
                    {
                        //toolStripStatusLabelMain.ForeColor = Color.Red;
                        //toolStripStatusLabelMain.Text = "No payment mode found, please add one or more payment mode/s";
                    }
                }
                else if (resTermCode.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {
                    //toolStripStatusLabelMain.ForeColor = Color.Red;
                    //toolStripStatusLabelMain.Text = "No data found in payment mode";
                }

                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resTermCode.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }
        public void FillOrderFromComboBox()
        {
            try
            {
                comboBoxOrderFrom.DataSource = null;
                var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                var resOrderFrom = objService.GetAllPOFroms(true);

                if (resOrderFrom.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                {
                    var OrderFromList = resOrderFrom.POFormCollection;
                    if (OrderFromList != null && OrderFromList.Count > 0)
                    {
                        OrderFromList.Add(new POFromBo { ID = -1, POFromName = "------ Select ------" });

                        comboBoxOrderFrom.DataSource = OrderFromList.OrderBy(x => x.ID).ToList();
                        comboBoxOrderFrom.DisplayMember = "POFromName";
                        comboBoxOrderFrom.ValueMember = "ID";
                        //comboBoxOrderFrom.SelectedValue = -1;

                    }
                    else
                    {
                        //toolStripStatusLabelMain.ForeColor = Color.Red;
                        //toolStripStatusLabelMain.Text = "No payment mode found, please add one or more payment mode/s";
                    }
                }
                else if (resOrderFrom.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {
                    //toolStripStatusLabelMain.ForeColor = Color.Red;
                    //toolStripStatusLabelMain.Text = "No data found in payment mode";
                }

                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resOrderFrom.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }
        public void FillShippingMethodComboBox()
        {
            try
            {
                comboBoxShippingMethod.DataSource = null;
                var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                var resShipMethod = objService.GetAllShippingMethods(true);

                if (resShipMethod.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                {
                    var ShipMethodList = resShipMethod.ShippingMethodCollection;
                    if (ShipMethodList != null && ShipMethodList.Count > 0)
                    {
                        ShipMethodList.Add(new ShippingMethodBo { ID = -1, ShippingMethodName = "------ Select ------" });

                        comboBoxShippingMethod.DataSource = ShipMethodList.OrderBy(x => x.ID).ToList();
                        comboBoxShippingMethod.DisplayMember = "ShippingMethodName";
                        comboBoxShippingMethod.ValueMember = "ID";
                        //comboBoxShipMethod.SelectedValue = -1;

                    }
                    else
                    {
                        //toolStripStatusLabelMain.ForeColor = Color.Red;
                        //toolStripStatusLabelMain.Text = "No payment mode found, please add one or more payment mode/s";
                    }
                }
                else if (resShipMethod.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {
                    //toolStripStatusLabelMain.ForeColor = Color.Red;
                    //toolStripStatusLabelMain.Text = "No data found in payment mode";
                }

                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resShipMethod.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }
        public void FillPackingTypeComboBox()
        {
            try
            {
                comboBoxPackingType.DataSource = null;
                var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                var resPackingType = objService.GetAllPackingTypes(true);

                if (resPackingType.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                {
                    var PackingTypeList = resPackingType.PackingTypeCollection;
                    if (PackingTypeList != null && PackingTypeList.Count > 0)
                    {
                        PackingTypeList.Add(new PackingTypeBo { ID = -1, PackingTypeName = "------ Select ------" });

                        comboBoxPackingType.DataSource = PackingTypeList.OrderBy(x => x.ID).ToList();
                        comboBoxPackingType.DisplayMember = "PackingTypeName";
                        comboBoxPackingType.ValueMember = "ID";
                        //comboBoxPackingType.SelectedValue = -1;

                    }
                    else
                    {
                        //toolStripStatusLabelMain.ForeColor = Color.Red;
                        //toolStripStatusLabelMain.Text = "No payment mode found, please add one or more payment mode/s";
                    }
                }
                else if (resPackingType.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {
                    //toolStripStatusLabelMain.ForeColor = Color.Red;
                    //toolStripStatusLabelMain.Text = "No data found in payment mode";
                }

                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resPackingType.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }
        public void FillShipmentTermComboBox()
        {
            try
            {
                comboBoxShipmentTerm.DataSource = null;
                var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                var resShipmentTerm = objService.GetAllShipmentTerms(true);

                if (resShipmentTerm.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                {
                    var ShipmentTermList = resShipmentTerm.ShipmentTermCollection;
                    if (ShipmentTermList != null && ShipmentTermList.Count > 0)
                    {
                        ShipmentTermList.Add(new ShipmentTermBo { ID = -1, ShipmentTermName = "------ Select ------" });

                        comboBoxShipmentTerm.DataSource = ShipmentTermList.OrderBy(x => x.ID).ToList();
                        comboBoxShipmentTerm.DisplayMember = "ShipmentTermName";
                        comboBoxShipmentTerm.ValueMember = "ID";
                        //comboBoxShipmentTerm.SelectedValue = -1;

                    }
                    else
                    {
                        //toolStripStatusLabelMain.ForeColor = Color.Red;
                        //toolStripStatusLabelMain.Text = "No payment mode found, please add one or more payment mode/s";
                    }
                }
                else if (resShipmentTerm.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {
                    //toolStripStatusLabelMain.ForeColor = Color.Red;
                    //toolStripStatusLabelMain.Text = "No data found in payment mode";
                }

                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resShipmentTerm.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }
        public void FillPOLevelComboBox()
        {
            try
            {
                comboBoxPOLevel.DataSource = null;
                var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                var resPOLevel = objService.GetAllPOLevels(true);

                if (resPOLevel.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                {
                    var POLevelList = resPOLevel.POLevelCollection;
                    if (POLevelList != null && POLevelList.Count > 0)
                    {
                        POLevelList.Add(new POLevelBo { ID = -1, POLevelName = "------ Select ------" });

                        comboBoxPOLevel.DataSource = POLevelList.OrderBy(x => x.ID).ToList();
                        comboBoxPOLevel.DisplayMember = "POLevelName";
                        comboBoxPOLevel.ValueMember = "ID";
                        //comboBoxPOLevel.SelectedValue = -1;

                    }
                    else
                    {
                        //toolStripStatusLabelMain.ForeColor = Color.Red;
                        //toolStripStatusLabelMain.Text = "No payment mode found, please add one or more payment mode/s";
                    }
                }
                else if (resPOLevel.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {
                    //toolStripStatusLabelMain.ForeColor = Color.Red;
                    //toolStripStatusLabelMain.Text = "No data found in payment mode";
                }

                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resPOLevel.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DialogResult resultResetQ = MessageBox.Show("Are you sure to reset selection?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultResetQ == DialogResult.Yes)
            {
                ResetSelectionForm();
            }
        }

        private void comboBoxPOType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPOType.SelectedIndex <= 0)
            {
                textBoxPOTypeDays.Text = "";
            }
            else
            {
                var objService = new GPMSService.GPMSServiceClient();
                var poTypeDataResponse = objService.GetPOTypeById(Convert.ToInt32(comboBoxPOType.SelectedValue));
                if (poTypeDataResponse.DtoStatus == DtoStatus.Success) // attention required
                {
                    textBoxPOTypeDays.Text = poTypeDataResponse.POTypeBo.LeadDays.HasValue ? poTypeDataResponse.POTypeBo.LeadDays.ToString() : "";

                }
                else if (poTypeDataResponse.DtoStatus == DtoStatus.Error)
                {
                    textBoxPOTypeDays.Text = "";
                    MessageBox.Show(poTypeDataResponse.DtoStatusNotes.Exception);
                }
                else
                {
                    textBoxPOTypeDays.Text = "";
                }
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (currentPOMID > 0)
            {
                DialogResult resultResetQ = MessageBox.Show("Are you sure to reset this and define new?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultResetQ == DialogResult.Yes)
                {
                    textBoxPOMID.Text = "";
                    ResetSelectionForm();
                }
            }
        }

        private void dateTimePickerStartDate_ValueChanged(object sender, EventArgs e)
        {
            //if (!dateValidation())
            //{

            //}
        }

        bool isShowDateChangeMsg = true;
        private void dateTimePickerOrderDate_ValueChanged(object sender, EventArgs e)
        {

            //bool StartDateChecked = dateTimePickerStartDate.Checked;
            //bool ShipDateChecked = dateTimePickerShipDate.Checked;
            //bool ShipRequestDateChecked = dateTimePickerShipRequestDate.Checked;
            //bool RevisionDateChecked = dateTimePickerRevisionDate.Checked;

            dateTimePickerStartDate.MinDate = dateTimePickerOrderDate.Value.Date.AddDays(+1);
            dateTimePickerShipDate.MinDate = dateTimePickerOrderDate.Value.Date.AddDays(+1);
            dateTimePickerShipRequestDate.MinDate = dateTimePickerOrderDate.Value.Date.AddDays(+1);
            dateTimePickerRevisionDate.MinDate = dateTimePickerOrderDate.Value.Date.AddDays(+1);

            dateTimePickerStartDate.Value = dateTimePickerOrderDate.Value.Date.AddDays(+1);
            dateTimePickerShipDate.Value = dateTimePickerOrderDate.Value.Date.AddDays(+1);
            dateTimePickerShipRequestDate.Value = dateTimePickerOrderDate.Value.Date.AddDays(+1);
            dateTimePickerRevisionDate.Value = dateTimePickerOrderDate.Value.Date.AddDays(+1);

            dateTimePickerStartDate.Checked = false;
            dateTimePickerShipDate.Checked = false;
            dateTimePickerShipRequestDate.Checked = false;
            dateTimePickerRevisionDate.Checked = false;

            //dateTimePickerStartDate.Checked = StartDateChecked;
            //dateTimePickerShipDate.Checked = ShipDateChecked;
            //dateTimePickerShipRequestDate.Checked = ShipRequestDateChecked;
            //dateTimePickerRevisionDate.Checked = RevisionDateChecked;

            if (isShowDateChangeMsg)
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Info, "PO Rec. Date is changed, all other date values are reset and unchecked accordingly");
            else
                isShowDateChangeMsg = true;
        }

        private void textBoxRevisionNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentPOMID > 0 && !string.IsNullOrEmpty(currentPONo))
            {
                this.Cursor = Cursors.WaitCursor;
                var childForm = new FormPO2(currentPONo) { TopLevel = false };
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

        }
    }
}
