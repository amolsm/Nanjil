<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSupplierRDInfo.aspx.cs" Inherits="Dairy.Tabs.Procurement.AddSupplierRDInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">

        $(function () {
            $("#MainContent_txtRDStartDate").datepicker({ format: 'dd-MM-yyyy' });
            $("#MainContent_txtRDMaturityDate").datepicker({ format: 'dd-MM-yyyy' });
            $("#MainContent_txtRDAmountDate").datepicker({ format: 'dd-MM-yyyy' });
            $("#MainContent_txtRDPaymentDate").datepicker({ format: 'dd-MM-yyyy' });

        })
    </script>
     <script type="text/javascript">
         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
         function InIEvent() {

             $(function () {
                 $("#example1").DataTable();
                 $('#example2').DataTable({
                     "paging": true,
                     "lengthChange": false,
                     "searching": false,
                     "ordering": true,
                     "info": true,
                     "autoWidth": false
                 });
             });
         }
    </script>
    <section class="content-header">
          <h1>
             Supplier RD Information
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add Supplier RD Information"></asp:Label> </li>
          </ol>
    </section>
     <section class="content">
                <div class="row">
                <asp:UpdatePanel runat="server" ID="pnlError" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="col-md-12">
                            <div class="alert alert-danger alert-dismissable" runat="server" id="divDanger" visible="false">


                                <h4>
                                    <i class="icon fa fa-ban"></i>Alert!</h4>
                                <asp:Label runat="server" ID="lbldanger" Text="Something went worng please try Again"></asp:Label>
                            </div>
                            <div class="alert alert-warning alert-dismissable" runat="server" id="divwarning"
                                visible="false">
                                <h4>
                                    <i class="icon fa fa-warning"></i>Warning!</h4>
                                <asp:Label runat="server" ID="lblwarning" Text="Something Went wrong Please Try Again"></asp:Label>
                            </div>
                            <div class="alert alert-success alert-dismissable" runat="server" id="divSusccess"
                                visible="false">
                                <h4>
                                    <i class="icon fa fa-check"></i>Success!</h4>
                                <asp:Label runat="server" ID="lblSuccess" Text="Records Insert Succesfully"></asp:Label>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
          <!-- Default box -->
              <div class="box <%--collapsed-box--%>">
            <div class="box-header with-border">
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Supplier RD Information"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Supplier Advance Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList ID="dpSupplier" class="form-control" DataTextField="Name" DataValueField="SupplierID" runat="server" selected ToolTip="Select supplier"> 
                       </asp:DropDownList>                               
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
           
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtRDStartDate" class="form-control" placeholder="RD Start Date" runat="server" required ToolTip="RD Start Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtRDMaturityDate" class="form-control" placeholder="RD Maturity Date" type="text" runat="server" required ToolTip="RD Maturity Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtRDAmount" class="form-control" placeholder="RD Amount" runat="server" required ToolTip="RD AMount"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
       

            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtRDAmountDate" class="form-control" placeholder="RD Amount Date" runat="server" required ToolTip="RD Amount Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>                        
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">

                           <asp:ListItem>---Select RD Status---</asp:ListItem>
                           <asp:ListItem>Complete</asp:ListItem>
                           <asp:ListItem>Incomplete</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>   
   <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtRDPaymentDate" class="form-control" placeholder="RD Payment Date" type="text" runat="server" required ToolTip="RD Payment Date"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bank"></i><span style="color:red">&nbsp;*</span>
                      </div>
                    <asp:DropDownList  ID="dpBankName" ToolTip="Select Bank Name" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList> </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>    
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAccountName" class="form-control" placeholder="Account Name" ToolTip="Account Name" runat="server" required type="text"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAccountNo" class="form-control" placeholder="Account No" ToolTip="Account No" runat="server" required type="text"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-4">

             

                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-bars"></i><span style="color:red">&nbsp;*</span>
                      </div>
                     <asp:DropDownList  ID="dpIfscCode" ToolTip="Select IFSC Code" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                      </div>
            
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBranchName" class="form-control" placeholder="Branch Name" runat="server" required ToolTip="Branch Name"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            <div class="col-lg-4 pull-right">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddRDInfo" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnAddRDInfo_Click"  Text="Add" ValidationGroup="Save" />     
                        <asp:Button ID="btnupdateRDInfo" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnupdateRDInfo_Click" Text="Update" ValidationGroup="Save" />           
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            
           
        </div><!-- /.box-body -->
      </div>
               
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                 
                
            </div><!-- /.box-body -->            
          </div><!-- /.box -->

         <div class="box ">
            <div class="box-header with-border">
              <h3 class="box-title"> RD List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpRDInfo" runat="server" OnItemCommand="rpRDInfo_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>SupplierID</th>
                        <th>RD Start Date</th>
                        <th>RD Maturity Date</th> 
                        <th> RD Amount</th>
                          <th>RD Amount Date</th>
                            <th>RD STatus</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("SupplierID")%></td>
                      <td><%# Eval("RDStartDate")%></td>
                      <td><%# Eval("RDMaturityDate")%></td>
                      <td><%# string.Format("{0:n2}",Eval("RDAmount"))%></td>
                     
                      <td><%# Eval("RDAmountDate")%></td>
                   <td><%# Eval("RDStatus")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("RDID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("RDID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                             <th>SupplierID</th>
                        <th>RD Start Date</th>
                        <th>RD Maturity Date</th> 
                        <th> RD Amount</th>
                          <th>RD Amount Date</th>
                            <th>RD STatus</th>
                       
                       
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfRDID" runat="server" />
             
                
                  
                     
                   
                  </table>
               
                
                        </ContentTemplate>
                </asp:UpdatePanel>
  


            </div><!-- /.box-body --> 
                       <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="uprouteList">
            <ProgressTemplate>
                
                <div class="overlay">
                  <i class="fa fa-refresh fa-spin"></i>
                </div>

            </ProgressTemplate>
            </asp:UpdateProgress>           
          </div>
        </section>
</asp:Content>
