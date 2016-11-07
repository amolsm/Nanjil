using Bussiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dairy.Tabs.Procurement
{
    public partial class ConsolidatePaymentSummary : System.Web.UI.Page
    {
        DataSet DS = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();
            }
        }
        public void BindDropDown()
        {
            DS = BindCommanData.BindCommanDropDwon("CenterID ", "CenterCode +' '+CenterName as Name  ", "tbl_MilkCollectionCenter", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpCenter.DataSource = DS;
                dpCenter.DataBind();
                dpCenter.Items.Insert(0, new ListItem("--All Center  --", "0"));
            }
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 ");
            if (!Comman.Comman.IsDataSetEmpty(DS))
            {
                dpRoute.DataSource = DS;
                dpRoute.DataBind();
                dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));

            }
        }

        protected void btnGeneratereport_Click(object sender, EventArgs e)
        {
            Model.Procurement p = new Model.Procurement();
            ProcurementData pd = new ProcurementData();

            p.CenterID = Convert.ToInt32(dpCenter.SelectedItem.Value);
            p.FomDate = Convert.ToDateTime(txtStartDate.Text);
            p.ToDate = Convert.ToDateTime(txtEndDate.Text);
            p.RouteID = Convert.ToInt32(dpRoute.SelectedItem.Value);
            DataSet DS = new DataSet();
            DS = pd.ConsolidatePayementSummary(p);
            string result = string.Empty;
            if (!Comman.Comman.IsDataSetEmpty(DS))
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

                sb.Append("</colgroup>");

                sb.Append("<tr>");
                sb.Append("<th class='tg-yw4l' rowspan='2'>");
                sb.Append("<img src='/Theme/img/logo1.png' class='img-circle' alt='Logo' width='50px' hight='50px'>");
                sb.Append("</th>");

                sb.Append("<th class='tg-baqh' colspan='7' style='text-align:center'>");
                sb.Append("<u>Consolidate Payment Summary</u> <br/>");
                sb.Append("</th>");

                sb.Append("<th class='tg-yw4l' style='text-align:right'>");

                sb.Append("TIN:330761667331<br>");
                sb.Append("</th>");
                sb.Append("</tr>");

                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td class='tg-yw4l' colspan='7' style='text-align:center'>");
                sb.Append("<b>Nanjil Integrated Dairy Development, Mulagumoodu, K.K.Dt.</b>");

                sb.Append("</td>");

                sb.Append("<td class='tg-yw4l' style='text-align:right'>");

                sb.Append("PH:248370,248605");

                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append(" <td colspan='2' style='text-align:left'>");
                sb.Append("Date : " + DateTime.Now.ToString());
                sb.Append("</td>");

                sb.Append("<td colspan='3'>");
                sb.Append(dpRoute.SelectedItem.Text.ToString());
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append("Date : " + Convert.ToDateTime(txtStartDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("<td colspan='2'>");
                sb.Append("To : " + Convert.ToDateTime(txtEndDate.Text).ToString("dd-MM-yyyy"));
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("<tr style='border-bottom:1px solid'>");
                sb.Append("<td colspan='2' style='text-align:center'>");
                sb.Append("<b>Supplier</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>MilkInLtr</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Amount</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Scheme</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>RD</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Can</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Loan</b>");
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<b>Net Amount</b>");
                sb.Append("</td>");


                sb.Append("</tr>");
                sb.Append("<tr>");
                double milkinlter = 0.00;
                double scheme = 0.00;
                double supplierscheme = 0.00;
                double rd = 0.00;
                double can = 0.00;
                double loan = 0.00;
                double netamt = 0.00;
                double amt = 0.00;
                foreach (DataRow row in DS.Tables[0].Rows)
                {

                    sb.Append("<td>");
                    sb.Append(row["SupplierCode"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append(row["SupplierName"].ToString());
                    sb.Append("</td>");
                    sb.Append("<td>");
                    milkinlter = Convert.ToDouble(row["MilkInLtr"]);
                    sb.Append(Convert.ToDecimal(milkinlter).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    amt = Convert.ToDouble(row["Amount"]);
                    sb.Append(Convert.ToDecimal(amt).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");

                    scheme = Convert.ToDouble(row["Scheme"]);
                    supplierscheme = scheme * milkinlter;
                    sb.Append(Convert.ToDecimal(supplierscheme).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    rd = Convert.ToDouble(row["RDAmt"]);
                    sb.Append(Convert.ToDecimal(rd).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    can = Convert.ToDouble(row["Can"]);
                    sb.Append(Convert.ToDecimal(can).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    loan = Convert.ToDouble(row["LoanPaid"]);
                    sb.Append(Convert.ToDecimal(loan).ToString("0.00"));
                    sb.Append("</td>");
                    sb.Append("<td>");
                    netamt = (amt - (supplierscheme + rd + can + loan));
                    sb.Append(Convert.ToDecimal(netamt).ToString("0.00"));
                    sb.Append("</td>");

                    sb.Append("</tr>");
                }
                result = sb.ToString();
                Payment.Text = result;

                Session["ctrl"] = pnlPayment;

            }
            else
            {
                result = "No Records Found";
                Payment.Text = result;

            }
            uprouteList.Update();

        }

       
           
protected void dpCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpRoute.ClearSelection();
            DS = BindCommanData.BindCommanDropDwon("RouteID ", "RouteCode +' '+RouteName as Name  ", "Proc_MilkCollectionRoute", "IsActive=1 and CenterID=" + dpCenter.SelectedItem.Value);

            dpRoute.DataSource = DS;
            dpRoute.DataBind();
            dpRoute.Items.Insert(0, new ListItem("--Select Route  --", "0"));
        }
    }
    }
