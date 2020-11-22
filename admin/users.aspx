<%@ Page Language="C#" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Biker Sales :: Users</title>

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
                <li class="nav-item active">
                    <a class="nav-link" href="index.aspx">
                        <i class="fas fa-fw fa-tachometer-alt"></i>
                        <span>Dashboard</span>
                    </a>
                </li>

                <!-- Divider -->
                <hr class="sidebar-divider">

                <!-- Heading -->
                <div class="sidebar-heading">
                    Interface
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

                <!-- Nav Item - Settings/Utilities Collapse Menu -->
                <li class="nav-item">
                    <a class="nav-link collapsed" href="#" data-toggle="collapse" data-target="#collapseUtilities"
                       aria-expanded="true" aria-controls="collapseUtilities">
                        <i class="fa fa-bicycle"></i>
                        <span>Biker Sales</span>
                    </a>
                    <div id="collapseUtilities" class="collapse" aria-labelledby="headingUtilities"
                         data-parent="#accordionSidebar">
                        <div class="bg-white py-2 collapse-inner rounded">
                            <h6 class="collapse-header">Customer</h6>
                            <a class="collapse-item" href="blank.html">Blank Page</a>
                            <h6 class="collapse-header">Orders</h6>
                            <a class="collapse-item" href="blank.html">Blank Page</a>
                            <h6 class="collapse-header">Brand</h6>
                            <a class="collapse-item" href="blank.html">Blank Page</a>
                            <h6 class="collapse-header">Inventory</h6>
                            <a class="collapse-item" href="blank.html">Blank Page</a>
                        </div>
                        
                    </div>
                </li>

                <!-- Divider -->
                <hr class="sidebar-divider">

                <!-- Heading -->
                <div class="sidebar-heading">
                    Addons
                </div>

                <!-- Nav Item - Pages Collapse Menu -->
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

                <!-- Nav Item - Charts -->
                <!-- <li class="nav-item">
                    <a class="nav-link" href="charts.html">
                        <i class="fas fa-fw fa-chart-area"></i>
                        <span>Charts</span></a>
                </li> -->
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
                                <a class="dropdown-item" href="settings.aspx">
                                    <i class="fas fa-cogs fa-sm fa-fw mr-2 text-gray-400"></i>
                                    Settings
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
                                <a class="dropdown-item" href="users.aspx">
                                        <i class="fas fa-cogs fa-sm fa-fw mr-2 text-gray-400"></i>
                                        Settings
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


                <!-- Page Heading -->
                <h1 class="h3 mb-4 text-gray-800"><span class="fas fa-user-alt">&nbsp;</span>Users</h1>
                
                
    <form id="form1" runat="server">

                <!-- Search and Add Button -->
                <div class="input-group">
                    <asp:TextBox ID="txtSearch" class="form-control col-3" runat="server" placeholder="Seach..."></asp:TextBox>
                        <div class="input-group-append">
                            <asp:LinkButton ID="btnSearch" runat="server" class="btn btn-secondary" OnClick="btnSearch_Click" ToolTip="Seach"><i class="fa fa-search"></i></asp:LinkButton>
                        </div>
                        <div>
                            &nbsp;
                        </div>  
                        <div class="col-xs-2">
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#adduserModal" title="New">
                                New
                            </button>
                        </div>
                </div>
                
                <br />

                <!-- table grid views -->
                <div class="row">  
                    <div class="col-lg-12 ">  
                        <div class="table-responsive">
                            <asp:GridView ID="GridViewUsers" Width="100%" CssClass="table table-striped table-bordered table-hover" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="False" DataKeyNames="token_id" OnSelectedIndexChanged="GridViewUsers_SelectedIndexChanged" OnRowDeleting="GridViewUsers_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="token_id" HeaderText="Token ID" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                        <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                        <ItemStyle CssClass="visible-lg"></ItemStyle>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="fname" HeaderText="First name" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                        <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="lname" HeaderText="Last name" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-md">
                                        <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="email" HeaderText="Email" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-lg">
                                        <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="username" HeaderText="Username" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs">
                                        <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-md">
                                        <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="role" HeaderText="Role" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-lg">
                                        <HeaderStyle CssClass="visible-lg"></HeaderStyle>
                                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="date_created" HeaderText="Date Created" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-xs" DataFormatString="{0:MM/dd/yyyy}">
                                        <HeaderStyle CssClass="visible-xs"></HeaderStyle>
                                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="date_modify" HeaderText="Date Modified" ItemStyle-CssClass="visible-xs" HeaderStyle-CssClass="visible-md" DataFormatString="{0:MM/dd/yyyy}">
                                        <HeaderStyle CssClass="visible-md"></HeaderStyle>
                                        <ItemStyle CssClass="visible-xs"></ItemStyle>
                                    </asp:BoundField>
                                    
                                    <asp:TemplateField>
	                                <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" CommandName="Select" Text="Edit" ControlStyle-CssClass="btn btn-success" ShowSelectButton="True" ToolTip="Edit"/>
                                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True" OnClientClick="return confirmDelete(this);"  ToolTip="Delete"/>
	                                </ItemTemplate>
                                    </asp:TemplateField>
                        
                                </Columns>
                                <HeaderStyle CssClass="table table-hover" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
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

    <!-- Add User Modal Modal -->
    <div class="modal fade" id="adduserModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Add User</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                
                <div class="form-group row">
                    <label for="inputFirstName" class="col-sm-5 col-form-label">First Name</label>
                        <div class="col-sm-12">
                            <!-- <input type="text" readonly class="form-control-plaintext" id="staticEmail" value="email@example.com"> -->
                            <!-- <input type="password" class="form-control" id="inputPassword"> -->
                            <asp:TextBox ID="txtFname" class="form-control" runat="server"></asp:TextBox>
                        </div>
                </div>
                <div class="form-group row">
                    <label for="inputLastName" class="col-sm-5 col-form-label">Last Name</label>
                        <div class="col-sm-12">
                            <!-- <input type="password" class="form-control" id="inputPassword"> -->
                            <asp:TextBox ID="txtLname" class="form-control" runat="server"></asp:TextBox>
                        </div>
                </div>
                <div class="form-group row">
                    <label for="inputEmail" class="col-sm-5 col-form-label">Email</label>
                        <div class="col-sm-12">
                            <!-- <input type="password" class="form-control" id="inputPassword"> -->
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                        </div>
                </div>
                <div class="form-group row">
                    <label for="inputEmail" class="col-sm-5 col-form-label">Role</label>
                        <div class="col-sm-12">
                            <!-- <input type="password" class="form-control" id="inputPassword"> -->
                            <asp:DropDownList ID="DropDownListRole" class="form-control" runat="server">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>admin</asp:ListItem>
                                <asp:ListItem>member</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                </div>
                <div class="form-group row">
                    <label for="inputImage" class="col-sm-5 col-form-label">Image</label>
                        <div class="col-sm-12">
                            <!-- <input type="password" class="form-control" id="inputPassword"> -->
                            <!-- <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox> -->
                            <asp:FileUpload ID="fileUploadImageUser" runat="server" />
                        </div>
                </div>
                <div class="form-group row">
                    <label for="inputUsername" class="col-sm-5 col-form-label">Username</label>
                        <div class="col-sm-12">
                            <!-- <input type="password" class="form-control" id="inputPassword"> -->
                            <asp:TextBox ID="txtUsername" class="form-control" runat="server"></asp:TextBox>
                        </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-5 col-form-label">Password</label>
                        <div class="col-sm-12">
                            <!-- <input type="password" class="form-control" id="inputPassword"> -->
                            <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                </div>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-5 col-form-label">Confirm Password</label>
                        <div class="col-sm-12">
                            <!-- <input type="password" class="form-control" id="inputPassword"> -->
                            <asp:TextBox ID="txtCPassword" class="form-control" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal">Close</button>
                    <asp:Button ID="btnAddUser" class="btn btn-primary" runat="server" Text="Save" OnClick="btnAddUser_Click"/>
                </div>
            </div>
        </div>
    </div>

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
                    <!-- <a class="btn btn-primary" href="login.html">Logout</a> -->
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

     <!-- New User Form Validation -->
     <script language="javascript" type="text/javascript">
        function validationCheck() {
            var summary = "";
            summary += isvalidfname();
            summary += isvalidlname();
            summary += isvalidemail();
            summary += isvalidrole();
            summary += isvalidupload();
            summary += isvaliduser();
            summary += isvalidpassword();
            summary += isvalidcpassword();

            if (summary != "") {
                alert(summary);
                return false;
            } else {
                return true;
            }

        }

        function isvalidfname() {
            var id;
            var temp = document.getElementById("<%=txtFname.ClientID %>");
            id = temp.value;

            if (id == "") {
                return ("*First Name is required" + "\n");
            } else {
                return "";
            }
         }

         function isvalidlname() {
             var id;
             var temp = document.getElementById("<%=txtLname.ClientID %>");
             id = temp.value;

             if (id == "") {
                 return ("*Last Name is required" + "\n");
             } else {
                 return "";
             }
         }

         function isvalidemail() {
             var id;
             var temp = document.getElementById("<%=txtEmail.ClientID %>");
             id = temp.value;

             var re = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
             if (id == "") {
                 return ("*Email is required" + "\n");
             }
             else if (re.test(id)) {
                return "";
             } else {
                return ("*Email should be in the form ex: juan.delacruz@xyz.com" + "\n");
             }
         }

         function isvalidrole() {
             var id;
             var temp = document.getElementById("<%=DropDownListRole.ClientID %>");
             id = temp.value;

             if (id == "") {
                 return ("*Role is required" + "\n");
             } else {
                 return "";
             }
         }

         function isvalidupload() {
             var id;
             var temp = document.getElementById("<%=fileUploadImageUser.ClientID %>");
             id = temp.value;

             if (id == "") {
                 return ("*Please Upload file" + "\n");
             } else {
                 return "";
             }
         }

         function isvaliduser() {
             var id;
             var temp = document.getElementById("<%=txtUsername.ClientID %>");
             id = temp.value;

             if (id == "") {
                 return ("*Username is required" + "\n");
             } else {
                 return "";
             }
         }

         function isvalidpassword() {
             var id;
             var temp = document.getElementById("<%=txtPassword.ClientID %>");
             id = temp.value;

             if (id == "") {
                 return ("*Password is required" + "\n");
             } else {
                 return "";
             }
         }

         function isvalidcpassword() {
             var uidpwd;
             var uidcnmpwd;
             var tempcnmpwd = document.getElementById("<%=txtCPassword.ClientID %>");
             uidcnmpwd = tempcnmpwd.value;
             var temppwd = document.getElementById("<%=txtPassword.ClientID %>");
             uidpwd = temppwd.value;

             if (uidcnmpwd == "") {
                 return ("*Confirm Password is required" + "\n");
             }else if (uidcnmpwd == "" || uidcnmpwd != uidpwd) {
                 return ("*Password not match!" + "\n");
             } else {
                 return "";
             }
         }
     </script>

</body>

</html>