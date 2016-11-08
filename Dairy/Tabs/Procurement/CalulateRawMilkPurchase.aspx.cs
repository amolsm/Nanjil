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

            //DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            //if (!Comman.Comman.IsDataSetEmpty(DS))
            //{
            //    dpCenter.DataSource = DS;
            //    dpCenter.DataBind();
            //    dpCenter.Items.Insert(0, new ListItem("--Select Center  --", "0"));
            //}


        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.CollectionID = 6;//Convert.ToInt32(dpCenter.SelectedItem.Value);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtFromDate.Text);
            p.ToDate = Convert.ToDateTime(txtToDate.Text);
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString();
            int Result = 0;
            DataSet DS1 = new DataSet();
            DS1 = pd.CalculateBill(p);

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





        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();
            p.CollectionID = 6;//Convert.ToInt32(dpCenter.SelectedItem.Value);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtFromDate.Text);
            p.ToDate = Convert.ToDateTime(txtToDate.Text);
            p.ModifiedBy = App_code.GlobalInfo.Userid;
            p.ModifiedDate = DateTime.Now.ToString();

            DataSet DS1 = new DataSet();
            DS1 = pd.CalculateBill(p);

            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS1))
            {
                StringBuilder sb = new StringBuilder();


                sb.Append("<style type='text / css'>");
                sb.Append(".tg  { border - collapse:collapse; border - spacing:0; border: none; } .dispnone {display:none;} ");
                sb.Append("</style>");
                sb.Append("<table class='tg style1' style='page-break-inside:avoid; align:center;'>");
                sb.Append("<colgroup>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("<col style = 'width:100px'>");
                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='8' style='text-align:center'>");
                sb.Append("<u>Raw Milk Purchase Report </u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='8' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='3' style='text-align:left'>");
                sb.Append("Date : " + DateTime.Now.ToString());
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<td colspan='2'>");
                sb.Append(App_code.GlobalInfo.UserName);
                sb.Append("</td>");
                sb.Append("<td colspan='3'>");
                sb.Append(dpRoute.SelectedItem.Text.ToString());
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append(Convert.ToDateTime(txtFromDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td>");
                sb.Append("<b>Date</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Session</b>");
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append("<b>Supplier</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>MilkInLtr</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Fat Perc.</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>SNF Perc.</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>TS Perc.</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>RPL</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");

                sb.Append("</tr>");
               
                double milkinltr = 0.00;
                double totalmilkinltr = 0.00;
                double fatinper = 0.00;
                double totalfatinper = 0.00;
                double snf = 0.00;
                double totalsnf = 0.00;
                double ts = 0.00;
                double totalts = 0.00;
                double rpl = 0.00;
                double totalrpl = 0.00;
                double amt = 0.00;
                double totalamt = 0.00;
                sb.Append("<tr>");
                foreach (DataRow row in DS1.Tables[0].Rows)
                {

                    sb.Append("<td>");
                    sb.Append(Convert.ToDateTime(row["_Date"]).ToString("dd-MM-yyyy"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["_Session"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td colspan='2'>");
                    sb.Append(row["Supplier"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    milkinltr = Convert.ToDouble(row["MilkInLtr"]);
                    totalmilkinltr += milkinltr;
                    sb.Append(row["MilkInLtr"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    fatinper= Convert.ToDouble(row["FATPercentage"]);
                    totalfatinper += fatinper;
                    sb.Append(row["FATPercentage"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    snf = Convert.ToDouble(row["SNFPercentage"]);
                    totalsnf += snf;
                    sb.Append(row["SNFPercentage"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    ts = Convert.ToDouble(row["TSPercentage"]);
                    totalts += ts;
                    sb.Append(row["TSPercentage"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    rpl = Convert.ToDouble(row["RPL"]);
                    totalrpl += rpl;
                    sb.Append(row["RPL"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    amt= Convert.ToDouble(row["Amount"]);
                    totalamt += amt;
                    sb.Append(row["Amount"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                sb.Append("<tr style='border-bottom:1px solid'><td colspan='10'></td></tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='4'>");
                sb.Append("<b>Total</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(totalmilkinltr);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(totalfatinper);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(totalsnf);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(totalts);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(totalrpl);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(totalamt);
                sb.Append("</td>");
                sb.Append("</tr>");
                result = sb.ToString();
                RequestDetails.Text = result;

                Session["ctrl"] = pnlRequestDetails;

            }
            else
            {
                result = "No Records Found";
                RequestDetails.Text = result;

            }
        
         
            upModal.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
           
        }
    }
}