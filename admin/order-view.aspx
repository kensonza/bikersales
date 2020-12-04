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
        
        <!-- table grid views -->
        <div class="table-responsive">
            <asp:GridView ID="GVOrders" Width="100%" CssClass="table table-striped table-bordered table-hover" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataKeyNames="order_id" AllowPaging="True" OnPageIndexChanging="GVOrders_PageIndexChanging">
                <Columns>
                        
                    <asp:BoundField DataField="category" HeaderText="Category" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                        <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="brand" HeaderText="Brand" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                        <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="model" HeaderText="Model" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                        <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="price" HeaderText="Price" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                        <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="total_price" HeaderText="Total Price" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                        <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField="order_status" HeaderText="Status" ItemStyle-CssClass="visible-md" HeaderStyle-CssClass="visible-md">
                        <HeaderStyle CssClass="visible-md"></HeaderStyle>
                        <ItemStyle CssClass="visible-md"></ItemStyle>
                    </asp:BoundField>
                                    
                    <asp:BoundField DataField="order_date" HeaderText="Order Date" DataFormatString="{0:MM/dd/yyyy}" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg">
                        <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                        <ItemStyle CssClass="visible-lg"></ItemStyle>
                    </asp:BoundField>

                </Columns>
                <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
            </asp:GridView>
        </div>
                    
        </div>
    </main>

</form>
    
    <!-- Footer -->
    <footer class="sticky-footer bg-white">
        <div class="container my-auto">
            <div class="copyright text-center my-auto">
                <span>Copyright &copy; Biker Sales 2020</span>
            </div>
        </div>
    </footer>
    <!-- End of Footer -->
</body>
</html>