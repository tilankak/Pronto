
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
using System.Configuration;
using System.IO;
using Pronto.Utility;
using Pronto.Common;
using System.Globalization;


namespace Pronto
{
    public partial class RouteForm : Form
    {
        ErrorLog.Logger errorLog;
        BindingList<Stop> stopslist;
        LoginType CurMode;
        //DateTimePicker oDateTimePicker;

        private const String CUSTOMER_COLUMN = "customer";
        private const string SERVICE_COLUMN = "service";
        private const string ARIVAL_TIME_COLUMN = "StopArrivalTime";
        private const string DEPARTURE_TIME_COLUMN = "StopDepartTime";

        Route routeLoaded = null;
        DateTimePicker dateTimePicker = new DateTimePicker();
        Rectangle _Rectangle;
        ComboBoxData comboData;
        bool isChange;
        public RouteForm()
        {
            InitializeComponent();
        }

        
        private void RouteForm_Load(object sender, EventArgs e)
        {
            try
            {
                Pronto.Utility.ProjectPaths.AppName = "Pronto";
                errorLog = new Logger(Pronto.Utility.ProjectPaths.AppDataPath, Pronto.Utility.ProjectPaths.AppName);

                Pronto.Common.WebLogonForm logonForm = new WebLogonForm();
                DialogResult dlg = logonForm.ShowDialog();

                if (dlg != DialogResult.OK)
                {
                    errorLog.WriteToErroLog("Login Failed");
                    this.Close();
                    return;
                }

                CurMode = logonForm.loginMode;
                this.Text = this.Text + " " + CurMode.ToString();

                routeNoTxt.Text = DataAccessFactory.GetRootNo().ToString();

                RefreshComboData();


                stopslist = new BindingList<Stop>();




                customer.DataSource = comboData.ActiveCustomer;
                customer.DisplayMember = "CustomerName";
                //customer.ValueMember= null;
                service.DataSource = comboData.ActiveService;
                service.DisplayMember = "ServiceType";
                //service.ValueMember = null;
                ///
                RefreshGrid();

                CODDisTxt.Text = "0";

                //decimal money = 99.95m;
                //string moneyStr = String.Format("{0:00.00}", money);
                EditBtn.Visible = false;
                btnSave.Visible = true;
                btnAdmin.Visible = CurMode == LoginType.Admin ? true : false;

                //MaskedTextBox = new MaskedTextBox();
                //MaskedTextBox.Visible = false;
                //stopDGV.Controls.Add(MaskedTextBox);

                //stopDGV.CellBeginEdit += new DataGridViewCellCancelEventHandler(stopDGV_CellBeginEdit);
                //stopDGV.CellEndEdit += new DataGridViewCellEventHandler(stopDGV_CellEndEdit);
                //stopDGV.Scroll += new ScrollEventHandler(stopDGV_Scroll);

                stopDGV.Controls.Add(dateTimePicker);
                dateTimePicker.Visible = false;
                dateTimePicker.Format = DateTimePickerFormat.Time;
                dateTimePicker.ShowUpDown = true;

                dateTimePicker.TextChanged += new EventHandler(dateTimePicker_TextChange);

                //truckIDcmb.SelectedItem = new Truck();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLog.LogError(ex);
                this.Close();
            }



        }

        private void RefreshComboData()
        {
            comboData = new ComboBoxData();
            driverNameCmb.DataSource = comboData.ActiveDriverName;
            driverNameCmb.ValueMember = "DriverName";
            truckIDcmb.DataSource = comboData.ActiveTruck;
            //truckIDcmb.ValueMember = "TruckId";
            truckIDcmb.DisplayMember = "TruckId";

            helpercmb1.DataSource = comboData.ActiveHelper;
            helpercmb1.ValueMember = "HelperName";
            helpercmb2.DataSource = comboData.ActiveHelper;
            helpercmb2.ValueMember = "HelperName";
            helpercmb3.DataSource = comboData.ActiveHelper;
            helpercmb3.ValueMember = "HelperName";
            helpercmb4.DataSource = comboData.ActiveHelper;
            helpercmb4.ValueMember = "HelperName";

            
            driverNameCmb.Text = "";
            helpercmb1.Text = "";
            helpercmb2.Text = "";
            helpercmb3.Text = "";
            helpercmb4.Text = "";
            truckIDcmb.Text = "";

            vIDTxt.Text = "";
            LPlateIDTxt.Text = "";

        }

