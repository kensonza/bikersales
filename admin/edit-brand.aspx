<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit-brand.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Biker Sales :: Edit Brand</title>

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
            <h1 class="mt-5"><span class="fas fa-user-alt">&nbsp;</span>Edit Brand</h1>

            <fieldset>
                <div class="form-group">
                    <label>Brand Name</label>
                    <asp:TextBox ID="txtBrand" class="form-control" runat="server"></asp:TextBox>
                </div>
                
                <label>Image</label>
                <div class="form-group">
                    <asp:FileUpload ID="FileUploadImageBrand" runat="server" />
                </div>
                
                <asp:Button ID="btnEditBrandCancel" CssClass="btn btn-info" runat="server" Text="Cancel" OnClick="btnEditBrandCancel_Click" /> <asp:Button ID="btnEditBrandSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnEditBrandSave_Click" />
            </fieldset>
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