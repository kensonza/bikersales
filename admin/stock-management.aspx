﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="stock-management.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Biker Sales :: Stock Management</title>

    <!-- Custom fonts for this template-->
    <link href="../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="../css/sb-admin-2.min.css" rel="stylesheet">

    <!-- Bikersales CSS customize template -->
    <link href="../css/bikersales.css" rel="stylesheet">

   <!-- Sweet alert bootstrap -->
   <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" type="text/javascript"></script>
   <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" rel="stylesheet" />

    

    <script>
        var object = { status: false, ele: null };
        function confirmDelete(ev) {
            if (object.status) { return true; };
                swal({
                    title: "Are you sure?",
                    text: "Your will not be able to recover this record!",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonClass: "btn-danger",
                    confirmButtonText: "Yes, delete it!",
                    closeOnConfirm: true
                },
                function () {
                    object.status = true;
                    object.ele = ev;
                    object.ele.click();

                    });
            return false;
        }
    </script>

</head>

<body id="page-top">

        <!-- Page Wrapper -->
        <div id="wrapper">

        <!-- Sidebar -->
            <ul class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion" id="accordionSidebar">

                <!-- Sidebar - Brand -->
                <a class="sidebar-brand d-flex align-items-center justify-content-center" href="index.aspx">
                    <div class="sidebar-brand-icon rotate-n-15">
                        <i class="fa fa-bicycle"></i>
                    </div>
                    <div class="sidebar-brand-text mx-3">Biker Sales</div>
                </a>

                <!-- Divider -->
                <hr class="sidebar-divider my-0">

                <!-- Nav Item - Dashboard -->
                <li class="nav-item">
                    <a class="nav-link" href="index.aspx">
                        <i class="fas fa-fw fa-tachometer-alt"></i>
                        <span>Dashboard</span>
                    </a>
                </li>

                <!-- Divider -->
                <hr class="sidebar-divider">

                <!-- Heading -->
                <div class="sidebar-heading">
                    BS Tools
                </div>

                <!-- Nav Item - Pages Collapse Menu -->
                <!-- <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseTwo"
                        aria-expanded="true" aria-controls="collapseTwo">
                        <i class="fas fa-fw fa-cog"></i>
                        <span>Components</span>
                    </a>
                    <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Custom Components:</h6>
                            <a class="collapse-item" href="buttons.html">Buttons</a>
                            <a class="collapse-item" href="cards.html">Cards</a>
                        </div>
                    </div>
                </li> -->

                <!-- Nav Item - Biker Sales Collapse Menu -->
                <li class="nav-item active">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseUtilities"
                       aria-expanded="true" aria-controls="collapseUtilities">
                        <i class="fa fa-bicycle"></i>
                        <span>Biker Sales</span>
                    </a>
                    <div id="collapseUtilities" class="collapse" aria-labelledby="headingUtilities"
                         data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Bikes</h6>
                            <a class="collapse-item" href="brand.aspx">Brand</a>
                            <a class="collapse-item" href="brand-categories.aspx">Categories</a>
                            <h6 class="collapse-header">Sales</h6>
                            <a class="collapse-item" href="customer.aspx">Customer</a>
                            <a class="collapse-item" href="orders.aspx">Orders</a>
                            <h6 class="collapse-header">Inventory</h6>
                            <a class="collapse-item" href="products.aspx">Products</a>
                            <a class="collapse-item active" href="stock-management.aspx">Stock Management</a>
                            <h6 class="collapse-header">Settings</h6>
                            <a class="collapse-item" href="customer-account.aspx">Customer Account</a>
                            <a class="collapse-item" href="staff-account.aspx">Staff Account</a>
                            <a class="collapse-item" href="stores.aspx">Stores</a>
                        </div>
                        
                    </div>
                </li>

                <!-- Divider -->
                <hr class="sidebar-divider">

                <!-- Heading -->
                <div class="sidebar-heading">
                    BS Reports
                </div>

                <!-- Nav Item - Reports Collapse Menu -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapsePages"
                       aria-expanded="true" aria-controls="collapsePages">
                        <i class="fas fa-fw fa-folder"></i>
                        <span>Reports</span>
                    </a>
                    <div id="collapsePages" class="collapse" aria-labelledby="headingPages" data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Tabular:</h6>
                            <!-- <a class="collapse-item" href="login.html">Login</a> -->
                            <!-- <a class="collapse-item" href="register.html">Register</a> -->
                            <a class="collapse-item" href="blank.html">Blank Page</a>
                            <div class="collapse-divider"></div>
                            <h6 class="collapse-header">Vizual:</h6>
                            <!-- <a class="collapse-item" href="404.html">404 Page</a> -->
                            <a class="collapse-item" href="blank.html">Blank Page</a>
                        </div>
                    </div>
                </li>

                <!-- Divider -->
                <hr class="sidebar-divider">

                <!-- Heading -->
                <div class="sidebar-heading">
                    BS Settings
                </div>

                <!-- Nav Item - Users -->
                <li class="nav-item">
                    <a class="nav-link" href="users.aspx">
                        <i class="fas fa-fw fa fa-users"></i>
                        <span>Users</span>
                    </a>
                </li>
                <!-- Nav Item - Tables -->
                <!-- <li class="nav-item">
                    <a class="nav-link" href="tables.html">
                        <i class="fas fa-fw fa-table"></i>
                        <span>Tables</span></a>
                </li> -->
                <!-- Divider -->
                <hr class="sidebar-divider d-none d-md-block">

                <!-- Sidebar Toggler (Sidebar) -->
                <div class="text-center d-none d-md-inline">
                    <button class="rounded-circle border-0" id="sidebarToggle"></button>
                </div>

            </ul>
            <!-- End of Sidebar -->

            <!-- Content Wrapper -->
            <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">

                <!-- Topbar -->
                <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">

                    <!-- Sidebar Toggle (Topbar) -->
                    <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
                        <i class="fa fa-bars"></i>
                    </button>

                    <!-- Topbar Navbar -->
                    <ul class="navbar-nav ml-auto">

                        <!-- Nav Item - (Mobile) User Information Dropdown (Visible Only XS) -->
                        <li class="nav-item dropdown no-arrow d-sm-none">
                            <a class="nav-link dropdown-toggle" href="#" id="searchDropdown" role="button"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <i class="fas fa fa-ellipsis-v"></i>
                            </a>
                            <!-- Dropdown - (Mobile) User Information -->
                            <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in"
                                aria-labelledby="userDropdown">
                                <a class="dropdown-item" href="profile.aspx">
                                    <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Profile
                                </a>
                                
                                <div class="dropdown-divider"></div>
                                
                                <a class="dropdown-item" href="#" data-toggle="modal" data-target="#logoutModal">
                                    <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Logout
                                </a>
                            </div>
                        </li>

                       <div class="topbar-divider d-none d-sm-block"></div>

                        <!-- Nav Item - User Information -->
                        <li class="nav-item dropdown no-arrow">
                            <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="mr-2 d-none d-lg-inline text-gray-600 small"><b><asp:Label ID="getSession" runat="server" Text="<%= User %>"></asp:Label></b></</span>
                                <!-- <img class="img-profile rounded-circle" src="img/undraw_profile.svg"> -->
                            </a>
                            <!-- Dropdown - User Information -->
                            <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in"
                                aria-labelledby="userDropdown">
                                <a class="dropdown-item" href="profile.aspx">
                                    <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Profile
                                </a>
                                
                                <div class="dropdown-divider"></div>
                                
                                <a class="dropdown-item" href="#" data-toggle="modal" data-target="#logoutModal">
                                    <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Logout
                                </a>
                            </div>
                        </li>

                    </ul>

                </nav>
                <!-- End of Topbar -->

                <!-- Begin Page Content -->
                <div class="container-fluid">

                <form id="form1" runat="server">
                
        
                <!-- Page Heading -->
                <div class="d-sm-flex align-items-center justify-content-between mb-4 dropdown">
                    <h1 class="h3 mb-0 text-gray-800"><span class="fa fa-bicycle">&nbsp;</span>Stock Management</h1>
                    <button class="btn btn-sm btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" title="Options">
                        <span class="fa fa-cogs"></span>
                     </button>
                     <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <!-- <a class="dropdown-item" href="#" data-toggle="modal" data-target="#exampleModalCP" title="Export to CSV">CSV</a> -->
                        <!-- <a class="dropdown-item" href="#" data-toggle="modal" data-target="#exampleModalCP" title="Export to Excel">Excel</a> -->
                        <!-- <a class="dropdown-item" href="#" data-toggle="modal" data-target="#exampleModalCP" title="Export to PDF">PDF</a> -->
                        <asp:Button ID="BtnExcel" runat="server" class="dropdown-item" data-toggle="modal" data-target="#exampleModalCP" title="Export" Text="Export" />
                     </div>
                </div>
                
                <!-- Content Row -->
                <div class="row">

                     <!-- Total Products Card -->
                     <div class="col-xl-3 col-md-6 mb-4">
                        <div class="card border-left-primary shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">
                                            Total Products
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800"><asp:Label ID="totalProducts" runat="server"></asp:Label></div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fa fa-bicycle fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                         </div>
                      </div>

                     <!-- Low Stock Products Card -->
                     <div class="col-xl-3 col-md-6 mb-4">
                        <div class="card border-left-warning shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                            Low Stock Products
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800"><asp:Label ID="lowstockProd" runat="server"></asp:Label></div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-box-open fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                     </div>                
                
                     <!-- Out of Stock Products Card -->
                     <div class="col-xl-3 col-md-6 mb-4">
                        <div class="card border-left-danger shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                            Out of Stock Products
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800"><asp:Label ID="outofstockProd" runat="server"></asp:Label></div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-box-open fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                     </div>

                    <!-- Restock Products Card -->
                     <div class="col-xl-3 col-md-6 mb-4">
                        <div class="card border-left-success shadow h-100 py-2">
                            <div class="card-body">
                                <div class="row no-gutters align-items-center">
                                    <div class="col mr-2">
                                        <div class="text-xs font-weight-bold text-success text-uppercase mb-1">
                                            Restock Products
                                        </div>
                                        <div class="h5 mb-0 font-weight-bold text-gray-800">0</div>
                                    </div>
                                    <div class="col-auto">
                                        <i class="fas fa-box-open fa-2x text-gray-300"></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                     </div>   
                
                </div>

                <!-- Recent Stats Alert -->
                <div class="alert alert-danger" role="alert">
                    Recent Stats
                </div>              

                <!-- Recent Stats Navigation -->
                <section>
                    <ul class="nav nav-tabs" id="myTab" role="tablist">
                        <li class="nav-item waves-effect waves-light">
                            <a class="nav-link active" id="new-tab" data-toggle="tab" href="#new" role="tab" aria-controls="new" aria-selected="true">Best Seller</a>
                        </li>
                
                        <li class="nav-item waves-effect waves-light">
                            <a class="nav-link" id="pending-tab" data-toggle="tab" href="#pending" role="tab" aria-controls="pending" aria-selected="false">Recent P.O</a>
                        </li>
                
                        <li class="nav-item waves-effect waves-light">
                            <a class="nav-link" id="cancel-tab" data-toggle="tab" href="#cancel" role="tab" aria-controls="cancel" aria-selected="false">New Products</a>
                        </li>

                        <li class="nav-item waves-effect waves-light">
                            <a class="nav-link" id="delivered-tab" data-toggle="tab" href="#delivered" role="tab" aria-controls="delivered" aria-selected="false">Stock Updates</a>
                        </li>
                     </ul>
            
                     <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade active show" id="new" role="tabpanel" aria-labelledby="new-tab">
                        <br />

                            <!-- table grid views (New Order) -->
                            <div class="table-responsive">
                                <asp:GridView ID="GVBSeller" Width="100%" CssClass="table table-striped table-bordered table-hover" runat="server" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataKeyNames="prod_id" AllowPaging="True" OnPageIndexChanging="GVBSeller_PageIndexChanging" ShowFooter="True" FooterStyle-BackColor="White">
                                    <Columns>
                        
                                        <asp:BoundField DataField="prod_id" HeaderText="Product ID" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                            <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                            <ItemStyle CssClass="visible-xs"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="sku" HeaderText="SKU" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                            <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                            <ItemStyle CssClass="visible-md"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="prod_name" HeaderText="Product Name" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                            <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                            <ItemStyle CssClass="visible-lg"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="model_year" HeaderText="Model Year" HeaderStyle-CssClass="visible-xs" ItemStyle-CssClass="visible-xs">
                                            <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                            <ItemStyle CssClass="visible-xs"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="quantity" HeaderText="Quantity" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md">
                                            <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                            <ItemStyle CssClass="visible-md"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="price" HeaderText="Sales" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                            <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                            <ItemStyle CssClass="visible-lg"></ItemStyle>
                                        </asp:BoundField>

                                    </Columns>

                                <FooterStyle BackColor="White"></FooterStyle>

                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
                        </asp:GridView>
                        </div>

                        </div>
                
                        <div class="tab-pane fade" id="pending" role="tabpanel" aria-labelledby="pending-tab">
                        <br />

                            <!-- table grid views (Pending Order) -->
                            <h1>TEST 2</h1>

                        </div>

                        <div class="tab-pane fade" id="cancel" role="tabpanel" aria-labelledby="cancel-tab">
                        <br />

                            <!-- table grid views (Pending Order) -->
                            <h1>TEST 3</h1>

                         </div>

                         <div class="tab-pane fade" id="delivered" role="tabpanel" aria-labelledby="delivered-tab">
                         <br />

                            <!-- table grid views (Delivered Order) -->
                            <h1>TEST 4</h1>

                          </div>
                      </div>
      
                </section>
                
                        
                        

                    


















                

                </div>
                <!-- /.container-fluid -->

            </div>
            <!-- End of Main Content -->

            <!-- Footer -->
            <footer class="sticky-footer bg-white">
                <div class="container my-auto">
                    <div class="copyright text-center my-auto">
                        <span>Copyright &copy; Biker Sales 2020</span>
                    </div>
                </div>
            </footer>
            <!-- End of Footer -->

            </div>
            <!-- End of Content Wrapper -->

    </div>
    <!-- End of Page Wrapper -->

    <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
        <i class="fas fa-angle-up"></i>
    </a>

    <!-- Logout Modal-->
    <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel2"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Ready to Leave?</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <asp:Button ID="btnLogout" class="btn btn-primary" runat="server" Text="Logout" OnClick="btnLogout_Click" />
                </div>
            </div>
        </div>
    </div>

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