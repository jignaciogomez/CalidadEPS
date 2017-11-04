<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calidad.aspx.cs" Inherits="AplicacionCalidad.Calidad" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <%-- <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridDatosCalidad">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridDatosCalidad" LoadingPanelID="RadAjaxPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>--%>
    </telerik:RadAjaxManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>

    <div id="PanelDiv" class="col-md-12">
        <div class="row">
            <div class="col-md-12">
                <label>EPS:</label>
                <asp:DropDownList ID="DDLDatoEPS" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLDatoEPS_SelectedIndexChanged"></asp:DropDownList>
                <asp:LinkButton ID="LnkEncuesta" runat="server" OnClick="LnkEncuesta_Click">Realizar encuesta</asp:LinkButton>
            </div>
            <div class="col-md-12">
                <br/>
            </div>

            <div class="col-md-12">
                <asp:Label ID="LblGraficas" runat="server" Text="Graficas de Datos" Visible=" false"></asp:Label>
                <%--<label>Fecha de Orden:</label>--%>
            </div>
            <%-- <div class="col-md-4">
                 
           </div>--%>
        </div>
    </div>

    <div class="col-md-12">
        <asp:Chart ID="Chart2" runat="server" Height="240px" Width="468px">
            <series>
                <asp:Series Name="Series1" Label="#VAL">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:Chart ID="Chart1" runat="server" Height="230px" Width="497px">
            <series>
                <asp:Series ChartType="Doughnut" Name="Series1" Legend="Legend1" Label="#VAL" LegendText="#VALX" LegendMapAreaAttributes="#VALX">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
            <%--<Legends>
                <asp:Legend Name="Legend1" Title="Cantidades por SubCategorias">
                </asp:Legend>
            </Legends>--%>
            <Legends>
                <asp:Legend Name="Legend1" Title="SubCategorias">
                </asp:Legend>
            </Legends>
        </asp:Chart>
    </div>
    <div class="col-md-12">
        <br/>
    </div>

    <div class="col-md-12">
        <asp:Label ID="LblGrilla" runat="server" Text="Datos generales de Calidad EPS" Visible="False"></asp:Label>

    </div>
    <div class="col-md-12">
        <br/>
    </div>
    <div class="col-md-12">
    </div>

    <%--<div class="col-md-12">
               <telerik:RadChart ID="RadChart1" runat="server" Skin="Classic" Width="700px" DefaultType="Pie">
                   <series>
                       <telerik:ChartSeries Name="Series 1" Type="Pie">
                           <Appearance>
                               <FillStyle MainColor="255, 206, 38" SecondColor="255, 247, 221">
                               </FillStyle>
                               <Border Color="DimGray" />
                           </Appearance>
                       </telerik:ChartSeries>
                       <telerik:ChartSeries Name="Series 2" Type="Pie">
                           <Appearance>
                               <FillStyle MainColor="99, 99, 99" SecondColor="231, 231, 231">
                               </FillStyle>
                               <Border Color="DimGray" />
                           </Appearance>
                       </telerik:ChartSeries>
                   </series>
                   <Legend Visible="False">
                       <Appearance Visible="False">
                           <ItemTextAppearance TextProperties-Color="DimGray">
                           </ItemTextAppearance>
                           <Border Color="DimGray" />
                       </Appearance>
                   </Legend>
                   <PlotArea>
                       <XAxis>
                           <Appearance>
                               <MajorGridLines Color="DimGray" Width="0" />
                           </Appearance>
                           <AxisLabel>
                               <TextBlock>
                                   <Appearance TextProperties-Font="Verdana, 9.75pt, style=Bold">
                                   </Appearance>
                               </TextBlock>
                           </AxisLabel>
                       </XAxis>
                       <YAxis>
                           <Appearance>
                               <MajorGridLines Color="DimGray" />
                           </Appearance>
                           <AxisLabel>
                               <TextBlock>
                                   <Appearance TextProperties-Font="Verdana, 9.75pt, style=Bold">
                                   </Appearance>
                               </TextBlock>
                           </AxisLabel>
                       </YAxis>
                       <YAxis2>
                           <AxisLabel>
                               <TextBlock>
                                   <Appearance TextProperties-Font="Verdana, 9.75pt, style=Bold">
                                   </Appearance>
                               </TextBlock>
                           </AxisLabel>
                       </YAxis2>
                       <Appearance Corners="Round, Round, Round, Round, 6">
                           <FillStyle FillType="Solid" MainColor="White">
                           </FillStyle>
                           <Border Color="DimGray" />
                       </Appearance>
                   </PlotArea>
                   <ChartTitle>
                       <Appearance Dimensions-Margins="4%, 10px, 14px, 0%" Corners="Round, Round, Round, Round, 6" Position-AlignedPosition="Top">
                           <FillStyle MainColor="224, 224, 224" GammaCorrection="False">
                           </FillStyle>
                           <Border Color="DimGray" />
                       </Appearance>
                       <TextBlock Text="Categorias">
                           <Appearance TextProperties-Font="Verdana, 11.25pt">
                           </Appearance>
                       </TextBlock>
                   </ChartTitle>
               </telerik:RadChart>
      </div>--%>


    <div class="col-md-12">
        <asp:GridView ID="GridDatos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC"/>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black"/>
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White"/>
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"/>
            <RowStyle BackColor="#EEEEEE" ForeColor="Black"/>
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White"/>
            <SortedAscendingCellStyle BackColor="#F1F1F1"/>
            <SortedAscendingHeaderStyle BackColor="#0000A9"/>
            <SortedDescendingCellStyle BackColor="#CAC9C9"/>
            <SortedDescendingHeaderStyle BackColor="#000065"/>
        </asp:GridView>
    </div>
    <%--</div>--%>

    <div class="col-md-12">
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" HorizontalAlign="NotSet">
            <telerik:RadGrid runat="server" ID="GridDatosCalidad" Culture="es-ES" AllowSorting="True" PageSize="5" Height="282px" AllowFilteringByColumn="True" AllowPaging="True" OnNeedDataSource="GridDatosCalidad_NeedDataSource">
                <%--AllowFilteringByColumn="True"--%>
                <%--<PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>--%>
                <ClientSettings>
                    <Scrolling AllowScroll="True"></Scrolling>
                    <Selecting AllowRowSelect="True"/>
                </ClientSettings>
                <ClientSettings AllowColumnsReorder="True" ReorderColumnsOnClient="True">
                </ClientSettings>
                <MasterTableView DataKeyNames="Codigo_EPS">
                    <PagerStyle PagerTextFormat="{4} Página {0} de {1}, Registro {2} de {3} de un total de {5}" FirstPageToolTip="Primera página " LastPageToolTip="Última página" NextPagesToolTip="Siguientes páginas" NextPageToolTip="Siguiente página" PageSizeLabelText="Registros:" PrevPagesToolTip="Anteriores páginas" PrevPageToolTip="Anterior página"/>
                </MasterTableView>
                <HeaderStyle Font-Bold="True" HorizontalAlign="Center"/>
            </telerik:RadGrid>
        </telerik:RadAjaxPanel>
    </div>
</form>
</body>
</html>