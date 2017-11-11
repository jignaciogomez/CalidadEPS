<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuesta.aspx.cs" Inherits="AplicacionCalidad.Encuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <script type="text/javascript" >

       function cerrarpagina() {

           window.close();
           return false;

       }
</script>
    <form id="form1" runat="server">
    <div class="col-md-12">
        <div class="row">
            <div class="col-md-2">
                 <label>Seleccione su EPS:</label>
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="DDLDatoEPS" runat="server" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div class="col-md-6">
            </div>
          </div>
    </div>
    <div class="col-md-12">
    </div>
    <div class="col-md-12">
            <div class="col-md-8">
                 <label>Esta conforme con la atencion de su EPS:</label>
            </div>
            <div class="col-md-2">
                <asp:RadioButtonList ID="RbPreg1" runat="server">
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                    <asp:ListItem Value="1">SI</asp:ListItem>
                </asp:RadioButtonList>
            </div>
         </div>   
            <div class="col-md-12">
            <div class="col-md-8">
                 <label>Cree usted que su EPS puede mejorar la atencion prestada:</label>
            </div>
            <div class="col-md-2">
                <asp:RadioButtonList ID="Rbpreg2" runat="server">
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                    <asp:ListItem Value="1">SI</asp:ListItem>
                </asp:RadioButtonList>
            </div>
         </div>    
        <div class="col-md-12">
            <div class="col-md-8">
                 <label>Se cambiaria a una EPS de mayor calidad en su atencion:</label>
            </div>
            <div class="col-md-2">
                <asp:RadioButtonList ID="Rbpreg3" runat="server">
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                    <asp:ListItem Value="1">SI</asp:ListItem>
                </asp:RadioButtonList>
            </div>
         </div>   
        <div class="col-md-12">
             <asp:Button ID="BtnGuardar" runat="server" Text="Terminar encuesta" OnClick="BtnGuardar_Click" OnClientClick="return cerrarpagina();"/>    
        </div>
        <div class="col-md-12">
              <asp:Button ID="Button1" runat="server" Text="Terminar encuesta" OnClientClick="return cerrarpagina();"/>    
        </div>
    </form>
</body>
</html>
