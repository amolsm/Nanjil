<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VehicleTariff.aspx.cs" Inherits="Dairy.Tabs.Procurement.VehicleTeriff" %>
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
             Vehicle Tariff
            <small>Procurement</small>
          </h1>
          <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i> Procurement</a></li>
            <li class="active"> <asp:Label runat="server" ID="lblHeaderTab" Text="Vehicle Tariff"></asp:Label> </li>
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
              <h3 class="box-title"><asp:Label ID="lblTabName" runat="server" Text="Vehicle Tariff"></asp:Label> </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-plus"></i></button>
                
              </div>
            </div>
            <div class="box-body">
               
              
                      <asp:UpdatePanel runat="server" ID="upMain" UpdateMode="Conditional">
                    <ContentTemplate>           

        <div class="box box-solid box-default" style="margin-bottom:5px !important;" >
        <div class="box-header" style="padding:0px 0px 0px 10px !important">
          <h3 class="box-title">Vehicle Tariff </h3>
        </div><!-- /.box-header -->
        <div class="box-body">
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtSrNo" class="form-control" placeholder="TariffID" runat="server" required ></asp:TextBox>                        
                    </div><!-- /.input group -->

                  </div><!-- /.form group --> 
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa fa-road "></i><span style="color:red">&nbsp;*</span>
                      </div>
                        <asp:DropDownList ID="dpVehicleType" class="form-control" DataTextField="VehicleName" DataValueField="VahicleID" ToolTip="Select Vehicle Model" runat="server" selected> 
                       </asp:DropDownList>                       
                    </div><!-- /.input group -->

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txtBata" class="form-control" placeholder="Bata" runat="server" required ToolTip="Bata"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
                  


                        <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                      <span style="color:red">&nbsp;*</span>
                      </div>        
                     <asp:TextBox ID="txtLess100" class="form-control" placeholder="KM<100" runat="server" required ToolTip="KM<100"></asp:TextBox>                        

                  </div><!-- /.form group -->

                     
                       
                          
                      </div> 
                            </div>
             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                        <i class="fa  fa-code "></i></i><span style="color:red">&nbsp;*</span>
                      </div>
                       <asp:TextBox ID="txt100To200" class="form-control" placeholder="100To200" runat="server" required ToolTip="100To200"></asp:TextBox>                        
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->                   
                  </div>  
           

             <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txt201To250" class="form-control" placeholder="201To250" runat="server" required ToolTip="201To250"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txt251To300" class="form-control" placeholder="251To300" runat="server" required ToolTip="251To300"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>     
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtKMGreater300" class="form-control" placeholder="KM>300" runat="server" required ToolTip="KM>300"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>
            <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      <div class="input-group-addon">
                       <span style="color:red">&nbsp;*</span>
                      </div>
                      <asp:TextBox ID="txtDesc" class="form-control" placeholder="Description" runat="server" ToolTip="Description" TextMode="MultiLine"></asp:TextBox>                        
                         
                    </div><!-- /.input group -->
                  </div><!-- /.form group -->

                     
                       
                          
                      </div>         
                   <div class="col-lg-4">
                  <div class="form-group">
                    <div class="input-group">
                      
                    
                      
                              <asp:Button ID="btnAddVeh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Add" ValidationGroup="Save" OnClick="btnAddVeh_Click" />     
                        <asp:Button ID="btnupdateVeh" class="btn btn-primary" runat="server" CommandName="MoveNext"    Text="Update" ValidationGroup="Save" OnClick="btnupdateVeh_Click" />           
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
              <h3 class="box-title"> Vehical List </h3>
              <div class="box-tools pull-right">
                <button class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse"><i class="fa fa-minus"></i></button>
                
              </div>
            </div>
            <div class="box-body" id="datalist">
                   
                
                       

                                <asp:UpdatePanel runat="server" ID="uprouteList" UpdateMode="Conditional">
                    <ContentTemplate>

                <table id="example1" class="table table-bordered table-striped">
                   

                 

                <asp:Repeater ID="rpVehicleMaster" runat="server" OnItemCommand="rpVehicleMaster_ItemCommand">
                
               <HeaderTemplate>
                  <thead>
                      <tr>
                          <th>Tariff ID</th>
                        <th>Vehicle Model</th>
                        <th>Bata</th>
                        <th>KM<100</th>
                        <th>101To200</th>
                        <th>201To250</th>
                          <th>251To300</th>
                          <th>KM>300</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </thead>
                    <tbody>

                   
               </HeaderTemplate>
               <ItemTemplate>
                    <tr>
                         <td><%# Eval("SrNo")%></td>
                      <td><%# Eval("VehicleType")%></td>
                      <td><%# Eval("Bata")%></td>
                      <td><%# Eval("KMLessThan100")%></td>
                        <td><%# Eval("[101To200]") %></td>
                        <td><%# Eval("[201To250]") %></td>
                        <td><%# Eval("[251To300]") %></td>
                      <td><%# Eval("KMGreaterThan300") %></td>
                         <td>

                             <asp:LinkButton ID="lbEdite" AlternateText="Edit" ForeColor="Gray" OnItemCommand="lbEdite_ItemCommand" 
                                                                    ToolTip="Edit" runat="server" CommandArgument='<%#Eval("VahicleID") %>'
                                                                    CommandName="Edit"><i class="fa fa-edit"></i></asp:LinkButton>

                         </td>
                         <td>   <asp:LinkButton ID="lbdelete" AlternateText="delete" ForeColor="Gray" OnItemCommand="lbdelete_ItemCommand" 
                                                                    ToolTip="Delete" runat="server" CommandArgument='<%#Eval("VahicleID") %>'
                                                                    CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
</td>
                    </tr>
               </ItemTemplate>
                    <FooterTemplate>

                         </tbody>

                    <tfoot>
                      <tr>
                          <th>Tariff ID</th>
                          <th>Vehicle Model</th>
                        <th>Bata</th>
                        <th>KM<100</th>
                        <th>101To200</th>
                        <th>201To250</th>
                          <th>251To300</th>
                          <th>KM>300</th>
                           <th>Edit</th>
                          <th>Delete</th>
                      </tr>
                    </tfoot>

                    </FooterTemplate>
                                             
           </asp:Repeater>
                    <asp:HiddenField id="hfrouteID" runat="server" />
             
                
                  
                     
                   
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