        private void RefreshGrid()
        {
            stopDGV.AutoGenerateColumns = false;
            stopDGV.DataSource = stopslist;
            stopDGV.Columns["ID"].Visible = false;
            stopDGV.Columns["StopNo"].ReadOnly = true;

            this.ID.DataPropertyName = "ID";
            //this.customer.DataPropertyName = "customer";
            //this.service.DataPropertyName = "service";
            this.PtsId.DataPropertyName = "PtsId";
            this.ClientName.DataPropertyName = "ClientName";
            this.ClientAddr.DataPropertyName = "ClientAddr";
            this.ClientPh.DataPropertyName = "ClientPh";
            this.QbDocNo.DataPropertyName = "QbDocNo";
            this.PadId.DataPropertyName = "PadId";
            this.PhoneId.DataPropertyName = "PhoneId";
            this.Eta.DataPropertyName = "Eta";
            this.StopCodAmount.DataPropertyName = "StopCodAmount";
            this.StopArrivalTime.DataPropertyName = ARIVAL_TIME_COLUMN;
            this.StopDepartTime.DataPropertyName = DEPARTURE_TIME_COLUMN;
            this.StopMlgMeterRead.DataPropertyName = "StopMlgMeterRead";
            this.StopNo.DataPropertyName = "StopNo";
            this.StopTimeAllot.DataPropertyName = "StopTimeAllot";
            this.StopNote.DataPropertyName = "StopNote";
            this.ClientCity.DataPropertyName = "ClientCity";
            this.ClientZipCode.DataPropertyName = "ClientZipCode";
            this.ClientState.DataPropertyName = "ClientState";
            this.ClientPh.DisplayIndex = 10;
            //StopTimeAllot
        }

        //private List<Customer> GetCustomers(string CSVPath)
        //{
        //    List<string> customers = comboData.Customer;
        //    List<Customer> CustomerList = new List<Customer>();
        //    int id = 0;
        //    foreach (var item in customers)
        //    {
        //        if (!string.IsNullOrEmpty(item))
        //        {
        //            CustomerList.Add(new Customer() { ID = id, CustomerName = item });
        //            id++;
        //        }
        //    }

        //    return CustomerList;
        //}

        //private List<Service> GetService(string CSVPath)
        //{
        //    List<string> customers = Pronto.Common.DataAccessFactory.GetCSVData(Path.Combine(CSVPath, "Service.csv"));
        //    List<Service> ServiceList = new List<Service>();
        //    int id = 0;
        //    foreach (var item in customers)
        //    {
        //        if (!string.IsNullOrEmpty(item))
        //        {
        //            ServiceList.Add(new Service() { ID = id, ServiceType = item });
        //            id++;
        //        }
        //    }

        //    return ServiceList;
        //}

