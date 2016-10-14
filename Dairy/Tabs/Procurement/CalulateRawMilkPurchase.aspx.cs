using System;
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
    public partial class CalulateRawMilkPurchase : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
            
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

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd=new ProcurementData();
            p.RouteID =Convert.ToInt32( dpRoute.SelectedItem.Value);
            p.SupplierID = Convert.ToInt32(dpSupplier.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtFromDate.Text);
            p.ToDate = Convert.ToDateTime(txtToDate.Text);
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString();
            int Result = 0;
            DataSet DS1 = new DataSet();
            DS1 = pd.CalculateBill(p);
            if (DS1.Tables[0].Rows.Count>0)
            {
                GridView1.DataSource = DS1;
                GridView1.DataBind();
                divDanger.Visible = false;
                divwarning.Visible = false;
                //divSusccess.Visible = true;
                //lblSuccess.Text = "Bill Calculated Successfully";
                uprouteList.Update();
                pnlError.Update();
                upMain.Update();
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