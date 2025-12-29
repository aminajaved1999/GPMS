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
    public partial class FormPO3 : Form
    {
        public FormPO3()
        {
            InitializeComponent();
        }
        public FormPO3(string pPONo)
        {
            InitializeComponent();
            textBoxPONo.Text = pPONo.ToString();
            buttonPOGo_Click(null, null);
            //buttonPOGo.PerformClick();
        }
        private void FormPO3_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = buttonSaveNNext.Enabled = buttonSaveNPrevious.Enabled = true;
        }


        public class thisPODBO
        {
            public PODBo PODBo { get; set; }
            public bool IsNew { get; set; } = false;
            public bool IsUpdated { get; set; } = false;

            public thisPODBO(PODBo pPODBO)
            {
                PODBo = pPODBO;
                IsNew = false;
                IsUpdated = false;
            }
        }

        public class thisPOSizeDBO
        {
            public POSizeDBo POSizeDBo { get; set; }
            public bool IsNew { get; set; } = false;
            public bool IsUpdated { get; set; } = false;

            public thisPOSizeDBO(POSizeDBo pPOSizeDBo)
            {
                POSizeDBo = pPOSizeDBo;
                IsNew = false;
                IsUpdated = false;
            }
        }

        POMBo pCurrentPOM = null;

        Font fontOfStyle = new Font("Century Gothic", 16F, FontStyle.Bold);
        Font fontOfColor = new Font("Century Gothic", 16F, FontStyle.Regular);
        Font fontOfSize = new Font("Century Gothic", 13F, FontStyle.Regular);


        private void buttonPOGo_Click(object sender, EventArgs e)
        {
            //pictureBoxPONoSelect.Image = Properties.Resources.icons8_pending_24;
            pCurrentPOM = null;
            treeViewColorSize.Nodes.Clear();
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
                        if (string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) || resPOM.POMBo.ApprovedStatus == POApprovalStatus.Rejected)
                        {
                            pictureBoxPONoSelect.Image = Properties.Resources.icons8_tick_24;

                            pCurrentPOM = resPOM.POMBo;
                            //textBoxPONo.Text = resPOM.POMBo.PONo;
                            textBoxPOMID.Text = resPOM.POMBo.ID.ToString();
                            //if (resPOM.POMBo.PODCollection != null && resPOM.POMBo.PODCollection.Count > 0)
                            //{

                            //}
                            buildTreeview();
                        }
                        else
                        {
                            string poStatus = "";
                            if (!string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) && resPOM.POMBo.ApprovedStatus == POApprovalStatus.Approved)
                                poStatus = "Approved";
                            else if (!string.IsNullOrEmpty(resPOM.POMBo.ApprovedStatus) && resPOM.POMBo.ApprovedStatus == POApprovalStatus.Posted)
                                poStatus = "Posted";

                            new MessagePopup().ShowMessagePopup((this), MessagePopupType.Info, "PO Status is " + poStatus);
                            ResetForm();
                        }
                    }
                    else if (resPOM.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                    {
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


            if (pCurrentPOM != null && pCurrentPOM.PODCollection != null && pCurrentPOM.PODCollection.Count > 0 && pCurrentPOM.PODCollection.Where(x => x.POSizeDCollection != null && x.POSizeDCollection.Count > 0).Any())
                buttonNext.Enabled = true;
            else
                buttonNext.Enabled = false;

            if (pCurrentPOM != null && pCurrentPOM.ID > 0)
                buttonPrevious.Enabled = true;
            else
                buttonPrevious.Enabled = false;
        }
        void ResetForm()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                panelColorSizeContainer.Controls.OfType<Form>().ToList().ForEach(f => f.Dispose());
                pCurrentPOM = null;
                if (pCurrentPOM != null && pCurrentPOM.PODCollection != null && pCurrentPOM.PODCollection.Count > 0 && pCurrentPOM.PODCollection.Where(x => x.POSizeDCollection != null && x.POSizeDCollection.Count > 0).Any())
                    buttonNext.Enabled = true;
                else
                    buttonNext.Enabled = false;

                if (pCurrentPOM != null && pCurrentPOM.ID > 0)
                    buttonPrevious.Enabled = true;
                else
                    buttonPrevious.Enabled = false;
                pictureBoxPONoSelect.Image = Properties.Resources.icons8_pending_24;
                textBoxPOMID.Text = "";
                treeViewColorSize.Nodes.Clear();
                treeViewColorSize.SelectedNode = null;
                buttonUpdateColor.Enabled = buttonAddSize.Enabled = buttonUpdateSize.Enabled = buttonDelete.Enabled = buttonAddColor.Enabled = false;
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
        }

        void buildTreeview()
        {
            this.Cursor = Cursors.WaitCursor;
            panelColorSizeContainer.Controls.OfType<Form>().ToList().ForEach(f => f.Dispose());
            try
            {
                buttonUpdateColor.Enabled = buttonAddSize.Enabled = buttonUpdateSize.Enabled = buttonDelete.Enabled = buttonAddColor.Enabled = false;
                treeViewColorSize.Nodes.Clear();
                if (pCurrentPOM != null)
                {

                    foreach (var pod in pCurrentPOM.PODCollection)
                    {
                        TreeNode tn = treeViewColorSize.Nodes.Add(pod.StyleInfoBo.StyleName);
                        tn.NodeFont = fontOfStyle;
                        tn.Tag = new thisPODBO(pod);


                        var distinctColors = pod.POSizeDCollection.Where(x => x.PODID == pod.ID).GroupBy(x =>
                                                                             new
                                                                             {
                                                                                 PODID = x.PODID
                                                                                 ,
                                                                                 ColorID = x.ColorID
                                                                                 ,
                                                                                 ColorName = x.ColorInfoBo.ColorName
                                                                             }
                                                                         ).Select(s => s.Key).ToList();
                        foreach (var color in distinctColors)
                        {

                            TreeNode tn2 = getTreeNodes(0).Where(x => (x.Tag.GetType()) == typeof(thisPODBO) && (x.Tag as thisPODBO).PODBo.ID == color.PODID).First()
                                .Nodes
                                .Add(color.ColorName);
                            tn2.NodeFont = fontOfColor;
                            //if (!colorSize.Status)
                            //    tn.ForeColor = Color.Gray;

                            //tn2.Tag = new thisPOSizeDBO(color);
                            var colorPOSizeDBO = pCurrentPOM.PODCollection.Where(x => x.ID == pod.ID).First().POSizeDCollection.Where(x => x.ColorID == color.ColorID).First();
                            tn2.Tag = new thisPOSizeDBO(colorPOSizeDBO);
                        }

                        var sizelist = pod.POSizeDCollection.Where(x => x.PODID == pod.ID).ToList();
                        foreach (var size in sizelist)
                        {
                            //var list = getTreeNodes(1);
                            TreeNode tn3 = getTreeNodes(1).Where(x => (x.Tag.GetType()) == typeof(thisPOSizeDBO) && (x.Tag as thisPOSizeDBO).POSizeDBo.PODID == size.PODID && (x.Tag as thisPOSizeDBO).POSizeDBo.ColorID == size.ColorID).First()
                                .Nodes
                                .Add(size.SizeInfoBo.SizeName);
                            tn3.NodeFont = fontOfSize;

                            //if (!colorSize.Status)
                            //    tn.ForeColor = Color.Gray;

                            tn3.Tag = new thisPOSizeDBO(size);
                        }
                    }
                    //var i = treeViewColorSize.Nodes.Cast<TreeNode>().First().Tag.GetType();
                    treeViewColorSize.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void textBoxPONo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonPOGo.PerformClick();
            }
        }

        TreeNode getRootNode(TreeNode node)
        {
            TreeNode pParent = node;
            while (node.Parent != null)
            {
                pParent = node.Parent;
            }
            return pParent;
        }
        private void treeViewColorSize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewColorSize.SelectedNode != null)
            {
                if (treeViewColorSize.SelectedNode.Level == 0) //style
                {
                    buttonUpdateColor.Enabled = buttonAddSize.Enabled = buttonUpdateSize.Enabled = buttonDelete.Enabled = false;
                    buttonAddColor.Enabled = true;
                    panelColorSizeContainer.Controls.OfType<Form>().ToList().ForEach(f => f.Dispose());
                }
                else if (treeViewColorSize.SelectedNode.Level == 1) // color
                {
                    buttonAddColor.Enabled = buttonUpdateSize.Enabled = false;
                    buttonUpdateColor.Enabled = buttonAddSize.Enabled = true;
                    buttonDelete.Enabled = true;
                    //if ((treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO).POSizeDBo.ID <= 0)
                    //    buttonDelete.Enabled = true;
                    //else
                    //    buttonDelete.Enabled = false;

                    buttonUpdateColor.PerformClick();
                }
                else if (treeViewColorSize.SelectedNode.Level == 2) // size
                {
                    buttonAddColor.Enabled = buttonUpdateColor.Enabled = buttonAddSize.Enabled = false;
                    buttonUpdateSize.Enabled = true;
                    buttonDelete.Enabled = true;
                    //if ((treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO).POSizeDBo.ID <= 0)
                    //    buttonDelete.Enabled = true;
                    //else
                    //    buttonDelete.Enabled = false;

                    buttonUpdateSize.PerformClick();

                }
            }
            else
            {
                buttonUpdateColor.Enabled = buttonAddSize.Enabled = buttonUpdateSize.Enabled = buttonAddColor.Enabled = false;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (pCurrentPOM != null)
            {
                DialogResult resultResetQ = MessageBox.Show("Are you sure to reset?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultResetQ == DialogResult.Yes)
                {
                    ResetForm();
                }
            }
        }

        private void buttonExpandAll_Click(object sender, EventArgs e)
        {
            treeViewColorSize.Focus();

            treeViewColorSize.ExpandAll();
        }

        private void buttonCollapseAll_Click(object sender, EventArgs e)
        {

            treeViewColorSize.CollapseAll();
            treeViewColorSize.Focus();
            //treeViewColorSize.SelectedNode = getRootNode(treeViewColorSize.SelectedNode);
            treeViewColorSize_AfterSelect(treeViewColorSize, null);
        }

        void addFormTopanelContainer(Form pForm)
        {
            panelColorSizeContainer.Controls.OfType<Form>().ToList().ForEach(f => f.Dispose());
            pForm.TopLevel = false;
            pForm.FormBorderStyle = FormBorderStyle.None;
            pForm.Dock = DockStyle.Fill;
            panelColorSizeContainer.Controls.Add(pForm);
            pForm.Show();
            //var t = this.ActiveControl;
            //var t2 = pForm.ActiveControl;
            pForm.Focus();
            var ctrl = pForm.Controls.OfType<TextBox>().Where(x => x.TabIndex == 0).FirstOrDefault();
            if (ctrl != null)
                ctrl.Select();
        }

        private void buttonAddColor_Click(object sender, EventArgs e)
        {
            if (treeViewColorSize.SelectedNode != null)
            {
                treeViewColorSize.Focus();
                if (treeViewColorSize.SelectedNode.Level == 0) //style
                {
                    var podBO = (treeViewColorSize.SelectedNode.Tag as thisPODBO);
                    FormAddPODColor formAddPODColor = new FormAddPODColor();

                    formAddPODColor.thisColorID = 0;
                    formAddPODColor.thisPODID = podBO.PODBo.ID;
                    formAddPODColor.thisPODStyleID = podBO.PODBo.StyleID;
                    formAddPODColor.thisPOMID = podBO.PODBo.POMID;
                    formAddPODColor.thisCustomerID = pCurrentPOM.CustomerID;

                    var colorIDs = getTreeNodes(1).Where(tn => tn.Level == 1
                                                      && ((tn.Parent.Tag.GetType()) == typeof(thisPODBO)
                                                            && (tn.Parent.Tag as thisPODBO).PODBo.StyleID == podBO.PODBo.StyleID)
                                                      )
                                                        .Select(s => (s.Tag as thisPOSizeDBO).POSizeDBo.ColorID).ToList();
                    if (colorIDs != null && colorIDs.Count > 0)
                        formAddPODColor.thisUsedColors.AddRange(colorIDs);

                    formAddPODColor.textBoxPODSizeID.Text = "";
                    formAddPODColor.textBoxPONo.Text = textBoxPONo.Text;
                    formAddPODColor.textBoxStyle.Text = podBO.PODBo.StyleInfoBo.StyleName;
                    formAddPODColor.textBoxColorCode.Text = "";

                    formAddPODColor.FormClosing += FormAddPODColor_FormClosing;

                    addFormTopanelContainer(formAddPODColor);
                    //formAddPODColor.ShowDialog();
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Cannot add color in this node");
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void buttonUpdateColor_Click(object sender, EventArgs e)
        {
            if (treeViewColorSize.SelectedNode != null)
            {
                treeViewColorSize.Focus();

                if (treeViewColorSize.SelectedNode.Level == 1) //color
                {
                    var podBO = (treeViewColorSize.SelectedNode.Parent.Tag as thisPODBO);
                    var posizedBO = (treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO);
                    FormAddPODColor formAddPODColor = new FormAddPODColor();

                    formAddPODColor.thisColorID = posizedBO.POSizeDBo.ColorID;
                    formAddPODColor.thisPODID = posizedBO.POSizeDBo.PODID;
                    formAddPODColor.thisPODStyleID = podBO.PODBo.StyleID;
                    formAddPODColor.thisPOMID = podBO.PODBo.POMID;
                    formAddPODColor.thisCustomerID = pCurrentPOM.CustomerID;

                    var colorIDs = getTreeNodes(1).Where(tn => tn.Level == 1
                                                      && ((tn.Parent.Tag.GetType()) == typeof(thisPODBO)
                                                            && (tn.Parent.Tag as thisPODBO).PODBo.StyleID == podBO.PODBo.StyleID))
                                                        .Select(s => (s.Tag as thisPOSizeDBO).POSizeDBo.ColorID).ToList();
                    if (colorIDs != null && colorIDs.Count > 0)
                        formAddPODColor.thisUsedColors.AddRange(colorIDs);

                    formAddPODColor.textBoxPODSizeID.Text = posizedBO.POSizeDBo.ID.ToString();
                    formAddPODColor.textBoxPONo.Text = textBoxPONo.Text;
                    formAddPODColor.textBoxStyle.Text = podBO.PODBo.StyleInfoBo.StyleName;
                    formAddPODColor.textBoxColorCode.Text = posizedBO.POSizeDBo.ColorInfoBo.ColorCode;

                    formAddPODColor.FormClosing += FormAddPODColor_FormClosing;
                    addFormTopanelContainer(formAddPODColor);
                    //formAddPODColor.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Cannot update color of this node");
                }
            }
        }
        private void FormAddPODColor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var refForm = (sender as FormAddPODColor);
                if (refForm != null)
                {
                    if (refForm.thisPOSizeDBo != null && refForm.thisPOSizeDBo.POSizeDBo != null)
                    {
                        if (refForm.thisPOSizeDBo.POSizeDBo.ID > 0
                               || (refForm.thisPOSizeDBo.POSizeDBo.ID <= 0 && refForm.thisPOSizeDBo.IsUpdated))
                        {
                            // updated
                            treeViewColorSize.SelectedNode.Text = refForm.thisPOSizeDBo.POSizeDBo.ColorInfoBo.ColorName;
                            treeViewColorSize.SelectedNode.Tag = refForm.thisPOSizeDBo;
                            treeViewColorSize.SelectedNode.ImageIndex = 1;
                            treeViewColorSize.SelectedNode.SelectedImageIndex = 1;

                            foreach (TreeNode tn in treeViewColorSize.SelectedNode.Nodes)
                            {
                                if ((tn.Tag.GetType()) == typeof(thisPOSizeDBO))
                                {
                                    (tn.Tag as thisPOSizeDBO).POSizeDBo.ColorID = refForm.thisPOSizeDBo.POSizeDBo.ColorInfoBo.ID;
                                    (tn.Tag as thisPOSizeDBO).POSizeDBo.ColorInfoBo = refForm.thisPOSizeDBo.POSizeDBo.ColorInfoBo;

                                    if (refForm.thisPOSizeDBo.POSizeDBo.ID > 0)
                                    {
                                        (tn.Tag as thisPOSizeDBO).POSizeDBo.UpdatedBy = refForm.thisPOSizeDBo.POSizeDBo.UpdatedBy;
                                        (tn.Tag as thisPOSizeDBO).POSizeDBo.UpdatedByID = refForm.thisPOSizeDBo.POSizeDBo.UpdatedByID;
                                    }
                                    else
                                    {
                                        (tn.Tag as thisPOSizeDBO).POSizeDBo.CreatedBy = refForm.thisPOSizeDBo.POSizeDBo.UpdatedBy;
                                        (tn.Tag as thisPOSizeDBO).POSizeDBo.CreatedByID = refForm.thisPOSizeDBo.POSizeDBo.UpdatedByID;
                                        (tn.Tag as thisPOSizeDBO).POSizeDBo.UpdatedBy = refForm.thisPOSizeDBo.POSizeDBo.UpdatedBy;
                                        (tn.Tag as thisPOSizeDBO).POSizeDBo.UpdatedByID = refForm.thisPOSizeDBo.POSizeDBo.UpdatedByID;
                                    }
                                    (tn.Tag as thisPOSizeDBO).IsUpdated = true;

                                    tn.ImageIndex = 1;
                                    tn.SelectedImageIndex = 1;

                                }
                            }

                            treeViewColorSize.SelectedNode = treeViewColorSize.SelectedNode.Parent;


                        }
                        else if (refForm.thisPOSizeDBo.POSizeDBo.ID <= 0 && refForm.thisPOSizeDBo.IsNew)
                        {
                            //local added
                            var tn = treeViewColorSize.SelectedNode.Nodes.Add(refForm.thisPOSizeDBo.POSizeDBo.ColorInfoBo.ColorName);
                            tn.Tag = refForm.thisPOSizeDBo;
                            tn.ImageIndex = 0;
                            tn.SelectedImageIndex = 0;
                            tn.NodeFont = fontOfColor;

                            treeViewColorSize.SelectedNode = tn.Parent;
                        }
                        else
                        {
                            MessageBox.Show("invalid condition");
                        }
                        treeViewColorSize.ExpandAll();
                        treeViewColorSize.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }



        private void buttonAddSize_Click(object sender, EventArgs e)
        {
            if (treeViewColorSize.SelectedNode != null)
            {
                treeViewColorSize.Focus();

                if (treeViewColorSize.SelectedNode.Level == 1) //color
                {
                    var podBO = (treeViewColorSize.SelectedNode.Parent.Tag as thisPODBO);
                    var posizedBO = (treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO);
                    FormAddPODSize formAddPODSize = new FormAddPODSize();

                    formAddPODSize.thisColorID = posizedBO.POSizeDBo.ColorID;
                    formAddPODSize.thisPODID = posizedBO.POSizeDBo.PODID;
                    formAddPODSize.thisPODStyleID = podBO.PODBo.StyleID;
                    formAddPODSize.thisPOMID = podBO.PODBo.POMID;
                    formAddPODSize.thisSizeID = 0;
                    formAddPODSize.thisCustomerID = pCurrentPOM.CustomerID;

                    var sizeIDs = getTreeNodes(2).Where(tn => tn.Level == 2
                                                     && ((tn.Parent.Parent.Tag.GetType()) == typeof(thisPODBO)
                                                            && (tn.Parent.Parent.Tag as thisPODBO).PODBo.StyleID == podBO.PODBo.StyleID)
                                                     && ((tn.Tag.GetType()) == typeof(thisPOSizeDBO)
                                                            && (tn.Tag as thisPOSizeDBO).POSizeDBo.ColorID == posizedBO.POSizeDBo.ColorID
                                                        )
                                                            ).Select(s => (s.Tag as thisPOSizeDBO).POSizeDBo.SizeID).ToList();
                    if (sizeIDs != null && sizeIDs.Count > 0)
                    {
                        formAddPODSize.thisUsedSizes.AddRange(sizeIDs);
                        formAddPODSize.thisUsedSizes.Remove(formAddPODSize.thisSizeID);
                    }
                    formAddPODSize.textBoxPODSizeID.Text = "";
                    //formAddPODSize.textBoxPONo.Text = textBoxPONo.Text;
                    formAddPODSize.textBoxStyle.Text = podBO.PODBo.StyleInfoBo.StyleName;
                    formAddPODSize.textBoxColor.Text = posizedBO.POSizeDBo.ColorInfoBo.ColorName;
                    formAddPODSize.textBoxSizeCode.Text = "";

                    formAddPODSize.FormClosing += FormAddPODSize_FormClosing;
                    addFormTopanelContainer(formAddPODSize);
                    //formAddPODSize.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Cannot add size in this node");
                }
            }
        }

        private void buttonUpdateSize_Click(object sender, EventArgs e)
        {
            if (treeViewColorSize.SelectedNode != null)
            {
                treeViewColorSize.Focus();

                if (treeViewColorSize.SelectedNode.Level == 2) //size
                {
                    var podBO = (treeViewColorSize.SelectedNode.Parent.Parent.Tag as thisPODBO);
                    var posizedBO = (treeViewColorSize.SelectedNode.Parent.Tag as thisPOSizeDBO);
                    var _posizedBO = (treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO);
                    FormAddPODSize formAddPODSize = new FormAddPODSize();

                    formAddPODSize.thisColorID = posizedBO.POSizeDBo.ColorID;
                    formAddPODSize.thisPODID = posizedBO.POSizeDBo.PODID;
                    formAddPODSize.thisPODStyleID = podBO.PODBo.StyleID;
                    formAddPODSize.thisPOMID = podBO.PODBo.POMID;
                    formAddPODSize.thisSizeID = _posizedBO.POSizeDBo.SizeID;
                    formAddPODSize.thisCustomerID = pCurrentPOM.CustomerID;

                    var sizeIDs = getTreeNodes(2).Where(tn => tn.Level == 2
                                                      && ((tn.Parent.Parent.Tag.GetType()) == typeof(thisPODBO)
                                                             && (tn.Parent.Parent.Tag as thisPODBO).PODBo.StyleID == podBO.PODBo.StyleID)
                                                      && ((tn.Tag.GetType()) == typeof(thisPOSizeDBO)
                                                             && (tn.Tag as thisPOSizeDBO).POSizeDBo.ColorID == posizedBO.POSizeDBo.ColorID
                                                         )
                                                            ).Select(s => (s.Tag as thisPOSizeDBO).POSizeDBo.SizeID).ToList();
                    if (sizeIDs != null && sizeIDs.Count > 0)
                    {
                        formAddPODSize.thisUsedSizes.AddRange(sizeIDs);
                        formAddPODSize.thisUsedSizes.Remove(formAddPODSize.thisSizeID);
                    }
                    formAddPODSize.textBoxPODSizeID.Text = _posizedBO.POSizeDBo.ID.ToString();
                    //formAddPODSize.textBoxPONo.Text = textBoxPONo.Text;
                    formAddPODSize.textBoxStyle.Text = podBO.PODBo.StyleInfoBo.StyleName;
                    formAddPODSize.textBoxColor.Text = posizedBO.POSizeDBo.ColorInfoBo.ColorName;
                    formAddPODSize.textBoxQty.Text = _posizedBO.POSizeDBo.Qty.ToString();
                    formAddPODSize.textBoxPrice.Text = _posizedBO.POSizeDBo.Price.ToString();
                    formAddPODSize.checkBoxIsPilotRun.Checked = _posizedBO.POSizeDBo.IsPilotRun.HasValue ? _posizedBO.POSizeDBo.IsPilotRun.Value : false;
                    formAddPODSize.textBoxComboCode.Text = _posizedBO.POSizeDBo.ComboCode.HasValue ? _posizedBO.POSizeDBo.ComboCode.Value.ToString() : "";
                    formAddPODSize.textBoxSizeCode.Text = _posizedBO.POSizeDBo.SizeInfoBo.SizeCode;
                    formAddPODSize.textBoxItemNo.Text = _posizedBO.POSizeDBo.ItemNo;

                    formAddPODSize.textBoxDescription.Text = _posizedBO.POSizeDBo.Description;

                    formAddPODSize.FormClosing += FormAddPODSize_FormClosing;
                    addFormTopanelContainer(formAddPODSize);
                    //formAddPODSize.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Cannot add size in this node");
                }
            }
        }
        private void FormAddPODSize_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var refForm = (sender as FormAddPODSize);
                if (refForm != null)
                {
                    if (refForm.thisPOSizeDBo != null && refForm.thisPOSizeDBo.POSizeDBo != null)
                    {
                        if (refForm.thisPOSizeDBo.POSizeDBo.ID > 0
                                || (refForm.thisPOSizeDBo.POSizeDBo.ID <= 0 && refForm.thisPOSizeDBo.IsUpdated))
                        {
                            //local updated
                            treeViewColorSize.SelectedNode.Text = refForm.thisPOSizeDBo.POSizeDBo.SizeInfoBo.SizeName;
                            treeViewColorSize.SelectedNode.Tag = refForm.thisPOSizeDBo;
                            treeViewColorSize.SelectedNode.ImageIndex = 1;
                            treeViewColorSize.SelectedNode.SelectedImageIndex = 1;

                            treeViewColorSize.SelectedNode = treeViewColorSize.SelectedNode.Parent;
                        }
                        else if (refForm.thisPOSizeDBo.POSizeDBo.ID <= 0 && refForm.thisPOSizeDBo.IsNew)
                        {
                            //local added
                            var tn = treeViewColorSize.SelectedNode.Nodes.Add(refForm.thisPOSizeDBo.POSizeDBo.SizeInfoBo.SizeName);
                            tn.Tag = refForm.thisPOSizeDBo;
                            tn.ImageIndex = 0;
                            tn.SelectedImageIndex = 0;
                            tn.NodeFont = fontOfSize;

                            treeViewColorSize.SelectedNode = tn.Parent;
                        }
                        else
                        {
                            MessageBox.Show("invalid condition");
                        }
                        treeViewColorSize.ExpandAll();
                        treeViewColorSize.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void treeViewColorSize_Leave(object sender, EventArgs e)
        {
            //treeViewColorSize.SelectedNode = null;
        }

        bool SaveColorSize()
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

                        List<POSizeDBo> poSiseDList = new List<POSizeDBo>();
                        foreach (var tn in getTreeNodes(2))
                        {
                            if ((tn.Tag.GetType()) == typeof(thisPOSizeDBO) && (tn.Tag as thisPOSizeDBO).POSizeDBo.ID <= 0) //add
                            {
                                poSiseDList.Add((tn.Tag as thisPOSizeDBO).POSizeDBo);
                            }
                            else if ((tn.Tag.GetType()) == typeof(thisPOSizeDBO) && (tn.Tag as thisPOSizeDBO).IsUpdated && (tn.Tag as thisPOSizeDBO).POSizeDBo.ID > 0) //update
                            {
                                poSiseDList.Add((tn.Tag as thisPOSizeDBO).POSizeDBo);
                            }
                        }

                        //Adding Catalog's object with properties via service object
                        //Calling Manager's Function to Add new data with Catalog's Object on Web Service Object
                        var objService = new GPMSService.GPMSServiceClient();
                        var res = objService.AddUpdatePOSizeD(poSiseDList.ToArray()); //getting Response from Action
                        if (res.DtoStatus == DtoStatus.Success) // if Add New Data status is successfull then positive actions
                        {
                            this.Cursor = Cursors.Default;
                            //MessageBox.Show("Data is saved successfully!");
                            string strMsg = "Color and sizes are saved successfully";
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

        List<TreeNode> getTreeNodes(int level)
        {
            List<TreeNode> treeNodes = new List<TreeNode>();
            foreach (TreeNode treeNode0 in treeViewColorSize.Nodes)
            {
                if (level == 0)
                {
                    treeNodes.Add(treeNode0);
                    continue;
                }
                foreach (TreeNode treeNode1 in treeNode0.Nodes)
                {
                    if (level == 1)
                    {
                        treeNodes.Add(treeNode1);
                        continue;
                    }
                    foreach (TreeNode treeNode2 in treeNode1.Nodes)
                    {
                        if (level == 2)
                        {
                            treeNodes.Add(treeNode2);
                            continue;
                        }
                    }
                }
            }
            return treeNodes;
        }

        bool isValidate()
        {
            if (string.IsNullOrEmpty(textBoxPOMID.Text))
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "Please select a PONo");
                textBoxPONo.Focus();
                return false;
            }

            if (getTreeNodes(1).Where(x => x.Nodes.Count <= 0).Count() > 0)
            {
                var errNode = getTreeNodes(1).Where(x => x.Nodes.Count <= 0).First();
                treeViewColorSize.SelectedNode = errNode;
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "No sizes found in this color");
                treeViewColorSize.Focus();
                return false;
            }

            var addCount = getTreeNodes(2).Where(tn => tn.Level == 2
                                                     && ((tn.Tag.GetType()) == typeof(thisPOSizeDBO)
                                                     && (tn.Tag as thisPOSizeDBO).POSizeDBo.ID <= 0)).Count();
            var updateCount = getTreeNodes(2).Where(tn => tn.Level == 2
                                                      && ((tn.Tag.GetType()) == typeof(thisPOSizeDBO)
                                                      && (tn.Tag as thisPOSizeDBO).IsUpdated
                                                      && (tn.Tag as thisPOSizeDBO).POSizeDBo.ID > 0)).Count();

            if (addCount == 0 && updateCount == 0)
            {
                new MessagePopup().ShowMessagePopup((this), MessagePopupType.Warning, "No changes found in color and sizes");
                treeViewColorSize.Focus();
                return false;
            }



            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (SaveColorSize())
                {
                    ResetForm();
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
                if (SaveColorSize())
                {

                    var childForm = new FormPO2(pCurrentPOM.PONo) { TopLevel = false };
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (treeViewColorSize.SelectedNode != null)
            {
                treeViewColorSize.Focus();
                if (treeViewColorSize.SelectedNode.Level > 0 && (treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO).POSizeDBo.ID <= 0) //not style and is new
                {
                    //local delete
                    if (treeViewColorSize.SelectedNode.Level == 1) // color
                    {
                        //remove child
                        var childNodes = treeViewColorSize.SelectedNode.Nodes.Cast<TreeNode>().ToList();
                        foreach (TreeNode nd in childNodes)
                        {
                            if (nd != null)
                                treeViewColorSize.SelectedNode.Nodes.Remove(nd);
                        }
                        //remove this
                        var thisNode = treeViewColorSize.SelectedNode;
                        treeViewColorSize.Nodes.Remove(thisNode);
                    }
                    else if (treeViewColorSize.SelectedNode.Level == 2) //size
                    {
                        //remove this
                        var thisNode = treeViewColorSize.SelectedNode;
                        treeViewColorSize.Nodes.Remove(thisNode);
                    }
                }
                else if (treeViewColorSize.SelectedNode.Level == 1 && (treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO).POSizeDBo.ID > 0)
                {
                    //db color and sizes delete
                    try
                    {
                        var poSized = ((treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO).POSizeDBo);
                        var childNodes = treeViewColorSize.SelectedNode.Nodes.Cast<TreeNode>().Select(s => (s.Tag as thisPOSizeDBO));
                        if (poSized != null)
                        {
                            DialogResult resultUpdateQ = MessageBox.Show("Are you sure to delete color and sizes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (resultUpdateQ == DialogResult.Yes)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                var objService = new GPMSService.GPMSServiceClient();

                                List<int> delIDs = childNodes.Select(s => s.POSizeDBo.ID).ToList();
                                var res = objService.DeletePOSizeDCollection(delIDs.ToArray(), LoginUser._userID);
                                if (res.DtoStatus == DtoStatus.Success) //if update response is successfull
                                {
                                    // show success message to user
                                    this.Cursor = Cursors.Default;

                                    var childNodes2 = treeViewColorSize.SelectedNode.Nodes.Cast<TreeNode>().ToList();
                                    foreach (TreeNode nd in childNodes2)
                                    {
                                        if (nd != null)
                                            treeViewColorSize.SelectedNode.Nodes.Remove(nd);
                                    }
                                    //remove this
                                    var thisNode = treeViewColorSize.SelectedNode;
                                    treeViewColorSize.Nodes.Remove(thisNode);

                                    var pod = pCurrentPOM.PODCollection.Where(x => x.ID == poSized.PODID).FirstOrDefault();
                                    if (pod != null)
                                    {
                                        var delList = pod.POSizeDCollection.Where(x => delIDs.Contains(x.ID)).ToList();
                                        foreach (var posized in delList)
                                        {
                                            pod.POSizeDCollection.Remove(posized);
                                        }
                                    }
                                    else
                                    {
                                        buttonPOGo.PerformClick();
                                    }

                                    //MessageBox.Show("Data is saved successfully!");
                                    string strMsg = "Color and sizes are deleted";
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else if (treeViewColorSize.SelectedNode.Level == 2 && (treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO).POSizeDBo.ID > 0)
                {
                    //db size delete
                    try
                    {
                        var poSized = ((treeViewColorSize.SelectedNode.Tag as thisPOSizeDBO).POSizeDBo);
                        if (poSized != null)
                        {
                            DialogResult resultUpdateQ = MessageBox.Show("Are you sure to delete this size?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (resultUpdateQ == DialogResult.Yes)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                var objService = new GPMSService.GPMSServiceClient();

                                var res = objService.DeletePOSizeD(poSized.ID, LoginUser._userID);
                                if (res.DtoStatus == DtoStatus.Success) //if update response is successfull
                                {
                                    // show success message to user
                                    this.Cursor = Cursors.Default;

                                    var pod = pCurrentPOM.PODCollection.Where(x => x.ID == poSized.PODID).FirstOrDefault();
                                    if (pod != null)
                                    {
                                        var del = pod.POSizeDCollection.Where(x => x.ID == poSized.ID).FirstOrDefault();
                                        if (del != null)
                                        {
                                            pod.POSizeDCollection.Remove(del);
                                        }
                                    }
                                    else
                                    {
                                        buttonPOGo.PerformClick();
                                    }

                                    TreeNode tnParent = treeViewColorSize.SelectedNode.Parent;
                                    //remove this
                                    var thisNode = treeViewColorSize.SelectedNode;
                                    treeViewColorSize.Nodes.Remove(thisNode);

                                    string strMsg = "";
                                    if (tnParent.Nodes.Count == 0)
                                    {
                                        treeViewColorSize.Nodes.Remove(tnParent);
                                        strMsg = "Size and color are deleted";
                                    }
                                    else
                                    {
                                        strMsg = "Size is deleted";
                                    }

                                    //MessageBox.Show("Data is saved successfully!");
                                    //string strMsg = "Size is deleted";
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Cannot delete this node");
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void textBoxPOMID_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonResetSelection_Click(object sender, EventArgs e)
        {
            if (pCurrentPOM != null)
            {
                DialogResult resultResetQ = MessageBox.Show("Are you sure to reset selection?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultResetQ == DialogResult.Yes)
                {

                    buildTreeview();
                }
            }
        }

        private void buttonSaveNNext_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxPOMID.Text.Trim()))
            {
                if (SaveColorSize())
                {

                    var childForm = new FormPO4Post(pCurrentPOM.PONo) { TopLevel = false };
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

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (pCurrentPOM != null && pCurrentPOM.ID > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                var childForm = new FormPO2(pCurrentPOM.PONo) { TopLevel = false };
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

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (pCurrentPOM != null && pCurrentPOM.ID > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                var childForm = new FormPO4Post(pCurrentPOM.PONo) { TopLevel = false };
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
    }
}
