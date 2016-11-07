using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class Transaction : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
                txtpaymentdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                
            }
            }
        public void BindDropDown()
        {
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
            }
        }
        protected void dpRoute_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ProcurementData pd = new ProcurementData();
            Model.Procurement p = new Model.Procurement();
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtfromdate.Text);
            p.ToDate = Convert.ToDateTime(txttodate.Text);
            DataSet DS = new DataSet();
            DS = pd.GetTransactionDetails(p);
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {

                rpRouteList.DataSource = DS;
                rpRouteList.DataBind();
                //rpBrandInfo.Visible = true;
                uprouteList.Update();
                foreach (RepeaterItem item in rpRouteList.Items)
                {
                    TextBox txtAmt = item.FindControl("txtAmt") as TextBox;
                    double amt = Convert.ToDouble(txtAmt.Text);
                    TextBox txtBonus = item.FindControl("txtBonus") as TextBox;
                    double bonus = Convert.ToDouble(txtBonus.Text);
                    TextBox txtScheme = item.FindControl("txtScheme") as TextBox;
                    double scheme = Convert.ToDouble(txtScheme.Text);
                    TextBox txtRD = item.FindControl("txtRD") as TextBox;
                    double rd = Convert.ToDouble(txtRD.Text);
                    TextBox txtloan = item.FindControl("txtloan") as TextBox;
                    double loan = Convert.ToDouble(txtloan.Text);
                    TextBox txtNetAmt = item.FindControl("txtNetAmt") as TextBox;
                    double netamt = 0.00;
                    netamt = amt - (bonus + scheme + rd + loan);
                    txtNetAmt.Text = Convert.ToString(netamt);

                }
                }
        }

        protected void rpRouteList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}