        public Route getSelectedRoute()
        {

            Route CurRoot = new Route();
            CurRoot.RootNo = Functions.StringToInt(routeNoTxt.Text);
            CurRoot.RouteDate = Functions.StringToDate(routeDateDTP.Text);
            CurRoot.driver = new Drivers() { DriverName = driverNameCmb.Text };
            //CurRoot.VehicleId = vIDTxt.Text;
            //CurRoot.LicencePlateId = LPlateIDTxt.Text;
            CurRoot.truck = new Truck() { TruckId = truckIDcmb.Text };
            CurRoot.helpers = new List<Helper>();

            if (!string.IsNullOrEmpty(helpercmb1.Text))
            {
                CurRoot.helpers.Add(new Helper() { HelperName = helpercmb1.Text });
            }

            if (!string.IsNullOrEmpty(helpercmb2.Text))
            {
                CurRoot.helpers.Add(new Helper() { HelperName = helpercmb2.Text });
            }

            if (!string.IsNullOrEmpty(helpercmb3.Text))
            {
                CurRoot.helpers.Add(new Helper() { HelperName = helpercmb3.Text });
            }

            if (!string.IsNullOrEmpty(helpercmb4.Text))
            {
                CurRoot.helpers.Add(new Helper() { HelperName = helpercmb4.Text });
            }


            CurRoot.DepatureTime = dTimeDTP.Value;
            CurRoot.ArrivelTime = aTimeDTP.Value;
            CurRoot.DepartureMilage = Functions.StringToInt(DMMReadTxt.Text);
            CurRoot.ArrivelMilage = Functions.StringToInt(AMMReadTxt.Text);

            CurRoot.HotelInfo = hotelInfoTxt.Text;
            CurRoot.HotelReceipt = hotelRecTxt.Text;
            CurRoot.LunchStart = LStartDTP.Value;
            CurRoot.LunchEnd = LEndDTP.Value;
            CurRoot.DinnerStart = DStartDTP.Value;
            CurRoot.DinnerEnd = DEndDTP.Value;
            CurRoot.BreakAStart = BAStartDTP.Value;
            CurRoot.BreakAEnd = BBEndDTP.Value;
            CurRoot.BreakBStart = BBStartDTP.Value;
            CurRoot.BreakBEnd = BBEndDTP.Value;
            CurRoot.TotolCod = Functions.StringToInt(totalCODtxt.Text);
            CurRoot.CodDecrepency = Functions.StringToInt(CODDisTxt.Text);
            CurRoot.DriverComments = driverComTxt.Text;
            CurRoot.stops = stopslist.ToList<Stop>();

            return CurRoot;
        }




        private void ResetData()
        {
            routeNoTxt.Text = DataAccessFactory.GetRootNo().ToString();
            routeDateDTP.Value = DateTime.Now;
            driverNameCmb.Text = "";
            vIDTxt.Text = "";
            LPlateIDTxt.Text = "";
            truckIDcmb.Text = "";
            helpercmb1.Text = "";
            helpercmb2.Text = "";
            helpercmb3.Text = "";
            helpercmb4.Text = "";
            dTimeDTP.Value = DateTime.Now;
            aTimeDTP.Value = DateTime.Now;
            DMMReadTxt.Text = "";
            AMMReadTxt.Text = "";
            TRMTxt.Text = "";
            hotelInfoTxt.Text = "";
            hotelRecTxt.Text = "";
            LStartDTP.Value = DateTime.Now;
            LEndDTP.Value = DateTime.Now;
            DStartDTP.Value = DateTime.Now;
            DEndDTP.Value = DateTime.Now;
            BAStartDTP.Value = DateTime.Now;
            BAEndDTP.Value = DateTime.Now;
            BBStartDTP.Value = DateTime.Now;
            BBEndDTP.Value = DateTime.Now;
            totalCODtxt.Text = "";
            CODDisTxt.Text = "";
            driverComTxt.Text = "";
            stopslist.Clear();
            RefreshGrid();
        }


