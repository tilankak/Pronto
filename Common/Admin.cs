using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorLog;
using Microsoft.Office.Interop.Excel;

namespace Pronto.Common
{
    public partial class Admin : Form
    {
        ErrorLog.Logger errorlog;
        List<LoginDetails> loginTypes = new List<LoginDetails>();
        ComboBoxData cmbData;

        List<comboDataType> Drivers = new List<comboDataType>();
        //BindingList<LoginDetails> logindetails;
        System.Data.DataTable logindata;
        System.Data.DataTable driverData;
        bool isChangeUser;
        bool isChangeDriver;
        enum comboDataType
        {
            Driver, Helper, TruckId, Customer, Service
        }
        public Admin(Logger log, ComboBoxData combodata)
        {
            InitializeComponent();
            errorlog = log;
            loginTypes.Add(new LoginDetails() { loginType = LoginType.Admin });
            loginTypes.Add(new LoginDetails() { loginType = LoginType.Median });
            loginTypes.Add(new LoginDetails() { loginType = LoginType.User });

            cmbData = combodata;
            Drivers.Add(comboDataType.Driver);
            Drivers.Add(comboDataType.Helper);
            Drivers.Add(comboDataType.TruckId);
            Drivers.Add(comboDataType.Customer);
            Drivers.Add(comboDataType.Service);
            DriverCombo.DataSource = Drivers;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

            logindata = DataAccessFactory.GetAllUsers();

            UserType.DataSource = loginTypes;
            UserType.ValueMember = "intType";
            UserType.DisplayMember = "loginType";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = logindata; // logindetails;
            ID.DataPropertyName = "ID";
            UserName.DataPropertyName = "UserName";
            UserType.DataPropertyName = "LoginType";
            Password.DataPropertyName = "Password";
            Active.DataPropertyName = "Active";
            dataGridView1.AllowUserToAddRows = true;
            //dataGridView1.Columns["UserName"].ReadOnly = true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrEmpty(UserNameTxt.Text))
                //{
                //    MessageBox.Show("Please Enter 'User Name'", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //if (string.IsNullOrEmpty(PwdTxt.Text))
                //{
                //    MessageBox.Show("Please Enter 'Password'", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //if (PwdTxt.Text != ConfirmTxt.Text)
                //{
                //    MessageBox.Show("Passwords not match", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                //LoginType curType = (LoginType)comboUserType.SelectedItem;
                //LoginDetails curLogin = new LoginDetails() { loginType = curType, Password = PwdTxt.Text, UserName = UserNameTxt.Text };

                //string SelectQuery = string.Format("SELECT [UserName],[LoginType],[Password]   FROM [Pronto].[Users] WHERE UserName = '{0}'", curLogin.UserName);
                //string InsertQuery = "INSERT INTO [Pronto].[Users] ([UserName],[LoginType],[Password]) VALUES  (@UserName,@LoginType ,@Password)";

                //LoginDetails NEWLOGIN = DataAccessFactory.Save<LoginDetails>(curLogin, InsertQuery, SelectQuery);

                //if(NEWLOGIN != null)
                //{
                //    ClearForm();
                //    MessageBox.Show("New User Added", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorlog.LogError(ex);
            }


        }

        private void ClearForm()
        {
            //PwdTxt.Clear();
            //ConfirmTxt.Clear();
            //UserNameTxt.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveDriver();

        }


