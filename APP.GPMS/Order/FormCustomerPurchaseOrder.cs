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
    public partial class FormCustomerPurchaseOrder : Form
    {
        public FormCustomerPurchaseOrder()
        {
            InitializeComponent();
        }
        string[] EnableCtrlList = new string[]
                    {
                        "panelContainer"
                    };

        //List<AppActionSelect> thisAppActiveActions = null;

        private void FormCustomerPurchaseOrder_Load(object sender, EventArgs e)
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
            //        MessageBox.Show("You don't have access to customer P.O", "Alter Message");
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
            //    MessageBox.Show("You don't have access to  customer P.O", "Alter Message");
            //    this.BeginInvoke(new MethodInvoker(Close));
            //}
            //this.Cursor = Cursors.Default;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