        private void LoadRoute(Route curRoute)
        {
            routeNoTxt.Text = curRoute.RootNo.ToString();
            routeDateDTP.Value = curRoute.RouteDate;
            driverNameCmb.Text = curRoute.driver.DriverName;
            //vIDTxt.Text = curRoute.VehicleId;
            //LPlateIDTxt.Text = curRoute.LicencePlateId;
            truckIDcmb.Text = curRoute.truck.TruckId;
            helpercmb1.Text = GetHelperCmg(curRoute, 0);
            helpercmb2.Text = GetHelperCmg(curRoute, 1);
            helpercmb3.Text = GetHelperCmg(curRoute, 2);
            helpercmb4.Text = GetHelperCmg(curRoute, 3);
            dTimeDTP.Value = curRoute.DepatureTime;
            aTimeDTP.Value = curRoute.ArrivelTime;
            DMMReadTxt.Text = curRoute.DepartureMilage.ToString();
            AMMReadTxt.Text = curRoute.ArrivelMilage.ToString();
            //TRMTxt.Text = "";
            hotelInfoTxt.Text = curRoute.HotelInfo;
            hotelRecTxt.Text = curRoute.HotelReceipt;
            LStartDTP.Value = curRoute.LunchStart;
            LEndDTP.Value = curRoute.LunchEnd;
            DStartDTP.Value = curRoute.DinnerStart;
            DEndDTP.Value = curRoute.DinnerEnd;
            BAStartDTP.Value = curRoute.BreakAStart;
            BAEndDTP.Value = curRoute.BreakAEnd;
            BBStartDTP.Value = curRoute.BreakBStart;
            BBEndDTP.Value = curRoute.BreakBEnd;
            totalCODtxt.Text = curRoute.TotolCod.ToString();
            CODDisTxt.Text = curRoute.CodDecrepency.ToString();
            driverComTxt.Text = curRoute.DriverComments;

            stopslist.Clear();
            if (curRoute.stops != null)
            {
                foreach (var item in curRoute.stops)
                {
                    stopslist.Add(item);
                }
            }

            RefreshGrid();

            if (curRoute.stops != null)
            {
                for (int i = 0; i < curRoute.stops.Count; i++)
                {
                    stopDGV.Rows[i].Cells[1].Value = "Stop-" + (i + 1).ToString();
                    stopDGV.Rows[i].Cells[2].Value = curRoute.stops[i].customer.CustomerName;
                    stopDGV.Rows[i].Cells[3].Value = curRoute.stops[i].service.ServiceType;
                }
            }
            UpdateTruck();
        }
        private void UpdateTruck()
        {
            Truck truckSelect = (Truck)truckIDcmb.SelectedItem;
            vIDTxt.Text = truckSelect.VehicleID;
            LPlateIDTxt.Text = truckSelect.LicencePlateId;
        }

        private string GetHelperCmg(Route curRoute, int index)
        {
            if (curRoute.helpers == null)
            { return ""; }
            if (curRoute.helpers.Count > index)
            {
                return curRoute.helpers[index].HelperName;
            }
            return "";
        }
        private void stopDGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.CurrentCell.ColumnIndex == dgv.Columns[CUSTOMER_COLUMN].Index || dgv.CurrentCell.ColumnIndex == dgv.Columns[SERVICE_COLUMN].Index)
            {
                ComboBox cbx = (ComboBox)e.Control;
                cbx.DropDownStyle = ComboBoxStyle.DropDown;
                cbx.Tag = dgv.CurrentCell.RowIndex;
                cbx.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                cbx.SelectedIndexChanged += LastColumnComboSelectionChanged;

            }
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var currentcell = stopDGV.CurrentCellAddress;
                var sendingCB = sender as DataGridViewComboBoxEditingControl;
                int CurRow = (int)sendingCB.Tag;
                var value = sendingCB.Text;

