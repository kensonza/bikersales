<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit-products.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Biker Sales :: Product</title>

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
            <h1 class="mt-5"><span class="fa fa-bicycle">&nbsp;</span>Edit Brand</h1>

            <fieldset>
                <div class="form-group">
                    <label>SKU</label>
                    <asp:TextBox ID="txtSKU" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Product Name</label>
                    <asp:TextBox ID="txtProdName" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Product Name</label>
                    <asp:DropDownList ID="DDLCategory" class="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label>Product Name</label>
                    <asp:DropDownList ID="DDLBrand" class="form-control" runat="server">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label>Model Year</label>
                    <asp:TextBox ID="txtModelYear" class="form-control datepicker" runat="server"></asp:TextBox>
                </div>
                
                <label>Image</label>
                <div class="form-group">
                    <asp:FileUpload ID="FileUploadImageProduct" runat="server" />
                </div>

                <div class="form-group">
                    <label>Price</label>
                    <asp:TextBox ID="txtPrice" class="form-control" runat="server"></asp:TextBox>
                </div>
                
                <asp:Button ID="btnEditProductCancel" CssClass="btn btn-info" runat="server" Text="Cancel" OnClick="btnEditProductCancel_Click" /> <asp:Button ID="btnEditProductSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnEditProductSave_Click"/>
            </fieldset>
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

     
    <!-- Datepicker Year Only -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" rel="stylesheet"/>
    
    <script>
        $(".datepicker").datepicker({
            format: " yyyy",
            viewMode: "years",
            minViewMode: "years"
        });
    </script>
    
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