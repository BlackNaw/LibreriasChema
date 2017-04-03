<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page import="Negocio.TLineaFactura" %>
<%@ page import="Negocio.ControlAccesoDAO" %>
<%@ page import="java.util.ArrayList" %>
<%@ page import="Negocio.TFactura" %>

<%String codFactura=request.getParameter("codFactura");%>
<%TFactura factura= (TFactura) new ControlAccesoDAO().buscar(TFactura.class,codFactura);%>
<%ArrayList<Object> lineasFacturas=new ControlAccesoDAO().buscar(TLineaFactura.class,"codFactura",codFactura);%>
<%int contador=0;%>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>Detalle Factura</title>
    <link rel="stylesheet" href="css/styleDetalle.css" media="all" />
  </head>
  <body>

      <button onclick="location.href='Perfil.jsp'">Volver</button>

    <header class="clearfix">
      <div id="logo">
        <img src="Imagenes/favicon.ico">
      </div>
      <div id="company">
        <h2 class="name">La Esquina del Zorro</h2>
        <div>C/ Arroyo del Olivar, 34 Puente de Vallecas</div>
        <div>(+34) 91 833 14 57</div>
        <div><a href="mailto:contacto@librerialaesquinadelzorro.com">contacto@librerialaesquinadelzorro.com</a></div>
      </div>
      </div>
    </header>
    <main>
      <div id="details" class="clearfix">
        <div id="client">
          <div class="to">Cliente:</div>
          <h2 class="name">${usuario.nick}</h2>
        </div>
        <div id="invoice">
          <h1>Factura: <%=factura.getCodFactura()%></h1>
          <div class="date">Fecha de pedido: <%=factura.getFechaFactura()%></div>
        </div>
      </div>
      <table border="0" cellspacing="0" cellpadding="0">
        <thead>

          <tr>
            <th class="no">Num:</th>
            <th class="desc">LIBRO</th>
            <th class="unit">PRECIO UNITARIO</th>
            <th class="qty">CANTIDAD</th>
            <th class="total">TOTAL</th>
          </tr>
        </thead>
        <tbody>
       <%double suma=0;
         for (Object linea:lineasFacturas) {%>
          <tr>
            <td class="no"><%=contador++%></td>
            <td class="desc"><h3><%=((TLineaFactura)linea).getLibro()%></h3></td>
            <td class="unit"><%=(Double.valueOf(((TLineaFactura)linea).getTotal())/Integer.valueOf(((TLineaFactura)linea).getCantidad()))%>&#8364</td>
            <td class="qty"><%=((TLineaFactura)linea).getCantidad()%></td>
            <td class="total"><%=((TLineaFactura)linea).getTotal()%>&#8364</td>
          </tr>
        <%suma+=Double.valueOf(((TLineaFactura)linea).getTotal());
         }%>
        </tbody>
        <tfoot>
          <tr>
            <td colspan="2"></td>
            <td colspan="2">TOTAL</td>
            <td><%=suma%>&#8364</td>
          </tr>
        </tfoot>
      </table>
      <div id="thanks">Gracias!</div>
      <div id="notices">
        <div>Aviso:</div>
        <div class="notice">El env&iacuteo se realizar&aacute en los pr&oacuteximos 30 d&iacuteas</div>
      </div>
    </main>
  </body>
</html>