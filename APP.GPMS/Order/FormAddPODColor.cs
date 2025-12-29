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
    public partial class FormAddPODColor : Form
    {
        public FormAddPODColor()
        {
            InitializeComponent();
            textBoxColorCode.Focus();
        }

        public int thisPOMID = 0;
        public int thisPODID = 0;
        public int thisPODStyleID = 0;
        public int thisColorID = 0;
        public int thisCustomerID = 0;
        public List<int> thisUsedColors = new List<int>();

        private void textBoxColorCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                var txtBox = sender as TextBox;

                if (txtBox == textBoxColorCode)
                    ColorLookup();
            }
        }
        private void ColorLookup()
        {
            FormGeneralLookup formColorListPopSelection = new FormGeneralLookup();
            formColorListPopSelection.Text = "Color Lookup";
            formColorListPopSelection.PopupSelectionType = GeneralPopupSelectionType.Color;
            formColorListPopSelection.pCustomerID = thisCustomerID;
            formColorListPopSelection.FormClosing += FormColorListPopSelection_FormClosing;
            formColorListPopSelection.ShowDialog();
        }

        private void FormColorListPopSelection_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string recCode = ((FormGeneralLookup)sender).sentAtrributes.sentCode;

                if (!string.IsNullOrEmpty(recCode))
                    textBoxColorCode.Text = recCode;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxColorCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var txtBox = sender as TextBox;

                if (txtBox == textBoxColorCode)
                {
                    if (!string.IsNullOrEmpty(textBoxColorCode.Text.Trim()))
                    {
                        //if (textBoxColorCode.Text.Length == 5)
                        {
                            var objService = new GPMSService.GPMSServiceClient();
                            var colorDataResponse = objService.GetColorByCode(textBoxColorCode.Text.Trim());

                            if (colorDataResponse.DtoStatus == DtoStatus.Success) // attention required
                            {
                                if (colorDataResponse.ColorInfoBo.CustomerID == thisCustomerID)
                                {
                                    textBoxColorID.Text = colorDataResponse.ColorInfoBo.ID.ToString();
                                    textBoxColorName.Text = colorDataResponse.ColorInfoBo.ColorName;
                                }
                                else
                                {
                                    textBoxColorID.Text = "";
                                    textBoxColorName.Text = "";
                                }

                            }
                            else if (colorDataResponse.DtoStatus == DtoStatus.Error)
                            {
                                MessageBox.Show(colorDataResponse.DtoStatusNotes.Exception);
                                textBoxColorID.Text = "";
                                textBoxColorName.Text = "";
                            }
                            else
                            {
                                textBoxColorID.Text = "";
                                textBoxColorName.Text = "";
                            }
                        }
                        //else
                        //{
                        //    textBoxColorID.Text = "";
                        //    textBoxColorName.Text = "";
                        //}


                    }
                    else
                    {
                        textBoxColorID.Text = "";
                        textBoxColorName.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        private void buttonColorLookup_Click(object sender, EventArgs e)
        {
            ColorLookup();
        }

        public thisPOSizeDBO thisPOSizeDBo = null;

        bool isUsed(int colorID)
        {
            if (thisUsedColors.Contains(colorID))
                return true;
            return false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxColorID.Text))
            {
                if (this.ParentForm != null)
                    new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Please select a color");
                else
                    new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a color");

                textBoxColorCode.Focus();
                return;
            }
            else
            {
                if (!string.IsNullOrEmpty(textBoxPODSizeID.Text.Trim()))
                {
                    if (Convert.ToInt32(textBoxColorID.Text) == thisColorID)
                    {
                        if (this.ParentForm != null)
                            new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Please select a new color");
                        else
                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a new color");

                        return;
                    }
                    else if (isUsed(Convert.ToInt32(textBoxColorID.Text)))
                    {
                        if (this.ParentForm != null)
                            new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Color already used, please select a different color");
                        else
                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Color already used, please select a different color");

                        return;
                    }
                    else
                    {
                        //update
                        POSizeDBo pOSizeDBo = new POSizeDBo();
                        pOSizeDBo.ID = Convert.ToInt32(textBoxPODSizeID.Text);
                        pOSizeDBo.PODID = thisPODID;
                        pOSizeDBo.ColorID = Convert.ToInt32(textBoxColorID.Text);
                        pOSizeDBo.ColorInfoBo = new ColorInfoBo();
                        pOSizeDBo.ColorInfoBo.ID = Convert.ToInt32(textBoxColorID.Text);
                        pOSizeDBo.ColorInfoBo.ColorName = textBoxColorName.Text;
                        pOSizeDBo.ColorInfoBo.ColorCode = textBoxColorCode.Text;
                        pOSizeDBo.UpdatedBy = LoginUser._userName;
                        pOSizeDBo.UpdatedByID = LoginUser._userID;

                        thisPOSizeDBo = new thisPOSizeDBO(pOSizeDBo);
                        thisPOSizeDBo.IsUpdated = true;
                        //this.Hide();
                        this.Close();
                    }
                }
                else
                {
                    //add
                    if (isUsed(Convert.ToInt32(textBoxColorID.Text)))
                    {
                        if (this.ParentForm != null)
                            new MessagePopup().ShowMessagePopup((this.ParentForm), MessagePopupType.Warning, "Color already used, please select a different color");
                        else
                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Color already used, please select a different color");

                        return;
                    }
                    else
                    {
                        POSizeDBo pOSizeDBo = new POSizeDBo();
                        pOSizeDBo.ID = 0;
                        pOSizeDBo.PODID = thisPODID;
                        pOSizeDBo.ColorID = Convert.ToInt32(textBoxColorID.Text);
                        pOSizeDBo.ColorInfoBo = new ColorInfoBo();
                        pOSizeDBo.ColorInfoBo.ID = Convert.ToInt32(textBoxColorID.Text);
                        pOSizeDBo.ColorInfoBo.ColorName = textBoxColorName.Text;
                        pOSizeDBo.ColorInfoBo.ColorCode = textBoxColorCode.Text;
                        pOSizeDBo.CreatedBy = LoginUser._userName;
                        pOSizeDBo.CreatedByID = LoginUser._userID;

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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
