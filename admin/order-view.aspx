<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order-view.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Biker Sales :: View Orders</title>

    <!-- Custom fonts for this template-->
    <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="../css/sb-admin-2.min.css" rel="stylesheet">

    <!-- Sweet alert bootstrap -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" type="text/javascript"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" rel="stylesheet" />

</head>
<body class="d-flex flex-column h-100">
<form id="form1" runat="server">
    <!-- Begin page content -->
    <main role="main" class="flex-shrink-0">
        <div class="container">
            <h1 class="mt-5"><span class="fas fa-shopping-cart">&nbsp;</span>Orders</h1>

            <hr />

            <fieldset>
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Order Number</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtOrdNum" class="form-control-plaintext" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                </div>
                
                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Customer Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtCustName" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                </div>

                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Address</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtAddress" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                </div>

                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Contact Number</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtPhone" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                </div>

                <div class="form-group row">
                    <label class="col-sm-2 col-form-label">Email</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                </div>
            </fieldset>

        <!-- Status Navigation -->
        <section>
            <ul class="nav nav-tabs" id="myTab" role="tablist">
                <li class="nav-item waves-effect waves-light">
                    <a class="nav-link active" id="new-tab" data-toggle="tab" href="#new" role="tab" aria-controls="new" aria-selected="true">New <asp:Label ID="countNew" CssClass="badge bg-light text-dark" runat="server"></asp:Label></a>
                </li>
                
                <li class="nav-item waves-effect waves-light">
                    <a class="nav-link" id="pending-tab" data-toggle="tab" href="#pending" role="tab" aria-controls="pending" aria-selected="false">Pending <asp:Label ID="countPending" CssClass="badge bg-light text-dark" runat="server"></asp:Label></a>
                </li>
                
                <li class="nav-item waves-effect waves-light">
                    <a class="nav-link" id="cancel-tab" data-toggle="tab" href="#cancel" role="tab" aria-controls="cancel" aria-selected="false">Cancelled <asp:Label ID="countCancelled" CssClass="badge bg-light text-dark" runat="server"></asp:Label></a>
                </li>

                <li class="nav-item waves-effect waves-light">
                    <a class="nav-link" id="delivered-tab" data-toggle="tab" href="#delivered" role="tab" aria-controls="delivered" aria-selected="false">Delivered <asp:Label ID="countDelivered" CssClass="badge bg-light text-dark" runat="server"></asp:Label></a>
                </li>
            </ul>
            
            <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade active show" id="new" role="tabpanel" aria-labelledby="new-tab">

                    <br />

                    <!-- table grid views (New Order) -->
                    <div class="table-responsive">
                        <asp:GridView ID="GVOrdNew" Width="100%" CssClass="table table-striped table-bordered table-hover" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataKeyNames="order_id" AllowPaging="True" OnPageIndexChanging="GVNewOrders_PageIndexChanging" ShowFooter="True" FooterStyle-BackColor="White">
                            <Columns>
                        
                                <asp:BoundField DataField="category" HeaderText="Category" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="brand" HeaderText="Brand" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="model" HeaderText="Model" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="price" HeaderText="Price" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="quantity" HeaderText="Quantity" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="total_price" HeaderText="Total Price" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="order_status" HeaderText="Status" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>
                                    
                                <asp:BoundField DataField="order_date" HeaderText="Order Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-md" HeaderStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="approved_date" HeaderText="Approved Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="shipping_date" HeaderText="Shipping Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
                        </asp:GridView>
                    </div>

                </div>
                
                <div class="tab-pane fade" id="pending" role="tabpanel" aria-labelledby="pending-tab">

                    <br />

                    <!-- table grid views (Pending Order) -->
                    <div class="table-responsive">
                        <asp:GridView ID="GVOrdPending" Width="100%" CssClass="table table-striped table-bordered table-hover" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataKeyNames="order_id" AllowPaging="True" OnPageIndexChanging="GVPendingOrders_PageIndexChanging" ShowFooter="True" FooterStyle-BackColor="White">
                            <Columns>
                        
                                <asp:BoundField DataField="category" HeaderText="Category" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="brand" HeaderText="Brand" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="model" HeaderText="Model" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="price" HeaderText="Price" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="quantity" HeaderText="Quantity" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="total_price" HeaderText="Total Price" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="order_status" HeaderText="Status" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>
                                    
                                <asp:BoundField DataField="order_date" HeaderText="Order Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-md" HeaderStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="approved_date" HeaderText="Approved Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="shipping_date" HeaderText="Shipping Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
                        </asp:GridView>
                    </div>

                </div>

                <div class="tab-pane fade" id="cancel" role="tabpanel" aria-labelledby="cancel-tab">

                    <br />

                    <!-- table grid views (Pending Order) -->
                    <div class="table-responsive">
                        <asp:GridView ID="GVOrdCancelled" Width="100%" CssClass="table table-striped table-bordered table-hover" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataKeyNames="order_id" AllowPaging="True" OnPageIndexChanging="GVCancelledOrders_PageIndexChanging" ShowFooter="True" FooterStyle-BackColor="White">
                            <Columns>
                        
                                <asp:BoundField DataField="category" HeaderText="Category" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="brand" HeaderText="Brand" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="model" HeaderText="Model" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="price" HeaderText="Price" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="quantity" HeaderText="Quantity" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="total_price" HeaderText="Total Price" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="order_status" HeaderText="Status" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>
                                    
                                <asp:BoundField DataField="order_date" HeaderText="Order Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-md" HeaderStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="approved_date" HeaderText="Approved Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="shipping_date" HeaderText="Shipping Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
                        </asp:GridView>
                    </div>

                </div>

                <div class="tab-pane fade" id="delivered" role="tabpanel" aria-labelledby="delivered-tab">

                    <br />

                    <!-- table grid views (Delivered Order) -->
                    <div class="table-responsive">
                        <asp:GridView ID="GVOrdersDel" Width="100%" CssClass="table table-striped table-bordered table-hover" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataKeyNames="order_id" AllowPaging="True" OnPageIndexChanging="GVOrdersDel_PageIndexChanging" ShowFooter="True" FooterStyle-BackColor="White">
                            <Columns>
                        
                                <asp:BoundField DataField="category" HeaderText="Category" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="brand" HeaderText="Brand" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="model" HeaderText="Model" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="price" HeaderText="Price" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="quantity" HeaderText="Quantity" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="total_price" HeaderText="Total Price" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="order_status" HeaderText="Status" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>
                                    
                                <asp:BoundField DataField="order_date" HeaderText="Order Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-md" HeaderStyle-CssClass="visible-md">
                                    <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                    <ItemStyle CssClass="visible-md"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="approved_date" HeaderText="Approved Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg">
                                    <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                    <ItemStyle CssClass="visible-lg"></ItemStyle>
                                </asp:BoundField>

                                <asp:BoundField DataField="shipping_date" HeaderText="Shipping Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                    <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                    <ItemStyle CssClass="visible-xs"></ItemStyle>
                                </asp:BoundField>

                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
                        </asp:GridView>
                    </div>

                </div>
            </div>
      
        </section>
        
       <br />
        
       </div>
    </main>

</form>

    <!-- Bootstrap core JavaScript-->
    <script src="../vendor/jquery/jquery.min.js"></script>
    <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="../js/sb-admin-2.min.js"></script>

    <!-- Page level plugins -->
    <script src="../vendor/chart.js/Chart.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="../js/demo/chart-area-demo.js"></script>
    <script src="../js/demo/chart-pie-demo.js"></script>

</body>
</html>