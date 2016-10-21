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
using System.IO;

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
                dpRoute.Items.Insert(0, new ListItem("--All Route  --", "0"));
            }

            DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCenter.DataSource = DS;
                dpCenter.DataBind();
                dpCenter.Items.Insert(0, new ListItem("--Select Center  --", "0"));
            }

         
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd=new ProcurementData();
            p.CollectionID = Convert.ToInt32(dpCenter.SelectedItem.Value);
            p.RouteID =Convert.ToInt32(dpRoute.SelectedItem.Value);
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
                GridView1.AllowPaging = false;
                GridView1.DataBind();
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView1.RenderControl(hw);
                string gridHTML = sw.ToString().Replace("\"", "'")
                    .Replace(System.Environment.NewLine, "");
                StringBuilder sb = new StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload = new function(){");
                sb.Append("var printWin = window.open('', '', 'left=0");
                sb.Append(",top=0,width=1000,height=600,status=0');");
                sb.Append("printWin.document.write(\"");
                sb.Append(gridHTML);
                sb.Append("\");");
                sb.Append("printWin.document.close();");
                sb.Append("printWin.focus();");
                sb.Append("printWin.print();");
                sb.Append("printWin.close();};");
                sb.Append("</script>");
                ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
                GridView1.AllowPaging = true;
                GridView1.DataBind();
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

     

       

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}