﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Text;
using System.Data;
using Bussiness;

namespace Dairy.Tabs.Procurement
{
    public partial class MilkCollectionDetails : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindMilkCollectionList();
                BindDropDown();
                btnAddMilkCollection.Visible = true;
                btnupdateMilkCollection.Visible = false;
            }
        }

        protected void BindDropDown()
        {
            RouteData routeData = new RouteData();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("SupplierID ", "SupplierCode +' '+SupplierName as Name  ", "Proc_MilkSuppliersProfile", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpSupplier.DataSource = DS;
                dpSupplier.DataBind();
                dpSupplier.Items.Insert(0, new ListItem("--Select Supplier  --", "0"));
            }
        }

        protected void txtMilkInKG_TextChanged(object sender, EventArgs e)
        {
            txtMilkInLtr.Text = System.Math.Round((Convert.ToDouble(txtMilkInKG.Text) / 1.031),2).ToString();
        }

        protected void txtCLRReading_TextChanged(object sender, EventArgs e)
        {
            //txtSNF.Text = (Convert.ToDouble(txtCLRReading.Text) + (0.2 * Convert.ToDouble(txtFATPercentage.Text)) + 0.036).ToString();
            txtFATInKG.Text = ((Convert.ToDouble(txtMilkInKG.Text) * Convert.ToDouble(txtFATPercentage.Text)) / 100).ToString();
            txtSNFPercentage.Text = (Convert.ToDouble(txtCLRReading.Text) / 4 + (0.2 * Convert.ToDouble(txtFATPercentage.Text)) + 36).ToString();
            txtSNFInKG.Text = ((Convert.ToDouble(txtMilkInKG.Text) * Convert.ToDouble(txtSNFPercentage.Text)) / 100).ToString();
            txtTSPercentage.Text = (Convert.ToDouble(txtFATPercentage.Text) + Convert.ToDouble(txtSNFPercentage.Text)).ToString();
            txtTSKG.Text = (Convert.ToDouble(txtFATInKG.Text) + Convert.ToDouble(txtSNFInKG.Text)).ToString();
        }

        //protected void txtSNFPercentage_TextChanged(object sender, EventArgs e)
        //{
        //    txtSNFInKG.Text = ((Convert.ToDouble(txtMilkInKG.Text) * Convert.ToDouble(txtSNFPercentage.Text))/100).ToString();
        //    txtTSPercentage.Text = (Convert.ToDouble(txtFATPercentage.Text) + Convert.ToDouble(txtSNFPercentage.Text)).ToString();
        //    txtTSKG.Text = (Convert.ToDouble(txtFATInKG.Text) + Convert.ToDouble(txtSNFInKG.Text)).ToString();
        //}
        protected void btnAddMilkCollection_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.MilkCollectionID = 0;
            p.Batch = txtBatch.Text;
            p.Session = dpSession.SelectedItem.Text;
            p.Date =Convert.ToDateTime(txtDate.Text);
            p.MilkInKG =Convert.ToDecimal(txtMilkInKG.Text);
            p.MilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            p.RouteID =Convert.ToInt32( dpRoute.SelectedItem.Value);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedItem.Value);
            p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
            p.FATInKG = Convert.ToDecimal(txtFATInKG.Text);
            p.CLRReading = Convert.ToDecimal(txtCLRReading.Text);
            //p.SNF = Convert.ToDecimal(txtSNF.Text);
            p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
            p.SNFInKG = Convert.ToDecimal(txtSNFInKG.Text);
            p.TSPercentage = Convert.ToDecimal(txtTSPercentage.Text);
            p.TSInKg = Convert.ToDecimal(txtTSKG.Text);
            p.MilkCan = Convert.ToInt32(txtMilkCan.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Insert";
            int Result = 0;
            Result = pd.InsertMilkCollectionDetails(p);
            if (Result > 0)
            {

                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Milk Collection Record Add  Successfully";

                ClearTextBox();
                BindMilkCollectionList();
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
            txtBatch.Text = string.Empty;
            txtDate.Text = string.Empty;
            dpSession.ClearSelection();
            txtTSPercentage.Text = string.Empty;
            txtSNFPercentage.Text = string.Empty;
            txtSNFInKG.Text = string.Empty;
            //txtSNF.Text = string.Empty;
            txtMilkInLtr.Text = string.Empty;
            txtMilkInKG.Text = string.Empty;
            txtFATPercentage.Text = string.Empty;
            txtFATInKG.Text = string.Empty;
            txtCLRReading.Text = string.Empty;
            dpRoute.ClearSelection();
            dpSupplier.ClearSelection();
            txtMilkCan.Text = string.Empty;
            txtTSKG.Text = string.Empty;
        }
        public void BindMilkCollectionList()
        {

            ProcurementData pd = new ProcurementData();
            DataSet DS = new DataSet();
            StringBuilder sb = new StringBuilder();
            DS = pd.GetAllMilkCollectionDetails();
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                rpMilkCollectionList.DataSource = DS;
                rpMilkCollectionList.DataBind();
            }
        }

        protected void rpMilkCollectionList_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {

            divDanger.Visible = false;
            divwarning.Visible = false;
            divSusccess.Visible = false;
            pnlError.Update();
            int MilkCollectionid = 0;
            MilkCollectionid = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Edit"):
                    {
                        //lbltital.Text = "Edit Route";
                        hfMilkCollectionID.Value = MilkCollectionid.ToString();
                        MilkCollectionid = Convert.ToInt32(hfMilkCollectionID.Value);
                        //BindRouteList();
                        GetMilkCollectionDetailsbyID(MilkCollectionid);
                        btnAddMilkCollection.Visible = false;
                        btnupdateMilkCollection.Visible = true;
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }
                case ("delete"):
                    {

                        hfMilkCollectionID.Value = MilkCollectionid.ToString();
                        MilkCollectionid = Convert.ToInt32(hfMilkCollectionID.Value);
                        DeleteMilkCollectionbyID(MilkCollectionid);
                        BindMilkCollectionList();
                        upMain.Update();
                        uprouteList.Update();
                        break;
                    }


            }
        }


        public void GetMilkCollectionDetailsbyID(int milkcollectionid)
        {
            DataSet DS = new DataSet();
            ProcurementData pd = new ProcurementData();
            DS = pd.GetMilkCollectionDetailsbyID(milkcollectionid);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                txtCLRReading.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["CLRReading"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["CLRReading"].ToString();
                txtFATInKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FATInKG"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FATInKG"].ToString();
                txtFATPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["FATPercentage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["FATPercentage"].ToString();
                txtMilkInKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkInKG"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkInKG"].ToString();
                txtMilkInLtr.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["MilkInLtr"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["MilkInLtr"].ToString();
                //txtSNF.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNF"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNF"].ToString();
                txtSNFInKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNFInKG"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNFInKG"].ToString();
                txtSNFPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["SNFPercentage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["SNFPercentage"].ToString();
                txtTSPercentage.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TSPercentage"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TSPercentage"].ToString();
                dpRoute.ClearSelection();
                if (dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()) != null)
                {
                    dpRoute.Items.FindByValue(DS.Tables[0].Rows[0]["RouteID"].ToString()).Selected = true;
                }
                dpSupplier.ClearSelection();
                if (dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()) != null)
                {
                    dpSupplier.Items.FindByValue(DS.Tables[0].Rows[0]["SupplierID"].ToString()).Selected = true;
                }
                txtBatch.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Batch"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Batch"].ToString();
                txtDate.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["_Date"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["_Date"].ToString();
                dpSession.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["_Session"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["_Session"].ToString();
                txtMilkCan.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["Can"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["Can"].ToString();
                txtTSKG.Text = string.IsNullOrEmpty(DS.Tables[0].Rows[0]["TSInKg"].ToString()) ? string.Empty : DS.Tables[0].Rows[0]["TSInKg"].ToString();
            }
        }
        public void DeleteMilkCollectionbyID(int collectionid)
        {

            //Model.Procurement p = new Model.Procurement();
            //ProcurementData pd = new ProcurementData();
            //p.VehicleMasterID = string.IsNullOrEmpty(hfMilkCollectionID.Value) ? 0 : Convert.ToInt32(hfMilkCollectionID.Value);
            //p.MilkInKG = Convert.ToDecimal(txtMilkInKG.Text);
            //p.MilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            //p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            //p.SupplierID = Convert.ToInt32(dpSupplier.SelectedItem.Value);
            //p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
            //p.FATInKG = Convert.ToDecimal(txtFATInKG.Text);
            //p.CLRReading = Convert.ToDecimal(txtCLRReading.Text);
            //p.SNF = Convert.ToDecimal(txtSNF.Text);
            //p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
            //p.SNFInKG = Convert.ToDecimal(txtSNFInKG.Text);
            //p.TSPercentage = Convert.ToDecimal(txtTSPercentage.Text);
            //p.IsActive = false;

            //p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            //p.ModifiedBy = App_code.GlobalInfo.Userid;
            //p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            //p.flag = "Delete";
            //int Result = 0;
            //Result = pd.InsertVehicleDetails(p);
            //if (Result > 0)
            //{

            //    divDanger.Visible = false;
            //    divwarning.Visible = false;
            //    divSusccess.Visible = true;
            //    lblSuccess.Text = "Delete Updated  Successfully";
            //    ClearTextBox();
            //    BindMilkCollectionList();
            //    pnlError.Update();
            //    btnAddMilkCollection.Visible = true;
            //    btnupdateMilkCollection.Visible = false;
            //    upMain.Update();
            //    uprouteList.Update();
            //}
            //else
            //{
            //    divDanger.Visible = false;
            //    divwarning.Visible = true;
            //    divSusccess.Visible = false;
            //    lblwarning.Text = "Please Contact to Site Admin";
            //    pnlError.Update();

            //}
        }
        protected void btnupdateMilkCollection_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.MilkCollectionID = string.IsNullOrEmpty(hfMilkCollectionID.Value) ? 0 : Convert.ToInt32(hfMilkCollectionID.Value);
            p.Batch = txtBatch.Text;
            p.Session = dpSession.SelectedItem.Text;
            p.Date = Convert.ToDateTime(txtDate.Text);
            p.MilkInKG = Convert.ToDecimal(txtMilkInKG.Text);
            p.MilkInLtr = Convert.ToDecimal(txtMilkInLtr.Text);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedItem.Value);
            p.FATPercentage = Convert.ToDecimal(txtFATPercentage.Text);
            p.FATInKG = Convert.ToDecimal(txtFATInKG.Text);
            p.CLRReading = Convert.ToDecimal(txtCLRReading.Text);
            //p.SNF = Convert.ToDecimal(txtSNF.Text);
            p.SNFPercentage = Convert.ToDecimal(txtSNFPercentage.Text);
            p.SNFInKG = Convert.ToDecimal(txtSNFInKG.Text);
            p.TSPercentage = Convert.ToDecimal(txtTSPercentage.Text);
            p.TSInKg = Convert.ToDecimal(txtTSKG.Text);
            p.MilkCan = Convert.ToInt32(txtMilkCan.Text);
            p.CreatedBy = App_code.GlobalInfo.Userid;
            p.Createddate = DateTime.Now.ToString("dd-MM-yyyy");
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString("dd-MM-yyyy");
            p.flag = "Update";
            int Result = 0;
            Result = pd.InsertMilkCollectionDetails(p);
            if (Result > 0)
            {
                //lbltital.Text = "Add Route";
                divDanger.Visible = false;
                divwarning.Visible = false;
                divSusccess.Visible = true;
                lblSuccess.Text = "Milk Collection Record Updated  Successfully";
                ClearTextBox();
                BindMilkCollectionList();
                pnlError.Update();
                btnAddMilkCollection.Visible = true;
                btnupdateMilkCollection.Visible = false;
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