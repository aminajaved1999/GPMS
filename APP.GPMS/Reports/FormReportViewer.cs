using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace APP.GPMS.Reports
{
    public partial class FormReportViewer : Form
    {
        ReportViewer reportViewer = null;
        public string ReportName { get; set; }
        public ReportParamertsValues ReportParamertsValues { get; set; }
        public FormReportViewer()
        {
            InitializeComponent();
            //
            //ReportParamertsValues = new ReportParamertsValues();
            //-- add reprot viewer
            reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            reportViewer.Location = new System.Drawing.Point(0, 0);
            reportViewer.Name = "ReportViewer";
            reportViewer.Size = new System.Drawing.Size(396, 246);
            reportViewer.TabIndex = 0;
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.ShowZoomControl = false;
            reportViewer.ShowRefreshButton = false;
            reportViewer.ProcessingMode = ProcessingMode.Remote; // Set the processing mode for the ReportViewer to Remote 
            reportViewer.LocalReport.EnableExternalImages = true;
            this.Controls.Add(reportViewer);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (ReportServerConfiguration(ReportName))
            {
                //if (ReportName.ToUpper().Trim().Equals("CustomerInvoice".ToUpper().Trim()))
                //    InvoiceReport(ReportParamertsValues);  
                if (ReportName.ToUpper().Trim().Contains("POOverview".ToUpper().Trim()))
                    CustomerPurchaseOrderOverviewReport(ReportParamertsValues);


                reportViewer.RefreshReport();
                //var listDS = reportViewer.ServerReport.GetDataSources();
                //if (listDS.Count() > 0)
                //{

                //    var name1 = listDS.Where(x => x.Name.Contains("Deploy_")).First().Name;
                //    reportViewer.ServerReport.SetDataSourceCredentials
                //        (new DataSourceCredentialsCollection()
                //        { new DataSourceCredentials()
                //    {     Name = name1
                //        , UserId = SetCredUserName
                //        , Password = SetCredPassword
                //    } });

                //    reportViewer.ShowCredentialPrompts = false;
                //    reportViewer.ShowParameterPrompts = false;
                //    // Refresh the report  
                //    reportViewer.RefreshReport();
                //}
                //else
                //{
                //    MessageBox.Show("Deploy Datasource is not found in report, please configure accordingly");
                //    Close();

                //}
            }
            //
        }

        List<ReportParameter> paramList = null;
        private void CustomerPurchaseOrderOverviewReport(ReportParamertsValues pReportParamertsValues)
        {
            // create instance of ReportParameter List
            ////List<ReportParameter> paramList = new List<ReportParameter>();
            // set report input parameter values
            paramList.Add(new ReportParameter("pPONo", pReportParamertsValues.PONo, false));
            // hide parameters
            //paramList.Add(new ReportParameter("pActivityInfo", "NA", false));
            //paramList.Add(new ReportParameter("pIsSucceeded", "true", false));
            // Set the report parameters for the report  
            reportViewer.ServerReport.SetParameters(paramList);
            reportViewer.LocalReport.EnableExternalImages = true;
        }


#pragma warning disable CS0414 // The field 'FormReportViewer.SetCredUserName' is assigned but its value is never used
        string SetCredUserName = null;
#pragma warning restore CS0414 // The field 'FormReportViewer.SetCredUserName' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FormReportViewer.SetCredPassword' is assigned but its value is never used
        string SetCredPassword = null;
#pragma warning restore CS0414 // The field 'FormReportViewer.SetCredPassword' is assigned but its value is never used

        private bool ReportServerConfiguration(string reportName)
        {
           // var connectionStrParts = ConfigurationManager.ConnectionStrings["GPMSEntities"].ConnectionString.ToString().Split(';');

            //var dBServer = connectionStrParts.Where(x => x.ToUpper().Contains("DATA SOURCE")).FirstOrDefault();
            //var dBName = connectionStrParts.Where(x => x.ToUpper().Contains("INITIAL CATALOG")).FirstOrDefault();
            //var userName = connectionStrParts.Where(x => x.ToUpper().Contains("USER ID")).FirstOrDefault();
            //var pwd = connectionStrParts.Where(x => x.ToUpper().Contains("PASSWORD")).FirstOrDefault();

            //if (!string.IsNullOrEmpty(dBServer) && !string.IsNullOrEmpty(dBName) && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(pwd))
            //{
            //    dBServer = dBServer.Substring(dBServer.LastIndexOf('=') + 1).Trim();
            //    dBName = dBName.Substring(dBName.LastIndexOf('=') + 1).Trim();
            //    userName = userName.Substring(userName.LastIndexOf('=') + 1).Trim();
            //    pwd = pwd.Substring(pwd.LastIndexOf('=') + 1).Trim();
            //}
            //else
            //{
            //    MessageBox.Show("Error in connection string configuration");

            //    return false;
            //}

            paramList = new List<ReportParameter>();

            string ssrsTargetReportFolder = ConfigurationManager.AppSettings["ssrsTargetReportFolder"].ToString();
            string ssrsReportServer = ConfigurationManager.AppSettings["ssrsReportServer"].ToString();
            string ssrsReportServerURL = "http://" + ssrsReportServer + "/ReportServer";
            string ssrsReportServerUserName = ConfigurationManager.AppSettings["ssrsReportServerUserName"].ToString();
            string ssrsReportServerPassword = ConfigurationManager.AppSettings["ssrsReportServerPassword"].ToString();

            //paramList.Add(new ReportParameter("DBServerName", dBServer, false));
            //paramList.Add(new ReportParameter("DBName", dBName, false));
            //paramList.Add(new ReportParameter("DBName", "TrackoISPro", false)); // hardcode

            reportViewer.ServerReport.ReportServerUrl = new Uri(ssrsReportServerURL); // Set the report server URL
            reportViewer.ServerReport.ReportServerCredentials.NetworkCredentials = new System.Net.NetworkCredential(ssrsReportServerUserName, ssrsReportServerPassword); // Set the report server credentials
            reportViewer.ServerReport.ReportPath = "/" + ssrsTargetReportFolder + "/" + reportName; // Set the report path

            //SetCredUserName = userName;
            //SetCredPassword = pwd;

            //reportViewer.ServerReport.SetDataSourceCredentials(new DataSourceCredentialsCollection() { new DataSourceCredentials() { Name = reportViewer.ServerReport.GetDataSources().First().Name , UserId = userName, Password = pwd } });

            return true;

        }
    }

    public class ReportParamertsValues
    {
        //public string DBServerName { get; set; }
        //public string DBName { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string CustomerID { get; set; }
        public string PONo { get; set; }

    }
}