                if (stopDGV.CurrentCell.ColumnIndex == stopDGV.Columns[CUSTOMER_COLUMN].Index)
                {
                    Customer Curcustomer = new Customer() { CustomerName = value };
                    stopslist[CurRow].customer = Curcustomer;
                }
                else if (stopDGV.CurrentCell.ColumnIndex == stopDGV.Columns[SERVICE_COLUMN].Index)
                {
                    Service curService = new Service() { ServiceType = value };
                    stopslist[CurRow].service = curService;
                }
            }
            catch (Exception)
            {


            }
        }

        private void stopDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            dateTimePicker.Visible = false;

        }



        private void stopDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] dateColumns = { this.Eta.Name };

            if (dateColumns.Contains(stopDGV.Columns[e.ColumnIndex].Name))
            {
                _Rectangle = stopDGV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true); //  
                dateTimePicker.Size = new Size(_Rectangle.Width, _Rectangle.Height); //  
                dateTimePicker.Location = new Point(_Rectangle.X, _Rectangle.Y);
                //if (stopDGV.Columns[e.ColumnIndex].Name == this.Eta.Name)
                //{
                dateTimePicker.Format = DateTimePickerFormat.Custom;
                dateTimePicker.CustomFormat = "hh: mm: tt";
                //    dateTimePicker.ShowUpDown = false;
                //    dateTimePicker.Tag = true;
                //}
                //else
                //{
                //hh: mm: tt
                //dateTimePicker.Format = DateTimePickerFormat.Time;
                dateTimePicker.ShowUpDown = true;
                dateTimePicker.Tag = false;

                //}
                dateTimePicker.Visible = true;
                //dateTimePicker.Value = Utility.Functions.StringToDate(stopDGV.CurrentCell.Value.ToString());

            }
            else
            {
                dateTimePicker.Visible = false;

                if (stopDGV.Columns[e.ColumnIndex].Name == StopArrivalTime.Name || stopDGV.Columns[e.ColumnIndex].Name == StopDepartTime.Name)
                {
                    SetTime TimeSetter = new SetTime();

                    if (stopslist != null)
                    {
                        TimeSetter.DepTime = stopslist[e.RowIndex].StopDepartTime;
                        TimeSetter.ArTime = stopslist[e.RowIndex].StopArrivalTime;
                    }

                    DialogResult dlg = TimeSetter.ShowDialog();
                    if (dlg == DialogResult.OK && stopslist != null)
                    {
                        stopslist[e.RowIndex].StopArrivalTime = TimeSetter.ArTime;
                        stopslist[e.RowIndex].StopDepartTime = TimeSetter.DepTime;
                        stopDGV.Refresh();
                        stopDGV.Update();

                    }
                }
            }

        }

        private void dateTimePicker_TextChange(object sender, EventArgs e)
        {
            if (stopDGV.CurrentCell != null)
            {
                //if ((bool)dateTimePicker.Tag)
                //{
                stopDGV.CurrentCell.Value = dateTimePicker.Value.ToString("t");
                //}
                //else
                //{
                //stopDGV.CurrentCell.Value = dateTimePicker.Value.ToString();
                //}

                stopDGV.Refresh();
                stopDGV.Update();
            }
        }

        private void stopDGV_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //dateTimePicker.Visible = false;

        }


        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            DateTimePicker curDtpic = (DateTimePicker)sender;
            curDtpic.Visible = false;
        }

        private void stopDGV_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // if (e.ColumnIndex == this.stopDGV.Columns[this.StopArrivalTime.Name].Index)
            // if (e.ColumnIndex == this.stopDGV.Columns[this.StopArrivalTime.Name].Index)
            // {
            //     oDateTimePicker.Visible = false;
            // }

            //else if (e.ColumnIndex == this.stopDGV.Columns[this.StopDepartTime.Name].Index)
            // {
            //     oDateTimePicker.Visible = false;
            // }
        }

        private void stopDGV_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            //stopDGV.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }

        private void vIDTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //(e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //    errorProvider1.SetError(vIDTxt, "Numbers Only");
            //}

            //else
            //    errorProvider1.SetError(vIDTxt, "");

        }



        private void stopDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {

                if (e.RowIndex < 0 || stopslist == null || stopslist.Count == 0)
                { return; }

                if (e.RowIndex > 0)
                {
                    stopslist[e.RowIndex - 1].StopNo = "Stop-" + e.RowIndex.ToString();
                }


                if(stopDGV.Rows.Count > 0)
                {
                    DateTime departTime;
                    DataGridViewRow departValueRow = stopDGV.Rows[e.RowIndex > 0 ? e.RowIndex - 1 : e.RowIndex];
                    string dTime = departValueRow.Cells["StopDepartTime"].Value.ToString();
                    DateTime enteredDate = DateTime.Parse(dTime);
                    stopDGV.Rows[e.RowIndex].Cells["StopDepartTime"].Value = enteredDate;


                }
            }
            catch (Exception ex)
            {


            }
        }



        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (isChange)
                {

                    DialogResult dlg = MessageBox.Show("Please Save before print, Do you want to save", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dlg == DialogResult.Yes)
                    {
                        if (routeLoaded == null)
                        {
                            SaveNew();
                        }
                        else
                        { Save(true); }
                    }

                }
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (routeLoaded != null)
                    {
                        Pronto.Common.ExcelImport.ExportExcel(routeLoaded);
                    }
                    else
                    {
                        MessageBox.Show("Please Select Route", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (isChange)
            {
                DialogResult dlg = MessageBox.Show("Please Save before print, Do you want to save", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == DialogResult.Yes)
                {
                    if (routeLoaded == null)
                    {
                        SaveNew();
                    }
                    else
                    { Save(); }
                }

            }
            else
            { PrintPdf(); }

        }

        private void PrintPdf()
        {
            try
            {
                if (routeLoaded != null)
                {
                    SaveFileDialog svd = new SaveFileDialog();

                    svd.Filter = "Pdf Files | *.pdf";
                    svd.DefaultExt = "pdf";
                    svd.Title = "Select pdf file location";
                    svd.InitialDirectory = ConfigurationManager.AppSettings["PDFPath"];
                    svd.FileName = routeLoaded.RootNo.ToString() + ".pdf";

                    DialogResult dlg = svd.ShowDialog();
                    if (dlg == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        Pronto.Common.ExcelImport.ExportToPdf(routeLoaded, svd.FileName);
                        MessageBox.Show(string.Format("Pdf file created at '{0}'", svd.FileName), Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start(svd.FileName);
                    }
                }

                else
                { MessageBox.Show("Please Select Route", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {

            SaveNew();
        }

        private void SaveNew(bool isExel = false)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Route CurRoot = getSelectedRoute();
                routeLoaded = DataAccessFactory.SaveRoute(CurRoot);
                isChange = false;
                MessageBox.Show("Data Saved", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!isExel)
                {
                    PrintPdf(); 
                }
                else
                { ExcelImport.ExportExcel(routeLoaded); }
                ResetData();

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

        private void LPlateIDTxt_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox currentContainer = ((TextBox)sender);
            int caretPosition = currentContainer.SelectionStart;

            currentContainer.Text = currentContainer.Text.ToUpper();
            currentContainer.SelectionStart = caretPosition++;
        }

        private void stopDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stopDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            dateTimePicker.Visible = false;

            if (e.ColumnIndex == this.stopDGV.Columns[ClientPh.Name].Index)
            {
                try
                {
                    string Value = stopDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (Value.Length > 10)
                    {
                        Value = Value.Substring(1, 10);
                    }

                    stopDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:000-000-0000}", Int64.Parse(Value));
                }
                catch (Exception ex)
                {

                    stopDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:000-000-0000}", 0);
                }
            }
            //else if (e.ColumnIndex == this.stopDGV.Columns[this.Eta.Name].Index)
            //{
            //    try
            //    {
            //        string Value = stopDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            //        stopDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (Utility.Functions.StringToDate(Value)).ToString("d");
            //    }
            //    catch (Exception ex)
            //    {

            //        stopDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DateTime.Now.ToString("d");
            //    }

            //}


        }

        private void CODDisTxt_Leave(object sender, EventArgs e)
        {
            //CalculateMeterRed();
            TextBox txt = (TextBox)sender;

            FormatTextBox(txt, "{0:C2}");

        }

        private void DMMReadTxt_Leave(object sender, EventArgs e)
        {
            //CalculateMeterRed();
            TextBox txt = (TextBox)sender;

            FormatTextBox(txt, "{0:F}");

        }

        private void DMMReadTxt_TextChanged_1(object sender, EventArgs e)
        {
            CalculateMeterRed();
            isChange = true;

        }

        private void FormatTextBox(TextBox textbox, string FormatSting)
        {
            Double value;
            if (Double.TryParse(textbox.Text, out value))
                textbox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, FormatSting, value);
            else
                value = 0;
            textbox.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, FormatSting, value);
        }

        private void CalculateMeterRed()
        {
            TRMTxt.Text = string.Format("{0:F}", (Pronto.Utility.Functions.StringToDouble(AMMReadTxt.Text) - Pronto.Utility.Functions.StringToDouble(DMMReadTxt.Text)).ToString());
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save(bool isExel = false)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Route CurRoot = getSelectedRoute();
                routeLoaded = DataAccessFactory.SaveRoute(CurRoot, true);
                isChange = false;
                MessageBox.Show("Data Updated", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!isExel)
                { PrintPdf(); }
                else
                { ExcelImport.ExportExcel(routeLoaded); }


                ResetData();

                EditBtn.Visible = false;
                btnSave.Visible = true;
                routeLoaded = null;
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

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Search searchForn = new Search(errorLog,  new ComboBoxData(), CurMode);
                DialogResult dlg = searchForn.ShowDialog();
                if (dlg == DialogResult.OK)
                {
                    Route curRoute = DataAccessFactory.GetRoute(searchForn.SelectedRootNo);
                    LoadRoute(curRoute);
                    EditBtn.Visible = true;
                    btnSave.Visible = false;
                    routeLoaded = curRoute;
                    isChange = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLog.LogError(ex);
            }
        }

        private void stopDGV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //MaskedTextBox.Mask = "###-###-####";
            //Rectangle rectangle = stopDGV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            //MaskedTextBox.Location = rectangle.Location;
            //MaskedTextBox.Size = rectangle.Size;
            //MaskedTextBox.Text = "";

            //if (stopDGV[e.ColumnIndex, e.RowIndex].Value != null)
            //{
            //    MaskedTextBox.Text = stopDGV[e.ColumnIndex, e.RowIndex].Value.ToString();
            //}
            //MaskedTextBox.Visible = true;
            isChange = true;
        }

        private void stopDGV_Scroll(object sender, ScrollEventArgs e)
        {
            dateTimePicker.Visible = false;

        }

        private void stopDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == this.stopDGV.Columns[StopTimeAllot.Name].Index)
            {
                if (e.Value != null)
                {
                    TimeSpan ts = (TimeSpan)e.Value;
                    e.Value = string.Format("{0}:{1}", ts.Hours, ts.Minutes); //  string.Format("{}",e.Value); // apply formating here
                    e.FormattingApplied = true;
                }
            }
        }

        private void stopDGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            errorLog.LogError(new Exception(e.ToString(), e.Exception));
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                Pronto.Common.Admin Adminform = new Admin(errorLog, comboData);
                DialogResult dlg = Adminform.ShowDialog();
                RefreshComboData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorLog.LogError(ex);
            }

        }

        private void truckIDcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTruck();
            isChange = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            DialogResult dlg = MessageBox.Show("Do you wish to Save changes before Clearing the form?", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dlg == DialogResult.Yes)
            {
                Save();
            }

            EditBtn.Visible = false;
            btnSave.Visible = true;
            routeLoaded = null;
            ResetData();
        }

        private void stopDGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }

        private void stopDGV_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ConfigurationManager.AppSettings["PDFPath"]);
        }

        private void routeDateDTP_ValueChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void driverNameCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void hotelInfoTxt_TextChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void hotelRecTxt_TextChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void totalCODtxt_TextChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void CODDisTxt_TextChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void helpercmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void helpercmb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void helpercmb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void helpercmb4_SelectedIndexChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void LStartDTP_ValueChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void driverComTxt_TextChanged(object sender, EventArgs e)
        {
            isChange = true;
        }

        private void RouteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (routeLoaded != null && isChange)
            {
                DialogResult dlg = MessageBox.Show("Do you want to save before close", Pronto.Utility.ProjectPaths.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == DialogResult.Yes)
                {
                    Save();
                }

            }
           
        }

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;
            const UInt32 HTTOPERROW = 31;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>()
                {
                {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
                {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
                {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
                {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
                };

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }
            else if (m.Msg == HTTOPERROW)
            {


            }

            if (!handled)
                base.WndProc(ref m);
        }

        private void helpercmb1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(helpercmb1.SelectedValue != null)
            {
                if (helpercmb2.Items.Contains(helpercmb1.SelectedItem) || helpercmb2.Items.Contains(helpercmb1.SelectedItem) || helpercmb2.Items.Contains(helpercmb1.SelectedItem))
                {
                    helpercmb2.DataSource = null;
                    helpercmb3.DataSource = null;
                    helpercmb4.DataSource = null;

                }
            }
        }
    }
}
