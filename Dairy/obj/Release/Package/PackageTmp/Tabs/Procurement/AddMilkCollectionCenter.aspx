<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMilkCollectionCenter.aspx.cs" Inherits="Dairy.Tabs.Procurement.AddMilkCollectionCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
             Milk Collection Center
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Add Milk Collection Center"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Add Milk Collection Center"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Milk Collection Center Information </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCenterCode" class="form-control" placeholder="Center Code" runat="server" required ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtCenterName" class="form-control" placeholder="Center Name" runat="server" required ToolTip="Center Name"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <%-- <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <i class="fa fa-rode"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList ID="dpRoute" class="form-control" DataTextField="Name" DataValueField="RouteID" runat="server" selected ToolTip="Select Route"> 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  --%>
       

            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress1" class="form-control" placeholder="Address 1" runat="server" required></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->
                

                     
                       
                          
                      </div>                        
                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress2" class="form-control" placeholder="Address 2" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
  <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-map-marker"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtAddress3" class="form-control" placeholder="Address 3" runat="server"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            
 

              <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-envelope-o"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" runat="server" required AutoCompleteType="Email"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                   </div> 
                        <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtMobile" class="form-control" placeholder="Mobile No" runat="server" required Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>                        
                 <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-phone"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtTelephone" class="form-control" placeholder="Telephone No" runat="server" required Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  


                        <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList  ID="dpCity" ToolTip="Select City" class="form-control" DataTextField="Name"  runat="server" > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                               <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-globe"></i><span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:DropDownList  ID="dpDistrict" ToolTip="Select District" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList></div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                      
                      
                  <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                            <asp:DropDownList  ID="dpState" ToolTip="Select State" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>  
            
                <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                  
                          <asp:DropDownList  ID="dpCountry" ToolTip="Select Country" class="form-control" DataTextField="Name"  runat="server"  > 
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:DropDownList  ID="dpContactPerson"  class="form-control" DataTextField="Name" DataValueField="EmployeeID"  runat="server"  > 
                       </asp:DropDownList>
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>            
            
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        Freezer Available :&nbsp&nbsp
                        <asp:RadioButton ID="rdYes" runat="server" Text="Yes" GroupName="Freezer" OnCheckedChanged="rdYes_CheckedChanged" AutoPostBack="true"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdNo" runat="server" Text="No" GroupName="Freezer" OnCheckedChanged="rdNo_CheckedChanged" AutoPostBack="true"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div id="d1" runat="server">
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        </i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtFreezerModel" class="form-control" placeholder="Freezer Model" runat="server" ToolTip="Freezer Model"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>           
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        </i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtQuantity" class="form-control" placeholder="Freezer Quantity" runat="server" ToolTip="Freezer Quantity"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div>              
              </div>
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBMC" class="form-control" placeholder="BMC" runat="server" required Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtMilkCan" class="form-control" placeholder="Milk Can" runat="server" required Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-mobile"></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSilo" class="form-control" placeholder="Silo" runat="server" required Type="number"></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 

            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        IBT :&nbsp&nbsp
                        <asp:RadioButton ID="rdIBTYes" runat="server" Text="Yes" GroupName="ibt"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdIBTNo" runat="server" Text="No" GroupName="ibt"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        ETP :&nbsp&nbsp
                        <asp:RadioButton ID="rdETPYes" runat="server" Text="Yes" GroupName="etp"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdETPNo" runat="server" Text="No" GroupName="etp"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        LAB :&nbsp&nbsp
                        <asp:RadioButton ID="rdLABYes" runat="server" Text="Yes" GroupName="lab"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdLABNo" runat="server" Text="No" GroupName="lab"></asp:RadioButton>
                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                        Store :&nbsp&nbsp
                        <asp:RadioButton ID="rdStoreYes" runat="server" Text="Yes" GroupName="store"></asp:RadioButton>&nbsp&nbsp&nbsp&nbsp
                        <asp:RadioButton ID="rdStoreNo" runat="server" Text="No" GroupName="store"></asp:RadioButton>
                       
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

                           <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                           <asp:ListItem Value="1">Active</asp:ListItem>
                           <asp:ListItem Value="2">Deactive</asp:ListItem>
                       
                       </asp:DropDownList>
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
            <div class="col-lg-3">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddCollection" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnClick_btnAddCollection"   Text="Add" ValidationGroup="Save" />     
                        <asp:Button ID="btnupdateCollection" class="btn btn-primary" runat="server" CommandName="MoveNext" OnClick="btnClick_btnupdateCollection"   Text="Update" ValidationGroup="Save" />           
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
              <h3 class="box-title">Milk Collection Center List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpCenterList" runat="server" OnItemCommand="rpCenterList_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Center Code</th>
                        <th>Center Name</th>
                        <th>Mobile No </th>
                        <th>Email</th> 
                        <th>Address</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("Centercode")%></td>
                      <td><%# Eval("CenterName")%></td>
                      <td><%# Eval("MobileNo")%></td>
                      <td><%# Eval("Email")%></td>
                     
                      <td><%# Eval("Address1")%></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("CenterID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("CenterID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                           <th>Center Code</th>
                        <th>Center Name</th>
                        <th>Mobile No</th>
                        <th>Email</th>
                       
                        <th>Address</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfcenterID" runat="server" />
             
                
                  
                     
                   
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
          </div><!-- /.box -->
        </section>
</asp:Content>
