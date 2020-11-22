<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Biker Sales :: Login</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet">

    <!-- Sweet alert bootstrap -->
   <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.js" type="text/javascript"></script>
   <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-sweetalert/1.0.1/sweetalert.css" rel="stylesheet" />

</head>

<body class="bg-gradient-primary">

    <div class="container">

        <!-- Outer Row -->
        <div class="row justify-content-center">

            <div class="col-xl-10 col-lg-12 col-md-9">

                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">
                        <!-- Nested Row within Card Body -->
                        <div class="row">
                           <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Biker Sales</h1>
                                    </div>
                                    <form id="form1" class="user" runat="server">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtUsername" class="form-control form-control-user" placeholder="Username" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:RequiredFieldValidator ID="rfvUser" ControlToValidate="txtUsername" runat="server" Display="Dynamic" CssClass="form-control is-invalid" Text="*Username is required." BorderStyle="None" forecolor="Red"/>
                                        </div>
                                       

                                        <div class="form-group">
                                            <asp:TextBox ID="txtPassword" TextMode="Password" class="form-control form-control-user" placeholder="Password" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:RequiredFieldValidator ID="rfvPword" ControlToValidate="txtPassword" runat="server" Display="Dynamic" CssClass="form-control is-invalid" Text="*Password is required." BorderStyle="None" forecolor="Red"/>
                                        </div>
                                        
                                        <div class="form-group">
                                            <div class="custom-control custom-checkbox small">
                                                <input type="checkbox" class="custom-control-input" id="customCheck">
                                                <label class="custom-control-label" for="customCheck">Remember Me</label>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnLogin" class="btn btn-primary btn-user btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                    </form>
                                    <hr>
                                    <div class="text-center">
                                        <span>Copyright &copy; Biker Sales 2020</span>
                                    </div>
                                     <div class="text-center">
                                        &nbsp;
                                    </div>                                     
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

    </div>

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>

</body>

</html>