<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaFarmaciaWeb.Formularios.Login" %>

<!DOCTYPE html>

<html class="bg-blue" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso al Sistema de Farmacia</title>
    
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/AdminLTE.css" rel="stylesheet" type="text/css" />

</head>
<body class="bg-blue">
    <div class="form-box" id="login-box">
        <div class="header">INICIO SESION</div>
        <form id="form1" runat="server">
            <div class="body bg-gray">
                
                <div class="form-group">
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Ingrese su cedula..."></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Ingrese su contraseña"></asp:TextBox>
                </div>

            </div>

          

            <div class="footer">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn bg-olive btn-block" OnClick="btnIngresar_Click"/>
            </div>
            
          
            

        </form>
    </div>

    <script src="js/jquery-3.1.0.min.js"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>

</body>
</html>
