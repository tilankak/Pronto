using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using ErrorLog;
using Pronto.Common;

namespace Pronto
{
    public partial class Search : Form
    {
        DataTable dt;
        int selectedRootNo = -1;
        ErrorLog.Logger errorLog;
        ComboBoxData cmbData;
        LoginType curmode;
        public Search(ErrorLog.Logger Log, ComboBoxData comboBoxData, LoginType CurMode)
        {
            InitializeComponent();
            errorLog = Log;
            cmbData = comboBoxData;
            curmode = CurMode;
            this.Text = this.Text + " " + CurMode.ToString();
        }

        public int SelectedRootNo
        {
            get
            {
                return selectedRootNo;
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string query = "";
            List<string> paramList = new List<string>();

            if (!string.IsNullOrEmpty(driverNameCmb.Text))
            {
                paramList.Add(String.Format(" DriverName LIKE '%{0}%'", driverNameCmb.Text));
            }

            if (!string.IsNullOrEmpty(TruckCombo.Text))
            {
                paramList.Add(String.Format(" TruckId LIKE '%{0}%'", TruckCombo.Text));
            }

            if (!string.IsNullOrEmpty(HelperCombo.Text))
            {
                paramList.Add(String.Format(" HELPERS LIKE '%{0}%'", HelperCombo.Text));
            }

            if (!string.IsNullOrEmpty(CustomerCombo.Text))
            {
                paramList.Add(String.Format(" Customers LIKE '%{0}%'", CustomerCombo.Text));
            }

            if (!string.IsNullOrEmpty(ServiceCombo.Text))
            {
                paramList.Add(String.Format(" Services LIKE '%{0}%'", ServiceCombo.Text));
            }

            if (!string.IsNullOrEmpty(ClientNameTxt.Text))
            {
                paramList.Add(String.Format(" ClientName LIKE '%{0}%'", ClientNameTxt.Text));
            }

            if (!string.IsNullOrEmpty(ClientPhTxt.Text))
            {
                paramList.Add(String.Format(" ClientPH LIKE '%{0}%'", ClientPhTxt.Text));
            }

            if (!string.IsNullOrEmpty(ClientCityTxt.Text))
            {
                paramList.Add(String.Format(" ClientCity LIKE '%{0}%'", ClientCityTxt.Text));
            }

            if (!string.IsNullOrEmpty(ClientZipTxt.Text))
            {
                paramList.Add(String.Format(" ClientZipCode LIKE '%{0}%'", ClientZipTxt.Text));
            }

            if (!string.IsNullOrEmpty(PtsIdTxt.Text))
            {
                paramList.Add(String.Format(" PtsId LIKE '%{0}%'", PtsIdTxt.Text));
            }



            if (paramList.Count > 0)
            { query = " WHERE " + string.Join(" AND ", paramList); }


            if (!string.IsNullOrEmpty(RootNoCombo.Text))
            {
                
                dt = Pronto.Common.DataAccessFactory.GetResultForRoot(RootNoCombo.Text);

            }
            else
            {
                dt = Pronto.Common.DataAccessFactory.GetSearchResult(dateTimePicker1.Value, dateTimePicker2.Value, query);

            }


            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns();


        }

        private void SearchPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void helpercmb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Search_Load(object sender, EventArgs e)
        {
            string CSVPath = ConfigurationManager.AppSettings["CSVFilePath"];
            driverNameCmb.DataSource = cmbData.AllDriverName;
            driverNameCmb.DisplayMember = "DriverName";
            TruckCombo.DataSource = cmbData.AllTruck;
            TruckCombo.DisplayMember = "TruckId";
            HelperCombo.DataSource = cmbData.AllHelper;
            HelperCombo.DisplayMember = "HelperName";
            CustomerCombo.DataSource = cmbData.AllCustomer;
            CustomerCombo.DisplayMember = "CustomerName";
            ServiceCombo.DataSource = cmbData.AllService;
            ServiceCombo.DisplayMember = "ServiceType";

            RootNoCombo.DataSource = cmbData.AllRoodNos;
            //RootNoCombo.SelectedValue = "";

            driverNameCmb.Text = "";
            TruckCombo.Text = "";
            HelperCombo.Text = "";
            CustomerCombo.Text = "";
            ServiceCombo.Text = "";

            dataGridView1.AllowUserToDeleteRows = curmode == LoginType.Admin ? true : false;
        }

        private void CustomerCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void helperLabel1_Click(object sender, EventArgs e)
        {

        }

        private void driverNameCmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (curmode == LoginType.User)
            { return; }


            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow rw = dt.Rows[e.RowIndex];
                selectedRootNo = (int)rw["RouteNo"];
            }
            this.DialogResult = DialogResult.OK;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (dt != null)
                {
                    Pronto.Common.ExcelImport.ExportExcel(dt);
                }
                else
                {
                    MessageBox.Show("Please Select Search", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLog.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void exportToPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt != null)
                {
                    SaveFileDialog svd = new SaveFileDialog();

                    svd.Filter = "Pdf Files | *.pdf";
                    svd.DefaultExt = "pdf";
                    svd.Title = "Select pdf file location";

                    DialogResult dlg = svd.ShowDialog();
                    if (dlg == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Pronto.Common.ExcelImport.ExportToPdf(dt, svd.FileName);
                        MessageBox.Show(string.Format("Pdf file created at '{0}'", svd.FileName), Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                { MessageBox.Show("Please Select Search", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLog.LogError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                DialogResult dlg = MessageBox.Show("Do You want to delete the Selected row", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    e.Cancel = false;
                    var rowv = (DataRowView)(e.Row.DataBoundItem);
                    DataRow rw = rowv.Row;
                    int RootNo = (int)rw["RouteNo"];
                    DataAccessFactory.DeleteRoute(RootNo);

                }
                else
                {
                    e.Cancel = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLog.LogError(ex);
                e.Cancel = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            driverNameCmb.Text = "";
            TruckCombo.Text = "";
            HelperCombo.Text = "";
            CustomerCombo.Text = "";
            ServiceCombo.Text = "";
            ClientNameTxt.Text = "";
            ClientPhTxt.Text = "";
            PtsIdTxt.Text = "";
            ClientCityTxt.Text = "";
            ClientZipTxt.Text = "";
            RootNoCombo.Text = "";
            ServiceCombo.Text = "";
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            
            
            dt = new System.Data.DataTable();

            dataGridView1.DataSource = dt;
        }
    }
}
