<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<jsp:useBean id="dao" class="Negocio.ControlAccesoDAO" scope="page"/>
<jsp:useBean id="factura" class="Negocio.TFactura" scope="page"/>
<jsp:useBean id="linea" class="Negocio.TLineaFactura" scope="page"/>
<c:set var="usuario" value="${sessionScope.usuario}" property="Negocio.TUsuario"/>
<!DOCTYPE html>
<html >
    <%@ include file="headerIndex.jsp"%>

    <c:set var="facturas" value="${dao.buscar(factura.getClass(),'usuario',usuario.nick)}"/>
    <head>
      <meta charset="UTF-8">
      <title>${usuario.nick}</title>

      <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
        <link rel="stylesheet" href="css/stylePerfil.css">
    </head>

    <body>
      <%--<h1>Responstable <span>2.0</span> by <span>jordyvanraaij</span></h1>--%>

    <table class="responstable">

      <tr>
        <%--<th data-th="Driver details"><span>Código de factura</span></th>--%>
            <th>Código de factura</th>
        <th style="text-align: center">Fecha</th>
        <th style="text-align: center">Importe</th>
            <th style="text-align: center">Detalle</th>
        <!--<th>Relationship</th>-->
            <script>
                function actionForm(formid, act)
                {
                    document.getElementById(formid).action=act;
                    document.getElementById(formid).submit();
                }
            </script>
      </tr>
        <c:set var="auxiliar" value="0"/>
        <c:forEach var="TFactura" items="${facturas}">
            <c:set var="contador" value="0"/>
            <c:if test="${TFactura.borrado==0}">
        <form id="form${auxiliar}" method="post">
                <tr>
                    <c:set var="auxiliar" value="${auxiliar+1}"/>
                    <td style="text-align: center"><input  type="hidden" name="codFactura" value="${TFactura.codFactura}">${TFactura.codFactura}</td>
                    <td style="text-align: center"><input  type="hidden" name="fecha" value="${TFactura.fechaFactura}">${TFactura.fechaFactura}</td>
                    <c:set var="lineas" value="${dao.buscar(linea.getClass(),'codFactura',TFactura.codFactura)}"/>
                    <c:forEach var="TLineaFactura" items="${lineas}">
                        <c:set var="contador" value="${contador+(TLineaFactura.total)}"/>
                    </c:forEach>
                    <td style="text-align: center">${contador}&#8364</td>
                    <td style="text-align: center">
                        <button name="boton" value="Ver" onclick="actionForm(this.form.id, 'detalle.jsp')">Ver</button>
                        <button onclick="actionForm(this.form.id, '/ServletFactura')">Borrar</button>
                    </td>
                    <input type="hidden" name="usuario" value="${usuario.nick}">

                </tr>
        </form>
            </c:if>
        </c:forEach>

    </table>
      </form>
      <script src='http://cdnjs.cloudflare.com/ajax/libs/respond.js/1.4.2/respond.js'></script>


    </body>
</html>
