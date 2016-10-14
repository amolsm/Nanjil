using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Bussiness;
using Model;
using System.Text;
using Model;

namespace Dairy.Tabs.Procurement
{
    public partial class VehicleTeriff : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindVehicleList();
                btnAddVeh.Visible = true;
                btnupdateVeh.Visible = false;
            }
        }

        protected void btnAddVeh_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.VehicleID = 0;
            p.SrNo = txtSrNo.Text;
            p.Vehicle = txtVehicleName.Text;
            p.Bata = Convert.ToDouble(txtBata.Text);
            p.KMLessThan100 = Convert.ToDouble(txtLess100.Text);
            p.V101To200 = Convert.ToDouble(txt100To200.Text);
            p.V201To250 = Convert.ToDouble(txt201To250.Text);
            p.V251To300 = Convert.ToDouble(txt251To300.Text);
            p.KMGreaterThan300 = Convert.ToDouble(txtKMGreater300.Text);
            p.Discription = txtDesc.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertVehicleMaster(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Record Add  Successfully";

                ClearTextBox();
                BindVehicleList();
                pnlError.Update();
                upMain.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Please Contact to Site Admin";
                pnlError.Update();

            }
        }

        public void ClearTextBox()
        {
            txt100To200.Text = string.Empty;
            txt201To250.Text = string.Empty;
            txt251To300.Text = string.Empty;
            txtBata.Text = string.Empty;
            txtKMGreater300.Text = string.Empty;
            txtLess100.Text = string.Empty;
            txtSrNo.Text = string.Empty;
            txtVehicleName.Text = string.Empty;
            txtDesc.Text = string.Empty;
        }
        public void BindVehicleList()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllVehicleMasterDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpVehicleMaster.DataSource = DS;
                rpVehicleMaster.DataBind();
            }
        }

        protected void rpVehicleMaster_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int vehicleid = 0;
            vehicleid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfrouteID.Value = vehicleid.ToString();
                        vehicleid = Convert.ToInt32(hfrouteID.Value);
                        //BindRouteList();
                        GetRouteDetailsbyID(vehicleid);
                        btnAddVeh.Visible = false;
                        btnupdateVeh.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfrouteID.Value = vehicleid.ToString();
                        vehicleid = Convert.ToInt32(hfrouteID.Value);
                        //DeleteRoutebyrouteID(vehicleid);
                        BindVehicleList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }


        public void GetRouteDetailsbyID(int vehicleid)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetVehicleMasterDetailsbyID(vehicleid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtSrNo.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SrNo"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SrNo"].ToString();
                txtVehicleName.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Vehicle"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Vehicle"].ToString();
                txtBata.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Bata"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Bata"].ToString();
                txtLess100.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["KMLessThan100"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["KMLessThan100"].ToString();
                txt100To200.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["101To200"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["101To200"].ToString();
                txt201To250.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["201To250"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["201To250"].ToString();
                txt251To300.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["251To300"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["251To300"].ToString();
                txtKMGreater300.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["KMGreaterThan300"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["KMGreaterThan300"].ToString();
                txtDesc.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Description"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Description"].ToString();
            }
        }
        //public void DeleteRoutebyrouteID(int routeID)
        //{

        //    Route route = new Route();
        //    RouteData routeDate = new RouteData();
        //    route.RouteID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
        //    route.RouteCode = string.Empty;
        //    route.RouteName = string.Empty;
        //    route.ASOID = Convert.ToInt32(dpASOID.SelectedItem.Value);
        //    route.Category = Convert.ToInt32(Category.SelectedItem.Value);
        //    route.RouteDesc = string.Empty;
        //    route.CreatedBy = App_code.GlobalInfo.Userid;
        //    route.Discription = txtDesc.Text;
        //    route.IsActive = false;
        //    route.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
        //    route.ModifiedBy = App_code.GlobalInfo.Userid;
        //    route.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
        //    route.flag = "Delete";
        //    int Result = 0;
        //    Result = routeDate.InsertMilkCollectionRoute(route);
        //    if (Result > 0)
        //    {

        //        divDanger.Visible = false;
        //        divwarning.Visible = false;
        //        divSusccess.Visible = true;
        //        lblSuccess.Text = "Delete Updated  Successfully";
        //        ClearTextBox();
        //        BindRouteList();
        //        pnlError.Update();
        //        btnAddRout.Visible = true;
        //        btnupdateroute.Visible = false;
        //        upMain.Update();
        //        uprouteList.Update();
        //    }
        //    else
        //    {
        //        divDanger.Visible = false;
        //        divwarning.Visible = true;
        //        divSusccess.Visible = false;
        //        lblwarning.Text = "Please Contact to Site Admin";
        //        pnlError.Update();

        //    }
        //}
        protected void btnupdateVeh_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.VehicleID = string.IsNullOrEmpty(hfrouteID.Value) ? 0 : Convert.ToInt32(hfrouteID.Value);
            p.SrNo = txtSrNo.Text;
            p.Vehicle = txtVehicleName.Text;
            p.Bata = Convert.ToDouble(txtBata.Text);
            p.KMLessThan100 = Convert.ToDouble(txtLess100.Text);
            p.V101To200 = Convert.ToDouble(txt100To200.Text);
            p.V201To250 = Convert.ToDouble(txt201To250.Text);
            p.V251To300 = Convert.ToDouble(txt251To300.Text);
            p.KMGreaterThan300 = Convert.ToDouble(txtKMGreater300.Text);
            p.Discription = txtDesc.Text;
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertVehicleMaster(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Vehicle Record Updated  Successfully";
                ClearTextBox();
                BindVehicleList();
                pnlError.Update();
                btnAddVeh.Visible = true;
                btnupdateVeh.Visible = false;
                upMain.Update();
                uprouteList.Update();
            }
            else
            {
                divDanger.Visible = false;
                divwarning.Visible = true;
                divSusccess.Visible = false;
                lblwarning.Text = "Please Contact to Site Admin";
                pnlError.Update();

            }
        }
    }
}