        private void SaveDriver()
        {

            try
            {

                driverData.EndInit();
                comboDataType cmbType = (comboDataType)DriverCombo.SelectedItem;
                object result = null;
                string InsertQuery = "";
                string UpdateQuery = "";
                string SelectQuery = "";

                System.Data.DataTable changeddata = driverData.GetChanges();

                if (changeddata != null)
                {
                    List<DriverBase> updated = new List<DriverBase>();
                    foreach (DataRow item in changeddata.Rows)
                    {

                        DriverBase dr = null;
                        string propVal = "";

                        switch (cmbType)
                        {
                            case comboDataType.Driver:
                                propVal = item["DriverName"].ToString();

                                InsertQuery = "INSERT INTO [Pronto].[Drivers]  ([DriverName],[Active])  VALUES (@DriverName, @Active)";
                                UpdateQuery = "UPDATE [Pronto].[Drivers]    SET [DriverName] = @DriverName,[Active] = @Active WHERE ID = @ID";
                                SelectQuery = string.Format("select [ID],[DriverName],[Active] from [Pronto].[Drivers] where [DriverName] = '{0}'", propVal);
                                dr = new Drivers() { DriverName = propVal };

                                break;
                            case comboDataType.Helper:
                                propVal = item["HelperName"].ToString();

                                InsertQuery = "INSERT INTO [Pronto].[Helper]  ([HelperName],[Active])  VALUES (@HelperName, @Active)";
                                UpdateQuery = "UPDATE [Pronto].[Helper]   SET [HelperName] = @HelperName,[Active] = @Active WHERE ID = @ID";
                                SelectQuery = string.Format("select [ID],[HelperName],[Active] from [Pronto].[Helper] where [HelperName]   = '{0}'", propVal); ;

                                dr = new Helper() { HelperName = propVal };

                                break;
                            case comboDataType.TruckId:
                                propVal = item["TruckId"].ToString();
                                InsertQuery = "INSERT INTO [Pronto].[Truck]  ([TruckId],[Active],[VehicleID],[LicencePlateId])  VALUES (@TruckId,@Active,@VehicleID,@LicencePlateId)";
                                UpdateQuery = "UPDATE [Pronto].[Truck]   SET [TruckId] = @TruckId,[Active] = @Active,[VehicleID] =@VehicleID,[LicencePlateId]=@LicencePlateId WHERE ID = @ID";
                                SelectQuery = string.Format("SELECT [ID],[TruckId],[Active],[VehicleID],[LicencePlateId] FROM [Pronto].[Truck] WHERE TruckId  = '{0}'", propVal); ;
                                dr = new Truck() { TruckId = propVal, LicencePlateId = item["LicencePlateId"].ToString(), VehicleID = item["VehicleID"].ToString() };
                                break;
                            case comboDataType.Customer:
                                propVal = item["CustomerName"].ToString();
                                InsertQuery = "INSERT INTO [Pronto].[Customer]  ([CustomerName],[Active])  VALUES (@CustomerName, @Active)";
                                UpdateQuery = "UPDATE [Pronto].[Customer]   SET [CustomerName] = @CustomerName,[Active] = @Active WHERE ID = @ID";
                                SelectQuery = string.Format("SELECT [ID],[CustomerName],[Active]  FROM [Pronto].[Customer] where [CustomerName] = '{0}'", propVal);
                                dr = new Customer() { CustomerName = propVal };
                                break;
                            case comboDataType.Service:
                                propVal = item["ServiceType"].ToString();
                                InsertQuery = "INSERT INTO [Pronto].[Service]  ([ServiceType],[Active])  VALUES (@ServiceType, @Active)";
                                UpdateQuery = "UPDATE [Pronto].[Service]  SET [ServiceType] = @ServiceType,[Active] = @Active WHERE ID = @ID";
                                SelectQuery = string.Format("SELECT [ID],[ServiceType],[Active]  FROM [Pronto].[Service] where [ServiceType] = '{0}'", propVal); ;
                                dr = new Service() { ServiceType = propVal };
                                break;
                            default:
                                // code block
                                break;
                        }



                        dr.ID = item["ID"] != DBNull.Value ? (int)item["ID"] : -1;
                        dr.Active = item["Active"] != DBNull.Value? (bool)item["Active"] : false;
                        if (!string.IsNullOrEmpty(propVal))
                        { updated.Add(dr); }


                    }


                    DataAccessFactory.UpdateDrivers(updated, InsertQuery, SelectQuery, UpdateQuery);
                    MessageBox.Show("Changes Saved..", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorlog.LogError(ex);
                isChangeDriver = false;
                this.Close();
            }
            finally
            { isChangeDriver = false; }
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveUser();
        }

        private void SaveUser()
        {
            try
            {
               
                System.Data.DataTable changeddata = logindata.GetChanges();

                if (changeddata != null)
                {
                    List<LoginDetails> updated = new List<LoginDetails>();
                    foreach (DataRow item in changeddata.Rows)
                    {
                        LoginDetails lg = new LoginDetails();
                        //object ob = item["ID"];
                        lg.ID = item["ID"] != DBNull.Value ? (int)item["ID"] : -1;
                        lg.UserName = item["UserName"].ToString();
                        lg.Password = item["Password"].ToString();
                        lg.intType = (int)item["loginType"];
                        lg.Active = item["Active"] != DBNull.Value ?  (bool)item["Active"]: false;


                        if (!string.IsNullOrEmpty(lg.UserName) && !string.IsNullOrEmpty(lg.Password))
                        { updated.Add(lg); }


                    }

                    DataAccessFactory.UpdateUsers(updated);
                    MessageBox.Show("Changes to Users Saved..", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorlog.LogError(ex);
            }
            finally
            { isChangeUser = false; }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DriverCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboDataType cmbType = (comboDataType)DriverCombo.SelectedItem;
                //object result = null;

                string script = "";

                switch (cmbType)
                {
                    case comboDataType.Driver:
                        script = "SELECT [ID],[DriverName] ,[Active]  FROM [Pronto].[Drivers]";
                        break;
                    case comboDataType.Helper:
                        script = "SELECT [ID],[HelperName] ,[Active]  FROM [Pronto].[Helper]";
                        break;
                    case comboDataType.TruckId:
                        script = "SELECT [ID],[TruckId] ,[VehicleID],[LicencePlateId],[Active]  FROM [Pronto].[Truck]";
                        break;
                    case comboDataType.Customer:
                        script = "SELECT [ID],[CustomerName] ,[Active]  FROM [Pronto].[Customer]";
                        break;
                    case comboDataType.Service:
                        script = "SELECT [ID],[ServiceType] ,[Active]  FROM [Pronto].[Service]";
                        break;
                    default:
                        // code block
                        break;
                }

                driverData = DataAccessFactory.LoadDataTable(script);
                //gridDriver.Rows.Clear();
                gridDriver.DataSource = driverData;
                gridDriver.Columns["ID"].Visible = false;
                gridDriver.Columns["Active"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (cmbType != comboDataType.TruckId)
                {
                    gridDriver.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }

                //gridDriver.Columns[1].ReadOnly = true;
            }
            catch (Exception ex)
            {


                errorlog.LogError(ex);
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            isChangeUser = true;

            e.Cancel = EnableEdit(dataGridView1, e.ColumnIndex, dataGridView1.Columns["UserName"].Index, e.RowIndex);
        }

        private bool EnableEdit(DataGridView grid, int Curcolumn, int RoColumn, int RowIndex)
        {
            if (Curcolumn == RoColumn)
            {
                if (!grid.Rows[RowIndex].IsNewRow)
                { return true; }
            }

            return false;
        }

        private void gridDriver_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            isChangeDriver = true;
            e.Cancel = EnableEdit(gridDriver, e.ColumnIndex, gridDriver.Columns[1].Index, e.RowIndex);
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(isChangeDriver || isChangeUser)
            {
                

                DialogResult dlg = MessageBox.Show("Do you wish to Save changes before Closing?", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {
                    
                    if (isChangeUser)
                    {
                        btnSave.Select();
                        SaveUser();
                    }

                    if (isChangeDriver)
                    {
                        button1.Select();
                        SaveDriver();
                    }
                }


            }
        }
    }
}
