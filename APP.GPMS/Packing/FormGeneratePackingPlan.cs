using Entities.GPMS;
using Microsoft.WindowsAPICodePack.Dialogs;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP.GPMS.Packing
{
    public partial class FormGeneratePackingPlan : Form
    {
        public FormGeneratePackingPlan()
        {
            InitializeComponent();
        }


        private void FormGeneratePackingPlan_Load(object sender, EventArgs e)
        {
            FillCustomerComboBox();
        }

        public void FillCustomerComboBox()
        {
            try
            {
                comboBoxCustomer.DataSource = null;
                var objService = new GPMSService.GPMSServiceClient(); // Creating Object of Web Service
                var resCust = objService.GetAllCustomers(true);

                if (resCust.DtoStatus == DtoStatus.Success) // Checking all of the things are Okay and response is positive
                {
                    var custList = resCust.CustomerInfoCollection;
                    if (custList != null && custList.Count > 0)
                    {
                        custList.Add(new CustomerInfoBo { ID = -1, CustomerName = "------ Select ------" });

                        comboBoxCustomer.DataSource = custList.OrderBy(x => x.ID).ToList();
                        comboBoxCustomer.ValueMember = "ID";
                        comboBoxCustomer.DisplayMember = "CustomerName";
                        //comboBoxPOType.SelectedValue = -1;

                    }
                    else
                    {
                        //toolStripStatusLabelMain.ForeColor = Color.Red;
                        //toolStripStatusLabelMain.Text = "No payment mode found, please add one or more payment mode/s";
                    }
                }
                else if (resCust.DtoStatus == DtoStatus.NoDataFound) //Response is No Data Found
                {
                    //toolStripStatusLabelMain.ForeColor = Color.Red;
                    //toolStripStatusLabelMain.Text = "No data found in payment mode";
                }

                else        //Checking all of the things( Client Side) are Okay but response is negative
                {
                    //Showing Error Message to User
                    string errorRes = resCust.DtoStatusNotes.Exception;
                    MessageBox.Show(errorRes, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message);
            }
        }

        string iconPending = " 🔄", iconCancel = " ❌", iconDone = " ✔";
        private void btnBowseSourcePath_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCustomer.SelectedIndex <= 0 || comboBoxCustomer.SelectedItem == null || comboBoxCustomer.SelectedValue.ToString() == "")
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Please select a customer");
                    return;
                }

                CommonOpenFileDialog folderDlg = new CommonOpenFileDialog();
                folderDlg.IsFolderPicker = true;

                //FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                string lastFolderSelection = Directory.GetCurrentDirectory() + "\\path.txt";
                if (!File.Exists(lastFolderSelection))
                    File.Create(lastFolderSelection).Close();

                if (!string.IsNullOrEmpty(File.ReadAllText(lastFolderSelection)))
                    folderDlg.InitialDirectory = File.ReadAllText(lastFolderSelection).Replace("\r\n", "");
                else
                    folderDlg.InitialDirectory = @"C:\\";

                SendKeys.Send("{TAB}{TAB}{RIGHT}"); // automactic scroll or direct focus on folder
                if (folderDlg.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    txtProcessedPath.Text = folderDlg.FileName + "\\";


                    using (StreamWriter file = new StreamWriter(lastFolderSelection, false))
                    {
                        file.WriteLine(folderDlg.FileName);
                    }

                    DirectoryInfo info = new DirectoryInfo(folderDlg.FileName);
                    if (info != null)
                    {
                        //FileInfo[] files = info.GetFiles().Where(x => x.Extension == ".xls").ToArray();
                        FileInfo[] files = info.GetFiles().Where(x => !x.Attributes.HasFlag(FileAttributes.Hidden) && (x.Extension == ".xls" || x.Extension == ".xlsx")).ToArray();
                        txtSourcePath.Text = folderDlg.FileName;
                        if (files.Count() > 0)
                        {
#pragma warning disable CS0219 // The variable 'img' is assigned but its value is never used
                            object img = null;
#pragma warning restore CS0219 // The variable 'img' is assigned but its value is never used
                            dataGridViewPackingPlan.Rows.Clear();
                            buttonProcess.Enabled = true;// it will enable if previous files will be removed
                            foreach (FileInfo file in files)
                            {

                                dataGridViewPackingPlan.Rows.Add();
                                //  img = new Bitmap(global::BHRIS.Properties.Resources.pending, 18, 18);
                                //else if (item.IsPostProcess == (byte)IsLeavePostEnum.Process)
                                //    img = new Bitmap(global::BHRIS.Properties.Resources.process, 18, 18);
                                //else if (item.IsPostProcess == (byte)IsLeavePostEnum.Approve)
                                //    img = new Bitmap(global::BHRIS.Properties.Resources.done, 18, 18);

                                dataGridViewPackingPlan.Rows[dataGridViewPackingPlan.Rows.Count - 1].Cells["FileName"].Value = file.Name;
                                dataGridViewPackingPlan.Rows[dataGridViewPackingPlan.Rows.Count - 1].Cells["Status"].Value = new Bitmap(global::APP.GPMS.Properties.Resources.pending, 18, 18);

                                dataGridViewPackingPlan.Rows[dataGridViewPackingPlan.Rows.Count - 1].Cells["Path"].Value = file.FullName;
                                dataGridViewPackingPlan.Rows[dataGridViewPackingPlan.Rows.Count - 1].Cells["checkbox"].Value = false;
                            }


                            Validations();
                            //chbSelectAll.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("File(s) does not exist at your selected directory.");
                            return;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString() + "\n\nContact with I.T Team.", "Error Message");

            }
        }

        void Validations()
        {
            if (!string.IsNullOrEmpty(txtSourcePath.Text) && !string.IsNullOrEmpty(txtProcessedPath.Text))
            {
                if (dataGridViewPackingPlan.Rows.Count > 0)
                {
                    foreach (DataGridViewRow ddataGridViewPackingPlanRow in dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().ToList())
                    {

                        //vallidation
                        ddataGridViewPackingPlanRow.Cells["Verified"].Value = iconPending;
                        ddataGridViewPackingPlanRow.Cells["Verified"].Style.ForeColor = Color.SkyBlue;

                        var checkIfEmptyFieldsExistsInFileRes = checkIfEmptyFieldsExistsInFile(ddataGridViewPackingPlanRow);
                        if (!string.IsNullOrEmpty(checkIfEmptyFieldsExistsInFileRes))
                        {
                            ddataGridViewPackingPlanRow.Cells["Description"].Value = checkIfEmptyFieldsExistsInFileRes;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Value = iconCancel;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.ForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.SelectionForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = null;
                            ddataGridViewPackingPlanRow.Cells["checkbox"] = new DataGridViewTextBoxCell();
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = "";
                            ddataGridViewPackingPlanRow.Cells["checkbox"].ReadOnly = true;

                            continue;

                        }

                        var checkPORes = checkIfMultiplePOExistInFile(ddataGridViewPackingPlanRow);
                        if (!string.IsNullOrEmpty(checkPORes))
                        {
                            ddataGridViewPackingPlanRow.Cells["Description"].Value = checkPORes;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Value = iconCancel;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.ForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.SelectionForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = null;
                            ddataGridViewPackingPlanRow.Cells["checkbox"] = new DataGridViewTextBoxCell();
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = "";
                            ddataGridViewPackingPlanRow.Cells["checkbox"].ReadOnly = true;

                            continue;

                        }

                        var checkIfPOExistInDBRes = checkIfPOExistInDB(ddataGridViewPackingPlanRow);
                        if (!string.IsNullOrEmpty(checkIfPOExistInDBRes))
                        {
                            ddataGridViewPackingPlanRow.Cells["Description"].Value = checkIfPOExistInDBRes;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Value = iconCancel;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.ForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.SelectionForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = null;
                            ddataGridViewPackingPlanRow.Cells["checkbox"] = new DataGridViewTextBoxCell();
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = "";
                            ddataGridViewPackingPlanRow.Cells["checkbox"].ReadOnly = true;

                            continue;
                        }

                        var checkFileNameExistRes = checkIfFileNameAlreadyExistInDB(ddataGridViewPackingPlanRow);
                        if (!string.IsNullOrEmpty(checkFileNameExistRes))
                        {
                            ddataGridViewPackingPlanRow.Cells["Description"].Value = checkFileNameExistRes;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Value = iconCancel;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.ForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.SelectionForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = null;
                            ddataGridViewPackingPlanRow.Cells["checkbox"] = new DataGridViewTextBoxCell();
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = "";
                            ddataGridViewPackingPlanRow.Cells["checkbox"].ReadOnly = true;

                            continue;
                        }




                        var checkUPC_PO_ExistRes = checkIfUPC_PO_ExistInDB(ddataGridViewPackingPlanRow);
                        if (!string.IsNullOrEmpty(checkUPC_PO_ExistRes))
                        {
                            ddataGridViewPackingPlanRow.Cells["Description"].Value = checkUPC_PO_ExistRes;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Value = iconCancel;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.ForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.SelectionForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = null;
                            ddataGridViewPackingPlanRow.Cells["checkbox"] = new DataGridViewTextBoxCell();
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = "";
                            ddataGridViewPackingPlanRow.Cells["checkbox"].ReadOnly = true;

                            continue;
                        }

                        var checkIfSIZECOLORDESC_SIZESTYLEExistRes = checkIfSIZECOLORDESC_SIZESTYLEExistInDB(ddataGridViewPackingPlanRow);
                        if (!string.IsNullOrEmpty(checkIfSIZECOLORDESC_SIZESTYLEExistRes))
                        {
                            ddataGridViewPackingPlanRow.Cells["Description"].Value = checkIfSIZECOLORDESC_SIZESTYLEExistRes;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Value = iconCancel;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.ForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["Verified"].Style.SelectionForeColor = Color.Red;
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = null;
                            ddataGridViewPackingPlanRow.Cells["checkbox"] = new DataGridViewTextBoxCell();
                            ddataGridViewPackingPlanRow.Cells["checkbox"].Value = "";
                            ddataGridViewPackingPlanRow.Cells["checkbox"].ReadOnly = true;

                            continue;
                        }

                        if (checkBoxQtyValidate.Checked)
                        {
                            var checkIfRequestedQtyIsValidRes = checkIfRequestedQtyIsValidInDB(ddataGridViewPackingPlanRow);
                            if (!string.IsNullOrEmpty(checkIfRequestedQtyIsValidRes))
                            {
                                ddataGridViewPackingPlanRow.Cells["Description"].Value = checkIfRequestedQtyIsValidRes;
                                ddataGridViewPackingPlanRow.Cells["Verified"].Value = iconCancel;
                                ddataGridViewPackingPlanRow.Cells["Verified"].Style.ForeColor = Color.Red;
                                ddataGridViewPackingPlanRow.Cells["Verified"].Style.SelectionForeColor = Color.Red;
                                ddataGridViewPackingPlanRow.Cells["checkbox"].Value = null;
                                ddataGridViewPackingPlanRow.Cells["checkbox"] = new DataGridViewTextBoxCell();
                                ddataGridViewPackingPlanRow.Cells["checkbox"].Value = "";
                                ddataGridViewPackingPlanRow.Cells["checkbox"].ReadOnly = true;

                                continue;
                            }
                        }


                        ddataGridViewPackingPlanRow.Cells["Verified"].Style.ForeColor = Color.Green;
                        ddataGridViewPackingPlanRow.Cells["Verified"].Value = iconDone;

                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Files are not fetched");
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Source folder path or Destination folder path is empty!");
            }
        }

        private void btnBrowseProcessedPath_Click(object sender, EventArgs e)
        {
            try
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                //dialog.InitialDirectory = "C:\\Users";
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    txtProcessedPath.Text = dialog.FileName + "\\";
                }
                else
                {
                    txtProcessedPath.Text = string.Empty;
                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message.ToString() + "\n\nContact with I.T Team.", "Error Message");

            }
        }


        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chbSelectAll.CheckState == CheckState.Checked)
            {
                dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString())).ToList()
                    .ForEach(f =>
                    {
                        f.Cells["checkbox"].Value = true;
                    });
            }
            else if (chbSelectAll.CheckState == CheckState.Unchecked)
            {
                dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString())).ToList()
                    .ForEach(f =>
                    {
                        f.Cells["checkbox"].Value = false;
                    });
            }
            updateCheckBoxValue();
        }
        void updateCheckBoxValue()
        {
            if (dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value)).Count() > 0 && dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value)).Count() == dataGridViewPackingPlan.RowCount)
                chbSelectAll.CheckState = CheckState.Checked;
            else if (dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value)).Count() == 0)
                chbSelectAll.CheckState = CheckState.Unchecked;
            else
                chbSelectAll.CheckState = CheckState.Indeterminate;

        }

        string checkIfMultiplePOExistInFile(DataGridViewRow ddataGridViewPackingPlanrow)
        {
            try
            {
                var dTable = GetExcelData(ddataGridViewPackingPlanrow);
                if (dTable != null && dTable.Rows.Count > 0)
                {
                    DataTable distinctValues = new DataView(dTable).ToTable(true, "PO_NO");
                    if (distinctValues.Rows.Count == 1)
                    {
                        return null;
                    }
                    else
                    {
                        return "Multiple POs found in excel file.";
                    }
                }
                else
                {
                    return "File Error: file contains no rows";
                }
            }
            catch (System.InvalidOperationException ix)
            {
                return "Error: " + ix + ", please provide .xls or .xlsx format.";
            }
            catch (Exception ex)
            {
                return "App Error: " + ex.Message;
            }
#pragma warning disable CS0162 // Unreachable code detected
            return null;
#pragma warning restore CS0162 // Unreachable code detected
        }
        string checkIfFileNameAlreadyExistInDB(DataGridViewRow ddataGridViewPackingPlanrow)
        {
            try
            {
                var objService = new GPMSService.GPMSServiceClient();
                var validDataResponse = objService.IsPackingPlanAlreadyProcessed(ddataGridViewPackingPlanrow.Cells["FileName"].Value.ToString());

                if (validDataResponse.DtoStatus != DtoStatus.Error) // attention required
                {
                    if (validDataResponse.IsExist.HasValue)
                    {
                        if (validDataResponse.IsExist.Value)
                            return "Already proccessed";
                        else
                            return null;
                    }
                    else
                    {
                        return "DB Error: File Process status not found";
                    }
                }
                else if (validDataResponse.DtoStatus == DtoStatus.Error)
                {
                    return "DB Error: " + validDataResponse.DtoStatusNotes.Exception;
                }

            }
            catch (Exception ex)
            {
                return "App Error: " + ex.Message;
            }
            return null;
        }
        string checkIfPOExistInDB(DataGridViewRow ddataGridViewPackingPlanrow)
        {
            try
            {
                var dTable = GetExcelData(ddataGridViewPackingPlanrow);
                if (dTable != null && dTable.Rows.Count > 0)
                {
                    var objService = new GPMSService.GPMSServiceClient();
                    var validDataResponse = objService.IsPONumberExist(dTable.Rows[0]["PO_NO"].ToString());

                    if (validDataResponse.DtoStatus != DtoStatus.Error) // attention required
                    {
                        if (validDataResponse.IsExist.HasValue)
                        {
                            if (!validDataResponse.IsExist.Value)
                                return "PO not found";
                            else
                                return null;
                        }
                        else
                        {
                            return "DB Error: PO status not found";
                        }
                    }
                    else if (validDataResponse.DtoStatus == DtoStatus.Error)
                    {
                        return "DB Error: " + validDataResponse.DtoStatusNotes.Exception;
                    }
                }
                else
                {
                    return "File Error: file contains no rows";
                }

            }
            catch (Exception ex)
            {
                return "App Error: " + ex.Message;
            }
            return null;
        }

        string checkIfUPC_PO_ExistInDB(DataGridViewRow ddataGridViewPackingPlanrow)
        {
            try
            {
                var dTable = GetExcelData(ddataGridViewPackingPlanrow);
                foreach (DataRow exlrow in dTable.Rows)
                {
                    var objService = new GPMSService.GPMSServiceClient();
                    var validDataResponse = objService.IsItemExistInPO(exlrow["PO_NO"].ToString(), exlrow["ItemNo"].ToString());

                    if (validDataResponse.DtoStatus != DtoStatus.Error) // attention required
                    {
                        if (validDataResponse.IsExist.HasValue)
                        {
                            if (!validDataResponse.IsExist.Value)
                                return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> Item not found in PO";
                            //else
                            //    return null;
                        }
                        else
                        {
                            return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> DB Error: Item in PO status not found";
                        }
                    }
                    else if (validDataResponse.DtoStatus == DtoStatus.Error)
                    {
                        return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> DB Error: " + validDataResponse.DtoStatusNotes.Exception;
                    }

                }
                return null;

            }
            catch (Exception ex)
            {
                return "App Error: " + ex.Message;
            }
#pragma warning disable CS0162 // Unreachable code detected
            return null;
#pragma warning restore CS0162 // Unreachable code detected
        }

        string checkIfEmptyFieldsExistsInFile(DataGridViewRow ddataGridViewPackingPlanrow)
        {
            try
            {
                var dTable = GetExcelData(ddataGridViewPackingPlanrow);
                foreach (DataRow exlrow in dTable.Rows)
                {

                    if (exlrow["PO_NO"] == null || string.IsNullOrEmpty(exlrow["PO_NO"].ToString()))
                    {
                        return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> File Error: PO_NO is empty";
                    }
                    if (exlrow["ItemNo"] == null || string.IsNullOrEmpty(exlrow["ItemNo"].ToString()))
                    {
                        return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> File Error: ItemNo is empty";
                    }
                    if (exlrow["ItemQtyPerCase"] == null || string.IsNullOrEmpty(exlrow["ItemQtyPerCase"].ToString()))
                    {
                        return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> File Error: ItemQtyPerCase is empty";
                    }
                    if (exlrow["GroupNo"] == null || string.IsNullOrEmpty(exlrow["GroupNo"].ToString()))
                    {
                        return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> File Error: GroupNo is empty";
                    }
                    if (exlrow["GroupCaseQty"] == null || string.IsNullOrEmpty(exlrow["GroupCaseQty"].ToString()))
                    {
                        return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> File Error: GroupCaseQty is empty";
                    }
                }
                return null;

            }
            catch (Exception ex)
            {
                return "App Error: " + ex.Message;
            }
#pragma warning disable CS0162 // Unreachable code detected
            return null;
#pragma warning restore CS0162 // Unreachable code detected
        }

        string checkIfRequestedQtyIsValidInDB(DataGridViewRow ddataGridViewPackingPlanrow)
        {

            try
            {
                var dTable = GetExcelData(ddataGridViewPackingPlanrow);
                foreach (DataRow exlrow in dTable.Rows)
                {
                    var objService = new GPMSService.GPMSServiceClient();
                    var validDataResponse = objService.IsPackQtyValid(Convert.ToInt32(comboBoxCustomer.SelectedValue), exlrow["PO_NO"].ToString(), exlrow["ItemNo"].ToString(), Convert.ToInt32(exlrow["ItemQtyPerCase"]));

                    if (validDataResponse.DtoStatus != DtoStatus.Error) // attention required
                    {
                        if (validDataResponse.IsExist.HasValue)
                        {
                            if (!validDataResponse.IsExist.Value)
                                return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + "  -> ORDER QTY(Processed + Current) connot be greater than PO Qty";
                            //else
                            //    return null;
                        }
                        else
                        {
                            return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> DB Error: Requested Qty Valid status not found";
                        }
                    }
                    else if (validDataResponse.DtoStatus == DtoStatus.Error)
                    {
                        return "In File Row# " + (dTable.Rows.IndexOf(exlrow) + 1) + " -> DB Error: " + validDataResponse.DtoStatusNotes.Exception;
                    }

                }
                return null;

            }
            catch (Exception ex)
            {
                return "App Error: " + ex.Message;
            }
#pragma warning disable CS0162 // Unreachable code detected
            return null;
#pragma warning restore CS0162 // Unreachable code detected
        }

        string checkIfSIZECOLORDESC_SIZESTYLEExistInDB(DataGridViewRow row)
        {
            //try
            //{
            //    var dTable = GetExcelData(row);
            //    foreach (DataRow dr in dTable.Rows)
            //    {
            //        string checkStrCount = @"SELECT color_desc SIZECOLORDESC,BUYER_PID SIZESTYLE 
            //                    FROM SCM401_EDI850_POD
            //                    WHERE customercode = '" + comboBoxCustomer.SelectedValue.ToString() + "'"
            //                    + " and po_no = '" + dr["PO_NO"] + "' AND UPC_CONSUMER_CODE = '" + dr["UPC"] + "'";


            //        var dt = new OraDB().GetData(checkStrCount, ref responseMsg);
            //        if (dt != null && dt.Rows.Count > 0)
            //        {
            //            if (dt.Rows[0]["SIZECOLORDESC"].ToString() != dr["SIZECOLORDESC"].ToString())
            //            {
            //                return "In File Row#: " + (dTable.Rows.IndexOf(dr) + 1) + " -> SIZECOLORDESC not valid";

            //            }
            //            else if (dt.Rows[0]["SIZESTYLE"].ToString() != dr["SIZESTYLE"].ToString())
            //            {
            //                return "In File Row#: " + (dTable.Rows.IndexOf(dr) + 1) + " -> SIZESTYLE not valid";

            //            }
            //        }
            //        else
            //        {
            //            return "DB Error: " + responseMsg;
            //        }
            //    }
            //    return null;

            //}
            //catch (Exception ex)
            //{
            //    return "App Error: " + ex.Message;
            //}
            return null;
        }


        DataTable GetExcelData(DataGridViewRow row)
        {
            if (row == null)
                return null;

            DataSet ds = new DataSet();
            try
            {
                string connectionString, strSQL = "";
                string fileExtension = System.IO.Path.GetExtension(row.Cells["FileName"].Value.ToString());
                //if (fileExtension == ".xls")
                //    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + row.Cells["Path"].Value.ToString() + ";" + "Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";
                //else if (fileExtension == ".xlsx")
                //    connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + row.Cells["Path"].Value.ToString() + ";Extended Properties='Excel 12.0;HDR=Yes; IMEX=1';";
                //else
                //{
                //    return null;
                //}
                //connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + row.Cells["Path"].Value.ToString() + ";" + "Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + row.Cells["Path"].Value.ToString() + ";Extended Properties=Excel 12.0;";
                OleDbConnection excelConnection = new OleDbConnection(connectionString);//E:\CMAU.xls;
                excelConnection.Open();

                var dtSchema = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                var Sheet1 = dtSchema.Rows[0].Field<string>("TABLE_NAME");
                // -- 
                //if (comboBoxCustomer.SelectedValue.ToString() == "05009") // Nexcom
                //strSQL = "SELECT PO_NO,ORDERSIZE1,SIZESTYLE,UPC,SIZECOLORDESC,PACKSIZE,ORDERQTY,ORDERSIZE,SIZEORDERQTY,ORDERSIZE2,[Size Code],[Complete Cartons],[PCs in Complete Cartons] FROM [" + Sheet1 + "] where PO_NO is not null";
                strSQL = "SELECT * FROM [" + Sheet1 + "] where PO_NO is not null";
                OleDbCommand dbCommand = new OleDbCommand(strSQL, excelConnection);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(dbCommand);
                dataAdapter.Fill(ds, "ExcelData");
            }
#pragma warning disable CS0168 // The variable 'ix' is declared but never used
            catch (System.InvalidOperationException ix)
#pragma warning restore CS0168 // The variable 'ix' is declared but never used
            {
                MessageBox.Show("Please provide .xls or .xlsx format.", "Error Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }

            return ds.Tables["ExcelData"];
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void setLastError(int rowIndex)
        {
            if (!string.IsNullOrEmpty(lastError))
            {
                if (dataGridViewPackingPlan.Rows[rowIndex].Cells["Description"].Value == null || string.IsNullOrEmpty(dataGridViewPackingPlan.Rows[rowIndex].Cells["Description"].Value.ToString()))
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["Description"].Value = lastError;
                else
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["Description"].Value = dataGridViewPackingPlan.Rows[rowIndex].Cells["Description"].Value.ToString() + "," + lastError;
                lastError = "";
            }
        }
        void assignRowStatus(int rowIndex, string stAddPackPlan, string stGenBarcode, string stGenPackQty, string stGenLabel)
        {
            if (rowIndex >= 0)
            {
                if (!string.IsNullOrEmpty(stAddPackPlan))
                {
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["PackPlanStatus"].Value = stAddPackPlan;

                    Color rowFColor = Color.Black;

                    if (stAddPackPlan == iconPending)
                        rowFColor = Color.SkyBlue;
                    else if (stAddPackPlan == iconDone)
                        rowFColor = Color.Green;
                    else if (stAddPackPlan == iconCancel)
                    {
                        setLastError(rowIndex);
                        rowFColor = Color.Red;
                    }

                    dataGridViewPackingPlan.Rows[rowIndex].Cells["PackPlanStatus"].Style.ForeColor = rowFColor;
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["PackPlanStatus"].Style.SelectionForeColor = rowFColor;
                }

                if (!string.IsNullOrEmpty(stGenBarcode))
                {
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["BarcodeStatus"].Value = stGenBarcode;

                    Color rowFColor = Color.Black;

                    if (stGenBarcode == iconPending)
                        rowFColor = Color.SkyBlue;
                    else if (stGenBarcode == iconDone)
                        rowFColor = Color.Green;
                    else if (stGenBarcode == iconCancel)
                    {
                        setLastError(rowIndex);
                        rowFColor = Color.Red;
                    }
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["BarcodeStatus"].Style.ForeColor = rowFColor;
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["BarcodeStatus"].Style.SelectionForeColor = rowFColor;
                }

                if (!string.IsNullOrEmpty(stGenPackQty))
                {
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["PackQtyStatus"].Value = stGenPackQty;

                    Color rowFColor = Color.Black;

                    if (stGenPackQty == iconPending)
                        rowFColor = Color.SkyBlue;
                    else if (stGenPackQty == iconDone)
                        rowFColor = Color.Green;
                    else if (stGenPackQty == iconCancel)
                    {
                        setLastError(rowIndex);
                        rowFColor = Color.Red;
                    }

                    dataGridViewPackingPlan.Rows[rowIndex].Cells["PackQtyStatus"].Style.ForeColor = rowFColor;
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["PackQtyStatus"].Style.SelectionForeColor = rowFColor;
                }

                if (!string.IsNullOrEmpty(stGenLabel))
                {
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["LabelStatus"].Value = stGenLabel;

                    Color rowFColor = Color.Black;

                    if (stGenLabel == iconPending)
                        rowFColor = Color.SkyBlue;
                    else if (stGenLabel == iconDone)
                        rowFColor = Color.Green;
                    else if (stGenLabel == iconCancel)
                    {
                        setLastError(rowIndex);
                        rowFColor = Color.Red;
                    }

                    dataGridViewPackingPlan.Rows[rowIndex].Cells["LabelStatus"].Style.ForeColor = rowFColor;
                    dataGridViewPackingPlan.Rows[rowIndex].Cells["LabelStatus"].Style.SelectionForeColor = rowFColor;
                }

                updateFileStatus(rowIndex);
            }

        }
        void updateFileStatus(int? rowInd)
        {
            foreach (DataGridViewRow row in dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value) && (rowInd.HasValue ? x.Index == rowInd : x.Index == x.Index)).ToList())
            {

                if (
                       (row.Cells["PackPlanStatus"].Value == null || string.IsNullOrEmpty(row.Cells["PackPlanStatus"].Value.ToString()))
                    && (row.Cells["BarcodeStatus"].Value == null || string.IsNullOrEmpty(row.Cells["BarcodeStatus"].Value.ToString()))
                    && (row.Cells["PackQtyStatus"].Value == null || string.IsNullOrEmpty(row.Cells["PackQtyStatus"].Value.ToString()))
                    && (row.Cells["LabelStatus"].Value == null || string.IsNullOrEmpty(row.Cells["LabelStatus"].Value.ToString()))
                   )
                {
                    row.Cells["Status"].Value = new Bitmap(Properties.Resources.pending, 18, 18);
                }
                else
                if (
                       (row.Cells["PackPlanStatus"].Value != null && (row.Cells["PackPlanStatus"].Value.ToString() == iconCancel))
                    && (row.Cells["BarcodeStatus"].Value != null && (row.Cells["BarcodeStatus"].Value.ToString() == iconCancel))
                    && (row.Cells["PackQtyStatus"].Value != null && (row.Cells["PackQtyStatus"].Value.ToString() == iconCancel))
                    && (row.Cells["LabelStatus"].Value != null && (row.Cells["LabelStatus"].Value.ToString() == iconCancel))
                   )
                {
                    row.Cells["Status"].Value = new Bitmap(Properties.Resources.error, 18, 18);
                }
                else
                if (
                       (row.Cells["PackPlanStatus"].Value != null && (row.Cells["PackPlanStatus"].Value.ToString() == iconDone))
                    && (row.Cells["BarcodeStatus"].Value != null && (row.Cells["BarcodeStatus"].Value.ToString() == iconDone))
                    && (row.Cells["PackQtyStatus"].Value != null && (row.Cells["PackQtyStatus"].Value.ToString() == iconDone))
                    && (row.Cells["LabelStatus"].Value != null && (row.Cells["LabelStatus"].Value.ToString() == iconDone))
                   )
                {
                    row.Cells["Status"].Value = new Bitmap(Properties.Resources.done, 18, 18);
                }
                else
                if (
                       (row.Cells["PackPlanStatus"].Value != null && (row.Cells["PackPlanStatus"].Value.ToString() == iconPending))
                    && (row.Cells["BarcodeStatus"].Value != null && (row.Cells["BarcodeStatus"].Value.ToString() == iconPending))
                    && (row.Cells["PackQtyStatus"].Value != null && (row.Cells["PackQtyStatus"].Value.ToString() == iconPending))
                    && (row.Cells["LabelStatus"].Value != null && (row.Cells["LabelStatus"].Value.ToString() == iconPending))
                   )
                {
                    row.Cells["Status"].Value = new Bitmap(Properties.Resources.process, 18, 18);
                }
                else
                if (
                       (row.Cells["PackPlanStatus"].Value != null && !string.IsNullOrEmpty(row.Cells["PackPlanStatus"].Value.ToString()))
                   || (row.Cells["BarcodeStatus"].Value != null && !string.IsNullOrEmpty(row.Cells["BarcodeStatus"].Value.ToString()))
                   || (row.Cells["PackQtyStatus"].Value != null && !string.IsNullOrEmpty(row.Cells["PackQtyStatus"].Value.ToString()))
                   || (row.Cells["LabelStatus"].Value != null && !string.IsNullOrEmpty(row.Cells["LabelStatus"].Value.ToString()))
                   )
                {
                    row.Cells["Status"].Value = new Bitmap(Properties.Resources.process, 18, 18);
                }
                else
                {
                    row.Cells["Status"].Value = new Bitmap(Properties.Resources.icons8_warning_32, 18, 18);
                }

            }
        }


        string lastError = "";

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedIndex <= 0 || comboBoxCustomer.SelectedItem == null)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Please select a customer");
                comboBoxCustomer.Focus();
                return;
            }
            if (!string.IsNullOrEmpty(txtSourcePath.Text) && !string.IsNullOrEmpty(txtProcessedPath.Text))
            {
                if (dataGridViewPackingPlan.Rows.Count > 0)
                {
                    if (dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value)).Count() > 0)
                    {
                        foreach (DataGridViewRow dgvRow in dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value)).ToList())
                        {
                            this.Cursor = Cursors.WaitCursor;
                            assignRowStatus(dgvRow.Index, iconPending, iconPending, iconPending, iconPending);

                            if (AddPackPlanData(dgvRow)) // both add data nad barcode generate
                            {
                                buttonProcess.Enabled = false;// it will disable if any file's data will be inserted
                                dgvRow.Cells["IsSuccess"].Value = "Y";
                                var poNo = dgvRow.Cells["PONo"].Value.ToString();
                                //  both add data nad barcode generate done
                                assignRowStatus(dgvRow.Index, iconDone, iconDone, null, null);

                                bool resPackQty = GetPackQty(poNo);
                                if (resPackQty)
                                {
                                    foreach (DataGridViewRow row in dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value) && x.Cells["PONo"].Value != null && x.Cells["PONo"].Value.ToString().Trim() == poNo).ToList())
                                        assignRowStatus(row.Index, null, null, iconDone, null);
                                }
                                else
                                {
                                    foreach (DataGridViewRow row in dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value) && x.Cells["PONo"].Value != null && x.Cells["PONo"].Value.ToString().Trim() == poNo).ToList())
                                        assignRowStatus(row.Index, null, null, iconCancel, null);
                                }

                                bool resLabel = GetLabel(poNo);
                                if (resLabel)
                                {
                                    foreach (DataGridViewRow row in dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value) && x.Cells["PONo"].Value != null && x.Cells["PONo"].Value.ToString().Trim() == poNo).ToList())
                                        assignRowStatus(row.Index, null, null, null, iconDone);
                                }
                                else
                                {
                                    foreach (DataGridViewRow row in dataGridViewPackingPlan.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["checkbox"].Value != null && !string.IsNullOrEmpty(x.Cells["checkbox"].Value.ToString()) && Convert.ToBoolean(x.Cells["checkbox"].Value) && x.Cells["PONo"].Value != null && x.Cells["PONo"].Value.ToString().Trim() == poNo).ToList())
                                        assignRowStatus(row.Index, null, null, null, iconCancel);
                                }

                                updateFileStatus(null);

                            }
                            else
                            {
                                setLastError(dgvRow.Index);
                                assignRowStatus(dgvRow.Index, iconCancel, iconCancel, iconCancel, iconCancel);
                            }

                            this.Cursor = Cursors.Default;
                        }
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;

                        MessageBox.Show("Please select one or more files to process");
                    }


                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Files are not fetched");
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Source folder path or Destination folder path is empty!");
            }
            this.Cursor = Cursors.Default;
            updateCheckBoxValue();

        }

        bool AddPackPlanData(DataGridViewRow dgvRow)
        {
            var excelData = GetExcelData(dgvRow);
            //int excelRowNo = 2;
            var packDto = new PackingDto();
            packDto.PackingPlanDataList = new List<PackingPlanDataBo>();
            foreach (DataRow dr in excelData.Rows)
            {
                PackingPlanDataBo PackingPlanDataBo = new PackingPlanDataBo();

                PackingPlanDataBo.CustomerID = Convert.ToInt32(comboBoxCustomer.SelectedValue);
                PackingPlanDataBo.PONo = dr["PO_NO"].ToString();
                PackingPlanDataBo.SourceFileName = dgvRow.Cells["FileName"].Value.ToString();
                PackingPlanDataBo.GroupNo = Convert.ToInt32(dr["GroupNo"]);
                PackingPlanDataBo.GroupCaseQty = Convert.ToInt32(dr["GroupCaseQty"]);
                PackingPlanDataBo.ItemQtyPerCase = Convert.ToInt32(dr["ItemQtyPerCase"]);
                PackingPlanDataBo.ItemNo = dr["ItemNo"].ToString();
                PackingPlanDataBo.StoreNo = dr["Store #"].ToString();
                PackingPlanDataBo.DC = dr["DC"].ToString();
                PackingPlanDataBo.CreatedByID = LoginUser._userID;
                PackingPlanDataBo.CreatedBy = LoginUser._userName;

                packDto.PackingPlanDataList.Add(PackingPlanDataBo);
            }
            //Adding Catalog's object with properties via service object
            //Calling Manager's Function to Add new data with Catalog's Object on Web Service Object
            var objService = new GPMSService.GPMSServiceClient();
            var res = objService.AddPackingPlanData(packDto); //getting Response from service Action
            if (res.DtoStatus == DtoStatus.Success) // if Add New Data status is successfull then positive actions
            {
                dgvRow.Cells["PONo"].Value = excelData.Rows[0]["PO_NO"].ToString();
                return true;
            }
            else if (res.DtoStatus == DtoStatus.RecordNotAdded)
            {
                lastError = "Record is not added";
            }
            else if (res.DtoStatus == DtoStatus.RecordNotUpdated)
            {
                lastError = "Record is not updated";
            }
            else if (res.DtoStatus == DtoStatus.Failed)
            {
                lastError = "Failed to add data";
            }
            else // if Add New Data status is not successfull then showing exception messages
            {
                ////// error/alter message
                string errorRes = res.DtoStatusNotes.Exception;
                lastError = errorRes;
            }
            dgvRow.Cells["IsSuccess"].Value = "N";
            return false;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxCustomer.SelectedIndex = 0;
            dataGridViewPackingPlan.Rows.Clear();
            chbSelectAll.Checked = false;
            txtSourcePath.Text = txtProcessedPath.Text = "";
        }


        /// <summary>
        /// get get pack qty for all selected and successfull processed file
        /// </summary>
        bool GetPackQty(string pPoNO)
        {

            {
                //Adding Catalog's object with properties via service object
                //Calling Manager's Function to Add new data with Catalog's Object on Web Service Object
                var objService = new GPMSService.GPMSServiceClient();
                var res = objService.GetPackQty(Convert.ToInt32(comboBoxCustomer.SelectedValue), pPoNO, DateTime.Now.Date); //getting Response from service Action
                if (res.DtoStatus == DtoStatus.Success) // if Add New Data status is successfull then positive actions
                {
                    // write excel here

                    // file name with .xlsx extension 
                    if (!Directory.Exists(txtProcessedPath.Text + "PackQty"))
                        Directory.CreateDirectory(txtProcessedPath.Text + "PackQty");

                    string p_strPath = txtProcessedPath.Text + @"PackQty\PackQty_" + pPoNO + ".xlsx";

                    if (File.Exists(p_strPath))
                        File.Delete(p_strPath);

                    if (res != null && res.DataTable.Rows.Count > 0)
                    {
                        // Creating an instance
                        // of ExcelPackage
                        ExcelPackage excel = new ExcelPackage();

                        // name of the sheet
                        var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

                        // setting the properties
                        // of the work sheet 
                        workSheet.TabColor = System.Drawing.Color.Black;
                        workSheet.DefaultRowHeight = 12;

                        // Setting the properties
                        // of the first row
                        workSheet.Row(1).Height = 20;
                        workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        workSheet.Row(1).Style.Font.Bold = true;

                        // Header of the Excel sheet
                        // PO_NO BOXBARCODE  UPC STYLE_ID    COLOR_ID SIZE_ID PACKQTY

                        int i = 1;
                        foreach (DataColumn dc in res.DataTable.Columns)
                        {
                            workSheet.Cells[1, i].Value = dc.ColumnName;
                            i++;
                        }

                        //workSheet.Cells[1, 1].Value = "PO_NO";
                        //workSheet.Cells[1, 2].Value = "BOXBARCODE";
                        //workSheet.Cells[1, 3].Value = "UPC";
                        //workSheet.Cells[1, 4].Value = "STYLE_ID";
                        //workSheet.Cells[1, 5].Value = "COLOR_ID";
                        //workSheet.Cells[1, 6].Value = "SIZE_ID";
                        //workSheet.Cells[1, 7].Value = "PACKQTY";
                        //workSheet.Cells[1, 8].Value = "USER_GIVEN_STORE_NO";
                        //workSheet.Cells[1, 9].Value = "SYSTEM_STORE_NO";

                        // Inserting the article data into excel
                        // sheet by using the for each loop
                        // As we have values to the first row 
                        // we will start with second row
                        //int recordIndex = 2;

                        //foreach (DataRow data in res.DataTable.Rows)
                        //{
                        //    workSheet.Cells[recordIndex, 1].Value = data["po_no"].ToString();
                        //    workSheet.Cells[recordIndex, 2].Value = data["boxbarcode"].ToString();
                        //    workSheet.Cells[recordIndex, 3].Value = data["upc"].ToString();
                        //    workSheet.Cells[recordIndex, 4].Value = data["style_id"].ToString();
                        //    workSheet.Cells[recordIndex, 5].Value = data["color_id"].ToString();
                        //    workSheet.Cells[recordIndex, 6].Value = data["size_id"].ToString();
                        //    workSheet.Cells[recordIndex, 7].Value = Convert.ToInt32(data["packqty"].ToString());
                        //    workSheet.Cells[recordIndex, 8].Value = data["UserGivenStoreno"] is DBNull ? "" : data["UserGivenStoreno"].ToString();
                        //    workSheet.Cells[recordIndex, 9].Value = data["SystemStoreno"] is DBNull ? "" : data["SystemStoreno"].ToString();
                        //    recordIndex++;
                        //}
                        int recordIndex = 2;

                        foreach (DataRow dr in res.DataTable.Rows)
                        {
                            int cInd = 1;
                            foreach (DataColumn dc in res.DataTable.Columns)
                            {
                                workSheet.Cells[recordIndex, cInd].Value = dr[cInd - 1].ToString();
                                cInd++;
                            }
                            recordIndex++;
                        }


                        for (int j = 1; j <= res.DataTable.Columns.Count; j++)
                        {
                            workSheet.Column(j).AutoFit();
                        }
                        // By default, the column width is not 
                        // set to auto fit for the content
                        // of the range, so we are using
                        // AutoFit() method here. 
                        workSheet.Column(1).AutoFit();
                        workSheet.Column(2).AutoFit();
                        workSheet.Column(3).AutoFit();
                        workSheet.Column(4).AutoFit();
                        workSheet.Column(5).AutoFit();
                        workSheet.Column(6).AutoFit();
                        workSheet.Column(7).AutoFit();
                        workSheet.Column(8).AutoFit();
                        workSheet.Column(9).AutoFit();

                        workSheet.Column(7).Style.Numberformat.Format = "0";


                        // Create excel file on physical disk 
                        FileStream objFileStrm = File.Create(p_strPath);
                        objFileStrm.Close();

                        // Write content to excel file 
                        File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
                        //Close Excel package
                        excel.Dispose();
                    }
                    else
                    {
                        lastError = "PackQty returns no row";
                    }
                    return File.Exists(p_strPath);
                }
                else if (res.DtoStatus == DtoStatus.RecordNotAdded)
                {
                    lastError = "Record is not added";
                }
                else if (res.DtoStatus == DtoStatus.RecordNotUpdated)
                {
                    lastError = "Record is not updated";
                }
                else if (res.DtoStatus == DtoStatus.Failed)
                {
                    lastError = "Failed to add data";
                }
                else // if Add New Data status is not successfull then showing exception messages
                {
                    ////// error/alter message
                    string errorRes = res.DtoStatusNotes.Exception;
                    lastError = errorRes;
                }


            }
            return false;
        }

        /// <summary>
        /// get indivisual label file of each PO 
        /// </summary>
        bool GetLabel(string pPoNO)
        {

            if (!string.IsNullOrEmpty(pPoNO))
            {
                //Adding Catalog's object with properties via service object
                //Calling Manager's Function to Add new data with Catalog's Object on Web Service Object
                var objService = new GPMSService.GPMSServiceClient();
                var res = objService.GetLabels_AcdSprt(Convert.ToInt32(comboBoxCustomer.SelectedValue), pPoNO, DateTime.Now.Date); //getting Response from service Action
                if (res.DtoStatus == DtoStatus.Success) // if Add New Data status is successfull then positive actions
                {
                    if (!Directory.Exists(txtProcessedPath.Text + "Label"))
                        Directory.CreateDirectory(txtProcessedPath.Text + "Label");
                    // file name with .xlsx extension 
                    string p_strPath = txtProcessedPath.Text + @"Label\Label_" + pPoNO + ".xlsx";

                    if (File.Exists(p_strPath))
                        File.Delete(p_strPath);

                    {


                        if (res != null && res.DataTable.Rows.Count > 0)
                        {
                            // write excel here

                            // Creating an instance
                            // of ExcelPackage
                            ExcelPackage excel = new ExcelPackage();

                            // name of the sheet
                            var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

                            // setting the properties
                            // of the work sheet 
                            workSheet.TabColor = System.Drawing.Color.Black;
                            workSheet.DefaultRowHeight = 12;

                            // Setting the properties 91560
                            // of the first row
                            workSheet.Row(1).Height = 20;
                            workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            workSheet.Row(1).Style.Font.Bold = true;

                            // Header of the Excel sheet
                            // PO_NO BOXBARCODE  UPC STYLE_ID    COLOR_ID SIZE_ID PACKQTY


                            int i = 1;
                            foreach (DataColumn dc in res.DataTable.Columns)
                            {
                                workSheet.Cells[1, i].Value = dc.ColumnName;
                                i++;
                            }

                            //workSheet.Cells[1, 1].Value = "PARTYCODE";
                            //workSheet.Cells[1, 2].Value = "SHIPTONAME";
                            //workSheet.Cells[1, 3].Value = "SHIPADDRESS";
                            //workSheet.Cells[1, 4].Value = "SHIPCITYSTATE";
                            //workSheet.Cells[1, 5].Value = "PO";
                            //workSheet.Cells[1, 6].Value = "BOXBARCODE";
                            //workSheet.Cells[1, 7].Value = "TOTAL";
                            //workSheet.Cells[1, 8].Value = "CURRENT";
                            //workSheet.Cells[1, 9].Value = "POSTALCODE";
                            //workSheet.Cells[1, 10].Value = "DEPT";
                            //workSheet.Cells[1, 11].Value = "SCAC";
                            //workSheet.Cells[1, 12].Value = "CASENO";

                            // Inserting the article data into excel
                            // sheet by using the for each loop
                            // As we have values to the first row 
                            // we will start with second row
                            int recordIndex = 2;

                            foreach (DataRow dr in res.DataTable.Rows)
                            {
                                int cInd = 1;
                                foreach (DataColumn dc in res.DataTable.Columns)
                                {
                                    workSheet.Cells[recordIndex, cInd].Value = dr[cInd - 1].ToString();
                                    cInd++;
                                }
                                recordIndex++;
                            }


                            for (int j = 1; j <= res.DataTable.Columns.Count; j++)
                            {
                                workSheet.Column(j).AutoFit();
                            }
                            //foreach (DataRow data in res.Rows)
                            //{
                            //    workSheet.Cells[recordIndex, 1].Value = data["partycode"].ToString();
                            //    workSheet.Cells[recordIndex, 2].Value = data["ShipToName"].ToString();
                            //    workSheet.Cells[recordIndex, 3].Value = data["ShipAddress"].ToString();
                            //    workSheet.Cells[recordIndex, 4].Value = data["ShipCityState"].ToString();
                            //    workSheet.Cells[recordIndex, 5].Value = data["PO"].ToString();
                            //    workSheet.Cells[recordIndex, 6].Value = data["boxbarcode"].ToString();
                            //    workSheet.Cells[recordIndex, 7].Value = data["TOTAL"].ToString();
                            //    workSheet.Cells[recordIndex, 8].Value = data["CURRENT"].ToString();
                            //    workSheet.Cells[recordIndex, 9].Value = data["POSTALCODE"].ToString();
                            //    workSheet.Cells[recordIndex, 10].Value = data["dept"].ToString();
                            //    workSheet.Cells[recordIndex, 11].Value = data["scac"].ToString();
                            //    workSheet.Cells[recordIndex, 12].Value = data["caseno"].ToString();
                            //    recordIndex++;
                            //}

                            // By default, the column width is not 
                            // set to auto fit for the content
                            // of the range, so we are using
                            // AutoFit() method here. 
                            //workSheet.Column(1).AutoFit();
                            //workSheet.Column(2).AutoFit();
                            //workSheet.Column(3).AutoFit();
                            //workSheet.Column(4).AutoFit();
                            //workSheet.Column(5).AutoFit();
                            //workSheet.Column(6).AutoFit();
                            //workSheet.Column(7).AutoFit();
                            //workSheet.Column(8).AutoFit();
                            //workSheet.Column(9).AutoFit();
                            //workSheet.Column(10).AutoFit();
                            //workSheet.Column(11).AutoFit();
                            //workSheet.Column(12).AutoFit();


                            //workSheet.Column(7).Style.Numberformat.Format = "0";
                            //workSheet.Column(8).Style.Numberformat.Format = "0";

                            //Random r = new Random();
                            //var v = r.Next(0, 999);

                            // Create excel file on physical disk 
                            FileStream objFileStrm = File.Create(p_strPath);
                            objFileStrm.Close();


                            // Write content to excel file 
                            File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
                            //Close Excel package
                            excel.Dispose();
                        }
                        else
                        {
                            lastError = "Label returns no row";
                        }

                        return File.Exists(p_strPath);

                    }
                }
                else if (res.DtoStatus == DtoStatus.RecordNotAdded)
                {
                    lastError = "Record is not added";
                }
                else if (res.DtoStatus == DtoStatus.RecordNotUpdated)
                {
                    lastError = "Record is not updated";
                }
                else if (res.DtoStatus == DtoStatus.Failed)
                {
                    lastError = "Failed to add data";
                }
                else // if Add New Data status is not successfull then showing exception messages
                {
                    ////// error/alter message
                    string errorRes = res.DtoStatusNotes.Exception;
                    lastError = errorRes;
                }



            }

            return false;

        }
    }
}
